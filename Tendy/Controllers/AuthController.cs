using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Tendy.Authorizations;
using Tendy.BLL.ViewModels;
using Tendy.DAL.Entities;
using Tendy.Models;
using System.Security.Claims;
using Tendy.Common.Constants;

namespace Tendy.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtFactory jwtFactory;
        private readonly JsonSerializerSettings serializerSettings;
        private readonly JwtIssuerOptions jwtOptions;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            IJwtFactory jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions)
        {
            this.userManager = userManager;
            this.jwtFactory = jwtFactory;
            this.jwtOptions = jwtOptions.Value;

            serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.Email, credentials.Password);

            if (identity == null)
            {
                return BadRequest("Invalid username or password.");
            }

            var response = new
            {
                id = identity.Claims.Single(c => c.Type == JwtClaimIdentifiers.Id).Value,
                user_name = identity.Claims.Single(c => c.Type == JwtClaimIdentifiers.UserName).Value,
                auth_token = await jwtFactory.GenerateEncodedToken(credentials.Email, identity),
                expires_in = (int) jwtOptions.ValidFor.TotalSeconds
            };

            return new OkObjectResult(JsonConvert.SerializeObject(response, serializerSettings));
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            var userToVerify = await userManager.FindByEmailAsync(userName);

            if (userToVerify != null)
            {
                if (await userManager.CheckPasswordAsync(userToVerify, password))
                {
                    var claims = (await userManager.GetClaimsAsync(userToVerify)).ToList();

                    return await Task.FromResult(jwtFactory.GenerateClaimsIdentity(userToVerify, claims));
                }
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
