using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tendy.BLL.Interfaces;
using Tendy.BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Idemty_Web.Controllers
{
  [Authorize(Policy = "ApiUser")]
  [Route("api/idea")]
    public class IdeaController : Controller
    {
        private readonly IIdeasService _ideaService;
        public IdeaController(IIdeasService ideaService)
        {
            _ideaService = ideaService;
        }

        // GET: api/idea
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_ideaService.GetAll());
        }

        // GET api/idea/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

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

            return StatusCode(StatusCodes.Status201Created, _ideaService.Create(ideaVm));
        }

        // PUT api/idea/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody]IdeaViewModel ideaVm)
        {
            if (id == null)
            {
                return NotFound();
            }
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
            return StatusCode(StatusCodes.Status204NoContent, _ideaService.Delete(id));
        }
    }
}
