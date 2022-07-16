using System;
using System.Linq;
using System.Net.Http;
using adventureApi.Helpers;
using adventureApi.Models.DTO;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace adventureApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        [Authorize(Constants.UserRole.Contributor)]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll().Select(u => new DtoUser(u)));
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(_userService.GetDetails(userId, user));
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUserRequestModel request)
        {
            try
            {
                _userService.Create(request);

                var response = _authService.Login(new LoginRequestModel() { Email = request.Email, Password = request.Password });

                if (response == null) throw new Exception("Something went wrong.");

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("/profilepic")]
        public IActionResult PostUserImage()
        {
            return NotFound();
        }
    }
}
