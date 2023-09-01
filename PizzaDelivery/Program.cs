using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var deliveryMen = JsonUtils.LoadFromJson("deliveryMen.json");
            var persons = new List<Person>();

            var orders = new List<Order>();

            var clients = new List<Client>();


            Order order = new Order("Peperoni and wings");
            Person person = new Person("Artem", "Mardakhaev", DateTime.Parse("02.04.2004"));
            Client client = new Client(new Person("Client", "first", DateTime.Parse("01.01.1999")), new Order("Regular pizza"), "USA");
            orders.Add(order);
            persons.Add(person);
            clients.Add(client);
            DeliveryMan deliveryMan = new DeliveryMan(orders, persons, clients);
            deliveryMen.Add(deliveryMan);

            JsonUtils.SaveToJson(deliveryMen);
        }
    }
}
