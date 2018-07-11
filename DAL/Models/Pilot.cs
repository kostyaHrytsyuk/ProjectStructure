using System;

namespace DAL.Models
{
    class Pilot : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Experience { get; set; }
    }
}
