using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<TicketDto> GetAll()
        {
            var items = _unitOfWork.Repository<Ticket>().GetAll();
            return _mapper.Map<List<Ticket>, List<TicketDto>>(items);
        }

        public TicketDto Get(int id)
        {
            var item = _unitOfWork.Repository<Ticket>().Get(id);
            return _mapper.Map<Ticket, TicketDto>(item);
        }

        public void Create(TicketDto item)
        {
            var newItem = _mapper.Map<TicketDto, Ticket>(item);
            _unitOfWork.Repository<Ticket>().Create(newItem);
            _unitOfWork.Save();
        }

        public void Update(TicketDto item)
        {
            var updItem = _mapper.Map<TicketDto, Ticket>(item);
            _unitOfWork.Repository<Ticket>().Update(updItem);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Ticket>().Delete(id);
            _unitOfWork.Save();
        }
    }
}
