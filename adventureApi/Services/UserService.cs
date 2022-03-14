using System;
using System.Linq;
using adventureApi.Models.Entities;
using adventureApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adventureApi.Services
{
    public class UserService : IUserService
    {
        private AdventureContext _db;

        public UserService(AdventureContext db)
        {
            _db = db;
        }
        
        public User GetById(int id)
        {
            return _db.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _db.Users.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
