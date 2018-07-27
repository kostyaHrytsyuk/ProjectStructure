using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System.Threading.Tasks;

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

        public async Task<List<TicketDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<Ticket>().GetAll();
            return _mapper.Map<List<Ticket>, List<TicketDto>>(items);
        }

        public async Task<TicketDto> Get(int id)
        {
            var item = await _unitOfWork.Repository<Ticket>().Get(id);
            return _mapper.Map<Ticket, TicketDto>(item);
        }

        public async Task Create(TicketDto item)
        {
            var newItem = _mapper.Map<TicketDto, Ticket>(item);
            await _unitOfWork.Repository<Ticket>().Create(newItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(TicketDto item)
        {
            var updItem = _mapper.Map<TicketDto, Ticket>(item);
            await _unitOfWork.Repository<Ticket>().Update(updItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Repository<Ticket>().Delete(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
