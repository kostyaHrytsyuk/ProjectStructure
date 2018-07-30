using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System.Threading.Tasks;

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

        public async Task<List<StewardessDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<Stewardess>().GetAll();
            return _mapper.Map<List<Stewardess>, List<StewardessDto>>(items);
        }

        public async Task<StewardessDto> Get(int id)
        {
            var item = await _unitOfWork.Repository<Stewardess>().Get(id);
            return _mapper.Map<Stewardess, StewardessDto>(item);
        }

        public async Task<StewardessDto> Create(StewardessDto item)
        {
            var newItem = _mapper.Map<StewardessDto, Stewardess>(item);
            await _unitOfWork.Repository<Stewardess>().Create(newItem);
            await _unitOfWork.SaveAsync();
            return item = _mapper.Map<Stewardess, StewardessDto>(newItem);
        }

        public async Task<StewardessDto> Update(StewardessDto item)
        {
            var updItem = _mapper.Map<StewardessDto, Stewardess>(item);
            await _unitOfWork.Repository<Stewardess>().Update(updItem);
            await _unitOfWork.SaveAsync();
            return item = _mapper.Map<Stewardess, StewardessDto>(updItem);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Repository<Stewardess>().Delete(id);
            await _unitOfWork.SaveAsync();
        }

    }
}
