using System;
using System.Collections.Generic;
using adventureApi.Models.Entities;

namespace adventureApi.Services.Interfaces
{
    public interface IAdventureService
    {
        Adventure Get(int adventureId);
        List<Adventure> GetAllByLocationId(int locationId);
        bool UserHasAccess(Adventure adventure, int userId);
    }
}
