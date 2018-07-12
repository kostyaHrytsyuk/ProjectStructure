using System;

namespace Common.DTO
{
    public class DepartureDto
    {
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }

        public CrewDto Crew { get; set; }

        public PlaneDto Plane { get; set; }
    }
}
