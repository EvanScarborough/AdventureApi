using System;
using System.Linq;
using adventureApi.Helpers;
using adventureApi.Models.DTO;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace adventureApi.Controllers
{
    [ApiController]
    [Route("location")]
    public class LocationController : ControllerBase
    {
        private ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Authorize(Constants.UserRole.Basic)]
        public IActionResult GetAll()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(_locationService.GetAll()
                .Where(l => _locationService.UserHasAccess(l, user.UserId))
                .Select(l => new DtoLocation(l, user.UserId)));
        }

        [HttpGet("{locationId}")]
        [Authorize(Constants.UserRole.Basic)]
        public IActionResult GetByLocationId(int locationId)
        {
            var user = (User)HttpContext.Items["User"];
            var location = _locationService.Get(locationId);
            if (location == null) return NotFound();
            if (!_locationService.UserHasAccess(location, user.UserId)) return Forbid();
            return Ok(new DtoLocation(location, user.UserId));
        }

        [HttpPost]
        [Authorize(Constants.UserRole.Contributor)]
        public IActionResult AddLocation(AddLocationRequestModel request)
        {
            var user = (User)HttpContext.Items["User"];
            var locationId = _locationService.Add(request, user.UserId);
            var location = _locationService.Get(locationId);
            return Ok(new DtoLocation(location));
        }
    }
}
