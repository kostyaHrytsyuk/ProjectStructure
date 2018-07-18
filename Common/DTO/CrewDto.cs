using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class CrewDto : BaseDto
    {
        [JsonIgnore]
        public int PilotId { get; set; }
                
        public List<PilotDto> Pilot { get; set; }

        public ICollection<StewardessDto> Stewardess { get; set; }
    }
}
