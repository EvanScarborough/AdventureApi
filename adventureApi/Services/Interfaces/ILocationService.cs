using System;
using System.Collections.Generic;
using adventureApi.Models.DTO;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;

namespace adventureApi.Services.Interfaces
{
    public interface ILocationService
    {
        List<Location> GetAll();
        Location Get(int locationId);
        bool UserHasAccess(Location location, int userId);
        int Add(AddLocationRequestModel request, int userId);
    }
}
