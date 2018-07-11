using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    class DataSource
    {
        public List<Departure> Departures { get; set; }

        public List<Fligth> Fligths { get; set; }

        public List<Ticket> Tickets { get; set; } 

        public List<Crew> Crews { get; set; }

        public List<Pilot> Pilots { get; set; }

        public List<Stewardess> Stewardesses { get; set; }

        public List<Plane> Planes { get; set; }

        public List<PlaneType> PlaneTypes { get; set; }
    }
}
