using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tendy.BLL.Interfaces;
using Tendy.BLL.Services;
using Tendy.BLL.ViewModels;

namespace Tendy.Controllers
{
    [Route("api/attachments")]
    public class AttachmentsController : Controller
    {
        private readonly IAttachmentsManager _attachmentsManager;

        public AttachmentsController(IAttachmentsManager attachmentsManager)
        {
            _attachmentsManager = attachmentsManager;
        }

        [HttpGet("link/{ideaId}")]
        public ActionResult GetLinks(int ideaId)
        {
            if (ideaId < 0)
            {
                return BadRequest();
            }

            return Ok(_attachmentsManager.GetLinks(ideaId));
        }

        [HttpPost("link/{ideaId}")]
        public IActionResult UpdateLinks(int? ideaId, [FromBody] IEnumerable<LinkViewModel> links)
        {
            if (ideaId == null || links == null)
            {
                return BadRequest();
            }

            return Ok(_attachmentsManager.UpdateLinks(ideaId.Value, links));
        }

        [HttpPost("file/{ideaId}")]
        public IActionResult AddFiles(int ideaId, [FromBody] IEnumerable<FileViewModel> model)
        {
            return Ok(true);
        }
    }
}