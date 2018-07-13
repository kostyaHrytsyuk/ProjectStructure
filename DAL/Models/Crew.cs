using System.Collections.Generic;

namespace DAL.Models
{
    public class Crew : Entity
    {
        public int PilotId { get; set; }

        public List<int> Stewardesses { get; set; }
    }
}
