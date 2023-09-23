using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var deliveryMen = JsonUtils.LoadFromJson("deliveryMen.json");
            var clients = JsonUtils.LoadFromJsonClient("clients.json");
            var orders = JsonUtils.LoadFromJsonOrder("order,json");
            var persons = JsonUtils.LoadFromJsonPerson("persons.json");

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("If you want to see all data about workers - press 1");
                Console.WriteLine("If you want to see all data about clients - press 2");
                Console.WriteLine("If you want to make an order - press 3");
                Console.WriteLine("if you want to cancel an order - press 4");
                Console.WriteLine("If you finish -  press 0");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("exit");
                        flag = false;
                        break;
                    case "1":
                        foreach (var deliveryMan in deliveryMen)
                        {
                            Console.WriteLine();
                            Console.WriteLine
                                (
                                $"WorkerId = {deliveryMan.WorkerId}\n" +
                                $"First name = {deliveryMan.Persons.Name}\n" +
                                $"Last name = {deliveryMan.Persons.LastName} \n" +
                                $"Date of bitrh = {deliveryMan.Persons.BirthDate} \n"
                                );
                            foreach (var ordersId in deliveryMan.OrdersId)
                            {
                                Console.WriteLine($"Order's id = {ordersId}");
                            }
                        }
                        break;
                    case "2":
                        foreach (var client1 in clients)
                        {
                            Console.WriteLine();

                            Console.WriteLine
                                (
                                $"Client id = {client1.ClientId} \n" +
                                $"First name = {client1.Persons.Name} \n" +
                                $"Last name = {client1.Persons.LastName} \n" +
                                $"Date of birth = {client1.Persons.BirthDate}\n" +
                                $"Order = {client1.OrderId} \n"
                                );
                        }
                        break;
                    case "3":
                        var deliveryMan1 = deliveryMen.FirstOrDefault();
                        deliveryMen.Remove(deliveryMan1);
                        Console.WriteLine("What do you want to order?");
                        var description = Console.ReadLine();
                        Order newOrder = new Order(description);
                        orders.Add(newOrder);
                        Console.WriteLine("Enter your name");
                        var name = Console.ReadLine();
                        Console.WriteLine("Enter your last name");
                        var lastName = Console.ReadLine();
                        Console.WriteLine("Enter your date of birth");
                        var dateBirth = Console.ReadLine();
                        if (!DateTime.TryParse(dateBirth, out DateTime birthDay))
                        {
                            Console.WriteLine("Invalid date of birth");
                        }
                        Console.WriteLine("What is your address?");
                        var address = Console.ReadLine();
                        Person person3 = new Person(name, lastName, birthDay);
                        Client client = new Client(person3, newOrder, address);
                        clients.Add(client);
                        deliveryMan1.ClientsId.Add(client.ClientId);
                        deliveryMan1.OrdersId.Add(newOrder.OrderId);
                        deliveryMen.Add(deliveryMan1);
                        persons.Add(person3);
                        Console.WriteLine("Thank you for your order");
                        JsonUtils.SaveToJsonDeliveryMan(deliveryMen);
                        JsonUtils.SaveToJsonClient(clients);
                        JsonUtils.SaveToJsonOrder(orders);
                        JsonUtils.SaveToJsonPerson(persons);
                        break;
                    case "4":
                        Console.WriteLine("Enter an order id");
                        var id = Console.ReadLine();
                        if(!Guid.TryParse(id, out Guid id2))
                        {
                            Console.WriteLine("invelid id of order");
                            break;
                        }
                        var orderToDel = orders.FirstOrDefault(o => o.OrderId == id2);
                        if(orderToDel == null)
                        {
                            Console.WriteLine("This order doesn't exist");
                            break;
                        }
                        orders.Remove(orderToDel);
                        JsonUtils.SaveToJsonOrder(orders);
                        Console.WriteLine("Order was canceled");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }


            //deliveryMen.Clear();
            //clients.Clear();
            //orders.Clear();
            //persons.Clear();

            //Order order = new Order("Peperoni and wings");
            //Person person1 = new Person("Artem", "Mardakhaev", DateTime.Parse("02.04.2004"));
            //Person person2 = new Person("Client", "First", DateTime.Parse("01.01.1999"));
            //Client client = new Client(person2, order, "USA");
            //orders.Add(order);
            //persons.Add(person1);
            //persons.Add(person2);
            //clients.Add(client);
            //DeliveryMan deliveryMan = new DeliveryMan(orders, person1, clients);
            //deliveryMen.Add(deliveryMan);

            //JsonUtils.SaveToJsonDeliveryMan(deliveryMen);
            //JsonUtils.SaveToJsonPerson(persons);
            //JsonUtils.SaveToJsonClient(clients);
            //JsonUtils.SaveToJsonOrder(orders);
        }
    }
}
