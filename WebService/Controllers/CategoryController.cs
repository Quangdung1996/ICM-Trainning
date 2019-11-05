using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercetools.Sdk.Client;
using commercetools.Sdk.Domain;
using commercetools.Sdk.Domain.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IClient _client;
        public CategoryController(IClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            var command = new QueryCommand<Category>();
            command.SetOffset(10);
            PagedQueryResult<Category> category =  _client.ExecuteAsync(new QueryCommand<Category>().SetLimit(10)).Result;
            return category.Results;
        }
        [HttpGet("{id}")]
        public async Task<Category> GetById(Guid id)
        {
            Category category = new Category();
            category = await _client.ExecuteAsync(new GetByIdCommand<Category>(id));
            return category;
        }



    }
}