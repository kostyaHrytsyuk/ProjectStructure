using System.Collections.Generic;

namespace DAL.Models
{
    public class Crew : Entity
    {
        public Pilot Pilot { get; set; }

        public List<Stewardess> Stewardesses { get; set; }
    }
}
