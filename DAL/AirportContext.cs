﻿using System;
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}

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
