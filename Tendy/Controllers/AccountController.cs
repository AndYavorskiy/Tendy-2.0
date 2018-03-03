using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tendy.BLL.Interfaces;
using Tendy.BLL.ViewModels;

namespace Tendy.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountsService _accountsService;

        public AccountController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _accountsService.CreateAccount(model);

            return StatusCode(StatusCodes.Status201Created, true);
        }

        [HttpPut("setting")]
        public IActionResult UpdateSetting([FromBody]AccountSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_accountsService.UpdateSettings(model));
        }
    }
}
