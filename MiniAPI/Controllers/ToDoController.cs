using Microsoft.AspNetCore.Mvc;

namespace MiniAPI.Controllers
{



    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        //     private static readonly string[] Summaries = new[]
        //     {
        //     "Freezing"
        // };

        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetToDoAPI")]
        public IEnumerable<Task> Get()
        {
            return Enumerable.Range(1, 2).Select(index => new Task
            {


            })
            .ToArray();
        }
    }


}