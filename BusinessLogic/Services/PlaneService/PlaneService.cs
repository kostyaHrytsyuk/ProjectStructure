using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System.Threading.Tasks;

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

        public async Task<List<PlaneDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<Plane>().GetAll();
            return _mapper.Map<List<Plane>, List<PlaneDto>>(items);
        }

        public async Task<PlaneDto> Get(int id)
        {
            var item = await _unitOfWork.Repository<Plane>().Get(id);
            return _mapper.Map<Plane, PlaneDto>(item);
        }

        public Task Create(PlaneDto item)
        {
            var newItem = _mapper.Map<PlaneDto, Plane>(item);
            _unitOfWork.Repository<Plane>().Create(newItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Update(PlaneDto item)
        {
            var updItem = _mapper.Map<PlaneDto, Plane>(item);
            _unitOfWork.Repository<Plane>().Update(updItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Delete(int id)
        {
            _unitOfWork.Repository<Plane>().Delete(id);
            return _unitOfWork.SaveAsync();
        }
    }
}
