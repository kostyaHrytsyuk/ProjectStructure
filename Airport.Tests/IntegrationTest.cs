using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using DAL;
using DAL.Models;
using DAL.UnitOfWork;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;


namespace Airport.Tests
{
    [TestFixture]
    public class IntegrationTest
    {
        AirportContext _context;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        [OneTimeSetUp]
        public void Init()
        {
            _context = TestSettings.Context;
            _unitOfWork = new UnitOfWork(_context);
            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PlaneType, PlaneTypeDto>();
                    cfg.CreateMap<PlaneTypeDto, PlaneType>();

                    cfg.CreateMap<Plane, PlaneDto>();
                    cfg.CreateMap<PlaneDto, Plane>();

                    cfg.CreateMap<Stewardess, StewardessDto>();
                    cfg.CreateMap<StewardessDto, Stewardess>();

                    cfg.CreateMap<Pilot, PilotDto>();
                    cfg.CreateMap<PilotDto, Pilot>();

                    cfg.CreateMap<Crew, CrewDto>();
                    cfg.CreateMap<CrewDto, Crew>();

                    cfg.CreateMap<Ticket, TicketDto>();
                    cfg.CreateMap<TicketDto, Ticket>();

                    cfg.CreateMap<Flight, FlightDto>();
                    cfg.CreateMap<FlightDto, Flight>();

                    cfg.CreateMap<Departure, DepartureDto>();
                    cfg.CreateMap<DepartureDto, Departure>();
                })
            );
        }

        [Test]
        public void Get_All_Stewardesses_And_Get_By_Id_With_The_Same_Id_Are_Equal()
        {
            //Arrange
            var stewardessService = new StewardessService(_unitOfWork, _mapper);

            //Act
            var items = stewardessService.GetAll();
            var item = stewardessService.Get(items[0].Id);
            var test = items[0];

            //Assert
            Assert.AreEqual(item.Id, test.Id);
            Assert.AreEqual(item.FirstName, test.FirstName);
            Assert.AreEqual(item.LastName, test.LastName);
            Assert.AreEqual(item.BirthDate, test.BirthDate);
            Assert.AreEqual(item.CrewId, test.CrewId);
        }

        [Test]
        public void Create_Crew_And_Stewardesses_With_Same_Crew_Id_Then_Crew_Should_Contain_These_Stewardesses()
        {
            //Arrange
            var testCrewDto = new CrewDto()
            {
                PilotId = 1
            };
            var stewardessService = new StewardessService(_unitOfWork, _mapper);
            var crewService = new CrewService(_unitOfWork, _mapper);

            //Act
            testCrewDto = crewService.Create(testCrewDto);

            var testStewardessOne = new StewardessDto()
            {
                FirstName = "First",
                LastName = "Last",
                BirthDate = new DateTime(1974, 5, 8),
                CrewId = testCrewDto.Id
            };
            var testStewardessSecond = new StewardessDto()
            {
                FirstName = "Firstone",
                LastName = "Lastone",
                BirthDate = new DateTime(1984, 5, 8),
                CrewId = testCrewDto.Id
            };

            testStewardessOne = stewardessService.Create(testStewardessOne);
            testStewardessSecond = stewardessService.Create(testStewardessSecond);

            var crewWithStewardesses = crewService.Get(testCrewDto.Id);

            //Assert
            Assert.True(crewWithStewardesses.Stewardesses.Any());
            Assert.AreEqual(2,crewWithStewardesses.Stewardesses.Count);
            Assert.AreEqual(crewWithStewardesses.Stewardesses.FirstOrDefault().Id, testStewardessOne.Id);
            Assert.AreEqual(crewWithStewardesses.Stewardesses.LastOrDefault().Id,  testStewardessSecond.Id);
        }

        [Test]
        public void Create_Flight_And_Tickets_With_Same_Flight_Id_Then_Flight_Should_Contain_These_Tickets()
        {
            //Arrange
            var testFlightDto = new FlightDto()
            {
                FlightNumber = "FK7684",
                DepartureAirport = "DGK",
                DestinationAirport = "FIR"
            };

            var ticketService = new TicketService(_unitOfWork, _mapper);
            var flightService = new FlightService(_unitOfWork, _mapper);

            //Act
            testFlightDto = flightService.Create(testFlightDto);

            var testTicketOne = new TicketDto()
            {
                FlightId = testFlightDto.Id,
                FlightNumber = testFlightDto.FlightNumber,
                Price = 200
            };
            var testTicketSecond = new TicketDto()
            {
                FlightId = testFlightDto.Id,
                FlightNumber = testFlightDto.FlightNumber,
                Price = 250
            };

            testTicketOne = ticketService.Create(testTicketOne);
            testTicketSecond = ticketService.Create(testTicketSecond);

            var flightWithTickets = flightService.Get(testFlightDto.Id);

            //Assert
            Assert.True(flightWithTickets.Tickets.Any());
            Assert.AreEqual(2, flightWithTickets.Tickets.Count());
            Assert.AreEqual(flightWithTickets.Tickets.FirstOrDefault().Id, testTicketOne.Id);
            Assert.AreEqual(flightWithTickets.Tickets.LastOrDefault().Id, testTicketSecond.Id);

        }
        

        [Test]
        public void Create_Plane_Should_Return_Existing_Item()
        {
            //Arrange
            var testPlaneDto = new PlaneDto()
            {
                PlaneTypeId = 1,
                Name = "Jet",
                ReleaseDate = new DateTime(2002, 2, 20)
            };
            
            var planeService = new PlaneService(_unitOfWork, _mapper);

            //Act
            var returnedItem = planeService.Create(testPlaneDto);

            //Assert
            Assert.IsNotNull(planeService.Get(returnedItem.Id));
        }

        [Test]
        public void Create_PlaneType_Then_Should_Be_Finded_By_Id()
        {
            //Arrange
            var testPlaneTypeDto = new PlaneTypeDto()
            {
                PlaneModel = "Malcon",
                SeatsNumber = 42,
                Carrying = 30000
            };
                        
            var planeTypeService = new PlaneTypeService(_unitOfWork, _mapper);

            //Act
            testPlaneTypeDto = planeTypeService.Create(testPlaneTypeDto);
            var id = testPlaneTypeDto.Id;

            //Assert
            Assert.AreEqual(id, planeTypeService.Get(id).Id);
        }

        [Test]
        public void Create_Departure_Then_Should_Contains_Entities()
        {
            //Arrange
            var planeService = new PlaneService(_unitOfWork, _mapper);
            var crewService = new CrewService(_unitOfWork, _mapper);
            var flightService = new FlightService(_unitOfWork, _mapper);
            var departureService = new DepartureService(_unitOfWork, _mapper);

            //Act
            var plane = planeService.GetAll().LastOrDefault();
            var crew = crewService.GetAll().LastOrDefault();
            var flight = flightService.GetAll().LastOrDefault();

            var testDepartureDto = new DepartureDto()
            {
                PlaneId = plane.Id,
                CrewId = crew.Id,
                FlightId = flight.Id,
                FlightNumber = flight.FlightNumber,
                DepartureDate = DateTime.Now
            };

            testDepartureDto = departureService.Create(testDepartureDto);
                        
            //Assert
            Assert.AreEqual(testDepartureDto.Flight.Id, flight.Id);
            Assert.AreEqual(testDepartureDto.Crew.Id, crew.Id);
            Assert.AreEqual(testDepartureDto.Flight.Id,flight.Id);
            Assert.AreEqual(testDepartureDto.FlightNumber, flight.FlightNumber);
        }

        [Test]
        public void Update_Pilot_With_Not_Exist_Id_Then_Throws_ArgumentNullException()
        {
            //Arrange
            var testPilotDto = new PilotDto()
            {
                Id = -1
            };
            
            var pilotService = new PilotService(_unitOfWork, _mapper);

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => pilotService.Update(testPilotDto));
        }

        [Test]
        public void Update_Crew_Then_Crew_With_Same_Id_Should_Be_Equal_Passed_Item()
        {
            //Arrange
            var testCrewDto = new CrewDto()
            {
                Id=2,
                PilotId = 2
            };
            
            var crewService = new CrewService(_unitOfWork, _mapper);

            //Act
            crewService.Update(testCrewDto);
            var updatedItem = crewService.Get(testCrewDto.Id);

            //Assert
            Assert.AreEqual(updatedItem.Id, testCrewDto.Id);
            Assert.AreEqual(updatedItem.PilotId, testCrewDto.PilotId);
        }

        [Test]
        public void Delete_Ticket_With_Not_Exist_Id_Then_Throws_NullReferenceException()
        {
            //Arrange
            
            var ticketService = new TicketService(_unitOfWork, _mapper);

            //Act
            //Assert
            Assert.Throws<NullReferenceException>(() => ticketService.Delete(-1));
        }

        [Test]
        public void Delete_Departure_Then_Deleted_Departure_Not_Exist()
        {
            //Arrange
            
            var departureService = new DepartureService(_unitOfWork, _mapper);
            var itemId = departureService.GetAll()[0].Id;

            //Act
            departureService.Delete(itemId);

            //Assert
            Assert.IsNull(departureService.Get(itemId));
        }
    }
}
