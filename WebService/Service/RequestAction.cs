using commercetools.Sdk.Domain;
using commercetools.Sdk.Domain.InventoryEntries;
using Doamin.InventoryEntryDTO.UpdateActionsDTO;
using Doamin.Models;
using System.Collections.Generic;
using WebService.Interface;

namespace WebService.Service
{
    public class RequestAction : IRequestAction
    {
        public RequestAction()
        { }

        public List<UpdateAction<InventoryEntry>> Handler(List<ActionManager> actions)
        {
            var ListAction = new List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>>();
            foreach (var item in actions)
            {
                if (item.Action.Contains("addQuantity"))
                {
                    var actionUpdate = new AddQuantityUpdateAction();
                    actionUpdate.Quantity = item.Quantity;
                    ListAction.Add(actionUpdate);
                }
                else if (item.Action.Contains("removeQuantity"))
                {
                    var actionUpdate = new RemoveQuantityUpdateAction();
                    actionUpdate.Quantity = item.Quantity;
                    ListAction.Add(actionUpdate);
                }
                else if (item.Action.Contains("changeQuantity"))
                {
                    var actionUpdate = new ChangeQuantityUpdateAction();
                    actionUpdate.Quantity = item.Quantity;
                    ListAction.Add(actionUpdate);
                }
            }
            return ListAction;
        }

        public List<UpdateAction<InventoryEntry>> SetFieldDTO(SetCustomFieldUpdateActionDTO action)
        {
            var ListAction = new List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>>();

            var actionSetField = new SetCustomFieldUpdateAction();
            actionSetField.Name = action.Name;
            actionSetField.Value = action.Value;
            ListAction.Add(actionSetField);
            return ListAction;
        }

        public List<UpdateAction<InventoryEntry>> SetTypeDTO(SetCustomTypeUpdateActionDTO action)
        {
            var ListAction = new List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>>();

            var actionSetField = new SetCustomTypeUpdateAction();
            actionSetField.Fields = action.Fields;
            actionSetField.Type = action.Type;
            ListAction.Add(actionSetField);
            return ListAction;
        }

        public List<UpdateAction<InventoryEntry>> SetExpectedDeliveryDTO(SetExpectedDeliveryUpdateActionDTO action)
        {
            var ListAction = new List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>>();

            var actionSetField = new SetExpectedDeliveryUpdateAction();
            actionSetField.ExpectedDelivery = action.ExpectedDelivery;
            ListAction.Add(actionSetField);
            return ListAction;
        }

        public List<UpdateAction<InventoryEntry>> SetRestockableInDays(SetRestockableInDaysUpdateActionDTO action)
        {
            var ListAction = new List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>>();

            var actionSetField = new SetRestockableInDaysUpdateAction();
            actionSetField.RestockableInDays = action.RestockableInDays;
            ListAction.Add(actionSetField);
            return ListAction;
        }
        public List<UpdateAction<InventoryEntry>> SetSupplyChannel(SetSupplyChannelUpdateActionDTO action)
        {
            var ListAction = new List<commercetools.Sdk.Domain.UpdateAction<InventoryEntry>>();

            var actionSetField = new SetSupplyChannelUpdateAction();
            actionSetField.SupplyChannel = action.SupplyChannel;
            ListAction.Add(actionSetField);
            return ListAction;
        }

    }
}