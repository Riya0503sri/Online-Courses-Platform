using APIImplementation.Repositories.Interfaces;
using APIImplementation.Repositories;
using APIImplementation.Services.Interfaces;
using APIImplementation.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APIImplementation
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
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));
            services.AddSingleton<ICourseService, CourseService>();
            services.AddSingleton<IScheduleService, ScheduleService>();
            services.AddSingleton<ITeacherService, TeacherService>();
            services.AddSingleton<ICourseRepository, CourseRepository>();
            services.AddSingleton<IScheduleRepository, ScheduleRepository>();
            services.AddSingleton<ITeacherRepository, TeacherRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
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
