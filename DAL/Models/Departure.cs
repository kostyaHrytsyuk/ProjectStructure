using System;

namespace DAL.Models
{
    public class Departure : Entity
    {
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }

        public int CrewId { get; set; }

        public int PlaneId { get; set; }
    }
}
