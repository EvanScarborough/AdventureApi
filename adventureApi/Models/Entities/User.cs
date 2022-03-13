using System;
using adventureApi.Helpers;

namespace adventureApi.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Constants.UserRole Role { get; set; }
    }
}
