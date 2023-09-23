using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ECommerceController : ControllerBase
    {


        private readonly ILogger<ECommerceController> _logger;

        public ECommerceController(ILogger<ECommerceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetECommerce")]
        public IEnumerable<E> Get()
        {



        }
    }
}