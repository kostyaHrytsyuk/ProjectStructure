using AutoMapper;
using DAL.UnitOfWork;
using DAL.Models;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Services
{
    public class CrewService : ICrewService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IPilotService _pilotService;
        private IStewardessService _stewardessService;

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper, IPilotService pilotService, IStewardessService stewardessService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pilotService = pilotService;
            _stewardessService = stewardessService;
        }

        public async Task<List<CrewDto>> GetAll()
        {
            var items = await _unitOfWork.Repository<Crew>().GetAll();
            return  _mapper.Map<List<Crew>, List<CrewDto>>(items);
        }

        public async Task CreateSaveOutCrews(List<CrewDto> crews)
        {


            await Task.WhenAll(CreateOutCrews(crews), SaveOutCrews());

            await GetAll();
        }

        private async Task CreateOutCrews(List<CrewDto> crews)
        {
            foreach (var crew in crews)
            {
                var pilot = crew.Pilot.FirstOrDefault();
                pilot.Id = 0;
                foreach (var stewardess in crew.Stewardess)
                {
                    stewardess.Id = 0;
                }
                crew.Id = 0;
                var item = _mapper.Map<CrewDto, Crew>(crew);
                await Create(crew);
            }
        }

        private async Task SaveOutCrews()
        {
            var items = await _unitOfWork.Repository<Crew>().GetAll();

            items = items.OrderByDescending(i => i.Id).Take(10).ToList();

            var csv = new StringBuilder();
            csv.AppendLine("Id,Pilot Name,Number of Stewardess");
            foreach (var item in items)
            {
                csv.AppendLine($"{item.Id},{item.Pilot.FirstName + " " + item.Pilot.LastName}, {item.Stewardess.Count}");
            }

            var path = Path.GetFullPath($"..\\Common\\Data\\{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
                        
            await File.WriteAllTextAsync(path, csv.ToString());

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
