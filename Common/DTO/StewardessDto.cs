using System;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class StewardessDto : BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [JsonConverter(typeof(CustomJsonDateConverter))]
        public DateTime DateOfBirth { get; set; }

        public int? CrewId { get; set;}
        [JsonIgnore]
        public CrewDto Crew { get; set; }
    }
}
