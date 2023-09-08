using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using ToDoListAPI;
using System.Text.Json;
using System.ComponentModel;

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
            Task instance = new Task();
            {
                instance.Id = 10;
                instance.Description = "Description";
                instance.IsCompleted = true;
            }

            taskList.Add(instance);

            return Ok(taskList);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Task newTask)
        {
            taskList.Add(newTask);

            return Ok(newTask);
        }
    }
}