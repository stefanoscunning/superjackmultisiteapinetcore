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
  public class Startup2
  {

    public Startup2(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    readonly string SuperjackPolicy = "SuperjackPolicy";
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy(SuperjackPolicy,
        builder =>
        {
          builder.WithOrigins("http://localhost:4200", "[::1]:4200")
         .WithHeaders("Authorization");
        });
      });

      //services.Configure<CookiePolicyOptions>(options =>
      //{
      //  options.CheckConsentNeeded = context => true;
      //  options.MinimumSameSitePolicy = SameSiteMode.None;
      //});

      //services.AddCors(options =>
      //{
      //  options.AddPolicy(name: SuperjackPolicy,
      //                    builder =>
      //                    {
      //                      builder.SetIsOriginAllowed(origin=>true)
      //                      .AllowAnyHeader()
      //                      .AllowAnyMethod()
      //                      .AllowCredentials();
      //                    });
      //});

      //services.AddCors();
      //services.AddCors(options =>
      //{
      //  options.AddPolicy("AllowSpecificOrigin",
      //      builder =>
      //      {
      //        builder
      //                .WithOrigins("http://localhost:4200", "https://localhost:44320")
      //                .SetIsOriginAllowedToAllowWildcardSubdomains()
      //                .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
      //                .AllowAnyHeader()
      //                .AllowCredentials();
      //      });
      //});

      var domain = $"https://{Configuration["Auth0:Domain"]}/";
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
            options.Authority = domain;
            options.Audience = Configuration["Auth0:Audience"];
          });

      services.AddAuthorization(options =>
      {
        options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
        options.AddPolicy("openid profile email", policy => policy.Requirements.Add(new HasScopeRequirement("openid profile email", domain)));
        options.AddPolicy("all", policy => policy.Requirements.Add(new HasScopeRequirement("all", domain)));
        options.AddPolicy("read:current_user", policy => policy.Requirements.Add(new HasScopeRequirement("read:current_user", domain)));
      });

     
      // Register the scope authorization handler
      services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

      services.AddControllers();
      services.AddDbContext<AppDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MyNewDatabase")));
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Superjack.MultiSites.Api", Version = "v1" });
      });


     

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

      // 1. Add Authentication Services
      //services.AddAuthentication(options =>
      //{
      //  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      //  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      //}).AddJwtBearer(options =>
      //{
      //  options.Authority = "https://dev-febcml-d.eu.auth0.com/";
      //  options.Audience = "https://localhost:44320";
      //});


      //services.AddAuthentication(x =>
      //{
      //  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      //  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      //})
      //    .AddJwtBearer(x =>
      //    {
      //      x.Events = new JwtBearerEvents
      //      {
      //        OnTokenValidated = context =>
      //        {
      //          var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
      //          var userId = int.Parse(context.Principal.Identity.Name);
      //          var user = userService.GetById(userId);
      //          if (user == null)
      //          {
      //            // return unauthorized if user no longer exists
      //            context.Fail("Unauthorized");
      //          }
      //          return Task.CompletedTask;
      //        }
      //      };
      //      x.RequireHttpsMetadata = false;
      //      x.SaveToken = true;
      //      x.TokenValidationParameters = new TokenValidationParameters
      //      {
      //        ValidateIssuerSigningKey = true,
      //        IssuerSigningKey = new SymmetricSecurityKey(key),
      //        ValidateIssuer = false,
      //        ValidateAudience = false
      //      };
      //    });

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
      app.UseHttpsRedirection();



      app.UseCors(SuperjackPolicy);
      //app.UseCors(x => x
      //         .WithOrigins("http://localhost:4200", "https://localhost:44320")
      //         .AllowAnyMethod()
      //         .AllowAnyHeader()
      //         .AllowCredentials());

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      //app.UseEndpoints(
      //         endpoints => {
      //           endpoints.MapControllers().RequireCors(SuperjackPolicy);
      //           //endpoints.MapControllers();
      //         });
      
    }
  }
}
