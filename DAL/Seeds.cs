using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public static class Seeds
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AirportContext(serviceProvider.GetRequiredService<DbContextOptions<AirportContext>>()))
            {
                if (!context.SetOf<PlaneType>().Any())
                {
                    context.SetOf<PlaneType>().AddRange
                    (
                        new PlaneType() { PlaneModel = "Civil", SeatsNumber = 200, Carrying = 10000 },
                        new PlaneType() { PlaneModel = "Cargo", SeatsNumber = 10, Carrying = 50000 },
                        new PlaneType() { PlaneModel = "Military", SeatsNumber = 40, Carrying = 3000 },
                        new PlaneType() { PlaneModel = "Falcon", SeatsNumber = 100, Carrying = 9 }
                    );
                    context.SaveChanges();
                }

                if (!context.SetOf<Plane>().Any())
                {
                    context.SetOf<Plane>().AddRange
                    (
                        new Plane(new DateTime(1995, 11, 4)) { Name = "Dream", PlaneType = context.PlaneTypes.Find(2) },
                        new Plane(new DateTime(2011, 6, 15)) { Name = "Boeing", PlaneType = context.PlaneTypes.Find(1)},
                        new Plane(new DateTime(2018, 2, 6)) { Name = "Heavy", PlaneType = context.PlaneTypes.Find(4) }
                        //new Plane() { Name = "Dream", PlaneTypeId = 2, ReleaseDate = new DateTime(1995, 11, 4) },
                        //new Plane() { Name = "Boeing", PlaneTypeId = 1, ReleaseDate = new DateTime(2011, 6, 15) },
                        //new Plane() { Name = "Heavy", PlaneTypeId = 4, ReleaseDate = new DateTime(2018, 2, 6) }
                    );
                    context.SaveChanges();
                }

                if (!context.SetOf<Stewardess>().Any())
                {
                    context.SetOf<Stewardess>().AddRange
                    (
                        new Stewardess() { Name = "Katy", Surname = "Smith", DateOfBirth = new DateTime(1983, 10, 5) },
                        new Stewardess() { Name = "Carol", Surname = "Hoover", DateOfBirth = new DateTime(1991, 4, 11) },
                        new Stewardess() { Name = "Ada", Surname = "Lovelace", DateOfBirth = new DateTime(1976, 7, 13) },
                        new Stewardess() { Name = "Beverly", Surname = "Marsh", DateOfBirth = new DateTime(2002, 2, 13) }
                    );
                    context.SaveChanges();
                }

                if (!context.SetOf<Pilot>().Any())
                {
                    context.SetOf<Pilot>().AddRange
                    (
                        new Pilot() { Name = "Jimmy", Surname = "Doolittle", DateOfBirth = new DateTime(1973, 9, 16), Experience = 12 },
                        new Pilot() { Name = "Noel", Surname = "Wien", DateOfBirth = new DateTime(1982, 8, 20), Experience = 9 },
                        new Pilot() { Name = "Robert", Surname = "Hoover", DateOfBirth = new DateTime(1980, 3, 13), Experience = 15 }
                    );
                    context.SaveChanges();
                }

                if (!context.SetOf<Crew>().Any())
                {
                    context.SetOf<Crew>().AddRange
                    (
                        new Crew() { Pilot = context.Pilots.Find(2), Stewardesses = new List<Stewardess>() { context.Stewardesses.Find(2), context.Stewardesses.Find(4) } },
                        new Crew() { Pilot = context.Pilots.Find(3), Stewardesses = new List<Stewardess>() { context.Stewardesses.Find(3) } },
                        new Crew() { Pilot = context.Pilots.Find(1), Stewardesses = new List<Stewardess>() { context.Stewardesses.Find(1) } }
                    );
                    context.SaveChanges();
                }

                if (!context.SetOf<Flight>().Any())
                {
                    context.SetOf<Flight>().AddRange
                    (
                        new Flight() {FlightNumber = "7W7017", DepartureAirport = "LWO", DepartureTime = new DateTime(2018, 7, 13, 22, 15, 0), DestinationAirport = "FCO", ArrivalTime = new DateTime(2018, 7, 13, 23, 45, 0) },
                        new Flight() {FlightNumber = "KP5311", DepartureAirport = "KBP", DepartureTime = new DateTime(2018, 7, 15, 14, 30, 0), DestinationAirport = "EIN", ArrivalTime = new DateTime(2018, 7, 15, 17, 45, 0) },
                        new Flight() {FlightNumber = "AZ4297", DepartureAirport = "ODS", DepartureTime = new DateTime(2018, 9, 15, 19, 45, 0), DestinationAirport = "LIS", ArrivalTime = new DateTime(2018, 9, 15, 22, 30, 0) }
                    );
                    context.SaveChanges();
                }

                if (!context.SetOf<Ticket>().Any())
                {                    
                    context.SetOf<Ticket>().AddRange
                    (
                        new Ticket() { Flight = context.Flights.Find(2), FlightNumber = context.Flights.Find(2).FlightNumber, Price = 250 },
                        new Ticket() { Flight = context.Flights.Find(1), FlightNumber = context.Flights.Find(1).FlightNumber, Price = 240 },
                        new Ticket() { Flight = context.Flights.Find(2), FlightNumber = context.Flights.Find(2).FlightNumber , Price = 300 },
                        new Ticket() { Flight = context.Flights.Find(1), FlightNumber = context.Flights.Find(1).FlightNumber , Price = 270 },
                        new Ticket() { Flight = context.Flights.Find(3), FlightNumber = context.Flights.Find(3).FlightNumber , Price = 280 }
                    );
                    context.SaveChanges();
                }

                if (!context.SetOf<Departure>().Any())
                {
                    context.SetOf<Departure>().AddRange
                    (
                        new Departure() { FlightNumber = "7W7017", DepartureDate = new DateTime(2018, 7, 13, 22, 15, 0), Crew = context.Crews.Find(1), Plane = context.Planes.Find(2) },
                        new Departure() { FlightNumber = "AZ4297", DepartureDate = new DateTime(2018, 9, 15, 19, 45, 0), Crew = context.Crews.Find(3), Plane = context.Planes.Find(1) }
                    );
                    context.SaveChanges();
                }

                //if (!context.SetOf<>().Any())
                //{
                //    context.SetOf<>().AddRange
                //    (

                //        );
                //    context.SaveChanges();
                //}

            }
        }
    }
}
