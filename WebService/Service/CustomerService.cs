using commercetools.Sdk.Client;
using commercetools.Sdk.Domain.Customers;
using Doamin.CustomersDTO;
using Doamin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Interface;

namespace WebService.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IClient _client;

        public CustomerService(IClient client)
        {
            _client = client;
        }

        public async Task<CustomerSignInResult> CreateCustomer(CustomerDraftDTO customerDraftDTO)
        {
            var customerDraft = new CustomerDraft();
            customerDraft.Email = customerDraftDTO.Email;
            customerDraft.FirstName = customerDraftDTO.FirstName;
            customerDraft.LastName = customerDraftDTO.LastName;
            customerDraft.Password = customerDraftDTO.Password;
            return _client.ExecuteAsync(new SignUpCustomerCommand(customerDraft)).Result as CustomerSignInResult;
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            return _client.ExecuteAsync(new GetByIdCommand<Customer>(id)).Result;
        }

        public async Task<Customer> GetCustomerByKey(string key)
        {
            return _client.ExecuteAsync(new GetByKeyCommand<Customer>(key)).Result;
        }

        //public async Task<Customer> UpdateCustomerById(string id, List<ActionManager> actions, int version = 0)
        //{
        //    if (version == 0)
        //    {
        //        Customer resultInventoryEntry = _client.ExecuteAsync(new GetByIdCommand<Customer>(id)).Result;
        //        version = resultInventoryEntry.Version;
        //    }
        //    var ListAction = new List<commercetools.Sdk.Domain.UpdateAction<Customer>>();
        //    foreach(var item in actions)
        //    {
        //        if(item.Action.Contains(""))
        //    }
        //}
    }
}