using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Crews")]
    public class Crew : Entity
    {
        [Column("PilotId")]
        public int PilotId { get; set; }

        public Pilot Pilot { get; set; }

        public ICollection<Stewardess> Stewardess { get; set; }

        public Departure Departure { get; set; }
    }
}
