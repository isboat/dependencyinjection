namespace DependencyInjectionHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Option 1: Register three implementations
            builder.Services.AddScoped<IReminderService, SmsReminderService>();
            builder.Services.AddScoped<IReminderService, EmailReminderService>();
            builder.Services.AddScoped<IReminderService, PushNotificationReminderService>();

            // Option 2: Service Delegate
            DependencyRegistrationBoostrapper.RegisterDependencies(builder.Services);

            // Option 3 – Factory
            DependencyRegistrationFactoryBoostrapper.RegisterDependencies(builder.Services);

            // Option 4 – Individual Interfaces Deriving from Single Interface
            builder.Services.AddScoped<ISmsReminderService, DerivedSmsReminderService>();
            builder.Services.AddScoped<IEmailReminderService, DerivedEmailReminderService>();
            builder.Services.AddScoped<IPushNotificationReminderService, DerivedPushNotificationReminderService>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}