﻿using System;

namespace DAL.Models
{
    public class Stewardess : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
