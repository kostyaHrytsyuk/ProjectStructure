using System;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class PilotDto : BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Experience { get; set; }

        [JsonIgnore]
        public CrewDto Crew { get; set; }
    }
}
