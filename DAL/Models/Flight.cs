using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Flights")]
    public class Flight : Entity
    {
        [Column("FlightNumber")]
        public string FlightNumber { get; set; }

        [Column("DepartureAirport")]
        public string DepartureAirport { get; set; }

        [Column("DepartureTime")]
        public DateTime DepartureTime { get; set; }

        [Column("DestinationAirport")]
        public string DestinationAirport { get; set; }

        [Column("ArrivalTime")]
        public DateTime ArrivalTime { get; set; }

        public Departure Departure { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
