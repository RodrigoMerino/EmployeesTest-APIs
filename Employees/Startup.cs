using AutoMapper;
using Core.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Newtonsoft.Json;

namespace Employees
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IAreaService, AreaService>();
            services.AddTransient<IAreaRepository, AreaRepository>();

            services.AddTransient<ISubareaService, SubareaService>();
            services.AddTransient<ISubareaRepository, SubareaRepository>();
            //comment: connection db
            services.AddDbContext<EmployeesDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TestConnection")));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            });
            services.AddMvc(option => option.EnableEndpointRouting = false)
       .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
       .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsPolicy");

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
