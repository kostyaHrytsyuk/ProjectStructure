﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProjectStructure.Migrations
{
    [DbContext(typeof(AirportContext))]
    partial class AirportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PilotId");

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("DAL.Models.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CrewId");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("FlightNumber");

                    b.Property<int?>("PlaneId");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("DAL.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<string>("DepartureAirport");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<string>("DestinationAirport");

                    b.Property<string>("FlightNumber");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("DAL.Models.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("Experience");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("DAL.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Lifetime");

                    b.Property<string>("Name");

                    b.Property<int?>("PlaneTypeId");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("Id");

                    b.HasIndex("PlaneTypeId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("DAL.Models.PlaneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Carrying");

                    b.Property<string>("PlaneModel");

                    b.Property<int>("SeatsNumber");

                    b.HasKey("Id");

                    b.ToTable("PlaneTypes");
                });

            modelBuilder.Entity("DAL.Models.Stewardess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CrewId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("Stewardesses");
                });

            modelBuilder.Entity("DAL.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightId");

                    b.Property<string>("FlightNumber");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DAL.Models.Crew", b =>
                {
                    b.HasOne("DAL.Models.Pilot", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId");
                });

            modelBuilder.Entity("DAL.Models.Departure", b =>
                {
                    b.HasOne("DAL.Models.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId");

                    b.HasOne("DAL.Models.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId");
                });

            modelBuilder.Entity("DAL.Models.Plane", b =>
                {
                    b.HasOne("DAL.Models.PlaneType", "PlaneType")
                        .WithMany()
                        .HasForeignKey("PlaneTypeId");
                });

            modelBuilder.Entity("DAL.Models.Stewardess", b =>
                {
                    b.HasOne("DAL.Models.Crew")
                        .WithMany("Stewardesses")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("DAL.Models.Ticket", b =>
                {
                    b.HasOne("DAL.Models.Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId");
                });
#pragma warning restore 612, 618
        }
    }
}
