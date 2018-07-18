using System;
using System.Linq;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AirportContext : DbContext
    {
        public DbSet<Departure> Departures { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Crew> Crews { get; set; }

        public DbSet<Pilot> Pilots { get; set; }

        public DbSet<Stewardess> Stewardesses { get; set; }

        public DbSet<Plane> Planes { get; set; }

        public DbSet<PlaneType> PlaneTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaneType>().ToTable("PlaneTypes");

            modelBuilder.Entity<Plane>().HasOne<PlaneType>(p => p.PlaneType)
                .WithMany(pt => pt.Planes)
                .HasForeignKey(p => p.PlaneTypeId);
            modelBuilder.Entity<Plane>().HasOne<Departure>(p => p.Departure)
                .WithOne(d => d.Plane)
                .HasForeignKey<Departure>(d => d.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("Planes");
            


            modelBuilder.Entity<Pilot>().HasOne<Crew>(p => p.Crew)
                .WithOne(c => c.Pilot)
                .HasForeignKey<Crew>(c => c.PilotId);
            modelBuilder.Entity<Pilot>().ToTable("Pilots");

            modelBuilder.Entity<Stewardess>().ToTable("Stewardesses");
            modelBuilder.Entity<Stewardess>().HasOne(s => s.Crew)
                .WithMany(c => c.Stewardess)
                .HasForeignKey(s => s.CrewId);

            modelBuilder.Entity<Crew>().HasOne<Departure>(c => c.Departure)
                .WithOne(d => d.Crew)
                .HasForeignKey<Departure>(d => d.CrewId);
            modelBuilder.Entity<Crew>().ToTable("Crews");

            modelBuilder.Entity<Ticket>().HasOne<Flight>(t => t.Flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightId);
            modelBuilder.Entity<Ticket>().ToTable("Tickets");

            modelBuilder.Entity<Flight>().HasOne<Departure>(f => f.Departure)
                .WithOne(d => d.Flight)
                .HasForeignKey<Departure>(d => d.FlightId);
            modelBuilder.Entity<Flight>().ToTable("Flights");

            modelBuilder.Entity<Departure>().ToTable("Departures");
        }

        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        {
            Data = new Dictionary<Type, IEnumerable<Entity>>
            {
                { typeof(PlaneType), PlaneTypes },
                { typeof(Plane), Planes },
                { typeof(Stewardess), Stewardesses },
                { typeof(Pilot), Pilots },
                { typeof(Crew), Crews},
                { typeof(Ticket), Tickets },
                { typeof(Flight), Flights },
                { typeof(Departure), Departures }
            };

        }

        private Dictionary<Type, IEnumerable<Entity>> Data;

        public DbSet<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            var res = Data[typeof(TEntity)] as DbSet<TEntity>;
            return res;
        }
    }
}
