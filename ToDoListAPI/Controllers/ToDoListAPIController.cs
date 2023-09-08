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
        private readonly ILogger<ViewController> _logger;

        public ViewController(ILogger<ViewController> logger)
        {
            _logger = logger;
        }
        public static List<Task> taskList = new List<Task>();
        static ViewController()
        {
            Task instance = new Task();
            {
                instance.Id = 10;
                instance.Description = "Description";
                instance.IsCompleted = true;
            }

            taskList.Add(instance);
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (taskList == null || taskList.Count == 0)
            {
                return BadRequest("Error, there was no Task found");
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

        [Route("put")]
        [HttpPut]
        public IActionResult Put([FromBody] Task newTask)
        {
            Task instance = new Task();
            for (int i = 0; i < taskList.Count; i++)
            {
                if (instance.Id == taskList[i].Id)
                {
                    instance.Id == taskList[i].Id;
                    instance.Description == taskList[i].Description;
                    instance.IsCompleted == taskList[i].IsCompleted;
                }
            }

            return Ok(newTask);
        }


    }
}