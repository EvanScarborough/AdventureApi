using System;
using System.Collections.Generic;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Models.ResponseModels;

namespace adventureApi.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        UserDetailsModel GetDetails(int id, User loggedInUser);
        User GetByEmail(string email);
        User Create(RegisterUserRequestModel request);
        User Update(User user);
    }
}
