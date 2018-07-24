using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using DAL;
using DAL.Models;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Linq;


namespace Airport.Tests.UnitTests
{
    [TestFixture]
    public class PlaneTypeServiceTest
    {
        private Mapper _mapper;
        private IRepository<PlaneType> _repository;
        private IPlaneTypeService _service;
        private IUnitOfWork _unitOfWork;
        private PlaneTypeDto testPlaneType;

        [OneTimeSetUp]
        public void Init()
        {
            testPlaneType = new PlaneTypeDto()
            {
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
        public void Get_PlaneType_With_Fake_Id_Then_Id_Equal_Zero()
        {
            var fakeId = -1;

            var planeType = _service.Get(fakeId);

            Assert.AreEqual(planeType.Id, 0);
        }

        //[Test]
        //public void CreateTicket_Should_Create_Ticket_Then_Equal_Last_Ticket()
        //{
        //    _service.Create(testPlaneType);

        //    var lastPlaneType = _service.GetAll().Last();

        //    Assert.AreEqual(testPlaneType, lastPlaneType);

        //}

        [OneTimeTearDown]
        public void TearDown()
        {
        }

    }
}
