using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL
{

    public class DataSource
    {
        public List<Departure> Departures { get; set; }

        public List<Flight> Flights { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<Crew> Crews { get; set; }

        public List<Pilot> Pilots { get; set; }

        public List<Stewardess> Stewardesses { get; set; }

        private readonly List<Plane> planes;

        private readonly List<PlaneType> planeTypes;

        public DataSource()
        {
            planeTypes = new List<PlaneType>()
            {
                new PlaneType() { Id = 1, PlaneModel = "Civil", SeatsNumber = 200, Carrying = 10000 },
                new PlaneType() { Id = 2, PlaneModel = "Cargo", SeatsNumber = 10, Carrying = 50000 },
                new PlaneType() { Id = 3, PlaneModel = "Military", SeatsNumber = 40, Carrying = 3000},
                new PlaneType() { Id = 4, PlaneModel = "Falcon", SeatsNumber = 100, Carrying = 9}
            };

            planes = new List<Plane>()
            {
                new Plane(1, "Dream", 2, new DateTime(1995, 11, 4)),
                new Plane(2, "Boeing", 1, new DateTime(2011, 6, 15)),
                new Plane(3, "Heavy", 4, new DateTime(2018, 2, 6))
            };

            Data = new Dictionary<Type, IEnumerable<Entity>>();
            Data.Add(typeof(Departure), Departures);
            Data.Add(typeof(Flight), Flights);
            Data.Add(typeof(Ticket), Tickets);
            Data.Add(typeof(Crew), Crews);
            Data.Add(typeof(Pilot), Pilots);
            Data.Add(typeof(Stewardess), Stewardesses);

            Data.Add(typeof(PlaneType), planeTypes);
            Data.Add(typeof(Plane), planes);

        }

        private Dictionary<Type, IEnumerable<Entity>> Data;

        public IEnumerable<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            var r = Data[typeof(TEntity)];
            return r as IEnumerable<TEntity>;
        }
    }
}
