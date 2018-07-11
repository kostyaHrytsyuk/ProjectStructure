using System;

namespace DAL.Models
{
    class Departures : Entity
    {
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }

        public Crew Crew { get; set; }

        public Plane Plane { get; set; }
    }

}
