using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBank.DTOs.Inputs;
using MyBank.DTOs.Outputs;
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
        private readonly IMapper _mapper;
        public CustomerController(ILogger<CustomerController> logger, 
                                ICustomerService customerService,
                                IMapper mapper)
        {
            _logger = logger;
            _customerService = customerService;
            _mapper = mapper;
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
        public async Task<IActionResult> RegisterCustomer([FromBody]CustomerInputModel request)
        {
            Customer customer = _mapper.Map<Customer>(request);
            Customer saved = await _customerService.RegisterCustomer(customer);
            CustomerViewModel response = _mapper.Map<CustomerViewModel>(customer);
            return Created($"customers/{saved.Id}", response);
        }
    }
}
