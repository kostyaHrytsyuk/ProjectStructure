using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    class FlightRepository : IRepository<Flight>
    {
        private DataSource _context;

        public FlightRepository(DataSource context)
        {
            _context = context;
        }

        public List<Flight> GetAll()
        {
            return _context.Flights;
        }

        public Flight Get(int id)
        {
            return _context.Flights.Find(f => f.Id == id);
        }

        public void Create(Flight item)
        {
            _context.Flights.Add(item);
        }

        public void Update(Flight item)
        {
            var updItem = Get(item.Id);
            updItem = item;
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                _context.Flights.Remove(deleteItem);
            }
        }
    }
}
