using commercetools.Sdk.Domain;
using commercetools.Sdk.Domain.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class SetSupplyChannelUpdateActionDTO
    {
        public string Action => "setSupplyChannel";
        public Reference<Channel> SupplyChannel { get; set; }
    }
}
