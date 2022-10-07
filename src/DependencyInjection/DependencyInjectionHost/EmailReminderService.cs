namespace DependencyInjectionHost
{
    // Email Reminder Service
    public class EmailReminderService : IReminderService
    {
        public EmailReminderService()
        {
        }

        public void SendReminder()
        {
            Console.WriteLine("EmailReminderService - Send Reminder - Executed");
        }
    }
}
