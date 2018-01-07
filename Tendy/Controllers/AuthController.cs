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
using Tendy.Constants;

namespace Tendy.Controllers
{
  [Route("api/auth")]
  public class AuthController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtFactory _jwtFactory;
    private readonly JsonSerializerSettings _serializerSettings;
    private readonly JwtIssuerOptions _jwtOptions;

    public AuthController(UserManager<ApplicationUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
    {
      _userManager = userManager;
      _jwtFactory = jwtFactory;
      _jwtOptions = jwtOptions.Value;

      _serializerSettings = new JsonSerializerSettings
      {
        Formatting = Formatting.Indented
      };
    }

    // POST api/auth/login
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

      // Serialize and return the response
      var response = new
      {
        id = identity.Claims.Single(c => c.Type == JwtClaimIdentifiers.Id).Value,
        user_name = identity.Claims.Single(c => c.Type == JwtClaimIdentifiers.UserName).Value,
        auth_token = await _jwtFactory.GenerateEncodedToken(credentials.Email, identity),
        expires_in = (int) _jwtOptions.ValidFor.TotalSeconds
      };

      var json = JsonConvert.SerializeObject(response, _serializerSettings);
      return new OkObjectResult(json);
    }

    private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
    {
        // get the user to verifty
        var userToVerify = await _userManager.FindByEmailAsync(userName);

        if (userToVerify != null)
        {
          // check the credentials  
          if (await _userManager.CheckPasswordAsync(userToVerify, password))
          {
            return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userToVerify));
          }
        }
      

      // Credentials are invalid, or account doesn't exist
      return await Task.FromResult<ClaimsIdentity>(null);
    }
  }
}
