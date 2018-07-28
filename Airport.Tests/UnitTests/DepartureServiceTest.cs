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
    public class DepartureServiceTest
    {
        private IMapper _mapper;
        private IRepository<Departure> _repository;
        private IDepartureService _service;
        private IUnitOfWork _unitOfWork;
        private DepartureDto testDepartureDto;

        [SetUp]
        public void Init()
        {
            testDepartureDto = new DepartureDto()
            {
                Id = 1,
                CrewId = 1,
                FlightId = 1,
                PlaneId = 1,
                FlightNumber = "RF7564",
                DepartureDate = new DateTime(2002, 4, 20)
            };

            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Departure, DepartureDto>();
                        cfg.CreateMap<DepartureDto, Departure>();
                    })
                );

            _repository = A.Fake<IRepository<Departure>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => _unitOfWork.Repository<Departure>()).Returns(_repository);
            _service = new DepartureService(_unitOfWork, _mapper);
        }

        [Test]
        public void Create_Departure_Should_Invoke_Repository_Create_Once()
        {
            //Act
            _service.Create(testDepartureDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Create").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Departure_Should_Invoke_Repository_Update_Once()
        {
            //Act
            _service.Update(testDepartureDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Update").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Map_Departure_From_Dto_To_Model_Then_Entities_Are_Equal()
        {
            //Act
            var departure = _mapper.Map<DepartureDto, Departure>(testDepartureDto);

            //Assert
            Assert.AreEqual(departure.Id, testDepartureDto.Id);
            Assert.AreEqual(departure.CrewId, testDepartureDto.CrewId);
            Assert.AreEqual(departure.FlightId, testDepartureDto.FlightId);
            Assert.AreEqual(departure.PlaneId, testDepartureDto.PlaneId);
            Assert.AreEqual(departure.FlightNumber, testDepartureDto.FlightNumber);
            Assert.AreEqual(departure.DepartureDate, testDepartureDto.DepartureDate);
        }

        [Test]
        public void Map_Departure_From_Model_To_Dto_Then_Entities_Are_Equal()
        {
            //Arrange
            var testDeparture = new Departure()
            {
                Id = 2,
                CrewId = 2,
                FlightId = 2,
                PlaneId = 2,
                FlightNumber = "KF6743",
                DepartureDate = new DateTime(2005, 8, 3)
            };

            //Act
            var departureDto = _mapper.Map<Departure, DepartureDto>(testDeparture);

            //Assert
            Assert.AreEqual(departureDto.Id, testDeparture.Id);
            Assert.AreEqual(departureDto.CrewId, testDeparture.CrewId);
            Assert.AreEqual(departureDto.Flight, testDeparture.Flight);
            Assert.AreEqual(departureDto.PlaneId, testDeparture.PlaneId);
            Assert.AreEqual(departureDto.FlightNumber, testDeparture.FlightNumber);
            Assert.AreEqual(departureDto.DepartureDate, testDeparture.DepartureDate);

        }
    }
}
