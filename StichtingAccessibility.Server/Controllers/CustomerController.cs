using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StichtingAccessibility.Server.Models;

namespace DotnetWebApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly StichtingDbContext _context;
        public CustomerController(StichtingDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET: api/Customer/1
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }
    }
}