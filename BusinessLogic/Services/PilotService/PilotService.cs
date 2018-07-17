using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

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

        public List<PilotDto> GetAll()
        {
            var items = _unitOfWork.Repository<Pilot>().GetAll();
            return  _mapper.Map<List<Pilot>, List<PilotDto>>(items);
        }

        public PilotDto Get(int id)
        {
            var item = _unitOfWork.Repository<Pilot>().Get(id);
            return  _mapper.Map<Pilot, PilotDto>(item);
        }

        public void Create(PilotDto item)
        {
            var newItem =  _mapper.Map<PilotDto, Pilot>(item);
            _unitOfWork.Repository<Pilot>().Create(newItem);
            _unitOfWork.Save();
        }

        public void Update(PilotDto item)
        {
            var updItem =  _mapper.Map<PilotDto, Pilot>(item);
            _unitOfWork.Repository<Pilot>().Update(updItem);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Pilot>().Delete(id);
            _unitOfWork.Save();
        }

    }
}
