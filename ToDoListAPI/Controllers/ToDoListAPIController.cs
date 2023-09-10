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
            bool idExists = false;
            for (int i = 0; i < taskList.Count; i++)
            {
                if (newTask.Id == taskList[i].Id)
                {
                    idExists = true;
                    return BadRequest("The Id exists please try again");

                }
                else if (newTask.Id != taskList[i].Id)
                {
                    idExists = false;
                    taskList.Add(newTask);
                }
                break;
            }

            return Ok(newTask);
        }

        [Route("updateId")]
        [HttpPut]
        public IActionResult Put([FromBody] Task put)
        {

            for (int i = 0; i < taskList.Count; i++)
            {
                if (put.Id == taskList[i].Id)
                {
                    taskList[i].Id = put.Id;
                    taskList[i].Description = put.Description;
                    taskList[i].IsCompleted = put.IsCompleted;

                    break;
                }
            }
            return Ok(put);
        }


    }
}