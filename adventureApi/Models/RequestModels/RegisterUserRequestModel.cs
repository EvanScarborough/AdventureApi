using System;
using System.ComponentModel.DataAnnotations;

namespace adventureApi.Models.RequestModels
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
