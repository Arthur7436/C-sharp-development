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
            Task instance1 = new Task();
            {
                instance1.Id = 21;
                instance1.Description = "This is the first instance";
                instance1.IsCompleted = false;
            }

            Task instance2 = new Task();
            {
                instance2.Id = 100;
                instance2.Description = "This is the second instance";
                instance2.IsCompleted = true;
            }

            Task instance3 = new Task();
            {
                instance3.Id = 1;
                instance3.Description = "This is the third instance";
                instance3.IsCompleted = false;
            }

            taskList.Add(instance1);
            taskList.Add(instance2);
            taskList.Add(instance3);

            if (taskList == null || taskList.Count == 0)
            {
                return NotFound("No list has been found");
            }

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