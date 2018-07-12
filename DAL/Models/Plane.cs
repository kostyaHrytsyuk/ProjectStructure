using System;

namespace DAL.Models
{
    public class Plane : Entity
    {
        public string Name { get; set; }

        public PlaneType Type { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan Lifetime { get; set; }
    }
}
