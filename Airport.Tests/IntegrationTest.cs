using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using DAL;
using DAL.Models;
using DAL.UnitOfWork;
using NUnit.Framework;


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
        public void Create_PlaneType_Then_Should_Find_By_Id()
        {
            _mapper = new Mapper(
                 new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<PlaneType, PlaneTypeDto>();
                     cfg.CreateMap<PlaneTypeDto, PlaneType>();
                 })
              );
            var planeTypeService = new PlaneTypeService(_unitOfWork, _mapper);

            var testPlaneTypeDto = new PlaneTypeDto()
            {
                PlaneModel = "Malcon",
                SeatsNumber = 42,
                Carrying = 30000
            };

            testPlaneTypeDto = planeTypeService.Create(testPlaneTypeDto);
            var id = testPlaneTypeDto.Id;
            Assert.AreEqual(id, planeTypeService.Get(id).Id);
        }
    }
}
