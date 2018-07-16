using System.Collections.Generic;

namespace DAL.Models
{
    public class Crew : Entity
    {
        public virtual Pilot Pilot { get; set; }

        public virtual List<Stewardess> Stewardesses { get; set; }
    }
}
