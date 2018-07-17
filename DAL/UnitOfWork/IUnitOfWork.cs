using DAL.Models;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;

        void Save();
    }
}
