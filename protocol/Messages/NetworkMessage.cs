namespace chat_app.protocol.Messages;

public abstract class NetworkMessage(MessageType type)
{
    public MessageType Type { get; set; } = type;
}
