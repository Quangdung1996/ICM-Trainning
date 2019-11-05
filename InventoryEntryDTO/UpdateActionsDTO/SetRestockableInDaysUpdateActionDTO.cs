using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class SetRestockableInDaysUpdateActionDTO
    {
        public string Action => "setRestockableInDays";
        public int RestockableInDays { get; set; }
    }
}
