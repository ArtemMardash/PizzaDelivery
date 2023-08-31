using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    internal class Order
    {
        public Guid OrderId { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public Order(string description, string status)
        {
            OrderId = Guid.NewGuid();
            Description = description;
            Status = status;
        }

        public Order() 
        {

        }

        public Order(Guid orderId, string description, string status)
        {
            OrderId = orderId;
            Description = description;
            Status = status;
        }
    }
}
