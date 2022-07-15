using System;
using System.Linq;
using adventureApi.Helpers;
using adventureApi.Models.DTO;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
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

        [HttpGet("{adventureId}")]
        [Authorize(Constants.UserRole.Basic)]
        public IActionResult GetById(int adventureId)
        {
            return Ok(new DtoAdventure(_adventureService.Get(adventureId)));
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

        [HttpPost]
        [Authorize(Constants.UserRole.Contributor)]
        public IActionResult AddAdventure(AddAdventureRequestModel request)
        {
            var user = (User)HttpContext.Items["User"];
            var addedAdventure = _adventureService.Add(request, user.UserId);
            return Ok(new DtoAdventure(_adventureService.Get(addedAdventure.AdventureId)));
        }
    }
}
