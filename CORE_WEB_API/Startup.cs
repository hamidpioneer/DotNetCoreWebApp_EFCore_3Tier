using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL.DatabaseContext;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_WEB_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region DbContext DI
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultSqlServer")));
            #endregion

            #region Repository DI
            services.AddScoped<ISampleRepo, SampleRepo>();
            services.AddScoped<IGenericRepo<Sample>, GenericRepo<Sample>>();
            services.AddScoped<IGenericRepo<Applicant>, GenericRepo<Applicant>>();
            services.AddScoped<IApplicationRepo, ApplicationRepo>();
            #endregion

            #region BLL Services DI
            services.AddScoped<Sample_Service, Sample_Service>();
            services.AddScoped<ICrudService, CrudService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IApplicationService, ApplicationService>();

            #endregion

            services.AddControllers()
                .AddNewtonsoftJson(action => action.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CORE_WEB_API", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CORE_WEB_API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
