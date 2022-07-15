using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Helpers;
using adventureApi.Models.Entities;

namespace adventureApi.Models.DTO
{
    public class DtoLocation
    {
        public int LocationId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Constants.LocationType LocationType { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
		public string Neighborhood { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public DtoUser AddedByUser { get; set; }
		public DateTime AddedAtTime { get; set; }
		public bool IsPrivate { get; set; }
		public decimal Rating { get; set; }
		public int AdventureCount { get; set; }
		public decimal MyRating { get; set; }
		public int MyAdventureCount { get; set; }

		public DtoLocation() { }
		public DtoLocation(Location l)
        {
            LocationId = l.LocationId;
            Name = l.Name;
            LocationType = l.LocationTypeId;
            Description = l.Description;
            AddedByUser = new DtoUser(l.AddedByUser);
            AddedAtTime = l.AddedAtTime;
            AddressLine1 = l.AddressLine1;
            AddressLine2 = l.AddressLine2;
            City = l.City;
            State = l.State;
            Country = l.Country;
            ZipCode = l.ZipCode;
            Neighborhood = l.Neighborhood;
            Latitude = l.Latitude;
            Longitude = l.Longitude;
            IsPrivate = l.IsPrivate;
            AdventureCount = l.Adventures?
                .Where(a => !a.IsDeleted)
                .Count() ?? 0;
            Rating = l.Adventures?
                .Where(a => !a.IsDeleted)
                .Select(a => a.AdventureMembers
                    .Where(am => !am.IsDeleted && am.IsCompleted)
                    .Select(am => (decimal)am.Rating)
                    .AverageOrDefault())
                .AverageOrDefault() ?? 0;
        }
        public DtoLocation(Location l, int userId) : this(l)
        {
            MyAdventureCount = l.Adventures?
                .Where(a => !a.IsDeleted
                    && a.AdventureMembers.Any(m => m.UserId == userId))
                .Count() ?? 0;
            MyRating = l.Adventures?
                .Where(a => !a.IsDeleted
                    && a.AdventureMembers.Any(m => m.UserId == userId))
                .Select(a => a.AdventureMembers
                    .Where(am => !am.IsDeleted && am.IsCompleted)
                    .Select(am => (decimal)am.Rating)
                    .AverageOrDefault())
                .AverageOrDefault() ?? 0;
        }
    }
}
