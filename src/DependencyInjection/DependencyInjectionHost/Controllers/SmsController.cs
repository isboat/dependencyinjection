using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjectionHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly IReminderServiceFactory reminderServiceFactory;

        public SmsController(IReminderServiceFactory reminderServiceFactory)
        {
            this.reminderServiceFactory = reminderServiceFactory;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var emailReminderService = reminderServiceFactory.GetInstance("SMS");
            if (emailReminderService != null)
            {
                emailReminderService.SendReminder();
            }

            return Ok();
        }
    }
}
