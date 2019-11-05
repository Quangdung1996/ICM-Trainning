using commercetools.Sdk.Client;
using commercetools.Sdk.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IClient _client;

        public ProductsController(IClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            PagedQueryResult<Product> products = _client.ExecuteAsync(new QueryCommand<Product>()).Result;
            return products.Results;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(Guid id)
        {
            var a = _client.ExecuteAsync(new GetByIdCommand<Product>(id)).Result;
            return a;
        }

        [HttpGet("Key/{key}")]
        public Product GetByKey(string key)
        {
            return _client.ExecuteAsync(new GetByKeyCommand<Product>(key)).Result;
        }
    }
}