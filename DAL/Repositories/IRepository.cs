using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        List<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
