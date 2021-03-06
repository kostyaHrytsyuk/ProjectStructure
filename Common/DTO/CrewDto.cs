﻿using System.Collections.Generic;

namespace Common.DTO
{
    public class CrewDto : BaseDto
    {
        
        public int PilotId { get; set; }
                
        public List<PilotDto> Pilot { get; set; }

        public ICollection<StewardessDto> Stewardess { get; set; }
    }
}
