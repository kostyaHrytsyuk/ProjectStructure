using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    class PlaneRepository : IRepository<Plane>
    {
        private DataSource _context;

        public PlaneRepository(DataSource context)
        {
            _context = context;
        }

        public List<Plane> GetAll()
        {
            return _context.Planes;
        }

        public Plane Get(int id)
        {
            return _context.Planes.Find(p => p.Id == id);
        }

        public void Create(Plane item)
        {
            _context.Planes.Add(item);
        }

        public void Update(Plane item)
        {
            var updItem = Get(item.Id);
            updItem = item;
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                _context.Planes.Remove(deleteItem);
            }
        }
    }
}
