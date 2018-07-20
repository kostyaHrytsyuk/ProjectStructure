using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Planes")]
    public class Plane : Entity
    {
        public Plane(DateTime releaseDate)
        {
            ReleaseDate = releaseDate;
            Lifetime = ReleaseDate.AddYears(10) - ReleaseDate;
        }

        [Column("Name")]
        public string Name { get; set; }

        [Column("ReleaseDate", TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public TimeSpan Lifetime { get; set; }

        [Column("LifeTimeTicks")]
        public long LifeTimeTicks
        {
            get { return Lifetime.Ticks; }
            set { Lifetime = TimeSpan.FromTicks(value); }
        }

        [Column("PlaneTypeId")]
        public int PlaneTypeId { get; set; }

        public PlaneType PlaneType { get; set; }

        public Departure Departure { get; set; }
    }
}
