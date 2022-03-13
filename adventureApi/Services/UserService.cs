using System;
using adventureApi.Models.Entities;
using adventureApi.Services.Interfaces;

namespace adventureApi.Services
{
    public class UserService : IUserService
    {
        
        public User GetById(int id)
        {
            if (id == 1) return new User() { UserId = 1, DisplayName = "Evan", Email = "evan@ekc.com", Password = "Password1!", Role = Helpers.Constants.UserRole.Admin };
            return null;
        }

        public User GetByEmail(string email)
        {
            if (email == "evan@ekc.com") return new User() { UserId = 1, DisplayName = "Evan", Email = "evan@ekc.com", Password = "Password1!", Role = Helpers.Constants.UserRole.Admin };
            return null;
        }
    }
}
