#region Usings
using AutoMapper;
using FluentValidation.AspNetCore;
using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Tendy.Abstract;
using Tendy.Authorizations;
using Tendy.Concrete;
using Tendy.Middlewares;
using Tendy.Models;
using Tendy.BLL.Interfaces;
using Tendy.BLL.Services;
using Tendy.BLL.Utils;
using Tendy.BLL.Utils.Validations;
using Tendy.DAL.Abstract;
using Tendy.DAL.Concrete;
using Tendy.DAL.EF;
using Tendy.DAL.Entities;
using Tendy.Common.Constants;
#endregion

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

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddCors(options =>
                options.AddPolicy("AllowCors",
                builder => builder
                           .WithOrigins("http://localhost:4200")
                           .WithMethods("GET", "PUT", "POST", "DELETE")
                           .AllowAnyHeader()
                ));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy =>
                        policy.RequireClaim(JwtClaimIdentifiers.Role, JwtClaims.ApiAccess));
                options.AddPolicy("OnlyForAdmin", policy =>
                        policy.RequireClaim(JwtClaimIdentifiers.Role, JwtClaims.Admin));
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
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Idea>, Repository<Idea>>();
            services.AddScoped<IRepository<PeopleGroup>, Repository<PeopleGroup>>();
            services.AddScoped<IRepository<Request>, Repository<Request>>();
            services.AddScoped<IRepository<UserProfile>, Repository<UserProfile>>();
            services.AddScoped<IRepository<IdeaCategory>, Repository<IdeaCategory>>();
            services.AddScoped<IRepository<Link>, Repository<Link>>();
            services.AddScoped<IRepository<File>, Repository<File>>();
            services.AddScoped<IRepository<AccountSettings>, Repository<AccountSettings>>();

            //dependency injection BLL
            services.AddScoped<IIdeasService, IdeaService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IAttachmentsManager, AttachmentsManager>();

            //dependency injection WEB
            services.AddSingleton<IJwtFactory, JwtFactory>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDbInitializer dbInitializer)
        {
            app.UseGlobalErrorHandling();

            if (env.IsDevelopment())
            {
                app.Shell("npm start");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

           //dbInitializer.Initialize();

            app.UseCors("AllowCors");
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
