using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Pilots")]
    public class Pilot : Entity
    {
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("BirthDate", TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public int Experience { get; set; }

        public Crew Crew { get; set; }
    }
}
