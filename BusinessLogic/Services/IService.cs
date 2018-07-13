using System.Collections.Generic;
using Common.DTO;

namespace BusinessLogic.Services
{
    public interface IService<T> where T : BaseDto
    {
        List<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
