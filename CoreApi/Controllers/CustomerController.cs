using CoreApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomers();

            if(!customers.Any()) 
            { 
                return NotFound();
            }

            return Ok(customers);
        }
    }
}
