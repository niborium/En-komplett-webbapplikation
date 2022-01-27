using AutoMapper;
using En_komplett_webbapplikation.Domain.Repositories;
using En_komplett_webbapplikation.Domain.Services;
using En_komplett_webbapplikation.Persistence.Contexts;
using En_komplett_webbapplikation.Persistence.Repositories;
using En_komplett_webbapplikation.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace En_komplett_webbapplikation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(opt =>
                                   opt.UseInMemoryDatabase("Niborium"));

            services.AddScoped<IRoverRepository, RoverRepository>();
            services.AddScoped<IRoverService, RoverService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
