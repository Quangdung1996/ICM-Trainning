using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doamin.InventoryEntryDTO.UpdateActionsDTO
{
    public class SetExpectedDeliveryUpdateActionDTO
    {
        public string Action => "setExpectedDelivery";
        public DateTime? ExpectedDelivery { get; set; }
    }
}
