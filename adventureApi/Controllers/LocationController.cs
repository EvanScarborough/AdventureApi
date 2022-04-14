using System;
using adventureApi.Helpers;
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
            return Ok(_locationService.GetAll(user.UserId));
        }

        [HttpPost]
        [Authorize(Constants.UserRole.Contributor)]
        public IActionResult AddLocation(AddLocationRequestModel request)
        {
            var user = (User)HttpContext.Items["User"];
            var location = _locationService.Add(request, user.UserId);
            return Ok(location);
        }
    }
}
