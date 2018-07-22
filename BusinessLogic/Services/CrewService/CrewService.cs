using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

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

        public List<CrewDto> GetAll()
        {
            var items = _unitOfWork.Repository<Crew>().GetAll();
            return  _mapper.Map<List<Crew>, List<CrewDto>>(items);
        }

        public CrewDto Get(int id)
        {
            var item = _unitOfWork.Repository<Crew>().Get(id);
            return  _mapper.Map<Crew, CrewDto>(item);
        }

        public void Create(CrewDto item)
        {
            var newItem =  _mapper.Map<CrewDto, Crew>(item);
            _unitOfWork.Repository<Crew>().Create(newItem);
            _unitOfWork.Save();
        }

        public void Update(CrewDto item)
        {
            var updItem =  _mapper.Map<CrewDto, Crew>(item);
            _unitOfWork.Repository<Crew>().Update(updItem);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Crew>().Delete(id);
            _unitOfWork.Save();
        }
    }
}
