using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    internal class Client
    {
        private Guid _orderId { get; set; }

        public Guid ClientId { get; set; }
        
        public List <Person> Persons { get; set; } = new List<Person>();

        public Order MyOrder { get; set; }

        public Client()
        {

        }

        public Client ( Guid clientId, List<Person> persons, Order myOrder)
        {
            ClientId = clientId;
            Persons = persons;
            MyOrder = myOrder;
            _orderId = myOrder.OrderId;
        }

        public Client( List<Person> persons, Order myOrder)
        {
            ClientId = Guid.NewGuid();
            Persons = persons;
            MyOrder = myOrder;
            _orderId = myOrder.OrderId;
        }
    }
}
