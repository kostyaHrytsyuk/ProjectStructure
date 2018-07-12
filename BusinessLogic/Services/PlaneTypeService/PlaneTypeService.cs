using System;
using System.Collections.Generic;
using System.Text;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services.PlaneTypeService
{
    class PlaneTypeService : IPlaneTypeService, IService<PlaneTypeDto>
    {
        private IUnitOfWork _unitOfWork;

        public PlaneTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<PlaneTypeDto> GetAll()
        {
            //return _unitOfWork.Repository<PlaneType>().GetAll();
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
