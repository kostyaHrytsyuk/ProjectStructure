using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System.Threading.Tasks;

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

        public async Task<List<DepartureDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<Departure>().GetAll();
            return _mapper.Map<List<Departure>, List<DepartureDto>>(items);
        }

        public async Task<DepartureDto> Get(int id)
        {
            var item = await _unitOfWork.Repository<Departure>().Get(id);
            return _mapper.Map<Departure, DepartureDto>(item);
        }

        public Task Create(DepartureDto item)
        {
            var newItem = _mapper.Map<DepartureDto, Departure>(item);
            _unitOfWork.Repository<Departure>().Create(newItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Update(DepartureDto item)
        {
            var updItem = _mapper.Map<DepartureDto, Departure>(item);
            _unitOfWork.Repository<Departure>().Update(updItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Delete(int id)
        {
            _unitOfWork.Repository<Departure>().Delete(id);
            return _unitOfWork.SaveAsync();
        }
    }
}
