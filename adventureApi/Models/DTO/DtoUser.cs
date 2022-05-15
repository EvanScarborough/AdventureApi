using System;
using adventureApi.Models.Entities;

namespace adventureApi.Models.DTO
{
    public class DtoUser
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }

        public DtoUser() { }
        public DtoUser(User user)
        {
            UserId = user.UserId;
            DisplayName = user.DisplayName;
        }
    }
}
