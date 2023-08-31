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
        public List <Person> Persons {  get; set; } = new List<Person>();

        /// <summary>
        /// List of orders id which employee need to delivery
        /// </summary>
        [JsonIgnore]
        public List <Guid> OrdersId { get => _ordersId; set => _ordersId = value; }

        /// <summary>
        /// List of clients id whom employee need to delivery an order
        /// </summary>
        [JsonIgnore]
        public List <Guid> ClientsId { get => _clientId; set => _clientId = value; }

        /// <summary>
        /// List where employee can find data about order
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// List where employee can find data about client
        /// </summary>
        public List<Client> Clients { get; set; } = new List<Client>();
        
        /// <summary>
        /// Constructors of DeliveryMan 
        /// </summary>
        public DeliveryMan(Guid workerId, List <Order> orders, List <Person> persons, List <Client> clients)
        {
            WorkerId = workerId;
            Orders = orders;
            Persons = persons;
            Clients = clients;
            _ordersId.AddRange(orders.Select(o => o.OrderId));
            _clientId.AddRange(clients.Select(c => c.ClientId));
        }
        public DeliveryMan(List<Order> orders, List <Person> persons, List<Client> clients)
        {
            WorkerId = Guid.NewGuid();  
            Orders = orders;
            Persons = persons;
            _ordersId.AddRange(orders.Select(o => o.OrderId));
            Clients = clients;
            _clientId.AddRange(clients.Select(c=>c.ClientId));
        }

        public DeliveryMan() 
        {

        }
    }
}
