using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tendy.BLL.Interfaces;
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

        [HttpGet("file/{ideaId}")]
        public ActionResult GetFiles(int ideaId)
        {
            if (ideaId < 0)
            {
                return BadRequest();
            }

            return Ok(_attachmentsManager.GetFiles(ideaId));
        }

        [HttpPost("file/{ideaId}")]
        public IActionResult UpdateFiles(int? ideaId, [FromBody] IEnumerable<FileViewModel> model)
        {
            if (ideaId == null || model == null)
            {
                return BadRequest();
            }

            return Ok(_attachmentsManager.UpdateFile(ideaId.Value, model));
        }
    }
}