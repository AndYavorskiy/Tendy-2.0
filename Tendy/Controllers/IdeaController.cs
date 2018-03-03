using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tendy.DAL.Entities;
using Tendy.BLL.Interfaces;
using Tendy.BLL.ViewModels;
using Tendy.Common.Constants;

namespace Idemty_Web.Controllers
{
    //[Authorize(Policy = "ApiUser")]
    [Route("api/idea")]
    public class IdeaController : Controller
    {
        private readonly IIdeasService _ideaService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdeaController(IIdeasService ideaService, UserManager<ApplicationUser> userManager)
        {
            _ideaService = ideaService;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("search")]
        public ActionResult Get(IdeaSearchFilter filter)
        {
            if (filter == null)
            {
                filter = new IdeaSearchFilter();
            }

            filter.AuthorId = HttpContext.User.FindFirst(JwtClaimIdentifiers.Id).Value;

            return Ok(_ideaService.Search(filter));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var a = HttpContext.User.Claims;

            return Ok(_ideaService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]IdeaViewModel ideaVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var authorId = HttpContext.User.FindFirst(JwtClaimIdentifiers.Id).Value;
            ideaVm.AuthorId = authorId;

            return StatusCode(StatusCodes.Status201Created, _ideaService.Create(ideaVm));
        }

        [HttpPut]
        public IActionResult Put([FromBody]IdeaViewModel ideaVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_ideaService.Update(ideaVm));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            return Ok(_ideaService.Delete(id));
        }
    }
}
