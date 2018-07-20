using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    [Table("Tickets")]
    public class Ticket : Entity
    {
        [Column("Price",TypeName = "decimal(18,2)"),Required]
        public decimal Price { get; set; }

        [Column("FlightNumber"),StringLength(maximumLength: 6, MinimumLength = 6),Required]
        public string FlightNumber { get; set; }

        [Column("FlightId")]
        public int FlightId { get; set; }

        public Flight Flight { get; set; }
    }
}
