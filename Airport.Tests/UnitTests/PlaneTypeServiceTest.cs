using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using DAL.Models;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;

namespace Airport.Tests.UnitTests
{
    [TestFixture]
    public class PlaneTypeServiceTest
    {
        private IMapper _mapper;
        private IRepository<PlaneType> _repository;
        private IPlaneTypeService _service;
        private IUnitOfWork _unitOfWork;
        private PlaneTypeDto testPlaneTypeDto;

        [SetUp]
        public void Init()
        {
            testPlaneTypeDto = new PlaneTypeDto()
            {
                Id = 1,
                PlaneModel = "Plane",
                SeatsNumber = 200,
                Carrying = 1000
            };
                        
            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PlaneType, PlaneTypeDto>();
                    cfg.CreateMap<PlaneTypeDto, PlaneType>();
                })
             );

            _repository = A.Fake<IRepository<PlaneType>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => _unitOfWork.Repository<PlaneType>()).Returns(_repository);
            _service = new PlaneTypeService(_unitOfWork, _mapper);
        }

        [Test]
        public void Create_PlaneType_Should_Invoke_Repository_Create_Once()
        {
            _service.Create(testPlaneTypeDto);

            A.CallTo(_repository).Where(call => call.Method.Name == "Create").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_PlaneType_Should_Invoke_Repository_Update_Once()
        {
            _service.Update(testPlaneTypeDto);

            A.CallTo(_repository).Where(call => call.Method.Name == "Update").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Map_PlaneType_From_Dto_To_Model_Then_Entities_Are_Equal_()
        {
            var planeType = _mapper.Map<PlaneTypeDto,PlaneType>(testPlaneTypeDto);

            Assert.AreEqual(planeType.Id, testPlaneTypeDto.Id);
            Assert.AreEqual(planeType.PlaneModel, testPlaneTypeDto.PlaneModel);
            Assert.AreEqual(planeType.SeatsNumber, testPlaneTypeDto.SeatsNumber);
            Assert.AreEqual(planeType.Carrying, testPlaneTypeDto.Carrying);
        }

        [Test]
        public void Map_PlaneType_From_Model_To_Dto_Then_Entities_Are_Equal_()
        {
            var testPlaneType = new PlaneType()
            {
                Id = 2,
                PlaneModel = "Avia",
                SeatsNumber = 500,
                Carrying = 2000
            };


            var planeTypeDto = _mapper.Map<PlaneType, PlaneTypeDto>(testPlaneType);

            Assert.AreEqual(planeTypeDto.Id, testPlaneType.Id);
            Assert.AreEqual(planeTypeDto.PlaneModel, testPlaneType.PlaneModel);
            Assert.AreEqual(planeTypeDto.SeatsNumber, testPlaneType.SeatsNumber);
            Assert.AreEqual(planeTypeDto.Carrying, testPlaneType.Carrying);
        }



    }
}
