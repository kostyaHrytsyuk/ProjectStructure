using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class CrewDto : BaseDto
    {
        
        public int PilotId { get; set; }
                
        public PilotDto Pilot { get; set; }

        public ICollection<StewardessDto> Stewardesses { get; set; }
    }
}
