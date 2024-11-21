using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Helpers.Extensions;
using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.SignalR
{
    public class NotificationHub : Hub
    {
        private readonly INotificationRepository notificationRepository;
        private readonly AppDbContext context;

        public NotificationHub(INotificationRepository notificationRepository, AppDbContext context)
        {
            this.notificationRepository = notificationRepository;
            this.context = context;
        }

        public override async Task OnConnectedAsync()
        {
            var notifications = await context.Notifications!
                .Where(x => x.UserId == Context.User!.GetUserId() && !x.IsRead)
                .OrderByDescending(x => x.TimeStamp).ToListAsync();

            foreach (var notification in notifications)
            {
                await Clients.Caller.SendAsync("ReceiveNotification", notification);
            }

            await base.OnConnectedAsync();
        }

        public async Task SendNotification(Notification notification)
        {
            await Clients.User(notification.UserId.ToString()).SendAsync("ReceiveNotification", notification);
        }
    }
}
