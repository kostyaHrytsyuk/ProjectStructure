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
    public class StewardessServiceTest
    {
        private IMapper _mapper;
        private IRepository<Stewardess> _repository;
        private IStewardessService _service;
        private IUnitOfWork _unitOfWork;
        private StewardessDto testStewardessDto;

        [SetUp]
        public void Init()
        {
            testStewardessDto = new StewardessDto()
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last",
                BirthDate = DateTime.Now,
                CrewId = 1
            };

            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Stewardess, StewardessDto>();
                    cfg.CreateMap<StewardessDto, Stewardess>();
                })
             );

            _repository = A.Fake<IRepository<Stewardess>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => _unitOfWork.Repository<Stewardess>()).Returns(_repository);
            _service = new StewardessService(_unitOfWork, _mapper);
        }

        [Test]
        public void Create_Stewardess_Should_Invoke_Repository_Create_Once()
        {
            _service.Create(testStewardessDto);

            A.CallTo(_repository).Where(call => call.Method.Name == "Create").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();

        }

        [Test]
        public void Update_Stewardess_Should_Invoke_Repository_Update_Once()
        {
            _service.Update(testStewardessDto);

            A.CallTo(_repository).Where(call => call.Method.Name == "Update").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Map_Stewardess_From_Dto_To_Model_Then_Entities_Are_Equal_()
        {
            var stewardess = _mapper.Map<StewardessDto, Stewardess>(testStewardessDto);

            Assert.AreEqual(stewardess.Id, testStewardessDto.Id);
            Assert.AreEqual(stewardess.FirstName, testStewardessDto.FirstName);
            Assert.AreEqual(stewardess.LastName, testStewardessDto.LastName);
            Assert.AreEqual(stewardess.BirthDate, testStewardessDto.BirthDate);
            Assert.AreEqual(stewardess.CrewId, testStewardessDto.CrewId);
        }

        [Test]
        public void Map_Stewardess_From_Model_To_Dto_Then_Entities_Are_Equal_()
        {
            var testStewardess = new Stewardess()
            {
                Id = 1,
                FirstName = "Tesname",
                LastName = "Testlast",
                BirthDate = new DateTime(2003, 8, 15),
                CrewId = 2
            };

            var stewardessDto = _mapper.Map<Stewardess, StewardessDto>(testStewardess);

            Assert.AreEqual(stewardessDto.Id, testStewardess.Id);
            Assert.AreEqual(stewardessDto.FirstName, testStewardess.FirstName);
            Assert.AreEqual(stewardessDto.LastName, testStewardess.LastName);
            Assert.AreEqual(stewardessDto.BirthDate, testStewardess.BirthDate);
            Assert.AreEqual(stewardessDto.CrewId, testStewardess.CrewId);

        }

    }
}
