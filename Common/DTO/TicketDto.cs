namespace Common.DTO
{
    public class TicketDto : BaseDto
    {
        public decimal Price { get; set; }

        public FlightDto Flight { get; set; }

        public string FlightNumber { get; set; }
        public int FlightId { get; set; }

        
    }
}
