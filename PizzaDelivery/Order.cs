using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    /// <summary>
    /// Class which create an order
    /// </summary>
    internal class Order
    {
        /// <summary>
        /// id of order
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Description of order
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// constructors of Order
        /// </summary>
        public Order(string description, string status)
        {
            OrderId = Guid.NewGuid();
            Description = description;
        }

        public Order() 
        {

        }

        public Order(Guid orderId, string description, string status)
        {
            OrderId = orderId;
            Description = description;
        }
    }
}
