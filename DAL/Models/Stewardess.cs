using System;

namespace DAL.Models
{
    public class Stewardess : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int? CrewId { get; set;}

        public Crew Crew { get; set; }
    }
}
