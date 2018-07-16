using System;

namespace DAL.Models
{
    public class Plane : Entity
    {
        public string Name { get; set; }

        public virtual PlaneType PlaneType { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan Lifetime { get; set; }
    }
}
