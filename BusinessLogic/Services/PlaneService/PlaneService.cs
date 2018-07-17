using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services
{
    public class PlaneService : IPlaneService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PlaneService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<PlaneDto> GetAll()
        {
            var items = _unitOfWork.Repository<Plane>().GetAll();
            return this._mapper.Map<List<Plane>, List<PlaneDto>>(items);
        }

        public PlaneDto Get(int id)
        {
            var item = _unitOfWork.Repository<Plane>().Get(id);
            return this._mapper.Map<Plane, PlaneDto>(item);
        }

        public void Create(PlaneDto item)
        {
            var newItem = this._mapper.Map<PlaneDto, Plane>(item);
            _unitOfWork.Repository<Plane>().Create(newItem);
            _unitOfWork.Save();
        }

        public void Update(PlaneDto item)
        {
            var updItem = this._mapper.Map<PlaneDto, Plane>(item);
            _unitOfWork.Repository<Plane>().Update(updItem);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Plane>().Delete(id);
            _unitOfWork.Save();
        }
    }
}
