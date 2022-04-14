using System;
using adventureApi.Helpers;

namespace adventureApi.Models.RequestModels
{
    public class AddLocationRequestModel
    {
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
		public bool IsPrivate { get; set; }
	}
}
