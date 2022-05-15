using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Models.Entities;
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
    }
}
