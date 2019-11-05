using System.ComponentModel.DataAnnotations;

namespace Doamin.InventoryEntryDTO.UpdateActionsDTO
{
    public class AddQuantityUpdateActionDTO
    {
        public string Action => "addQuantity";

        [Required]
        public long Quantity { get; set; }
    }
}