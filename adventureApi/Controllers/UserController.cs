using System;
using System.Linq;
using adventureApi.Helpers;
using adventureApi.Models.DTO;
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
    }
}
