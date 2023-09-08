using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

namespace ToDoListAPI.Controllers
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
        public IActionResult ToDoListAPIController.Get()
        {
            if (tasks == null || tasks.Count == 0)
            {
                return NotFound();
            }
        }
    }


}