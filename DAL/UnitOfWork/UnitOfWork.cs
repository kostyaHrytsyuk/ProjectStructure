using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using DAL.Models;

namespace DAL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private DataSource _context;

        #region Repositories
        private IRepository<PlaneType> _planeTypeRepository;
        private IRepository<Plane> _planeRepository;
        private IRepository<Stewardess> _stewardessRepository;
        private IRepository<Pilot> _pilotRepository;
        private IRepository<Crew> _crewRepository;
        private IRepository<Ticket> _ticketRepository;
        private IRepository<Fligth> _flightRepository;
        private IRepository<Departure> _departureRepository;
        #endregion


        public UnitOfWork(DataSource context)
        {
            _context = context;
        }

        public IRepository<PlaneType> PlaneTypeRepository => _planeTypeRepository ?? new PlaneTypeRepository(_context);        
        public IRepository<Plane> PlaneRepository => _planeRepository ?? new PlaneRepository(_context);
        public IRepository<Stewardess> StewardessRepository => _stewardessRepository ?? new StewardessRepository(_context);
        public IRepository<Pilot> PilotRepository => _pilotRepository ?? new PilotRepository(_context);
        public IRepository<Crew> CrewRepository => _crewRepository ?? new CrewRepository(_context);
        public IRepository<Ticket> TicketRepository => _ticketRepository ?? new TicketRepository(_context);
        public IRepository<Fligth> FligthRepository => _flightRepository ?? new FlightRepository(_context);
        public IRepository<Departure> DepartureRepository => _departureRepository ?? new DepartureRepository(_context);


    }
}
