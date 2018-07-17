using Newtonsoft.Json;

namespace Common.DTO
{
    public class TicketDto : BaseDto
    {
        public decimal Price { get; set; }

        [JsonIgnore]
        public FlightDto Flight { get; set; }

        public string FlightNumber { get; set; }

        public int FlightId { get; set; }
        
    }
}
