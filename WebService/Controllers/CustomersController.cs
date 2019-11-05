using commercetools.Sdk.Client;
using commercetools.Sdk.Domain;
using commercetools.Sdk.Domain.Customers;
using Doamin.CustomersDTO;
using Doamin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Interface;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IClient _client;

        private readonly ICustomerService _customerService;

        public CustomersController(IClient client, ICustomerService customerService)
        {
            _customerService = customerService;
            _client = client;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> QueryCustomers()
        {
            PagedQueryResult<Customer> products = _client.ExecuteAsync(new QueryCommand<Customer>()).Result;
            return products.Results;
        }

        [HttpPost]
        public async Task<CustomerSignInResult> CreateCustomer([FromBody] CustomerDraftDTO customerDraft)
        {
            return await _customerService.CreateCustomer(customerDraft);
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomerById(string id)
        {
            return await _customerService.GetCustomerById(id);
        }

        [HttpGet("key={key}")]
        public async Task<Customer> GetCustomerByKey(string key)
        {
            return await _customerService.GetCustomerByKey(key);
        }

        //[HttpPost("UpdateCustomerById/{id}")]
        //public async Task<Customer> UpdateCustomerById(string id, [FromBody] List<ActionManager> actions, int version = 0)
        //{
           
        //    return _client.ExecuteAsync(new UpdateByIdCommand<Customer>(id,version,actions)).Result;
        //}
    }
}