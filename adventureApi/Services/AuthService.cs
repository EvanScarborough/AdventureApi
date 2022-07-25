using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Models.ResponseModels;
using adventureApi.Models.Settings;
using adventureApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace adventureApi.Services
{
    public class AuthService : IAuthService
    {
        private AppSettings _appSettings;
        private IUserService _userService;
        private IEncryptionService _encryptionService;

        public AuthService(IOptions<AppSettings> appSettings, IUserService userService, IEncryptionService encryptionService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
            _encryptionService = encryptionService;
        }

        public LoginResponseModel Login(LoginRequestModel request)
        {
            User user = _userService.GetByEmail(request.Email);

            if (user == null || request.Password != _encryptionService.Decrypt(user.Password)) return null;

            return new LoginResponseModel()
            {
                UserId = user.UserId,
                Email = user.Email,
                DisplayName = user.DisplayName,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Role = user.Role,
                Token = GenerateToken(user)
            };
        }

        private string GenerateToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddYears(1)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
