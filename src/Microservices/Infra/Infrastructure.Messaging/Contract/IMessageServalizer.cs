using Infrastructure.Messaging.Model;

namespace Infrastructure.Messaging.Contract;
public interface IMessageSerializer
{
    byte[] SerializeToBytes(Message message);
    T Deserilize<T>(byte[] data) where T : Message;
    object Deserilize(byte[] data, Type t);
}
