using chat_app.protocol.Messages;
using System.Text.Json;

namespace chat_app.protocol.Serialization;

public class MessageSerializer
{
    public static string Serialize(NetworkMessage message)
    {
        return JsonSerializer.Serialize(message);
    }

    public static NetworkMessage Deserialize(string json)
    {
        return JsonSerializer.Deserialize<NetworkMessage>(json);
    }
}

