using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace DAL.Repositories
{
    class Repository<T> : IRepository<T> where T : Entity
    {
        private AirportContext _context;

        public Repository(AirportContext context)
        {
            _context = context;
        }
            
        public List<T> GetAll()
        {
            var items = _context.SetOf<T>().Select(item => item).ToList();
            return items;
        }

        public T Get(int id)
        {
            return _context.SetOf<T>().Where(e => e.Id == id).FirstOrDefault();
        }

        public void Create(T item)
        {
            (_context.SetOf<T>()).Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            var updItem = Get(item.Id);
            _context.SetOf<T>().Remove(updItem);
            _context.SetOf<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                (_context.SetOf<T>()).Remove(deleteItem);
            }
            _context.SaveChanges();
        }
    }
}


