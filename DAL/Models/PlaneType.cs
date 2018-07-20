using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("PlaneTypes")]
    public class PlaneType : Entity
    {
        [Column("PlaneModel")]
        public string PlaneModel { get; set; }

        [Column("SeatsNumber")]
        public int SeatsNumber { get; set; }

        [Column("Carrying")]
        public int Carrying { get; set; }

        public ICollection<Plane> Planes { get; set; }
    }
}
