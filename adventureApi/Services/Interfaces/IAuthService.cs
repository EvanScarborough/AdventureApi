using System;
using adventureApi.Models.RequestModels;
using adventureApi.Models.ResponseModels;

namespace adventureApi.Services.Interfaces
{
    public interface IAuthService
    {
        LoginResponseModel Login(LoginRequestModel request);
    }
}
