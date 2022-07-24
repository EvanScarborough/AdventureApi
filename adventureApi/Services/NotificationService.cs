using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Models.DTO;
using adventureApi.Models.Entities;
using adventureApi.Models.ResponseModels;
using adventureApi.Services.Interfaces;

namespace adventureApi.Services
{
    public class NotificationService : INotificationService
    {
        private AdventureContext _db;

        public NotificationService(AdventureContext db)
        {
            _db = db;
        }

        public List<NotificationModel> GetNotificationsForUser(int userId)
        {
            var notifications = new List<NotificationModel>();

            notifications.AddRange(GetAddedToAdventureNotifications(userId));

            return notifications;
        }

        private List<NotificationModel> GetAddedToAdventureNotifications(int userId)
        {
            return _db.AdventureMembers
                .Where(m => m.UserId == userId)
                .Where(m => !m.IsCompleted)
                .Select(m => new NotificationModel()
                {
                    NotificationType = Helpers.Constants.NotificationType.AddedToAdventure,
                    Text = $"{m.Adventure.AddedByUser.DisplayName} added you to an adventure at {m.Adventure.Location.Name}!",
                    CreatedAt = m.Adventure.Time,
                    User = new DtoUser(m.Adventure.AddedByUser),
                    Props = new Dictionary<string, string>()
                    {
                        { "adventureId", m.AdventureId.ToString() }
                    }
                }).ToList();
        }
    }
}
