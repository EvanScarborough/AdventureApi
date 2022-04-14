using System;
namespace adventureApi.Models.Entities
{
    public class AdventureMember
	{
        public int AdventureMemberId { get; set; }
        public int AdventureId { get; set; }
        public Adventure Adventure { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsPrimary { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool IsPrivate { get; set; }
    }
}
