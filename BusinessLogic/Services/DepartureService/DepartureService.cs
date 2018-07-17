using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services
{
    public class DepartureService : IDepartureService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DepartureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<DepartureDto> GetAll()
        {
            var items = _unitOfWork.Repository<Departure>().GetAll();
            return  _mapper.Map<List<Departure>, List<DepartureDto>>(items);
        }

        public DepartureDto Get(int id)
        {
            var item = _unitOfWork.Repository<Departure>().Get(id);
            return  _mapper.Map<Departure, DepartureDto>(item);
        }

        public void Create(DepartureDto item)
        {
            var newItem =  _mapper.Map<DepartureDto, Departure>(item);
            _unitOfWork.Repository<Departure>().Create(newItem);
            _unitOfWork.Save();
        }

        public void Update(DepartureDto item)
        {
            var updItem =  _mapper.Map<DepartureDto, Departure>(item);
            _unitOfWork.Repository<Departure>().Update(updItem);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Departure>().Delete(id);
            _unitOfWork.Save();
        }
    }
}
