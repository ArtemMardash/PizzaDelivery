using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace PizzaDelivery
{
    internal class JsonUtils
    {
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

        public static string ToJson(Person person)
        {
            var json = JsonConvert.SerializeObject(person, JsonSeetings);
            return json;
        }

        public static string ToJson(Client client)
        {
            var json = JsonConvert.SerializeObject(client, JsonSeetings);
            return json;
        }

        public static string ToJson(DeliveryMan deliveryMan)
        {
            var json = JsonConvert.SerializeObject(deliveryMan, JsonSeetings);
            return json;
        }

        public static string ToJson(Order order)
        {
            var json = JsonConvert.SerializeObject(order, JsonSeetings);
            return json;
        }
    }
}
