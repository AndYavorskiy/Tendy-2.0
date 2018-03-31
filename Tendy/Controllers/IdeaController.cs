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
        private readonly IIdeasService ideaService;
        private readonly UserManager<ApplicationUser> userManager;

        public IdeaController(IIdeasService ideaService, UserManager<ApplicationUser> userManager)
        {
            this.ideaService = ideaService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("search")]
        public ActionResult SearchIdea(IdeaSearchFilter filter)
        {
            if (filter == null)
            {
                filter = new IdeaSearchFilter();
            }

            filter.AuthorId = HttpContext.User.FindFirst(JwtClaimIdentifiers.Id)?.Value;

            return Ok(ideaService.Search(filter));
        }

        [HttpGet("{id}")]
        public ActionResult GetIdea(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var userId = HttpContext.User.FindFirst(JwtClaimIdentifiers.Id)?.Value;

            return Ok(ideaService.Get(id, userId));
        }

        [HttpPost]
        public IActionResult AddIdea([FromBody]IdeaViewModel ideaVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var authorId = HttpContext.User.FindFirst(JwtClaimIdentifiers.Id).Value;
            ideaVm.AuthorId = authorId;

            return StatusCode(StatusCodes.Status201Created, ideaService.Create(ideaVm));
        }

        [HttpPut]
        public IActionResult UpdateIdea([FromBody]IdeaViewModel ideaVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ideaService.Update(ideaVm));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIdea(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            return Ok(ideaService.Delete(id));
        }       
    }
}
