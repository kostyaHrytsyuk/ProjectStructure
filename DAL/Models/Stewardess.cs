using System;

namespace DAL.Models
{
    class Stewardess : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
