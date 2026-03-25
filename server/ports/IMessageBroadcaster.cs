namespace chat_app.server.ports;

public interface IMessageBroadcaster
{
    Task BroadcastAsync(byte[] message);
}
