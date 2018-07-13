using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    class StewardessRepository : IRepository<Stewardess>
    {
        private DataSource _context;

        public StewardessRepository(DataSource context)
        {
            _context = context;
        }

        public List<Stewardess> GetAll()
        {
            return _context.Stewardesses;
        }

        public Stewardess Get(int id)
        {
            return _context.Stewardesses.Find(s => s.Id == id);
        }

        public void Create(Stewardess item)
        {
            _context.Stewardesses.Add(item);
        }

        public void Update(Stewardess item)
        {
            var updItem = Get(item.Id);
            updItem = item;
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                _context.Stewardesses.Remove(deleteItem);
            }
        }
    }
}
