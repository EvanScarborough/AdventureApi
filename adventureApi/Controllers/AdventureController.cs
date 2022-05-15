using System;
using System.Linq;
using adventureApi.Helpers;
using adventureApi.Models.DTO;
using adventureApi.Models.Entities;
using adventureApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace adventureApi.Controllers
{
    [ApiController]
    [Route("adventure")]
    public class AdventureController : ControllerBase
    {
        private IAdventureService _adventureService;

        public AdventureController(IAdventureService adventureService)
        {
            _adventureService = adventureService;
        }

        [HttpGet("location/{locationId}")]
        [Authorize(Constants.UserRole.Basic)]
        public IActionResult GetAllByLocationId(int locationId)
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(_adventureService.GetAllByLocationId(locationId)
                .Where(a => _adventureService.UserHasAccess(a, user.UserId))
                .Select(a => new DtoAdventure(a)));
        }
    }
}
