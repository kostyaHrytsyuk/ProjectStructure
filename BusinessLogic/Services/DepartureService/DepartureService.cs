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
            return this._mapper.Map<List<Departure>, List<DepartureDto>>(items);
        }

        public DepartureDto Get(int id)
        {
            var item = _unitOfWork.Repository<Departure>().Get(id);
            return this._mapper.Map<Departure, DepartureDto>(item);
        }

        public void Create(DepartureDto item)
        {
            var newItem = this._mapper.Map<DepartureDto, Departure>(item);
            _unitOfWork.Repository<Departure>().Create(newItem);
        }

        public void Update(DepartureDto item)
        {
            var updItem = this._mapper.Map<DepartureDto, Departure>(item);
            _unitOfWork.Repository<Departure>().Update(updItem);
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Departure>().Delete(id);
        }
    }
}
