using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Models.DTO;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adventureApi.Services
{
    public class LocationService : ILocationService
    {
        private AdventureContext _db;

        public LocationService(AdventureContext db)
        {
            _db = db;
        }

        public int Add(AddLocationRequestModel request, int userId)
        {
            var location = new Location()
            {
                Name = request.Name,
                LocationTypeId = request.LocationType,
                Description = request.Description,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                City = request.City,
                State = request.State,
                Country = request.Country,
                ZipCode = request.ZipCode,
                Neighborhood = request.Neighborhood,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                AddedByUserId = userId,
                AddedAtTime = DateTime.UtcNow,
                IsPrivate = request.IsPrivate
            };
            _db.Locations.Add(location);
            _db.SaveChanges();
            return location.LocationId;
        }

        public Location Get(int locationId)
        {
            return _db.Locations
                .Where(l => l.LocationId == locationId)
                .Include(l => l.AddedByUser)
                .Include(l => l.Adventures)
                .ThenInclude(a => a.AdventureMembers)
                .ThenInclude(m => m.User)
                .SingleOrDefault();
        }

        public List<Location> GetAll()
        {
            return _db.Locations
                .Where(l => !l.IsDeleted)
                .Include(l => l.AddedByUser)
                .Include(l => l.Adventures)
                .ThenInclude(a => a.AdventureMembers)
                .ThenInclude(m => m.User)
                .ToList();
        }

        public bool UserHasAccess(Location location, int userId)
        {
            if (!location.IsPrivate) return true;
            if (location.AddedByUserId == userId) return true;
            if (location.Adventures.Any(a => a.AdventureMembers.Any(m => m.UserId == userId))) return true;
            return false;
        }
    }
}
