using Microsoft.AspNetCore.Mvc;

namespace MiniAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        //     private static readonly string[] Summaries = new[]
        //     {
        //     "Freezing"
        // };

        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTaskAPI")]
        public IEnumerable<Task> Get()
        {
            return Enumerable.Range(1, 2).Select(index => new Task
            {


            })
            .ToArray();
        }
    }


}