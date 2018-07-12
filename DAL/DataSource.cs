using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    
    public class DataSource
    {
        private static readonly Lazy<DataSource> lazySource = new Lazy<DataSource>(() => new DataSource());

        public static DataSource Source { get { return lazySource.Value; }  }

        public List<Departure> Departures { get; set; }

        public List<Fligth> Fligths { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<Crew> Crews { get; set; }

        public List<Pilot> Pilots { get; set; }

        public List<Stewardess> Stewardesses { get; set; }

        public List<Plane> Planes { get; set; }

        public List<PlaneType> PlaneTypes { get; set; }

        public DataSource()
        {
            Data.Add(typeof(Departure), Departures);
            Data.Add(typeof(Fligth), Fligths);
            Data.Add(typeof(Ticket), Tickets);
            Data.Add(typeof(Crew), Crews);
            Data.Add(typeof(Pilot), Pilots);
            Data.Add(typeof(Stewardess), Stewardesses);
            Data.Add(typeof(Plane), Planes);
            Data.Add(typeof(PlaneType), PlaneTypes);
        }

        public Dictionary<Type, IEnumerable<Entity>> Data { get; set; }

        public IEnumerable<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            return Data[typeof(TEntity)] as IEnumerable<TEntity>;
        }
    }
}
