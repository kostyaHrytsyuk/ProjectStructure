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
                    var planes = _context.Planes;
                    var planesWithTypes = planes.Include(p => p.PlaneType);
                    return planesWithTypes.ToList() as List<T>;
                case "Stewardess":
                    var stewardesses = _context.Stewardesses;
                    var stewardessesWithCrews = stewardesses.Include(s => s.Crew).ThenInclude(c => c.Pilot);
                    return stewardessesWithCrews.ToList() as List<T>;
                case "Pilot":
                    var pilots = _context.Pilots;
                    var pilotsWithCrews = pilots.Include(p => p.Crew).ThenInclude(c => c.Stewardesses);
                    return pilotsWithCrews.ToList() as List<T>;
                case "Crew":
                    var crews = _context.Crews;
                    var crewsWithStaff = crews.Include(c => c.Stewardesses).Include(c => c.Pilot);
                    return crewsWithStaff.ToList() as List<T>;
                case "Ticket":
                    var tickets = _context.Tickets;
                    var ticketsWithFlights = tickets.Include(t => t.Flight);
                    return ticketsWithFlights.ToList() as List<T>;
                case "Flight":
                    var flights = _context.Flights;
                    var flightsWithTickets = flights.Include(f => f.Tickets);
                    return flightsWithTickets.ToList() as List<T>;
                default:
                    return _context.SetOf<T>().ToList() as List<T>;
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


