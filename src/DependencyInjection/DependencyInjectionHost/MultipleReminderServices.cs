namespace DependencyInjectionHost
{
    //---------------------------------------------------------------------------------
    // Individual Interfaces derived from IReminderService
    //---------------------------------------------------------------------------------
    public interface IEmailReminderService : IReminderService { }
    public interface ISmsReminderService : IReminderService { }
    public interface IPushNotificationReminderService : IReminderService { }

    //---------------------------------------------------------------------------------
    // Derive classes from individual interfaces
    //---------------------------------------------------------------------------------
    public class DerivedEmailReminderService : IEmailReminderService
    {
        public void SendReminder()
        {
        }
    }
    public class DerivedSmsReminderService : ISmsReminderService
    {
        public void SendReminder()
        {
        }
    }
    public class DerivedPushNotificationReminderService : IPushNotificationReminderService
    {
        public void SendReminder()
        {
        }
    }
}
