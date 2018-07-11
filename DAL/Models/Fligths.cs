﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    class Fligths : Entity
    {
        public string FlightNumber { get; set; }

        public string DepartureAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public string DestinationAirport { get; set; }

        public DateTime ArrivalTime { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}