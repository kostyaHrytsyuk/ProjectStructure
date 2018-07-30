using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using DAL;
using DAL.Models;
using DAL.UnitOfWork;
using NUnit.Framework;
using System;
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
            
        }

        [Test]
        public void Get_All_Stewardesses_And_Get_By_Id_With_The_Same_Id_Are_Equal()
        {
            //Arrange
            _mapper = new Mapper(
                 new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<Stewardess, StewardessDto>();
                     cfg.CreateMap<StewardessDto, Stewardess>();
                 })
              );
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
        public void Create_Plane_Should_Return_Existing_Item()
        {
            //Arrange
            var testPlaneDto = new PlaneDto()
            {
                PlaneTypeId = 1,
                Name = "Jet",
                ReleaseDate = new DateTime(2002, 2, 20)
            };
            _mapper = new Mapper(
                 new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<Plane, PlaneDto>();
                     cfg.CreateMap<PlaneDto, Plane>();
                 })
              );
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

            _mapper = new Mapper(
                 new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<PlaneType, PlaneTypeDto>();
                     cfg.CreateMap<PlaneTypeDto, PlaneType>();
                 })
              );
            var planeTypeService = new PlaneTypeService(_unitOfWork, _mapper);

            //Act
            testPlaneTypeDto = planeTypeService.Create(testPlaneTypeDto);
            var id = testPlaneTypeDto.Id;

            //Assert
            Assert.AreEqual(id, planeTypeService.Get(id).Id);
        }

        [Test]
        public void Update_Pilot_With_Not_Exist_Id_Then_Throws_ArgumentNullException()
        {
            //Arrange
            var testPilotDto = new PilotDto()
            {
                Id = -1
            };
            _mapper = new Mapper(
                 new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<Pilot, PilotDto>();
                     cfg.CreateMap<PilotDto, Pilot>();
                 })
              );
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
                Id = 1,
                PilotId = 1
            };
            _mapper = new Mapper(
                 new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<Crew, CrewDto>();
                     cfg.CreateMap<CrewDto, Crew>();
                 })
              );
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
            _mapper = new Mapper(
                 new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<Ticket, TicketDto>();
                     cfg.CreateMap<TicketDto, Ticket>();
                 })
              );
            var ticketService = new TicketService(_unitOfWork, _mapper);

            //Act
            //Assert
            Assert.Throws<NullReferenceException>(() => ticketService.Delete(-1));
        }

        [Test]
        public void Delete_Departure_Then_Deleted_Departure_Not_Exist()
        {
            //Arrange
            _mapper = new Mapper(
                 new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<Departure, DepartureDto>();
                     cfg.CreateMap<DepartureDto, Departure>();
                 })
              );
            var departureService = new DepartureService(_unitOfWork, _mapper);
            var itemId = departureService.GetAll()[0].Id;

            //Act
            departureService.Delete(itemId);

            //Assert
            Assert.IsNull(departureService.Get(itemId));
        }
    }
}
