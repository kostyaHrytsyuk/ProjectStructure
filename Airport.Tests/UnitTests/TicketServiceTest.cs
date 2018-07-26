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
    public class TicketServiceTest
    {
        private IMapper _mapper;
        private IRepository<Ticket> _repository;
        private ITicketService _service;
        private IUnitOfWork _unitOfWork;
        private TicketDto testTicketDto;

        [SetUp]
        public void Init()
        {
            testTicketDto = new TicketDto()
            {
                Id = 1,
                Price = 100,
                FlightNumber = "AT7635",
                FlightId = 1
            };

            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Ticket, TicketDto>();
                    cfg.CreateMap<TicketDto, Ticket>();
                })
            );

            _repository = A.Fake<IRepository<Ticket>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => _unitOfWork.Repository<Ticket>()).Returns(_repository);
            _service = new TicketService(_unitOfWork, _mapper);
        }

        [Test]
        public void Create_Ticket_Should_Invoke_Repository_Create_Once()
        {
            //Act
            _service.Create(testTicketDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Create").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Ticket_Should_Invoke_Repository_Update_Once()
        {
            //Act
            _service.Update(testTicketDto);

            //Assert
            A.CallTo(_repository).Where(call => call.Method.Name == "Update").MustHaveHappenedOnceExactly();
            A.CallTo(() => _unitOfWork.Save()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Map_Ticket_From_Dto_To_Model_Then_Entities_Are_Equal()
        {
            //Act
            var ticket = _mapper.Map<TicketDto, Ticket>(testTicketDto);

            //Assert
            Assert.AreEqual(ticket.Id , testTicketDto.Id);
            Assert.AreEqual(ticket.Price , testTicketDto.Price);
            Assert.AreEqual(ticket.FlightNumber , testTicketDto.FlightNumber);
            Assert.AreEqual(ticket.FlightId , testTicketDto.FlightId);
        }

        [Test]
        public void Map_Ticket_From_Model_To_Dto_Then_Entities_Are_Equal()
        {
            //Arrange
            var testTicket = new Ticket()
            {
                Id = 2,
                Price = 200,
                FlightNumber = "MG4328",
                FlightId = 2
            };

            //Act
            var ticketDto = _mapper.Map<Ticket, TicketDto>(testTicket);

            //Arrange
            Assert.AreEqual(ticketDto.Id , testTicket.Id);
            Assert.AreEqual(ticketDto.Price , testTicket.Price);
            Assert.AreEqual(ticketDto.FlightNumber , testTicket.FlightNumber);
            Assert.AreEqual(ticketDto.FlightId , testTicket.FlightId);
        }

    }
}
