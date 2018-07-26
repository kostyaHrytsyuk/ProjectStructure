using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System.Threading.Tasks;

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

        public async Task<List<PlaneTypeDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<PlaneType>().GetAll();
            return _mapper.Map<List<PlaneType>, List<PlaneTypeDto>>(items);
        }

        public async Task<PlaneTypeDto> Get(int id)
        {
            var item = await _unitOfWork.Repository<PlaneType>().Get(id);
            return _mapper.Map<PlaneType, PlaneTypeDto>(item);
        }

        public async Task Create(PlaneTypeDto item)
        {
            var newItem = _mapper.Map<PlaneTypeDto, PlaneType>(item);
            await _unitOfWork.Repository<PlaneType>().Create(newItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(PlaneTypeDto item)
        {
            var updItem = _mapper.Map<PlaneTypeDto, PlaneType>(item);
            await _unitOfWork.Repository<PlaneType>().Update(updItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Repository<PlaneType>().Delete(id);
            await _unitOfWork.SaveAsync();
        }

    }
}
