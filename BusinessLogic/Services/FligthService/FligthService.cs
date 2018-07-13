using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services
{
    public class FligthService : IFligthService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FligthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<FligthDto> GetAll()
        {
            var items = _unitOfWork.Repository<Fligth>().GetAll();
            return this._mapper.Map<List<Fligth>, List<FligthDto>>(items);
        }

        public FligthDto Get(int id)
        {
            var item = _unitOfWork.Repository<Fligth>().Get(id);
            return this._mapper.Map<Fligth, FligthDto>(item);
        }

        public void Create(FligthDto item)
        {
            var newItem = this._mapper.Map<FligthDto, Fligth>(item);
            _unitOfWork.Repository<Fligth>().Create(newItem);
        }

        public void Update(FligthDto item)
        {
            var updItem = this._mapper.Map<FligthDto, Fligth>(item);
            _unitOfWork.Repository<Fligth>().Update(updItem);
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Fligth>().Delete(id);
        }
    }
}
