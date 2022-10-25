namespace DependencyInjectionHost
{
    public static class DependencyRegistrationFactoryBoostrapper
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            // Register three implementations
            services.AddScoped<IReminderService, SmsReminderService>();
            services.AddScoped<IReminderService, EmailReminderService>();
            services.AddScoped<IReminderService, PushNotificationReminderService>();
            services.AddTransient<IReminderServiceFactory, ReminderServiceFactory>();
        }

    }

    //---------------------------------------------------------------------------------
    // Factory Method for resolving the instance
    //---------------------------------------------------------------------------------
    public interface IReminderServiceFactory
    {
        IReminderService GetInstance(string token);
    }

    public class ReminderServiceFactory : IReminderServiceFactory
    {
        private readonly IEnumerable<IReminderService> reminderServices;

        public ReminderServiceFactory(IEnumerable<IReminderService> reminderServices)
        {
            this.reminderServices = reminderServices;
        }

        public IReminderService GetInstance(string token)
        {
            return token switch
            {
                "Email" => this.GetService(typeof(EmailReminderService)),
                "SMS" => this.GetService(typeof(SmsReminderService)),
                "PushNotifications" => this.GetService(typeof(PushNotificationReminderService)),
                _ => throw new InvalidOperationException()
            }; ;
        }

        public IReminderService GetService(Type type)
        {
            return this.reminderServices.FirstOrDefault(x => x.GetType() == type)!;
        }
    }
}
