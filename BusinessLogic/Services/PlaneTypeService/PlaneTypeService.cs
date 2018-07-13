﻿using System.Collections.Generic;
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
            return this._mapper.Map<List<PlaneType>, List<PlaneTypeDto>>(items);
        }

        public PlaneTypeDto Get(int id)
        {
            var item = _unitOfWork.Repository<PlaneType>().Get(id);
            return this._mapper.Map<PlaneType, PlaneTypeDto>(item);
        }

        public void Create(PlaneTypeDto item)
        {
            var newItem = this._mapper.Map<PlaneTypeDto, PlaneType>(item);
            _unitOfWork.Repository<PlaneType>().Create(newItem);
        }

        public void Update(PlaneTypeDto item)
        {
            var updItem = this._mapper.Map<PlaneTypeDto, PlaneType>(item);
            _unitOfWork.Repository<PlaneType>().Update(updItem);
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<PlaneType>().Delete(id);
        }

    }
}