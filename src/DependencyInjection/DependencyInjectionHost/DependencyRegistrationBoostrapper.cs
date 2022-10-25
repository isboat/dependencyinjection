namespace DependencyInjectionHost
{
    // -----------------------------------------------------------------------------------
    // Reminder Service Resolver delegate
    // -----------------------------------------------------------------------------------
    public delegate IReminderService ReminderServiceResolver(string identifier);


    public static class DependencyRegistrationBoostrapper
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            // -----------------------------------------------------------------------------------
            // Register all implementations as given below
            // -----------------------------------------------------------------------------------
            services.AddTransient<SmsReminderService>();
            services.AddTransient<EmailReminderService>();
            services.AddTransient<PushNotificationReminderService>();

            // -----------------------------------------------------------------------------------
            // Resolve the implementation via GetService as shown below
            // NOTE: If you have enabled NRT, then you may have to adjust return type of the resolver
            // -----------------------------------------------------------------------------------
            services.AddTransient<ReminderServiceResolver>(serviceProvider => token =>
            {
                // hardcoded strings can be extracted as constants
                return token switch
                {
                    "Email" => serviceProvider.GetService<EmailReminderService>(),
                    "SMS" => serviceProvider.GetService<SmsReminderService>(),
                    "PushNotifications" => serviceProvider.GetService<PushNotificationReminderService>(),
                    _ => throw new InvalidOperationException()
                };
            });
        }
    }
}
