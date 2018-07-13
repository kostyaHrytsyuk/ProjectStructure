using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace DAL.Repositories
{
    class Repository<T> : IRepository<T> where T : Entity
    {
        private DataSource _context;

        public Repository(DataSource context)
        {
            _context = context;
        }
            
        public List<T> GetAll()
        {
            return (List<T>)_context.SetOf<T>();
        }

        public T Get(int id)
        {
            return _context.SetOf<T>().Where(e => e.Id == id).FirstOrDefault();
        }

        public void Create(T item)
        {
            ((List<T>)_context.SetOf<T>()).Add(item);
        }

        public void Update(T item)
        {            
            var updItemIndex = _context.SetOf<T>().ToList().IndexOf(Get(item.Id));
            ((List<T>)_context.SetOf<T>())[updItemIndex] = item;
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                ((List<T>)_context.SetOf<T>()).Remove(deleteItem);
            }
        }
    }
}


