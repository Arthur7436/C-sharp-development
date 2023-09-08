using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace MiniAPI.Controllers
{



    [ApiController]
    [Route("[Api]")]
    public class TaskController : ControllerBase
    {
        private static List<Task> tasks = new List<Task>();
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTaskAPI")]
        public IActionResult Get()
        {
            Console.Write("asd");
        }
    }


}