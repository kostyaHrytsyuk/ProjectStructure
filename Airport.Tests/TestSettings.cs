using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace Airport.Tests
{
    [SetUpFixture]
    internal sealed class TestSettings
    {
        private static AirportContext context;
        internal static AirportContext Context { get { return context; } }

        [OneTimeSetUp]
        public void Init()
        {
            var serviceProvider = new ServiceCollection()
                                  .AddDbContext<AirportContext>(opt => opt.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=NewAirport;Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                                  .AddEntityFrameworkSqlServer()
                                  .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AirportContext>();
            
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=NewAirport;Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                   .UseInternalServiceProvider(serviceProvider);

            context = new AirportContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Database.Migrate();
            Seed();
        }

        private void Seed()
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
                    new Plane(new DateTime(2011, 6, 15)) { Name = "Boeing", PlaneType = context.PlaneTypes.Find(1) },
                    new Plane(new DateTime(2018, 2, 6)) { Name = "Heavy", PlaneType = context.PlaneTypes.Find(4) }
                );
                context.SaveChanges();
            }

            if (!context.SetOf<Stewardess>().Any())
            {
                context.SetOf<Stewardess>().AddRange
                (
                    new Stewardess() { FirstName = "Katy", LastName = "Smith", BirthDate = new DateTime(1983, 10, 5) },
                    new Stewardess() { FirstName = "Carol", LastName = "Hoover", BirthDate = new DateTime(1991, 4, 11) },
                    new Stewardess() { FirstName = "Ada", LastName = "Lovelace", BirthDate = new DateTime(1976, 7, 13) },
                    new Stewardess() { FirstName = "Beverly", LastName = "Marsh", BirthDate = new DateTime(2002, 2, 13) }
                );
                context.SaveChanges();
            }

            if (!context.SetOf<Pilot>().Any())
            {
                context.SetOf<Pilot>().AddRange
                (
                    new Pilot() { FirstName = "Jimmy", LastName = "Doolittle", BirthDate = new DateTime(1973, 9, 16), Experience = 12 },
                    new Pilot() { FirstName = "Noel", LastName = "Wien", BirthDate = new DateTime(1982, 8, 20), Experience = 9 },
                    new Pilot() { FirstName = "Robert", LastName = "Hoover", BirthDate = new DateTime(1980, 3, 13), Experience = 15 }
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
                    new Flight() { FlightNumber = "7W7017", DepartureAirport = "LWO", DepartureTime = new DateTime(2018, 7, 13, 22, 15, 0), DestinationAirport = "FCO", ArrivalTime = new DateTime(2018, 7, 13, 23, 45, 0) },
                    new Flight() { FlightNumber = "KP5311", DepartureAirport = "KBP", DepartureTime = new DateTime(2018, 7, 15, 14, 30, 0), DestinationAirport = "EIN", ArrivalTime = new DateTime(2018, 7, 15, 17, 45, 0) },
                    new Flight() { FlightNumber = "AZ4297", DepartureAirport = "ODS", DepartureTime = new DateTime(2018, 9, 15, 19, 45, 0), DestinationAirport = "LIS", ArrivalTime = new DateTime(2018, 9, 15, 22, 30, 0) }
                );
                context.SaveChanges();
            }

            if (!context.SetOf<Ticket>().Any())
            {
                context.SetOf<Ticket>().AddRange
                (
                    new Ticket() { Flight = context.Flights.Find(2), FlightNumber = context.Flights.Find(2).FlightNumber, Price = 250 },
                    new Ticket() { Flight = context.Flights.Find(1), FlightNumber = context.Flights.Find(1).FlightNumber, Price = 240 },
                    new Ticket() { Flight = context.Flights.Find(2), FlightNumber = context.Flights.Find(2).FlightNumber, Price = 300 },
                    new Ticket() { Flight = context.Flights.Find(1), FlightNumber = context.Flights.Find(1).FlightNumber, Price = 270 },
                    new Ticket() { Flight = context.Flights.Find(3), FlightNumber = context.Flights.Find(3).FlightNumber, Price = 280 }
                );
                context.SaveChanges();
            }

            if (!context.SetOf<Departure>().Any())
            {
                context.SetOf<Departure>().AddRange
                (
                    new Departure() { FlightNumber = "7W7017", Flight = context.Flights.Find(1), DepartureDate = new DateTime(2018, 7, 13, 22, 15, 0), Crew = context.Crews.Find(1), Plane = context.Planes.Find(2) },
                    new Departure() { FlightNumber = "AZ4297", Flight = context.Flights.Find(3), DepartureDate = new DateTime(2018, 9, 15, 19, 45, 0), Crew = context.Crews.Find(3), Plane = context.Planes.Find(1) }
                );
                context.SaveChanges();
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }
    }
}
