using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Models.DTO;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Services.Interfaces;

namespace adventureApi.Services
{
    public class LocationService : ILocationService
    {
        private AdventureContext _db;

        public LocationService(AdventureContext db)
        {
            _db = db;
        }

        public DtoLocation Add(AddLocationRequestModel request, int userId)
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
            return new DtoLocation(location);
        }

        public List<DtoLocation> GetAll(int userId)
        {
            return _db.Locations
                .Where(l => !l.IsDeleted)
                .Where(l => !l.IsPrivate
                    || l.AddedByUserId == userId
                    || l.Adventures.Any(a => !a.IsDeleted
                        && a.AdventureMembers.Any(m => m.UserId == userId)
                    )
                )
                .Select(l => new DtoLocation(l, userId))
                .ToList();
        }
    }
}
