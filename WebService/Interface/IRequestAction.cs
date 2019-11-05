using commercetools.Sdk.Domain;
using Doamin.InventoryEntryDTO.UpdateActionsDTO;
using Doamin.Models;
using System.Collections.Generic;

namespace WebService.Interface
{
    public interface IRequestAction
    {
        List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>> Handler(List<ActionManager> actions);

        List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>> SetFieldDTO(SetCustomFieldUpdateActionDTO action);

        List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>> SetTypeDTO(SetCustomTypeUpdateActionDTO action);

        List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>> SetExpectedDeliveryDTO(SetExpectedDeliveryUpdateActionDTO action);

        List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>> SetRestockableInDays(SetRestockableInDaysUpdateActionDTO action);

        List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>> SetSupplyChannel(SetSupplyChannelUpdateActionDTO action); 
    }
}