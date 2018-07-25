using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PilotService : IPilotService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PilotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PilotDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<Pilot>().GetAll();
            return _mapper.Map<List<Pilot>, List<PilotDto>>(items);
        }

        public async Task<PilotDto> Get(int id)
        {
            var item = await _unitOfWork.Repository<Pilot>().Get(id);
            return _mapper.Map<Pilot, PilotDto>(item);
        }

        public Task Create(PilotDto item)
        {
            var newItem = _mapper.Map<PilotDto, Pilot>(item);
            _unitOfWork.Repository<Pilot>().Create(newItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Update(PilotDto item)
        {
            var updItem = _mapper.Map<PilotDto, Pilot>(item);
            _unitOfWork.Repository<Pilot>().Update(updItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Delete(int id)
        {
            _unitOfWork.Repository<Pilot>().Delete(id);
            return _unitOfWork.SaveAsync();
        }

    }
}
