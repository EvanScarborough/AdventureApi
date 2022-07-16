using System;
using System.Collections.Generic;
using adventureApi.Models.DTO;

namespace adventureApi.Models.ResponseModels
{
    public class UserDetailsModel
    {
        public DtoUser User { get; set; }
        public List<DtoAdventure> Adventures { get; set; }
        public bool DetailsHidden { get; set; }
    }
}
