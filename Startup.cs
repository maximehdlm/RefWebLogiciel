using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RefWebLogiciel.Data;

namespace RefWebLogiciel
{
    public class Startup
    {

        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Instanciation des bases de donnée local ( phase de test )
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("project"));
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("task"));
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("user"));
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("task_type"));
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("specialization"));
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("project_type"));

            services.AddScoped<IProjectRepo, ProjectRepo>();
            services.AddScoped<IProjectTaskRepo, ProjectTaskRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IProjectTypeRepo, ProjectTypeRepo>();
            services.AddScoped<IProjectTaskTypeRepo, ProjectTaskTypeRepo>();
            services.AddScoped<IUserSpecializationRepo, UserSpecializationRepo>();

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RefWebLogiciel", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RefWebLogiciel v1"));
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
