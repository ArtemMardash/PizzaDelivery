using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    /// <summary>
    /// Person who make an order
    /// </summary>
    internal class Client
    {
        /// <summary>
        /// id of order that he did
        /// </summary>
        private Guid _orderId { get; set; }

        /// <summary> 
        /// id of client
        /// </summary>
        public Guid ClientId { get; set; }
        
        /// <summary>
        /// Person data of client
        /// </summary>
        public Person Persons { get; set; }

        /// <summary>
        /// Address of client
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Order that client did
        /// </summary>
        public Order MyOrder { get; set; }
        /// <summary>
        /// client constructor
        /// </summary>
        public Client()
        {

        }

        public Client ( Guid clientId, Person persons, Order myOrder, string address)
        {
            ClientId = clientId;
            Persons = persons;
            MyOrder = myOrder;
            _orderId = myOrder.OrderId;
            Address = address;
        }

        public Client( Person persons, Order myOrder, string address)
        {
            ClientId = Guid.NewGuid();
            Persons = persons;
            MyOrder = myOrder;
            _orderId = myOrder.OrderId;
            Address = address;
        }
    }
}
