using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Models.Entities;

namespace adventureApi.Models.DTO
{
    public class DtoAdventureMember
    {
        public int AdventureMemberId { get; set; }
        public DtoUser User { get; set; }
        public bool IsPrimary { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsCompleted { get; set; }
        public List<string> ImageUrls { get; set; }

        public DtoAdventureMember() { }
        public DtoAdventureMember(AdventureMember adventureMember)
        {
            AdventureMemberId = adventureMember.AdventureMemberId;
            User = new DtoUser(adventureMember.User);
            IsPrimary = adventureMember.IsPrimary;
            Rating = adventureMember.Rating;
            Comment = adventureMember.Comment;
            IsPrivate = adventureMember.IsPrivate;
            IsCompleted = adventureMember.IsCompleted;
            ImageUrls = adventureMember.AdventureImages.Select(i => i.ImageUrl).ToList();
        }
    }
}
