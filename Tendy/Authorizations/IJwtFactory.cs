using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Tendy.DAL.Entities;

namespace Tendy.Authorizations
{
  public interface IJwtFactory
  {
    Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);

    ClaimsIdentity GenerateClaimsIdentity(ApplicationUser user, IEnumerable<Claim> claims);
  }
}
