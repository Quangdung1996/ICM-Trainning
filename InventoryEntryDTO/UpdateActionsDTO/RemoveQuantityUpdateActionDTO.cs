using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.InventoryEntryDTO.UpdateActionsDTO
{
    public class RemoveQuantityUpdateActionDTO
    {
        public string Action => "removeQuantity";
        [Required]
        public long Quantity { get; set; }
    }
}
