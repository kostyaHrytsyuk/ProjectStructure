using System;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class PilotDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Exp { get; set; }

        public int CrewId { get; set; }

        [JsonIgnore]
        public CrewDto Crew { get; set; }
    }
}
