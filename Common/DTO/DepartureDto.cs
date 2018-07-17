using System;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class DepartureDto : BaseDto
    {
        public string FlightNumber { get; set; }

        [JsonIgnore]
        public int FlightId { get; set; }
        public FlightDto Flight { get; set; }

        public DateTime DepartureDate { get; set; }

        [JsonIgnore]
        public int CrewId { get; set; }
        public CrewDto Crew { get; set; }

        [JsonIgnore]
        public int PlaneId { get; set; }
        public PlaneDto Plane { get; set; }
    }
}
