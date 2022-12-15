using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace log_level.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoglevelController : ControllerBase
    {
       

        private readonly ILogger<LoglevelController> _logger;

        public LoglevelController(ILogger<LoglevelController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string loginglevel (string msg, LogLevel logLevel) {
            _logger.Log(logLevel, $" This message is {logLevel}");
           
            if (_logger.IsEnabled(logLevel))
            {
                return $"current log level is {logLevel} and log is printed";
            }
            else
            {
                return $"current log level is {logLevel} and log is not printed";
            }  
        }
    }
}