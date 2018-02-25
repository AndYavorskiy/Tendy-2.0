using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tendy.Constants;
using Tendy.DAL.Entities;
using Tendy.BLL.Interfaces;
using Tendy.BLL.ViewModels;

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

    // GET: api/idea
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

    // GET api/idea/5
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

    // POST api/idea
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

    // PUT api/idea/5
    [HttpPut]
    public IActionResult Put([FromBody]IdeaViewModel ideaVm)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      return Ok(_ideaService.Update(ideaVm));
    }

    // DELETE api/idea/5
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
