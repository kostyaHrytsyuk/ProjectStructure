using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Stewardess : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CrewId { get; set;}

        public Crew Crew { get; set; }
    }
}
