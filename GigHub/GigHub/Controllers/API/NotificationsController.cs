using AutoMapper;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _unitOfWork.Notifications.GetNotificationsForUser(userId);


            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }




        [Authorize]
        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var userNotifications = _unitOfWork.UserNotifications.GetUserNotifications(userId);

            foreach (var notification in userNotifications)
            {
                notification.Read();
            }

            _unitOfWork.Complete();

            return Ok();
        }

    }
}
