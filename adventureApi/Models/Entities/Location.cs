using System;
using System.Collections.Generic;

namespace adventureApi.Models.Entities
{
    public class Location
	{
		public int LocationId { get; set; }
		public string Name { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
		public string AreaName { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public List<Adventure> Adventures { get; set; }
	}
}
