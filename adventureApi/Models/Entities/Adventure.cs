using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace adventureApi.Models.Entities
{
    public class Adventure
    {
        public int AdventureId { get; set; }
        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDeleted { get; set; }
        public List<AdventureMember> AdventureMembers { get; set; }
    }
}
