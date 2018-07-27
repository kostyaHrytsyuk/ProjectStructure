using DAL.Models;
using DAL.Repositories;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;

        void Save();

        Task SaveAsync();
    }
}
