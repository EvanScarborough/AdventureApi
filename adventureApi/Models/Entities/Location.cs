using System;
using System.Collections.Generic;
using adventureApi.Helpers;

namespace adventureApi.Models.Entities
{
    public class Location
	{
		public int LocationId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Constants.LocationType LocationTypeId { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
		public string Neighborhood { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public int AddedByUserId { get; set; }
		public DateTime AddedAtTime { get; set; }
		public bool IsPrivate { get; set; }
		public bool IsDeleted { get; set; }
		public List<Adventure> Adventures { get; set; }
	}
}
