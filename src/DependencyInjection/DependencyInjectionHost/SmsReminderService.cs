namespace DependencyInjectionHost
{
    // SMS Reminder Service
    public class SmsReminderService : IReminderService
    {
        public SmsReminderService()
        {
        }

        public void SendReminder()
        {
            Console.WriteLine("SmsReminderService - Send Reminder - Executed");
        }
    }
}
