using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Flight : Entity
    {
        public string FlightNumber { get; set; }

        public string DepartureAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public string DestinationAirport { get; set; }

        public DateTime ArrivalTime { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
