using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("PlaneTypes")]
    public class PlaneType : Entity
    {
        [Column("PlaneModel"), StringLength(25), Required]
        public string PlaneModel { get; set; }

        [Column("SeatsNumber"),Range(1,1000),Required]
        public int SeatsNumber { get; set; }

        [Column("Carrying"),Range(100,200000), Required]
        public int Carrying { get; set; }

        public ICollection<Plane> Planes { get; set; }
    }
}
