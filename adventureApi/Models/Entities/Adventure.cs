using System;
using System.Collections.Generic;

namespace adventureApi.Models.Entities
{
    public class Adventure
    {
        public int AdventureId { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public List<AdventureMember> AdventureMembers { get; set; }
    }
}
