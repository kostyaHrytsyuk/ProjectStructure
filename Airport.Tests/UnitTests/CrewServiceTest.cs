using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using DAL.Models;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Airport.Tests.UnitTests
{
    [TestFixture]
    public class CrewServiceTest
    {
        private IMapper _mapper;
        private IRepository<Crew> _repository;
        private ICrewService _service;
        private IUnitOfWork _unitOfWork;
        private CrewDto testCrewDto;

        [SetUp]
        public void Init()
        {
            testCrewDto = new CrewDto()
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

            _repository = A.Fake<IRepository<Crew>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => _unitOfWork.Repository<Crew>()).Returns(_repository);
            _service = new CrewService(_unitOfWork, _mapper);
        }

        [Test]
        public void Create_Crew_Should_Invoke_Repository_Create_Once()
        {
            //Act
            _service.Create(testCrewDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Create").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Crew_Should_Invoke_Repository_Update_Once()
        {
            //Act
            _service.Update(testCrewDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Update").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Map_Crew_From_Dto_To_Model_Then_Entities_Are_Equal_()
        {
            //Act
            var crew = _mapper.Map<CrewDto, Crew>(testCrewDto);

            //Assert
            Assert.AreEqual(crew.Id, testCrewDto.Id);
            Assert.AreEqual(crew.PilotId, testCrewDto.PilotId);
        }

        [Test]
        public void Map_Crew_From_Model_To_Dto_Then_Entities_Are_Equal_()
        {
            //Arrange
            var testCrew = new Crew()
            {
                Id = 2,
                PilotId = 2,
                Stewardesses = new List<Stewardess>()
            };

            //Act
            var crewDto = _mapper.Map<Crew, CrewDto>(testCrew);

            //Assert
            Assert.AreEqual(crewDto.Id, testCrew.Id);
            Assert.AreEqual(crewDto.PilotId, testCrew.PilotId);
            Assert.AreEqual(crewDto.Stewardesses, testCrew.Stewardesses);
        }
    }
}
