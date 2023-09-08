using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using ToDoListAPI;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ViewController : ControllerBase
    {
        private static List<Task> tasks = new List<Task>();
        private readonly ILogger<ViewController> _logger;

        public ViewController(ILogger<ViewController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTaskAPI")]
        public IActionResult Get()
        {
            if (tasks == null || tasks.Count == 0)
            {
                return NotFound("No list has been found");
            }

            return Ok(tasks);
        }
    }


}