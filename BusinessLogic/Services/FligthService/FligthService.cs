using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services
{
    public class FlightService : IFlightService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<FlightDto> GetAll()
        {
            var items = _unitOfWork.Repository<Flight>().GetAll();
            return  _mapper.Map<List<Flight>, List<FlightDto>>(items);
        }

        public FlightDto Get(int id)
        {
            var item = _unitOfWork.Repository<Flight>().Get(id);
            return  _mapper.Map<Flight, FlightDto>(item);
        }

        public FlightDto Create(FlightDto item)
        {
            var newItem =  _mapper.Map<FlightDto, Flight>(item);
            _unitOfWork.Repository<Flight>().Create(newItem);
            _unitOfWork.Save();
            return item = _mapper.Map<Flight, FlightDto>(newItem);
        }

        public void Update(FlightDto item)
        {
            var updItem =  _mapper.Map<FlightDto, Flight>(item);
            _unitOfWork.Repository<Flight>().Update(updItem);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Flight>().Delete(id);
            _unitOfWork.Save();
        }
    }
}
