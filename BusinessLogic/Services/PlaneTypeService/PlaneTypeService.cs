using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services
{
    public class PlaneTypeService : IPlaneTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PlaneTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<PlaneTypeDto> GetAll()
        {
            var items = _unitOfWork.Repository<PlaneType>().GetAll();
            return  _mapper.Map<List<PlaneType>, List<PlaneTypeDto>>(items);
        }

        public PlaneTypeDto Get(int id)
        {
            var item = _unitOfWork.Repository<PlaneType>().Get(id);
            return  _mapper.Map<PlaneType, PlaneTypeDto>(item);
        }

        public void Create(PlaneTypeDto item)
        {
            var newItem =  _mapper.Map<PlaneTypeDto, PlaneType>(item);
            _unitOfWork.Repository<PlaneType>().Create(newItem);
            _unitOfWork.Save();
        }

        public void Update(PlaneTypeDto item)
        {
            var updItem =  _mapper.Map<PlaneTypeDto, PlaneType>(item);
            _unitOfWork.Repository<PlaneType>().Update(updItem);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<PlaneType>().Delete(id);
            _unitOfWork.Save();
        }

    }
}
