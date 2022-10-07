namespace DependencyInjectionHost
{
    // Push Notification Reminder Service
    public class PushNotificationReminderService : IReminderService
    {
        public PushNotificationReminderService()
        {
        }

        public void SendReminder()
        {
            Console.WriteLine("PushNotificationReminderService - Send Reminder - Executed");
        }
    }
}
