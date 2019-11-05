using commercetools.Sdk.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doamin.Models
{
    public class ActionManager
    {
        [Required]
        public string Action { get; set; }
        [Required]
        public long Quantity { get; set; }

    }
}
