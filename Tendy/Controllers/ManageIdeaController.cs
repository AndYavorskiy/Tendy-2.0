using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tendy.BLL.Interfaces;
using Tendy.Common.Constants;
using Tendy.DAL.Entities;

namespace Tendy.Controllers
{
    [Route("api/manage-idea")]
    public class ManageIdeaController : Controller
    {
        private readonly IManageIdeasService manageIdeasService;
        private readonly UserManager<ApplicationUser> userManager;

        public ManageIdeaController(IManageIdeasService manageIdeasService, UserManager<ApplicationUser> userManager)
        {
            this.manageIdeasService = manageIdeasService;
            this.userManager = userManager;
        }

        [HttpPut("join")]
        public IActionResult UpdateJoinRequest([FromBody] int ideaId)
        {
            var userId = HttpContext.User.FindFirst(JwtClaimIdentifiers.Id)?.Value;

            if ( string.IsNullOrEmpty(userId))
            {
                return BadRequest(ModelState);
            }

            return StatusCode(StatusCodes.Status201Created, manageIdeasService.UpdateJoinRequest(ideaId, userId));
        }

        [HttpGet("requests/{ideaId?}")]
        public IActionResult GetRequests(int? ideaId)
        {
            return StatusCode(StatusCodes.Status200OK, manageIdeasService.GetRequests(ideaId));
        }

        [HttpGet("confirm-request/{requestId?}/{ideaId?}/{userId?}")]
        public IActionResult ConfirmRequest(int requestId, int ideaId, string userId)
        {
            var managerId = HttpContext.User.FindFirst(JwtClaimIdentifiers.Id)?.Value;

            if (string.IsNullOrEmpty(managerId))
            {
                return BadRequest(ModelState);
            }

            return StatusCode(StatusCodes.Status201Created, manageIdeasService.ConfirmRequest(ideaId, requestId, userId, managerId));
        }
    }
}
