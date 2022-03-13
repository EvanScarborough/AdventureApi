using System;
using adventureApi.Models.Entities;

namespace adventureApi.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        User GetByEmail(string email);
    }
}
