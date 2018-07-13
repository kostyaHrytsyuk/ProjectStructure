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

        private readonly List<Pilot> pilots;

        private readonly List<Stewardess> stewardesses;

        private readonly List<Plane> planes;

        private readonly List<PlaneType> planeTypes;

        public DataSource()
        {
            #region Plane Types
            planeTypes = new List<PlaneType>()
            {
                new PlaneType() { Id = 1, PlaneModel = "Civil", SeatsNumber = 200, Carrying = 10000 },
                new PlaneType() { Id = 2, PlaneModel = "Cargo", SeatsNumber = 10, Carrying = 50000 },
                new PlaneType() { Id = 3, PlaneModel = "Military", SeatsNumber = 40, Carrying = 3000},
                new PlaneType() { Id = 4, PlaneModel = "Falcon", SeatsNumber = 100, Carrying = 9}
            };
            #endregion

            #region Planes
            planes = new List<Plane>()
            {
                new Plane(1, "Dream", 2, new DateTime(1995, 11, 4)),
                new Plane(2, "Boeing", 1, new DateTime(2011, 6, 15)),
                new Plane(3, "Heavy", 4, new DateTime(2018, 2, 6))
            };
            #endregion

            #region Stewardesses
            stewardesses = new List<Stewardess>()
            {
                new Stewardess() { Id = 1, Name = "Katy", Surname = "Smith" , DateOfBirth = new DateTime(1983, 10, 5)},
                new Stewardess() { Id = 2, Name = "Carol", Surname = "Hoover", DateOfBirth = new DateTime(1991, 4, 11)},
                new Stewardess() { Id = 3, Name = "Ada", Surname = "Lovelace", DateOfBirth = new DateTime(1976, 7, 13)},
                new Stewardess() { Id = 4, Name = "Beverly", Surname = "Marsh", DateOfBirth = new DateTime(2002 , 2, 13)}
            };
            #endregion

            #region Pilots
            pilots = new List<Pilot>()
            {
                new Pilot(){ Id = 1, Name = "Jimmy", Surname = "Doolittle", DateOfBirth = new DateTime(1973, 9, 16), Experience = 12},
                new Pilot(){ Id = 2, Name = "Noel", Surname = "Wien", DateOfBirth = new DateTime(1982, 8 , 20), Experience = 9},
                new Pilot(){ Id = 3, Name = "Robert", Surname = "Hoover", DateOfBirth = new DateTime(1980, 3 , 13), Experience = 15}
            };
            #endregion


            Data = new Dictionary<Type, IEnumerable<Entity>>();
            Data.Add(typeof(Departure), Departures);
            Data.Add(typeof(Flight), Flights);
            Data.Add(typeof(Ticket), Tickets);
            Data.Add(typeof(Crew), Crews);
            

            Data.Add(typeof(PlaneType), planeTypes);
            Data.Add(typeof(Plane), planes);
            Data.Add(typeof(Stewardess), stewardesses);
            Data.Add(typeof(Pilot), pilots);


        }

        private Dictionary<Type, IEnumerable<Entity>> Data;

        public IEnumerable<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            var r = Data[typeof(TEntity)];
            return r as IEnumerable<TEntity>;
        }
    }
}
