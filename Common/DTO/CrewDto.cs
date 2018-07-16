using System.Collections.Generic;

namespace Common.DTO
{
    public class CrewDto : BaseDto
    {
        public PilotDto Pilot { get; set; }

        public List<StewardessDto> Stewardesses { get; set; }
    }
}
