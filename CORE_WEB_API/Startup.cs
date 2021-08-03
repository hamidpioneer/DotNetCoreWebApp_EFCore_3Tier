using BLL.Services.Implementations;
using BLL.Services.Implementations.Authentication;
using BLL.Services.Interfaces;
using BLL.Services.Interfaces.Authentication;
using CORE_WEB_API.AppConfiguration;
using DAL.DatabaseContext;
using DAL.DatabaseContext.Authentication;
using DAL.Models;
using DAL.Models.Authentication;
using DAL.Repositories;
using DAL.Repositories.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            #region AppConfigurations
            var jwtConfigSection = Configuration.GetSection("JwtConfig");
            services.Configure<JwtConfig>(jwtConfigSection);
            var jwtConfigObj = jwtConfigSection.Get<JwtConfig>();
            #endregion

            #region DbContext DI
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultSqlServer")));
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultSqlServer")));
            #endregion

            #region Repository DI
            services.AddScoped<ISampleRepo, SampleRepo>();
            services.AddScoped<IGenericRepo<Sample>, GenericRepo<Sample>>();
            services.AddScoped<IGenericRepo<Applicant>, GenericRepo<Applicant>>();
            services.AddScoped<IApplicationRepo, ApplicationRepo>();
            services.AddScoped<IAuthRepo, AuthRepo>();
            #endregion

            #region BLL Services DI
            services.AddScoped<Sample_Service, Sample_Service>();
            services.AddScoped<ICrudService, CrudService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IAuthService, AuthService>();
            #endregion


            services.AddIdentity<AuthUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwtOptions =>
                {
                    var key = Encoding.ASCII.GetBytes(jwtConfigObj.Secret);

                    jwtOptions.SaveToken = true;
                    jwtOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfigObj.ValidIssuer,
                        ValidateAudience = true,
                        ValidAudience = jwtConfigObj.ValidAudience,
                        ValidateLifetime = true,                        
                        RequireExpirationTime = false
                    };

                });

            
            
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
