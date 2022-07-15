using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adventureApi.Services
{
    public class AdventureService : IAdventureService
    {
        private AdventureContext _db;

        public AdventureService(AdventureContext db)
        {
            _db = db;
        }

        public Adventure Get(int adventureId)
        {
            return _db.Adventures
                .Where(a => a.AdventureId == adventureId)
                .Include(a => a.AdventureMembers)
                .ThenInclude(am => am.User)
                .SingleOrDefault();
        }

        public List<Adventure> GetAllByLocationId(int locationId)
        {
            return _db.Adventures
                .Where(a => a.LocationId == locationId)
                .Where(a => !a.IsDeleted)
                .Include(a => a.AdventureMembers)
                .ThenInclude(am => am.User)
                .ToList();
        }

        public bool UserHasAccess(Adventure adventure, int userId)
        {
            return !adventure.IsPrivate || adventure.AdventureMembers.Any(am => am.UserId == userId);
        }

        public Adventure Add(AddAdventureRequestModel request, int userId)
        {
            Adventure adventure = new Adventure()
            {
                Time = request.Time,
                LocationId = request.LocationId,
                Description = request.Description,
                AddedByUserId = userId,
                AddedAtTime = DateTime.UtcNow,
                IsPrivate = request.IsPrivate,
                IsDeleted = false
            };
            _db.Adventures.Add(adventure);
            _db.SaveChanges();
            _db.AdventureMembers.Add(new AdventureMember()
            {
                AdventureId = adventure.AdventureId,
                UserId = userId,
                Comment = request.Comment,
                Rating = request.Rating,
                IsCompleted = true,
                IsPrimary = true,
                IsPrivate = false,
                IsDeleted = false
            });
            foreach (var member in request.Members)
            {
                _db.AdventureMembers.Add(new AdventureMember()
                {
                    AdventureId = adventure.AdventureId,
                    UserId = member.UserId,
                    Comment = "",
                    Rating = 0,
                    IsCompleted = false,
                    IsPrimary = false,
                    IsPrivate = false,
                    IsDeleted = false
                });
            }
            _db.SaveChanges();
            return adventure;
        }
    }
}
