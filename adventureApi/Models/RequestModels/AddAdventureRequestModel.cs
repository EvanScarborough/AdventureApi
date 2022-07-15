using System;
using System.Collections.Generic;
using adventureApi.Models.DTO;

namespace adventureApi.Models.RequestModels
{
    public class AddAdventureRequestModel
    {
        public int LocationId { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public List<DtoUser> Members { get; set; }
        public bool IsPrivate { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
