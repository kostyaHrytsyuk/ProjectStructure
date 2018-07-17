using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DTO;

namespace BusinessLogic.Services
{
    public interface IService<T> where T : BaseDto
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
