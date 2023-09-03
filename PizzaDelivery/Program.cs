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
            deliveryMen.Clear();
            var persons = new List<Person>();

            var orders = new List<Order>();

            var clients = new List<Client>();


            Order order = new Order("Peperoni and wings");
            Person person = new Person("Artem", "Mardakhaev", DateTime.Parse("02.04.2004"));
            Person person2 = new Person("Client", "First", DateTime.Parse("01.01.1999"));
            Client client = new Client(person2, order, "USA");
            orders.Add(order);
            persons.Add(person);
            persons.Add(person2);
            clients.Add(client);
            DeliveryMan deliveryMan = new DeliveryMan(orders, person, clients);
            deliveryMen.Add(deliveryMan);

            JsonUtils.SaveToJson(deliveryMen);
        }
    }
}
