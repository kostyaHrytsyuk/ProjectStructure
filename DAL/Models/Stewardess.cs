using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    [Table("Stewardesses")]
    public class Stewardess : Entity
    {
        [Column("FirstName"), StringLength(20),Required]        
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string FirstName { get; set; }

        [Column("LastName"), StringLength(20),Required]
        public string LastName { get; set; }

        [Column("BirthDate",TypeName = "date"),Required]
        public DateTime BirthDate { get; set; }

        [Column("CrewId")]
        public int? CrewId { get; set;}

        public Crew Crew { get; set; }
    }
}
