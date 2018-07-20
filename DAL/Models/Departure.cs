using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Departure")]
    public class Departure : Entity
    {
        [Column("FlightNumber"), StringLength(maximumLength: 6, MinimumLength = 6), Required]
        public string FlightNumber { get; set; }

        [Column("FlightId")]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        [Column("DepartureDate")]
        public DateTime DepartureDate { get; set; }

        [Column("CrewId")]
        public int CrewId { get; set; }
        public Crew Crew { get; set; }

        [Column("PlaneId")]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
    }
}
