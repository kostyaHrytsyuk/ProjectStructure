using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    class FlightRepository : IRepository<Fligth>
    {
        private DataSource _context;

        public FlightRepository(DataSource context)
        {
            _context = context;
        }

        public List<Fligth> GetAll()
        {
            return _context.Fligths;
        }

        public Fligth Get(int id)
        {
            return _context.Fligths.Find(f => f.Id == id);
        }

        public void Create(Fligth item)
        {
            _context.Fligths.Add(item);
        }

        public void Update(Fligth item)
        {
            var updItem = Get(item.Id);
            updItem = item;
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                _context.Fligths.Remove(deleteItem);
            }
        }
    }
}
