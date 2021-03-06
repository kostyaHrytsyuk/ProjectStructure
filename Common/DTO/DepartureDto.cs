﻿using System;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class DepartureDto : BaseDto
    {
        public string FlightNumber { get; set; }
        
        public int FlightId { get; set; }
        public FlightDto Flight { get; set; }

        [JsonConverter(typeof(CustomJsonDateTimeConverter))]
        public DateTime DepartureDate { get; set; }

        public int CrewId { get; set; }
        public CrewDto Crew { get; set; }

        public int PlaneId { get; set; }
        public PlaneDto Plane { get; set; }
    }
}
