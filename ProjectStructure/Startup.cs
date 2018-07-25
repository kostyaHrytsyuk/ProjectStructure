using AutoMapper;
using BusinessLogic.Services;
using Common.DTO;
using Common.Validation;
using DAL.Models;
using DAL.UnitOfWork;
using DAL;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ProjectStructure
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
                {
                    opt.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
                }
            );

            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .AddFluentValidation
            (
                fvc => fvc.RegisterValidatorsFromAssemblyContaining<EntityValidator>()
            );
            
            services.AddOptions();
                        
            services.AddDbContext<AirportContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),b => b.MigrationsAssembly("ProjectStructure")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPlaneTypeService, PlaneTypeService>();
            services.AddTransient<IPlaneService, PlaneService>();
            services.AddTransient<IStewardessService, StewardessService>();
            services.AddTransient<IPilotService, PilotService>();
            services.AddTransient<ICrewService, CrewService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IDepartureService, DepartureService>();
                      
            var mapper = MapperConfiguration().CreateMapper();
            services.AddScoped(_ => mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowCredentials().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlaneType, PlaneTypeDto>();
                cfg.CreateMap<PlaneTypeDto, PlaneType>();

                cfg.CreateMap<Plane, PlaneDto>();
                cfg.CreateMap<PlaneDto, Plane>();

                cfg.CreateMap<Stewardess, StewardessDto>();
                cfg.CreateMap<StewardessDto, Stewardess>();

                cfg.CreateMap<Pilot, PilotDto>();
                cfg.CreateMap<PilotDto, Pilot>();

                //cfg.CreateMap<Crew, CrewDto>();
                //cfg.CreateMap<CrewDto, Crew>();
                
                
                cfg.CreateMap<Crew, CrewDto>().
                ForMember(cd => cd.Pilot, opt => opt.MapFrom(c => new List<Pilot>() { c.Pilot}  ));

                cfg.CreateMap<CrewDto, Crew>().
                ForMember(c => c.Pilot, opt => opt.MapFrom(cd => cd.Pilot.FirstOrDefault()));

                cfg.CreateMap<Ticket, TicketDto>();
                cfg.CreateMap<TicketDto, Ticket>();

                cfg.CreateMap<Flight, FlightDto>();
                cfg.CreateMap<FlightDto, Flight>();

                cfg.CreateMap<Departure, DepartureDto>();
                cfg.CreateMap<DepartureDto, Departure>();
            });

            return config;
        }
    }
}
