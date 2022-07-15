using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace adventureApi.Models.Entities
{
    public class AdventureImage
    {
        public int AdventureImageId { get; set; }
        public int AdventureMemberId { get; set; }
        [ForeignKey(nameof(AdventureMemberId))]
        public AdventureMember AdventureMember { get; set; }
        public string ImageUrl { get; set; }
    }
}
