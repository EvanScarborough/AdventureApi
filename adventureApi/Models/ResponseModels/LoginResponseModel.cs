using System;
using adventureApi.Helpers;

namespace adventureApi.Models.ResponseModels
{
    public class LoginResponseModel
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public Constants.UserRole Role { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Token { get; set; }
    }
}
