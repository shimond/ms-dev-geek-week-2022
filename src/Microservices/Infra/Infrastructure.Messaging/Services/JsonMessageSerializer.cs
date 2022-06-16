using Infrastructure.Messaging.Contract;
using Infrastructure.Messaging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.Services
{
    public class JsonMessageSerializer : IMessageSerializer
    {
   
        public T Deserilize<T>(byte[] data) where T : Message
        {
            string value = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<T>(value);
        }

        public object Deserilize(byte[] data, Type t)
        {
            string value = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize(value, t);
        }

        public byte[] SerializeToBytes(Message message)
        {
            var data = JsonSerializer.Serialize(message);
            return Encoding.UTF8.GetBytes(data);
        }
    }
}
