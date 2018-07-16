using System;
using System.Collections.Generic;

namespace Common.DTO
{
    public class FlightDto : BaseDto
    {
        public string FlightNumber { get; set; }

        public string DepartureAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public string DestinationAirport { get; set; }

        public DateTime ArrivalTime { get; set; }

        public List<TicketDto> Tickets { get; set; }
    }
}
