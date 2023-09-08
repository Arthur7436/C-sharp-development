using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using ToDoListAPI;
using System.Text.Json;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class ViewController : ControllerBase
    {
        public static List<Task> taskList = new List<Task>();

        private readonly ILogger<ViewController> _logger;

        public ViewController(ILogger<ViewController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTaskAPI")]
        public IActionResult Get()
        {
            if (taskList == null || taskList.Count == 0)
            {
                return NotFound("No list has been found");
            }

            return Ok(taskList);
        }

        [Route("api/post")]
        [HttpPost(Name = "PostTaskAPI")]
        public IActionResult Create([FromBody] Task newTask)
        {
            Task instance1 = new Task();
            {
                instance1.Id = 21;
                instance1.Description = "This is the first instance";
                instance1.IsCompleted = false;
            }

            taskList.Add(newTask);

            Task instance2 = new Task();
            {
                instance2.Id = 21;
                instance2.Description = "This is the first instance";
                instance2.IsCompleted = false;
            }

            taskList.Add(newTask);

            if (taskList == null || taskList.Count == 0)
            {
                return BadRequest("Task data is null or malformed");
            }

            return Ok(newTask);


        }
    }


}