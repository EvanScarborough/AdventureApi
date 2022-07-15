using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adventureApi.Services
{
    public class UserService : IUserService
    {
        private AdventureContext _db;
        private IEncryptionService _encryptionService;

        public UserService(AdventureContext db, IEncryptionService encryptionService)
        {
            _db = db;
            _encryptionService = encryptionService;
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }
        
        public User GetById(int id)
        {
            return _db.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _db.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User Create(RegisterUserRequestModel request)
        {
            Validate(request);
            User user = new User()
            {
                Email = request.Email,
                DisplayName = request.DisplayName,
                Role = Helpers.Constants.UserRole.Basic,
                Password = _encryptionService.Encrypt(request.Password)
            };
            _db.Add(user);
            _db.SaveChanges();
            return GetByEmail(request.Email);
        }

        private void Validate(RegisterUserRequestModel request)
        {
            if (!IsValidEmail(request.Email)) throw new Exception("Invalid email address.");
            if (string.IsNullOrEmpty(request.DisplayName)) throw new Exception("Name cannot be blank.");
            if (!Regex.IsMatch(request.Password, Global.PASSWORD_REGEX)) throw new Exception("Invalid password.");
            if (GetByEmail(request.Email) != null) throw new Exception("A user with that email address already exists.");
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
