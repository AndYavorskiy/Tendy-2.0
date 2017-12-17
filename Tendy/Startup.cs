using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tendy.DAL.EF;
using Tendy.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using AutoMapper;
using Tendy.DAL.Abstract;
using Tendy.DAL.Concrete;
using Tendy.Abstract;
using Tendy.Concrete;
using Tendy.BLL.Utils;
using Tendy.BLL.Services;
using Tendy.BLL.Interfaces;
using FluentValidation.AspNetCore;
using Tendy.BLL.Utils.Validations;
using Tendy.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tendy.Authorizations;
using Tendy.Helpers;

namespace Tendy
{
  public class Startup
  {
    private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH";
    private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      string connectionType = "local";

      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString(connectionType)));

      services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

      services.AddCors(options => options.AddPolicy("AllowCors",
          builder =>
          {
            builder
                     .AllowAnyOrigin()
                     .WithMethods("GET", "PUT", "POST", "DELETE")
                     .AllowAnyHeader();
          }));

      services.AddAuthorization(options =>
      {
        options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
      });

      //jwt wire up. Get options from app settings
      var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

      // Configure JwtIssuerOptions
      services.Configure<JwtIssuerOptions>(options =>
      {
        options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
        options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
      });

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(o =>
      {
        o.RequireHttpsMetadata = false;
        o.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidateIssuer = true,
          ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

          ValidateAudience = true,
          ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

          ValidateIssuerSigningKey = true,
          IssuerSigningKey = _signingKey,

          RequireExpirationTime = false,
          ValidateLifetime = false,
          ClockSkew = TimeSpan.Zero
        };
      });

      services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

      services.AddMvc()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(RegistrationViewModelValidator))));

      //dependency injection DAL
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
      services.AddScoped<IRepository<Attachment>, Repository<Attachment>>();
      services.AddScoped<IRepository<AttachmentGroup>, Repository<AttachmentGroup>>();
      services.AddScoped<IRepository<Category>, Repository<Category>>();
      services.AddScoped<IRepository<Idea>, Repository<Idea>>();
      services.AddScoped<IRepository<IdeaImage>, Repository<IdeaImage>>();
      services.AddScoped<IRepository<Image>, Repository<Image>>();
      services.AddScoped<IRepository<PeopleGroup>, Repository<PeopleGroup>>();
      services.AddScoped<IRepository<Publication>, Repository<Publication>>();
      services.AddScoped<IRepository<PublicationImage>, Repository<PublicationImage>>();
      services.AddScoped<IRepository<Request>, Repository<Request>>();
      services.AddScoped<IRepository<UserProfile>, Repository<UserProfile>>();

      //dependency injection BLL
      services.AddScoped<IIdeasService, IdeaService>();
      services.AddScoped<IAccountsService, AccountsService>();

      //dependency injection WEB
      services.AddSingleton<IJwtFactory, JwtFactory>();

    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc();
    }
  }
}