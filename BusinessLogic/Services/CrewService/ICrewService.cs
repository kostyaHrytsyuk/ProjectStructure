using Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ICrewService : IService<CrewDto>
    {
        Task CreateSaveOutCrews(List<CrewDto> crews);
    }
}
