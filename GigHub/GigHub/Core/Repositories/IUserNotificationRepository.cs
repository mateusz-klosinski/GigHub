﻿using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUserNotifications(string userId);
    }
}