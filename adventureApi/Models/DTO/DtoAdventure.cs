using System;
using System.Collections.Generic;

namespace adventureApi.Models.DTO
{
    public class DtoAdventure
    {
        public int AdventureId { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public List<DtoAdventureMember> Members { get; set; }
        public bool IsPrivate { get; set; }
    }
}
