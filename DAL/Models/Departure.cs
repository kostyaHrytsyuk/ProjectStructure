using System;

namespace DAL.Models
{
    public class Departure : Entity
    {
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }

        public virtual Crew Crew { get; set; }

        public virtual Plane Plane { get; set; }
    }
}
