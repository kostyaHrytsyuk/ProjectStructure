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
        private PlaneTypeDto testPlaneType;

        [OneTimeSetUp]
        public void Init()
        {
            testPlaneType = new PlaneTypeDto()
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
        public void Create_PlaneType_Should_Create_Ticket_Then_Equal_Last_Ticket()
        {
            _service.Create(testPlaneType);

            A.CallTo(() => _unitOfWork.Save()).MustHaveHappened(Repeated.Exactly.Once);
        }
        
        [Test]
        public void Map_PlaneType_From_Dto_To_Model_Then_Entities_Are_Equal_()
        {
            var planeTypeDto = _mapper.Map<PlaneTypeDto,PlaneType>(testPlaneType);

            Assert.AreEqual(planeTypeDto.Id, testPlaneType.Id);
            Assert.AreEqual(planeTypeDto.PlaneModel, testPlaneType.PlaneModel);
            Assert.AreEqual(planeTypeDto.SeatsNumber, testPlaneType.SeatsNumber);
            Assert.AreEqual(planeTypeDto.Carrying, testPlaneType.Carrying);
        }

        //[Test]
        //public void Map_PlaneType_From_Model_To_Dto_Then_Entities_Are_Equal_()
        //{
        //    var planeTypeModel = _mapper.Map<PlaneType, PlaneTypeDto>(testPlaneType);

        //    Assert.AreEqual(planeTypeModel.Id, testPlaneType.Id);
        //    Assert.AreEqual(planeTypeModel.PlaneModel, testPlaneType.PlaneModel);
        //    Assert.AreEqual(planeTypeModel.SeatsNumber, testPlaneType.SeatsNumber);
        //    Assert.AreEqual(planeTypeModel.Carrying, testPlaneType.Carrying);
        //}



    }
}
