namespace DAL.Models
{
    public class Ticket : Entity
    {
        public decimal Price { get; set; }

        public string FlightNumber { get; set; }
    }
}
