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
using Superjack.MultiSites.Api.DataAccess;
using Superjack.MultiSites.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Superjack.MultiSites.Api.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;

namespace Superjack.MultiSites.Api
{
  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    //readonly string SuperjackPolicy = "SuperjackPolicy";

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      
      services.AddControllers();
      services.AddDbContext<AppDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MyNewDatabase")));
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Superjack.MultiSites.Api", Version = "v1" });
      });

      services.AddCors();

    

      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new AutoMapperProfile());
      });

      var mapper = mappingConfig.CreateMapper();
      services.AddSingleton(mapper);



      services.Configure<Encryption>(Configuration.GetSection("Encryption"));
      services.AddOptions();

      // configure strongly typed settings objects
      var appSettingsSection = Configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      // configure jwt authentication
      var appSettings = appSettingsSection.Get<AppSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
           .AddJwtBearer(x =>
           {
             x.Events = new JwtBearerEvents
             {
               OnTokenValidated = context =>
               {
                 var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                 var userId = int.Parse(context.Principal.Identity.Name);
                 var user = userService.GetById(userId);
                 if (user == null)
                 {
                    // return unauthorized if user no longer exists
                    context.Fail("Unauthorized");
                 }
                 return Task.CompletedTask;
               }
             };
             x.RequireHttpsMetadata = false;
             x.SaveToken = true;
             x.TokenValidationParameters = new TokenValidationParameters
             {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(key),
               ValidateIssuer = false,
               ValidateAudience = false
             };
           });


      services.AddScoped<IBlockService, BlockService>();
      services.AddScoped<IBlockFieldService, BlockFieldService>();
      services.AddScoped<IPageBlockService, PageBlockService>();
      services.AddScoped<IPageFieldService, PageFieldService>();
      services.AddScoped<IPageService, PageService>();
      services.AddScoped<IPageTypeService, PageTypeService>();
      services.AddScoped<ISiteService, SiteService>();
      services.AddScoped<IUserService, UserService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext db)
    {
      app.UseCors(options =>
     options.WithOrigins("http://localhost:4200")
     .AllowAnyMethod()
     .AllowAnyHeader());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Superjack.MultiSites.Api v1"));
      }

      using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
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
