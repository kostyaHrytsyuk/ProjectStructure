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
    public class PlaneServiceTest
    {
        private IMapper _mapper;
        private IRepository<Plane> _repository;
        private IPlaneService _service;
        private IUnitOfWork _unitOfWork;
        private PlaneDto testPlaneDto;

        [SetUp]
        public void Init()
        {
            testPlaneDto = new PlaneDto()
            {
                Id = 1,
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

            _repository = A.Fake<IRepository<Plane>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => _unitOfWork.Repository<Plane>()).Returns(_repository);
            _service = new PlaneService(_unitOfWork, _mapper);
        }

        [Test]
        public void Create_PlaneType_Should_Invoke_Repository_Create_Once()
        {
            //Act
            _service.Create(testPlaneDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Create").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Plane_Should_Invoke_Repository_Update_Once()
        {
            //Act
            _service.Update(testPlaneDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Update").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Map_Plane_From_Dto_To_Model_Then_Entities_Are_Equal()
        {
            //Act
            var plane = _mapper.Map<PlaneDto, Plane>(testPlaneDto);

            //Arrange
            Assert.AreEqual(plane.Id , testPlaneDto.Id);
            Assert.AreEqual(plane.PlaneTypeId , testPlaneDto.PlaneTypeId );
            Assert.AreEqual(plane.Name , testPlaneDto.Name );
            Assert.AreEqual(plane.ReleaseDate , testPlaneDto.ReleaseDate );
        }

        [Test]
        public void Map_Plane_From_Model_To_Dto_Then_Entities_Are_Equal()
        {
            //Arrange
            var testPlane = new Plane(new DateTime(2007, 7, 16))
            {
                Id = 2,
                PlaneTypeId = 2,
                Name = "Genesis"
            };

            //Act
            var plane = _mapper.Map<Plane, PlaneDto>(testPlane);

            //Assert
            Assert.AreEqual(plane.Id , testPlane.Id);
            Assert.AreEqual(plane.PlaneTypeId , testPlane.PlaneTypeId);
            Assert.AreEqual(plane.Name , testPlane.Name);
        }
    }
}
