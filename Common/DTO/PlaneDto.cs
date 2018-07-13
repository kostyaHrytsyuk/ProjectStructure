using System;

namespace Common.DTO
{
    public class PlaneDto : BaseDto
    {
        public PlaneDto(int id,string name, int typeId, DateTime releaseDate, TimeSpan lifetime)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
            ReleaseDate = releaseDate;
            Lifetime = ReleaseDate.AddYears(10) - ReleaseDate;
        }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan Lifetime { get; set; }
    }
}
