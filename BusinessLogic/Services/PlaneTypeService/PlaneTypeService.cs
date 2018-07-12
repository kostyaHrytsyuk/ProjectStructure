using System;
using System.Collections.Generic;
using System.Text;
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
            var planeTypes = _unitOfWork.Repository<PlaneType>().GetAll();
            return new List<PlaneTypeDto>();
        }

        public PlaneTypeDto Get(int id)
        {
            //return _unitOfWork.Repository<PlaneType>().Get(id);
            return new PlaneTypeDto();
        }

        public void Create(PlaneTypeDto item)
        {
            //_unitOfWork.Repository<PlaneType>().Create(item);
        }

        public void Update(PlaneTypeDto item)
        {
            //_unitOfWork.Repository<PlaneType>().Update(item);
        }
        
        public void Delete(int id)
        {
            _unitOfWork.Repository<PlaneType>().Delete(id);
        }

    }
}
