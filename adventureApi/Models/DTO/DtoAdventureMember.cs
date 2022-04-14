using System;
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
    }
}
