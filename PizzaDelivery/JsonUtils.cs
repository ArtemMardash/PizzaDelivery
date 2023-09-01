using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace PizzaDelivery
{
    /// <summary>
    /// Work with json
    /// </summary>
    internal class JsonUtils
    {
        /// <summary>
        /// Setting to serialize to json
        /// </summary>
        public static readonly JsonSerializerSettings JsonSeetings = new()
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter()
                {
                    DateTimeStyles = System.Globalization.DateTimeStyles.AssumeUniversal
                }
            }
        };

        /// <summary>
        /// Person to json
        /// </summary>
        public static string ToJson(Person person)
        {
            var json = JsonConvert.SerializeObject(person, JsonSeetings);
            return json;
        }

        /// <summary>
        /// Client to json
        /// </summary>
        public static string ToJson(Client client)
        {
            var json = JsonConvert.SerializeObject(client, JsonSeetings);
            return json;
        }

        /// <summary>
        /// DeliveryMan to json
        /// </summary>
        public static string ToJson(DeliveryMan deliveryMan)
        {
            var json = JsonConvert.SerializeObject(deliveryMan, JsonSeetings);
            return json;
        }

        /// <summary>
        /// Order to json
        /// </summary>
        public static string ToJson(Order order)
        {
            var json = JsonConvert.SerializeObject(order, JsonSeetings);
            return json;
        }

        public static void SaveToJson(List <DeliveryMan> deliveryMen)
        {
            var clients = deliveryMen.SelectMany(c => c.Clients);
            var orders = deliveryMen.SelectMany(o => o.Orders);
            var persons = deliveryMen.SelectMany(p => p.Persons);

            File.WriteAllText("persons.json", JsonConvert.SerializeObject(persons, JsonSeetings));
            File.WriteAllText("orders.json", JsonConvert.SerializeObject(orders, JsonSeetings));
            File.WriteAllText("clients.json", JsonConvert.SerializeObject(clients, JsonSeetings));
            File.WriteAllText("deliveryMen.json", JsonConvert.SerializeObject(deliveryMen, JsonSeetings));
        }

        public static List<DeliveryMan> LoadFromJson(string fileName)
        {
            var jsonFromFille = File.ReadAllText(fileName);
            var deliveryMen = JsonConvert.DeserializeObject<List<DeliveryMan>>(jsonFromFille, JsonSeetings);

            var ordersFromFile = File.ReadAllText("orders.json");
            var orders =  JsonConvert.DeserializeObject <List<Order>>(ordersFromFile, JsonSeetings);

            var clientsFromFile = File.ReadAllText("clients.json");
            var clients = JsonConvert.DeserializeObject <List<Client>>(clientsFromFile, JsonSeetings);

            var personsFromFile = File.ReadAllText("persons.json");
            var persons =  JsonConvert.DeserializeObject<List<Person>>(personsFromFile, JsonSeetings);

            return deliveryMen;
        }
    }
}
