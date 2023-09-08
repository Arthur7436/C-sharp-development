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

        public ToDoControllerController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Task> Get()
        {
            return Enumerable.Range(1, 2).Select(index => new Task
            {


            })
            .ToArray();
        }
    }


}