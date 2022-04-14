using System;
using System.Collections.Generic;
using adventureApi.Models.DTO;
using adventureApi.Models.RequestModels;

namespace adventureApi.Services.Interfaces
{
    public interface ILocationService
    {
        List<DtoLocation> GetAll(int userId);
        DtoLocation Add(AddLocationRequestModel request, int userId);
    }
}
