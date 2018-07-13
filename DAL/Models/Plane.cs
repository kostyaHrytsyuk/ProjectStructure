using System;

namespace DAL.Models
{
    public class Plane : Entity
    {
        public Plane(int id,string name, PlaneType type, DateTime releaseDate)
        {
            Id = id;
            Name = name;
            Type = type;
            ReleaseDate = releaseDate;
            Lifetime = ReleaseDate.AddYears(10) - ReleaseDate;
        }

        public string Name { get; set; }

        public PlaneType Type { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan Lifetime { get; set; }
    }
}
