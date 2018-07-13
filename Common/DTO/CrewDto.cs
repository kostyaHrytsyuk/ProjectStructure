using System.Collections.Generic;

namespace Common.DTO
{
    public class CrewDto : BaseDto
    {
        public int PilotId { get; set; }

        public List<int> Stewardesses { get; set; }
    }
}
