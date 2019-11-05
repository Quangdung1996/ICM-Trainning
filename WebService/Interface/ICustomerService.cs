using commercetools.Sdk.Domain.Customers;
using Doamin.CustomersDTO;
using Doamin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebService.Interface
{
    public interface ICustomerService
    {
        Task<CustomerSignInResult> CreateCustomer(CustomerDraftDTO customerDraftDTO);

        Task<Customer> GetCustomerById(string id);

        Task<Customer> GetCustomerByKey(string key);

        //Task<Customer> UpdateCustomerById(string id, List<ActionManager> actions, int version = 0);
    }
}