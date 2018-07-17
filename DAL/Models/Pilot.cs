using System;

namespace DAL.Models
{
    public class Pilot : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Experience { get; set; }

        public Crew Crew { get; set; }
    }
}
