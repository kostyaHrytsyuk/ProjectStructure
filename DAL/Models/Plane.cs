using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Plane : Entity
    {
        public Plane(DateTime releaseDate)
        {
            ReleaseDate = releaseDate;
            Lifetime = ReleaseDate.AddYears(10) - ReleaseDate;
        }

        public string Name { get; set; }

        public int PlaneTypeId { get; set; }

        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public TimeSpan Lifetime { get; set; }
        
        public long LifeTimeTicks
        {
            get { return Lifetime.Ticks; }
            set { Lifetime = TimeSpan.FromTicks(value); }
        }

        public PlaneType PlaneType { get; set; }
    }
}
