using System;


namespace Common.DTO
{
    public class PlaneDto : BaseDto
    {
        public string Name { get; set; }

        public PlaneTypeDto Type { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan Lifetime { get; set; }
    }
}
