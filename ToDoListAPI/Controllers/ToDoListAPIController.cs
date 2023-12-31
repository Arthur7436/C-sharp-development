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
        public IActionResult Put([FromBody] Task updateTask)
        {

            for (int i = 0; i < taskList.Count; i++)
            {
                if (updateTask.Id == taskList[i].Id)
                {
                    taskList[i].Id = updateTask.Id;
                    taskList[i].Description = updateTask.Description;
                    taskList[i].IsCompleted = updateTask.IsCompleted;

                    break;
                }
            }
            return Ok(updateTask);
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] Task DeleteTask)
        {
            //find if the id exists
            var item = taskList.FirstOrDefault(x => x.Id == DeleteTask.Id);
            //if not exist, then send bad request
            if (item == null)
            {
                return BadRequest("The Id does not exist");
            }

            //remove the item from the list
            taskList.Remove(item);
            return Ok("The Id has been successfully been deleted");

        }
    }
}