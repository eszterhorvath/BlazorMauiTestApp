using Shiny.Notifications;

namespace BlazorMauiTestApp.Shiny
{
    public class NotificationDelegate : INotificationDelegate
    {
        public Task OnEntry(NotificationResponse response)
        {
            return Task.CompletedTask;
        }
    }
}
