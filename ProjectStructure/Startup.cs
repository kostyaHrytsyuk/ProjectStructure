using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DAL.Models;
using Common.DTO;

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
            services.AddMvc();

            services.AddOptions();

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

            app.UseMvc();
        }

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlaneType, PlaneTypeDto>();

                cfg.CreateMap<Plane, PlaneDto>();
                cfg.CreateMap<Stewardess, StewardessDto>();
                cfg.CreateMap<Pilot, PilotDto>();
                cfg.CreateMap<Crew, CrewDto>();
                cfg.CreateMap<Ticket, TicketDto>();
                cfg.CreateMap<Fligth, FligthDto>();
                cfg.CreateMap<Departure, DepartureDto>();
            });

            return config;
        }
    }
}
