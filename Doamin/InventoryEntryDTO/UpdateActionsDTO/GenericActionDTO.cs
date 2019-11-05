using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doamin.InventoryEntryDTO.UpdateActionsDTO
{
    public class GenericActionDTO
    {
        public string Action { get; set; }
        [Required]
        public long Quantity { get; set; }
    }
}
