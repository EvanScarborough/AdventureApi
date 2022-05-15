using System;
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

        public DtoAdventureMember() { }
        public DtoAdventureMember(AdventureMember adventureMember)
        {
            AdventureMemberId = adventureMember.AdventureMemberId;
            User = new DtoUser(adventureMember.User);
            IsPrimary = adventureMember.IsPrimary;
            Rating = adventureMember.Rating;
            Comment = adventureMember.Comment;
            IsPrivate = adventureMember.IsPrivate;
        }
    }
}
