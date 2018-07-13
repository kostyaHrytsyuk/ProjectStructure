using System;

namespace Common.DTO
{
    public class DepartureDto : BaseDto
    {
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }

        public int CrewId { get; set; }

        public int PlaneID { get; set; }
    }
}
