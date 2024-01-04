using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBank.DTOs.Inputs;
using MyBank.Models;
using MyBank.Services;

namespace MyBank.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, 
                                IAccountService accountService,
                                IMapper mapper)
        {
            _logger = logger;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult OpenAccount([FromBody] OpenAccountRequest request)
        {
            Customer customer = _mapper.Map<Customer>(request.Customer);
            _logger.LogInformation(customer.BirthDate.ToString()); 
            return NoContent();
        }
    }
}