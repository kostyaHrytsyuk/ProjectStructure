using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Stewardesses")]
    public class Stewardess : Entity
    {
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("BirthDate",TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Column("CrewId")]
        public int? CrewId { get; set;}

        public Crew Crew { get; set; }
    }
}
