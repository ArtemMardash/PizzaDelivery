using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    internal class DeliveryMan
    {

        private List<Guid> _ordersId = new List<Guid>();

        private List<Guid> _clientId = new List<Guid>();


        public Guid WorkerId { get; set; }

        public List <Person> Persons {  get; set; } = new List<Person>();

        public List <Guid> OrdersId { get => _ordersId; set => _ordersId = value; }

        public List<Order> Orders { get; set; } = new List<Order>();
        

        public DeliveryMan(Guid workerId, List <Order> orders, List <Person> persons)
        {
            WorkerId = workerId;
            Orders = orders;
            Persons = persons;
            _ordersId.AddRange(orders.Select(o => o.OrderId));
        }
        public DeliveryMan(List<Order> orders, List <Person> persons)
        {
            WorkerId = Guid.NewGuid();  
            Orders = orders;
            Persons = persons;
            _ordersId.AddRange(orders.Select(o => o.OrderId));
        }
    }
}
