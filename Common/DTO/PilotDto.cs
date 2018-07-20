using System;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class PilotDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonConverter(typeof(CustomJsonDateConverter))]
        public DateTime DateOfBirth { get; set; }

        public int Experience { get; set; }

        [JsonIgnore]
        public CrewDto Crew { get; set; }
    }
}
