using System;
using System.Collections.Generic;
using adventureApi.Models.ResponseModels;

namespace adventureApi.Services.Interfaces
{
    public interface INotificationService
    {
        List<NotificationModel> GetNotificationsForUser(int userId);
    }
}
