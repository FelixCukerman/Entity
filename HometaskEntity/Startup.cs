using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HometaskEntity.BLL.Contracts;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.BLL.Service;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HometaskEntity
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
            services.AddAutoMapper();
            services.AddSingleton<IService<AviatorDTO>, AviatorService>();
            services.AddSingleton<IService<CrewDTO>, CrewService>();
            services.AddSingleton<IService<DepartureDTO>, DepartureService>();
            services.AddSingleton<IService<FlightDTO>, FlightService>();
            services.AddSingleton<IService<PlaneDTO>, PlaneService>();
            services.AddSingleton<IService<StewardessDTO>, StewardessService>();
            services.AddSingleton<IService<TicketDTO>, TicketService>();
            services.AddSingleton<IService<TypePlaneDTO>, TypePlaneService>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=AirportDB;Trusted_Connection=True;";
            services.AddDbContext<AirportContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("HometaskEntity")));
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
    }
}
