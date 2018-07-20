using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Tickets")]
    public class Ticket : Entity
    {
        [Column("Price",TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Flight Flight { get; set; }

        [Column("FlightNumber")]
        public string FlightNumber { get; set; }

        [Column("FlightId")]
        public int FlightId { get; set; }

        
    }
}
