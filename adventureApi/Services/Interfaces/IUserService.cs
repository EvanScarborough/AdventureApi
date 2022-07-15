using System;
using System.Collections.Generic;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;

namespace adventureApi.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        User Create(RegisterUserRequestModel request);
    }
}
