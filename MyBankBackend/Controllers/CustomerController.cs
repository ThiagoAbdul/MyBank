using Microsoft.AspNetCore.Mvc;

namespace MyBank.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController: ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("test")]
        public Object Test()
        {
            return new
            {
                teste = "ok"
            };
        }
    }
}
