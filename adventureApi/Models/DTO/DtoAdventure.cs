using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Helpers;
using adventureApi.Models.Entities;

namespace adventureApi.Models.DTO
{
    public class DtoAdventure
    {
        public int AdventureId { get; set; }
        public DateTime Time { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public DtoUser AddedByUser { get; set; }
        public DateTime AddedAtTime { get; set; }
        public List<DtoAdventureMember> Members { get; set; }
        public bool IsPrivate { get; set; }
        public int LocationId { get; set; }
        public DtoLocation Location { get; set; }

        public DtoAdventure() { }
        public DtoAdventure(Adventure adventure)
        {
            AdventureId = adventure.AdventureId;
            Time = adventure.Time;
            Rating = adventure.AdventureMembers
                .Where(am => !am.IsDeleted && am.IsCompleted)
                .Select(am => (decimal)am.Rating)
                .AverageOrDefault();
            Description = adventure.Description;
            AddedByUser = new DtoUser(adventure.AddedByUser);
            IsPrivate = adventure.IsPrivate;
            Members = adventure.AdventureMembers
                .Where(am => !am.IsDeleted)
                .Select(am => new DtoAdventureMember(am))
                .ToList();
            LocationId = adventure.LocationId;
            if (adventure.Location != null)
            {
                Location = new DtoLocation(adventure.Location, true);
            }
        }
    }
}
