using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Ticket : Entity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string FlightNumber { get; set; }
    }
}
