using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sts_daos;
using sts_i_daos;
using sts_i_services;
using sts_services;

namespace sts_web_api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //Managing Dependency injection
            services.AddScoped<ID_Category, D_Category>();
            services.AddScoped<ITournamentConfService, TournamentConfService>();
            services.AddScoped<ID_Pool, D_Pool>();
            services.AddScoped<ID_Team, D_Team>();
            services.AddScoped<ID_Field, D_Field>();
            services.AddScoped<ID_Player, D_Player>();

            //Managing mappers
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("STSConnection"))
                );
            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
