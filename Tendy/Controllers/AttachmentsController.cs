using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tendy.BLL.ViewModels;

namespace Tendy.Controllers
{
    [Route("api/attachments")]
    public class AttachmentsController : Controller
    {
        [HttpPost("{ideaId}")]
        public IActionResult Post(int ideaId, [FromBody] AttachmentViewModel model)
        {
            string a = "adada";

            Convert.FromBase64String(a);

            return Ok(true);
        }
    }
}