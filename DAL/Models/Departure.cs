using System;

namespace DAL.Models
{
    public class Departure : Entity
    {
        public string FlightNumber { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public DateTime DepartureDate { get; set; }

        public int CrewId { get; set; }
        public Crew Crew { get; set; }

        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
    }
}
