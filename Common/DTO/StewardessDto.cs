using System;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class StewardessDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        
        public int? CrewId { get; set;}
        [JsonIgnore]
        public CrewDto Crew { get; set; }
    }
}
