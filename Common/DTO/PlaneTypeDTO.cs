using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class PlaneTypeDto : BaseDto
    {
        public string PlaneModel { get; set; }

        public int SeatsNumber { get; set; }

        public int Carrying { get; set; }
    }
}
