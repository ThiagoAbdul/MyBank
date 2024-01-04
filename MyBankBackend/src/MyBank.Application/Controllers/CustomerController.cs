using Microsoft.AspNetCore.Mvc;
using MyBank.Models;
using MyBank.Services;

namespace MyBank.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController: ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger, 
                                ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("test")]
        public Object Test()
        {
            return new
            {
                teste = "ok"
            };
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody]Customer customer)
        {
            Customer saved = await _customerService.RegisterCustomer(customer);
            return Created($"customers/{saved.Id}", saved);
        }
    }
}
