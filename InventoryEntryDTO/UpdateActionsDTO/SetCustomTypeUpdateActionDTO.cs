using commercetools.Sdk.Domain;

namespace Domain.InventoryEntryDTO.UpdateActionsDTO
{
    public class SetCustomTypeUpdateActionDTO
    {
        public string Action => "setCustomType";
        public ResourceIdentifier Type { get; set; }
        public Fields Fields { get; set; }
    }
}