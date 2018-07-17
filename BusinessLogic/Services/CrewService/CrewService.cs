using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CrewService : ICrewService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CrewDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<Crew>().GetAll();
            return  _mapper.Map<List<Crew>, List<CrewDto>>(items);
        }

        public async Task<CrewDto> Get(int id)
        {
            var item = await _unitOfWork.Repository<Crew>().Get(id);
            return  _mapper.Map<Crew, CrewDto>(item);
        }

        public Task Create(CrewDto item)
        {
            var newItem =  _mapper.Map<CrewDto, Crew>(item);
            _unitOfWork.Repository<Crew>().Create(newItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Update(CrewDto item)
        {
            var updItem =  _mapper.Map<CrewDto, Crew>(item);
            _unitOfWork.Repository<Crew>().Update(updItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Delete(int id)
        {
            _unitOfWork.Repository<Crew>().Delete(id);
            return _unitOfWork.SaveAsync();
        }
    }
}
