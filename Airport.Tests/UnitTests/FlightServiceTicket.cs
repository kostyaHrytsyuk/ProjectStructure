using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using DAL.Models;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System;

namespace Airport.Tests.UnitTests
{
    [TestFixture]
    public class FlightServiceTicket
    {
        private IMapper _mapper;
        private IRepository<Flight> _repository;
        private IFlightService _service;
        private IUnitOfWork _unitOfWork;
        private FlightDto testFlightDto;

        [SetUp]
        public void Init()
        {
            testFlightDto = new FlightDto()
            {
                Id = 1,
                DepartureAirport = "AAA",
                DepartureTime = new DateTime(2007, 07, 13, 14, 45, 0),
                DestinationAirport = "BBB",
                ArrivalTime = new DateTime(2007, 07, 13, 16, 15, 0)
            };

            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Flight, FlightDto>();
                    cfg.CreateMap<FlightDto, Flight>();
                })
            );

            _repository = A.Fake<IRepository<Flight>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => _unitOfWork.Repository<Flight>()).Returns(_repository);
            _service = new FlightService(_unitOfWork, _mapper);
        }

        [Test]
        public void Create_Flight_Should_Invoke_Repository_Create_Once()
        {
            //Act
            _service.Create(testFlightDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Create").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Flight_Should_Invoke_Repository_Update_Once()
        {
            //Act
            _service.Update(testFlightDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Update").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Map_Flight_From_Dto_To_Model_Then_Entities_Are_Equal()
        {
            //Act
            var flight = _mapper.Map<FlightDto, Flight>(testFlightDto);

            //Arrange
            Assert.AreEqual(flight.Id , testFlightDto.Id);
            Assert.AreEqual(flight.DepartureAirport , testFlightDto.DepartureAirport);
            Assert.AreEqual(flight.DepartureTime , testFlightDto.DepartureTime);
            Assert.AreEqual(flight.DestinationAirport , testFlightDto.DestinationAirport);
            Assert.AreEqual(flight.ArrivalTime , testFlightDto.ArrivalTime);
            Assert.AreEqual(flight.FlightNumber , testFlightDto.FlightNumber);
        }

        [Test]
        public void Map_Flight_From_Model_To_Dto_Then_Entities_Are_Equal()
        {
            //Arrange
            var testFlight = new Flight()
            {
                Id = 2,
                DepartureAirport = "CCC",
                DepartureTime = new DateTime(2010, 10, 10, 10, 10, 00),
                DestinationAirport = "DDD",
                ArrivalTime = new DateTime(2010, 10, 10, 11, 00, 0),
                FlightNumber = "KE7531"                
            };

            //Act
            var flightDto = _mapper.Map<Flight, FlightDto>(testFlight);

            //Assert
            Assert.AreEqual(flightDto.Id , testFlight.Id);
            Assert.AreEqual(flightDto.DepartureAirport , testFlight.DepartureAirport);
            Assert.AreEqual(flightDto.DepartureTime , testFlight.DepartureTime);
            Assert.AreEqual(flightDto.DestinationAirport , testFlight.DestinationAirport);
            Assert.AreEqual(flightDto.ArrivalTime , testFlight.ArrivalTime);
            Assert.AreEqual(flightDto.FlightNumber , testFlight.FlightNumber);
        }
        }
}
