using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.DTO.CustomerDto;
using RestaurantReservation.Service.IServices;
using RestaurantReservation.Validator;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReservation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1.0/customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly CustomerValidator _customerValidator = new CustomerValidator();

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Customer> customers = await _customerService.GetAllAsync();
            List<CustomerDto> customersToBeReturned = _mapper.Map<List<CustomerDto>>(customers);
            return Ok(customersToBeReturned);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Customer customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            CustomerDto customerToBeReturned = _mapper.Map<CustomerDto>(customer);
            return Ok(customerToBeReturned);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _customerService.ExistByIdAsync(id))
            {
                return NotFound();
            }
            await _customerService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerDto customerDto)
        {
            if (customerDto == null || id == null)
            {
                return BadRequest();
            }

            Customer oldCustomer = await _customerService.GetByIdAsync(id);
            if (oldCustomer == null)
            {
                return NotFound();
            }

            _mapper.Map(customerDto, oldCustomer);
            ValidationResult results = _customerValidator.Validate(oldCustomer);
            if (!results.IsValid)
            {
                return BadRequest(new { Errors = results.Errors.Select(e => e.ErrorMessage) });
            }
            await _customerService.UpdateAsync(oldCustomer);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerDto customerDto)
        {
            Customer customerToBeAdded = _mapper.Map<Customer>(customerDto);
            ValidationResult results = _customerValidator.Validate(customerToBeAdded);
            if (!results.IsValid)
            {
                return BadRequest(new { Errors = results.Errors.Select(e => e.ErrorMessage) });
            }
            await _customerService.AddAsync(customerToBeAdded);
            return NoContent();
        }

    }
}