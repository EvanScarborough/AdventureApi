using System;
using System.Linq;
using adventureApi.Helpers;
using adventureApi.Models.Entities;
using adventureApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace adventureApi.Controllers
{
    [ApiController]
    [Route("notification")]
    public class NotificationController : ControllerBase
    {
        private INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [Authorize(Constants.UserRole.Basic)]
        public IActionResult GetNotifications()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(_notificationService.GetNotificationsForUser(user.UserId));
        }
    }
}
