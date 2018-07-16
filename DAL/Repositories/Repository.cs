using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using System;

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
            switch (typeof(T).Name)
            {
                case "Plane":
                    var planes = _context.SetOf<Plane>();
                    var planesWithTypes = planes.Include(p => p.PlaneType);
                    return planesWithTypes.ToList() as List<T>;
                default:
                    return _context.SetOf<T>() as List<T>;
            }
        }

        public T Get(int id)
        {
            var item = GetAll().Where(i => i.Id == id).FirstOrDefault();
            return item;
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


