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
    public class PilotServiceTest
    {
        private IMapper _mapper;
        private IRepository<Pilot> _repository;
        private IPilotService _service;
        private IUnitOfWork _unitOfWork;
        private PilotDto testPilotDto;

        [SetUp]
        public void Init()
        {
            testPilotDto = new PilotDto()
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last",
                BirthDate = DateTime.Now,
                Experience = 20
            };

            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Pilot, PilotDto>();
                        cfg.CreateMap<PilotDto, Pilot>();
                    })
                );

            _repository = A.Fake<IRepository<Pilot>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => _unitOfWork.Repository<Pilot>()).Returns(_repository);
            _service = new PilotService(_unitOfWork, _mapper);
        }

        [Test]
        public void Create_Pilot_Should_Invoke_Repository_Create_Once()
        {
            //Act
            _service.Create(testPilotDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Create").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Pilot_Should_Invoke_Repository_Update_Once()
        {
            //Act
            _service.Update(testPilotDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Update").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Map_Pilot_From_Dto_To_Model_Then_Entities_Are_Equal_()
        {
            //Act
            var pilot = _mapper.Map<PilotDto, Pilot>(testPilotDto);

            //Assert
            Assert.AreEqual(pilot.Id, testPilotDto.Id);
            Assert.AreEqual(pilot.FirstName, testPilotDto.FirstName);
            Assert.AreEqual(pilot.LastName, testPilotDto.LastName);
            Assert.AreEqual(pilot.BirthDate, testPilotDto.BirthDate);
            Assert.AreEqual(pilot.Experience, testPilotDto.Experience);
        }

        [Test]
        public void Map_Pilot_From_Model_To_Dto_Then_Entities_Are_Equal_()
        {
            //Arrange
            var testPilot = new Pilot()
            {
                Id = 2,
                FirstName = "Aviator",
                LastName = "Best",
                BirthDate = new DateTime(2006, 7, 11),
                Experience = 10
            };

            //Act
            var pilotDto = _mapper.Map<Pilot, PilotDto>(testPilot);

            //Assert
            Assert.AreEqual(pilotDto.Id, testPilot.Id);
            Assert.AreEqual(pilotDto.FirstName, testPilot.FirstName);
            Assert.AreEqual(pilotDto.LastName, testPilot.LastName);
            Assert.AreEqual(pilotDto.BirthDate, testPilot.BirthDate);
            Assert.AreEqual(pilotDto.Experience, testPilot.Experience);

        }
    }
}
