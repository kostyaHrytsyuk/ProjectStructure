using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Pilots")]
    public class Pilot : Entity
    {
        [Column("FirstName"), StringLength(20), Required]
        public string FirstName { get; set; }

        [Column("LastName"), StringLength(20), Required]
        public string LastName { get; set; }

        [Column("BirthDate", TypeName = "date"), Required]
        public DateTime BirthDate { get; set; }
        [Column("Experience"), Required]
        public int Exp { get; set; }

        public Crew Crew { get; set; }
    }
}
