using System;
using Newtonsoft.Json;

namespace Common.DTO
{
    public class PlaneDto : BaseDto
    {
        public string Name { get; set; }

        public int PlaneTypeId { get; set; }
                
        public PlaneTypeDto PlaneType { get; set; }

        [JsonConverter(typeof(CustomJsonDateConverter))]
        public DateTime ReleaseDate { get; set; }

        public TimeSpan Lifetime { get; set; }
    }
}
