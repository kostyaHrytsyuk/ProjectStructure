using System.Collections.Generic;

namespace DAL.Models
{
    class Crew : Entity
    {
        public Pilot Pilot { get; set; }

        public List<Stewardess> Stewardesses { get; set; }
    }
}
