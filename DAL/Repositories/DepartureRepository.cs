using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    class DepartureRepository : IRepository<Departure>
    {
        private DataSource _context;

        public DepartureRepository(DataSource context)
        {
            _context = context;
        }

        public List<Departure> GetAll()
        {
            return _context.Departures;
        }

        public Departure Get(int id)
        {
            return _context.Departures.Find(d => d.Id == id);
        }

        public void Create(Departure item)
        {
            _context.Departures.Add(item);
        }

        public void Update(Departure item)
        {
            var updItem = Get(item.Id);
            updItem = item;
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                _context.Departures.Remove(deleteItem);
            }
        }
    }
}
