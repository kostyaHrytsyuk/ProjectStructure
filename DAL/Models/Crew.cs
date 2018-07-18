using System.Collections.Generic;

namespace DAL.Models
{
    public class Crew : Entity
    {
        public int PilotId { get; set; }

        public Pilot Pilot { get; set; }

        public ICollection<Stewardess> Stewardess { get; set; }

        public Departure Departure { get; set; }
    }
}
