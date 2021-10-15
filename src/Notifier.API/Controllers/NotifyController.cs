using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notifier.Services;

namespace Notifier.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotifyController : ControllerBase
    {
        private readonly ILogger<NotifyController> _logger;
        private readonly INotifierService _notifierService;

        public NotifyController(ILogger<NotifyController> logger, INotifierService notifierService)
        {
            _logger = logger;
            _notifierService = notifierService;
        }

        [HttpGet]
        public IActionResult Publish(string topic, string messages)
        {
            _logger.LogInformation($"Publishing messages on the following topic: {topic}");
            _logger.LogInformation($"Publishing messages on the following topic: {topic}");

            _notifierService.Publish(topic, messages);

            return Ok("Messages published!");
        } 
    }
}
