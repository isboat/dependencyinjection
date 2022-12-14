using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjectionHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ReminderServiceResolver resolver;

        public EmailController(ReminderServiceResolver resolver)
        {
            this.resolver = resolver;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var service = resolver("Email");
            service.SendReminder();
            return Ok();
        }
    }
}
