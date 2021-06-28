using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Business.Interfaces;
using Business.Services;

namespace MebliWEBApi
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

            /*services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MebliWEBApi", Version = "v1" });
            });*/
            services.AddScoped<IMebliRepository, MebliRepository>();
            services.AddScoped<IOpisRepository, OpisRepository>();
            services.AddScoped<IPocupciRepository, PocupciRepository>();
            services.AddScoped<IZamovlennyaRepository, ZamovlennyaRepository>();
            services.AddScoped<IProdavciRepository, ProdavciRepository>();
            services.AddScoped<IRobitnikiRepository, RobitnikiRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMebliService, MebliService>();
            services.AddScoped<IPocupciService, PocupciService>();
            services.AddScoped<IOpisService, OpisService>();
            services.AddScoped<IZamovlennyaService, ZamovlennyaService>();
            services.AddScoped<IProdavciService, ProdavciService>();
            services.AddScoped<IRobitnikiService, RobitnikiService>();
            services.AddDbContext<ContextDB>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MebliWEBApi v1"));
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
