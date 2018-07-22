using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Common.DTO
{
    public class FlightDto : BaseDto
    {
        public string FlightNumber { get; set; }

        public string DepartureAirport { get; set; }

        [JsonConverter(typeof(CustomJsonDateTimeConverter))]
        public DateTime DepartureTime { get; set; }

        public string DestinationAirport { get; set; }

        [JsonConverter(typeof(CustomJsonDateTimeConverter))]
        public DateTime ArrivalTime { get; set; }

        public ICollection<TicketDto> Tickets { get; set; }
    }
}
