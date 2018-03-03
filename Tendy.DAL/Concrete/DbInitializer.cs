using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using Tendy.Common.Constants;
using Tendy.DAL.Abstract;
using Tendy.DAL.EF;
using Tendy.DAL.Entities;

namespace Tendy.DAL.Concrete
{
	public class DbInitializer : IDbInitializer
	{
		private readonly ApplicationDbContext context;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public DbInitializer(
		ApplicationDbContext context,
		UserManager<ApplicationUser> userManager,
		RoleManager<IdentityRole> roleManager)
		{
			this.context = context;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		public async void Initialize()
		{
			//create database schema if none exists
			context.Database.EnsureCreated();
			//Create the default Admin account
			string password = "12345";
			ApplicationUser user = new ApplicationUser
			{
				UserName = "Admin",
				Email = "admin@gmail.com",
				PhoneNumber = "+380000000000"
			};

			var isUserExists = (await userManager.FindByNameAsync(user.UserName)) != null;

			if (!isUserExists)
			{
				var claims = new List<Claim>
				{
					new Claim(JwtClaimIdentifiers.Role, JwtClaims.Admin)
				};

				var result = await userManager.CreateAsync(user, password);

				if (result.Succeeded)
				{
					await userManager.AddClaimsAsync(user, claims);
				}
			}
		}
	}
}
