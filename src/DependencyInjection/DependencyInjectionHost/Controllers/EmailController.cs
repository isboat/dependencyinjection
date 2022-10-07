using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjectionHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // This should be email service implementation
        private readonly IReminderService reminderService;

        public EmailController(IReminderService reminderService)
        {
            this.reminderService = reminderService;
        }

        // POST api/<SmsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // DELETE api/<SmsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
