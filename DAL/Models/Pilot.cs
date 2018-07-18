using System;

namespace DAL.Models
{
    public class Pilot : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Exp { get; set; }

        public Crew Crew { get; set; }
    }
}
