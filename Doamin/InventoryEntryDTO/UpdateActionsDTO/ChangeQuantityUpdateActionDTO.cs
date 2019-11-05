using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doamin.InventoryEntryDTO.UpdateActionsDTO
{
    public class ChangeQuantityUpdateActionDTO
    {
        public string Action => "changeQuantity";
        [Required]
        public long Quantity { get; set; }
    }
}
