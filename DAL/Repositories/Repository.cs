using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private AirportContext _context;
        private DbSet<T> _dataSet;

        public Repository(AirportContext context)
        {
            _context = context;
            _dataSet = _context.SetOf<T>();

        }
            
        public List<T> GetAll()
        {
            switch (typeof(T).Name)
            {
                #region Plane
                case "Plane":

                    var planes = _context.Planes;

                    var planesWithTypes = planes.Include(p => p.PlaneType);

                    return planesWithTypes.ToList() as List<T>;
                #endregion

                #region Stewardess
                case "Stewardess":

                    var stewardesses = _context.Stewardesses;

                    var stewardessesWithCrews = stewardesses
                                        .Include(s => s.Crew)
                                            .ThenInclude(c => c.Pilot);

                    return stewardessesWithCrews.ToList() as List<T>;
                #endregion

                #region Pilot
                case "Pilot":

                    var pilots = _context.Pilots;

                    var pilotsWithCrews = pilots
                                        .Include(p => p.Crew)
                                            .ThenInclude(c => c.Stewardesses);

                    return pilotsWithCrews.ToList() as List<T>;
                #endregion

                #region Crew
                case "Crew":

                    var crews = _context.Crews;

                    var crewsWithStaff = crews
                                .Include(c => c.Stewardesses)
                                .Include(c => c.Pilot);

                    return crewsWithStaff.ToList() as List<T>;
                #endregion

                #region Ticket
                case "Ticket":

                    var tickets = _context.Tickets;

                    var ticketsWithFlights = tickets.Include(t => t.Flight);

                    return ticketsWithFlights.ToList() as List<T>;
                #endregion

                #region Flight
                case "Flight":

                    var flights = _context.Flights;

                    var flightsWithTickets = flights.Include(f => f.Tickets);

                    return flightsWithTickets.ToList() as List<T>;
                #endregion

                #region Departure
                case "Departure":

                    var departures = _context.Departures;

                    var departuresWithInfo = departures
                                .Include(d => d.Crew)
                                    .ThenInclude(c => c.Pilot)
                                    .ThenInclude(c => c.Crew.Stewardesses)
                                .Include(d => d.Flight)
                                    .ThenInclude(f => f.Tickets)
                                .Include(d => d.Plane)
                                    .ThenInclude(p => p.PlaneType);

                    return departuresWithInfo.ToList() as List<T>;
                #endregion

                default:
                    return _dataSet.ToList() as List<T>;
            }
        }

        public T Get(int id)
        {
            var item = GetAll().Where(i => i.Id == id).FirstOrDefault();
            return item;
        }

        public void Create(T item)
        {
            _dataSet.Add(item);
        }

        public void Update(T item)
        {
            var updItem = Get(item.Id);
            _dataSet.Remove(updItem);
            _dataSet.Add(item);
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                _dataSet.Remove(deleteItem);
            }
        }
    }
}


