using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using DAL;
using DAL.Models;
using DAL.Repositories;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;


namespace Airport.Tests.UnitTests
{
    [TestFixture]
    public class StewardessServiceTest
    {
        private AirportContext _context;
        private Mapper _mapper;
        private IRepository<Stewardess> _repository;
        private IStewardessService _service;
        private IUnitOfWork _unitOfWork;

        [OneTimeSetUp]
        public void Init()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

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
        public void Get_Stewardess_With_Fake_Id_Then_Id_Equal_Zero()
        {
            var fakeId = -1;

            var stewardess = _service.Get(fakeId);
            var items = _service.GetAll();
            Assert.AreEqual(stewardess.Id,0);

        }
    }
}
