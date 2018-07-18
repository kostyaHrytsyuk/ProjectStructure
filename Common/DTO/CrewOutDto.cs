using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class CrewOutDto : BaseDto
    {
        [JsonIgnore]
        public int PilotId { get; set; }
                
        public ICollection<PilotDto> Pilot { get; set; }

        public ICollection<StewardessDto> Stewardess { get; set; }
    }
}
