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
        public IActionResult CreateTask([FromBody] Task newTask)
        {
            if (taskList.Any(taskListObject => taskListObject.Id == newTask.Id))
            {
                return BadRequest("This task id already exists");
            }

            taskList.Add(newTask);
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

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(Task delete)
        {
            var objectTask = taskList.FirstOrDefault(x => x.Id == delete.Id);
            if (objectTask == null)
            {
                return BadRequest("The Id does not exist");
            }

            taskList.Remove(objectTask);
            return Ok("success");


        }


    }
}