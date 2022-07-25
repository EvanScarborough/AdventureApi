using System;
using System.Collections.Generic;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using Microsoft.AspNetCore.Http;

namespace adventureApi.Services.Interfaces
{
    public interface IAdventureService
    {
        Adventure Get(int adventureId);
        List<Adventure> GetAllByLocationId(int locationId);
        bool UserHasAccess(Adventure adventure, int userId);
        Adventure Add(AddAdventureRequestModel request, int userId);
        void AddReview(int adventureId, AdventureReviewRequestModel request, int userId);
        AdventureImage AddImage(int adventureId, int userId, IFormFile file);
    }
}
