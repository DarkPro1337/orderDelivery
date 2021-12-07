using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderDelivery.Models
{
    public class OrderModel
    {
        public Guid ID { get; set; }
        public int OrderID { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddress { get; set; }
        public double PackageWeight { get; set; }
        public DateTime PickupDate { get; set; }
    }
}
