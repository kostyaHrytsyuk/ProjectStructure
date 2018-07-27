using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class Repository<T> : IRepository<T> where T : Entity
    {
        private AirportContext _context;
        private DbSet<T> _dataSet;

        public Repository(AirportContext context)
        {
            _context = context;
            _dataSet = _context.SetOf<T>();
        }
            
        public Task<List<T>> GetAll()
        {
            switch (typeof(T).Name)
            {
                #region Plane
                case "Plane":

                    var planes = _context.Planes;

                    var planesWithTypes = planes.Include(p => p.PlaneType);

                    return planesWithTypes.ToListAsync() as Task<List<T>>;
                #endregion

                #region Stewardess
                case "Stewardess":

                    var stewardesses = _context.Stewardesses;

                    var stewardessesWithCrews = stewardesses
                                        .Include(s => s.Crew)
                                            .ThenInclude(c => c.Pilot);

                    return stewardessesWithCrews.ToListAsync() as Task<List<T>>;
                #endregion

                #region Pilot
                case "Pilot":

                    var pilots = _context.Pilots;

                    var pilotsWithCrews = pilots
                                        .Include(p => p.Crew)
                                            .ThenInclude(c => c.Stewardess);

                    return pilotsWithCrews.ToListAsync() as Task<List<T>>;
                #endregion

                #region Crew
                case "Crew":

                    var crews = _context.Crews;

                    var crewsWithStaff = crews
                                .Include(c => c.Stewardess)
                                .Include(c => c.Pilot);

                    return crewsWithStaff.ToListAsync() as Task<List<T>>;
                #endregion

                #region Ticket
                case "Ticket":

                    var tickets = _context.Tickets;

                    var ticketsWithFlights = tickets.Include(t => t.Flight);

                    return ticketsWithFlights.ToListAsync() as Task<List<T>>;
                #endregion

                #region Flight
                case "Flight":

                    var flights = _context.Flights;

                    var flightsWithTickets = flights.Include(f => f.Tickets);

                    return flightsWithTickets.ToListAsync() as Task<List<T>>;
                #endregion

                #region Departure
                case "Departure":

                    var departures = _context.Departures;

                    var departuresWithInfo = departures
                                .Include(d => d.Crew)
                                    .ThenInclude(c => c.Pilot)
                                    .ThenInclude(c => c.Crew.Stewardess)
                                .Include(d => d.Flight)
                                    .ThenInclude(f => f.Tickets)
                                .Include(d => d.Plane)
                                    .ThenInclude(p => p.PlaneType);

                    return departuresWithInfo.ToListAsync() as Task<List<T>>;
                #endregion

                default:
                    return _dataSet.ToListAsync() as Task<List<T>>;
            }
        }

        public Task<T> Get(int id)
        {
            var item = _dataSet.FindAsync(id);
            return item;
        }
        
        public Task Create(T item)
        {
            return _dataSet.AddAsync(item);
        }

        public async Task Update(T item)
        {
            var updItem = await Get(item.Id);
            _dataSet.Remove(updItem);
            await _dataSet.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var deleteItem = await Get(id);
            if (deleteItem != null)
            {
                _dataSet.Remove(deleteItem);
            }
        }
    }
}


