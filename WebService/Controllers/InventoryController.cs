using commercetools.Sdk.Client;
using commercetools.Sdk.Domain;
using Doamin.InventoryEntryDTO.UpdateActionsDTO;
using Doamin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Interface;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IClient _client;
        private readonly IRequestAction _request;

        public InventoryController(IClient client, IRequestAction request)
        {
            _request = request;
            _client = client;
        }

        [HttpGet]
        public async Task<IEnumerable<InventoryEntry>> QueryInventory()
        {
            PagedQueryResult<InventoryEntry> products = _client.ExecuteAsync(new QueryCommand<InventoryEntry>()).Result;
            return products.Results;
        }

        [HttpGet("{id}")]
        public async Task<InventoryEntry> GetInventoryById(string id)
        {
            var result = _client.ExecuteAsync(new GetByIdCommand<InventoryEntry>(id)).Result;
            return result;
        }

        [HttpPost]
        public async Task<InventoryEntry> CreateInventoryEntry([FromBody] InventoryEntryDraft inventory)
        {
            var result = _client.ExecuteAsync(new CreateCommand<InventoryEntry>(inventory)).Result;
            return result;
        }

        [HttpPost("{id}")]
        public async Task<InventoryEntry> UpdateInventoryEntryById(string id, [FromBody] List<ActionManager> actions, int version = 0)
        {
            if (version == 0)
            {
                InventoryEntry resultInventoryEntry = _client.ExecuteAsync(new GetByIdCommand<InventoryEntry>(id)).Result;
                version = resultInventoryEntry.Version;
            }
            var ListAction = _request.Handler(actions);
            var result = _client.ExecuteAsync(new UpdateByIdCommand<InventoryEntry>(id, version, ListAction)).Result;
            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInventoryEntry(string id, int version)
        {
            var result = _client.ExecuteAsync(new DeleteByIdCommand<InventoryEntry>(id, version)).Result;
            return Ok(result);
        }

        [HttpPost("AddQuantity/{id}")]
        public async Task<InventoryEntry> AddQuantity(string id, [FromBody] AddQuantityUpdateActionDTO action, int version = 0)
        {
            var GenericAction = new GenericActionDTO();
            GenericAction.Action = action.Action;
            GenericAction.Quantity = action.Quantity;
            return await Utilities<GenericActionDTO>(id, GenericAction, version); ;
        }

        [HttpPost("ChangeQuantity/{id}")]
        public async Task<InventoryEntry> ChangeQuantity(string id, [FromBody] ChangeQuantityUpdateActionDTO action, int version = 0)
        {
            var GenericAction = new GenericActionDTO();
            GenericAction.Action = action.Action;
            GenericAction.Quantity = action.Quantity;
            return await Utilities<GenericActionDTO>(id, GenericAction, version); ;
        }

        [HttpPost("RemoveQuantity/{id}")]
        public async Task<InventoryEntry> RemoveQuantity(string id, [FromBody] RemoveQuantityUpdateActionDTO action, int version = 0)
        {
            var GenericAction = new GenericActionDTO();
            GenericAction.Action = action.Action;
            GenericAction.Quantity = action.Quantity;
            return await Utilities<GenericActionDTO>(id, GenericAction, version); ;
        }

        [HttpPost("SetCustomField/{id}")]
        public async Task<InventoryEntry> SetCustomField(string id, [FromBody] SetCustomFieldUpdateActionDTO action, int version = 0)
        {
            if (version == 0)
            {
                InventoryEntry resultInventoryEntry = _client.ExecuteAsync(new GetByIdCommand<InventoryEntry>(id)).Result;
                version = resultInventoryEntry.Version;
            }
            return _client.ExecuteAsync(new UpdateByIdCommand<InventoryEntry>(id, version, _request.SetFieldDTO(action))).Result;
        }

        [HttpPost("SetCustomType/{id}")]
        public async Task<InventoryEntry> SetCustomType(string id, [FromBody] SetCustomTypeUpdateActionDTO action, int version = 0)
        {
            if (version == 0)
            {
                InventoryEntry resultInventoryEntry = _client.ExecuteAsync(new GetByIdCommand<InventoryEntry>(id)).Result;
                version = resultInventoryEntry.Version;
            }
            return _client.ExecuteAsync(new UpdateByIdCommand<InventoryEntry>(id, version, _request.SetTypeDTO(action))).Result;
        }

        [HttpPost("SetExpectedDelivery/{id}")]
        public async Task<InventoryEntry> SetExpectedDelivery(string id, [FromBody] SetExpectedDeliveryUpdateActionDTO action, int version = 0)
        {
            if (version == 0)
            {
                InventoryEntry resultInventoryEntry = _client.ExecuteAsync(new GetByIdCommand<InventoryEntry>(id)).Result;
                version = resultInventoryEntry.Version;
            }
            return _client.ExecuteAsync(new UpdateByIdCommand<InventoryEntry>(id, version, _request.SetExpectedDeliveryDTO(action))).Result;
        }

        [HttpPost("SetRestockableInDays/{id}")]
        public async Task<InventoryEntry> SetRestockableInDays(string id, [FromBody] SetRestockableInDaysUpdateActionDTO action, int version = 0)
        {
            if (version == 0)
            {
                InventoryEntry resultInventoryEntry = _client.ExecuteAsync(new GetByIdCommand<InventoryEntry>(id)).Result;
                version = resultInventoryEntry.Version;
            }
            return _client.ExecuteAsync(new UpdateByIdCommand<InventoryEntry>(id, version, _request.SetRestockableInDays(action))).Result;
        }

        [HttpPost("SetSupplyChannel/{id}")]
        public async Task<InventoryEntry> SetSupplyChannel(string id, [FromBody] SetSupplyChannelUpdateActionDTO action, int version = 0)
        {
            if (version == 0)
            {
                InventoryEntry resultInventoryEntry = _client.ExecuteAsync(new GetByIdCommand<InventoryEntry>(id)).Result;
                version = resultInventoryEntry.Version;
            }
            return _client.ExecuteAsync(new UpdateByIdCommand<InventoryEntry>(id, version, _request.SetSupplyChannel(action))).Result;
        }

        private async Task<InventoryEntry> Utilities<T>(string id, [FromBody] T action, int version = 0) where T : GenericActionDTO
        {
            if (version == 0)
            {
                InventoryEntry resultInventoryEntry = _client.ExecuteAsync(new GetByIdCommand<InventoryEntry>(id)).Result;
                version = resultInventoryEntry.Version;
            }
            var ListAction = new List<ActionManager>();
            var actionManager = new ActionManager();
            actionManager.Action = action.Action;
            actionManager.Quantity = action.Quantity;
            ListAction.Add(actionManager);
            var result = _client.ExecuteAsync(new UpdateByIdCommand<InventoryEntry>(id, version, _request.Handler(ListAction))).Result;
            return result;
        }
    }
}