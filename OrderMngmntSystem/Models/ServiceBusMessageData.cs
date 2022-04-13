using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMngmntSystem.Models
{
    public class ServiceBusMessageData
    {
        public int? ProductId { get; set; }
        public string productName { get; set; }
        public string productCategory { get; set; }
        public int? customerId { get; set; }

        public string customerName { get; set; }
        public string Address { get; set; }
        public int?  OrderId { get; set; }
    }
}
