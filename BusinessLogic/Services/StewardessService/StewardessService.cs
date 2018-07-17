using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services
{
    public class StewardessService : IStewardessService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<StewardessDto> GetAll()
        {
            var items = _unitOfWork.Repository<Stewardess>().GetAll();
            return this._mapper.Map<List<Stewardess>, List<StewardessDto>>(items);
        }

        public StewardessDto Get(int id)
        {
            var item = _unitOfWork.Repository<Stewardess>().Get(id);
            return this._mapper.Map<Stewardess, StewardessDto>(item);
        }

        public void Create(StewardessDto item)
        {
            var newItem = this._mapper.Map<StewardessDto, Stewardess>(item);
            _unitOfWork.Repository<Stewardess>().Create(newItem);
            _unitOfWork.Save();
        }

        public void Update(StewardessDto item)
        {
            var updItem = this._mapper.Map<StewardessDto, Stewardess>(item);
            _unitOfWork.Repository<Stewardess>().Update(updItem);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Stewardess>().Delete(id);
            _unitOfWork.Save();
        }

    }
}
