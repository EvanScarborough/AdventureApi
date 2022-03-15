using System;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;

namespace adventureApi.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        User GetByEmail(string email);
        User Create(RegisterUserRequestModel request);
    }
}
