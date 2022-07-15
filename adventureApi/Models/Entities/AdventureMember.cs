using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace adventureApi.Models.Entities
{
    public class AdventureMember
	{
        public int AdventureMemberId { get; set; }
        public int AdventureId { get; set; }
        [ForeignKey(nameof(AdventureId))]
        public Adventure Adventure { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public bool IsPrimary { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
