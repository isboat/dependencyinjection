using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjectionHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotificationController : ControllerBase
    {
        private readonly IEnumerable<IReminderService> reminderServices;

        public PushNotificationController(IEnumerable<IReminderService> reminderServices)
        {
            this.reminderServices = reminderServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service = reminderServices.FirstOrDefault(x => x.GetType() == typeof(PushNotificationReminderService));

            if (service != null)
            {
                service.SendReminder();
            }

            return Ok();
        }
    }
}
