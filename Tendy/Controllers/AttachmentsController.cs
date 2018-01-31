using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tendy.BLL.ViewModels;

namespace Tendy.Controllers
{
    public class Attachment
    {
        public LinkViewModel[] Links { get; set; }

        public IEnumerable<IFormFile> Files { get; set; }
    }

    [Route("api/attachments")]
    public class AttachmentsController : Controller
    {
        [HttpPost("{ideaId}")]
        public IActionResult Post(int ideaId, [FromBody] Attachment model)
        {
            return Ok(true);
        }
    }
}