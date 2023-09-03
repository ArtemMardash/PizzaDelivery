using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    /// <summary>
    /// Employee who delivery an order
    /// </summary>
    internal class DeliveryMan
    {
        /// <summary>
        /// List of orders id that he need to delivery
        /// </summary>
        private List<Guid> _ordersId = new List<Guid>();

        /// <summary>
        /// List of client id whom he nned to delivery orders
        /// </summary>
        private List<Guid> _clientId = new List<Guid>();

        /// <summary>
        /// id of employee
        /// </summary>
        public Guid WorkerId { get; set; }

        /// <summary>
        /// Person data of employee
        /// </summary>
        public Person Persons { get; set; }

        /// <summary>
        /// List of orders id which employee need to delivery
        /// </summary>
        public List<Guid> OrdersId { get => _ordersId; set => _ordersId = value; }

        /// <summary>
        /// List of clients id whom employee need to delivery an order
        /// </summary>
        public List<Guid> ClientsId { get => _clientId; set => _clientId = value; }

        /// <summary>
        /// List where data about orders
        /// </summary>
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// List 
        /// </summary>
        [JsonIgnore]
        public List<Client> Clients { get; set; } = new List<Client>();

        /// <summary>
        /// Constructors of DeliveryMan 
        /// </summary>
        public DeliveryMan(Guid workerId, List<Order> orders, Person persons, List<Client> clients)
        {
            WorkerId = workerId;
            Orders = orders;
            Persons = persons;
            Clients = clients;
            OrdersId.AddRange(orders.Select(o => o.OrderId));
            ClientsId.AddRange(clients.Select(c => c.ClientId));
        }
        public DeliveryMan(List<Order> orders, Person persons, List<Client> clients)
        {
            WorkerId = Guid.NewGuid();
            Orders = orders;
            Persons = persons;
            OrdersId.AddRange(orders.Select(o => o.OrderId));
            Clients = clients;
            ClientsId.AddRange(clients.Select(c => c.ClientId));
        }

        public DeliveryMan()
        {

        }
    }
}
