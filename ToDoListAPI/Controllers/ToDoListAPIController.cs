using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using ToDoListAPI;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/potato/[controller]")]
    public class PotatoThisIsController : ControllerBase
    {
        private static List<Task> tasks = new List<Task>();
        private readonly ILogger<PotatoThisIsController> _logger;

        public PotatoThisIsController(ILogger<PotatoThisIsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTaskAPI")]
        public IActionResult Get()
        {
            if (tasks == null || tasks.Count == 0)
            {
                return NotFound("Bro no task was found Please use a different API call!");
            }

            return Ok(tasks);
        }
    }


}