using System;
using System.Collections.Generic;
using DAL.Repositories;
using DAL.Models;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataSource _context;

        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            if (repositories.ContainsKey(typeof(TEntity)))
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var newRepository = new Repository<TEntity>(_context);
            repositories.Add(typeof(TEntity), newRepository);
            return newRepository;
        }
        
        public UnitOfWork()
        {
            _context = DataSource.Source;
        }

        //#region Repositories
        //public IRepository<PlaneType> PlaneTypeRepository => new PlaneTypeRepository(_context);
        //public IRepository<Plane> PlaneRepository => new PlaneRepository(_context);
        //public IRepository<Stewardess> StewardessRepository => new StewardessRepository(_context);
        //public IRepository<Pilot> PilotRepository => new PilotRepository(_context);
        //public IRepository<Crew> CrewRepository => new CrewRepository(_context);
        //public IRepository<Ticket> TicketRepository => new TicketRepository(_context);
        //public IRepository<Fligth> FligthRepository => new FlightRepository(_context);
        //public IRepository<Departure> DepartureRepository => new DepartureRepository(_context);
        //#endregion



    }
}
