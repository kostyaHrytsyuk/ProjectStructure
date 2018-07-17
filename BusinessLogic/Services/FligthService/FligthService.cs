using System.Collections.Generic;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System.Threading.Tasks;

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

        public async Task<List<FlightDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<Flight>().GetAll();
            return _mapper.Map<List<Flight>, List<FlightDto>>(items);
        }

        public async Task<FlightDto> Get(int id)
        {
            var item = await _unitOfWork.Repository<Flight>().Get(id);
            return _mapper.Map<Flight, FlightDto>(item);
        }

        public Task Create(FlightDto item)
        {
            var newItem = _mapper.Map<FlightDto, Flight>(item);
            _unitOfWork.Repository<Flight>().Create(newItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Update(FlightDto item)
        {
            var updItem = _mapper.Map<FlightDto, Flight>(item);
            _unitOfWork.Repository<Flight>().Update(updItem);
            return _unitOfWork.SaveAsync();
        }

        public Task Delete(int id)
        {
            _unitOfWork.Repository<Flight>().Delete(id);
            return _unitOfWork.SaveAsync();
        }
    }
}
