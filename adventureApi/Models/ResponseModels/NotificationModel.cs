using System;
using System.Collections.Generic;
using adventureApi.Helpers;
using adventureApi.Models.DTO;

namespace adventureApi.Models.ResponseModels
{
    public class NotificationModel
    {
        public Constants.NotificationType NotificationType { get; set; }
        public string Text { get; set; }
        public DtoUser User { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, string> Props { get; set; } = new Dictionary<string, string>();
    }
}
