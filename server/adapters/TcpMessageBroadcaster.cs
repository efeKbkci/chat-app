using chat_app.server.ports;

namespace chat_app.server.adapters;

public class TcpMessageBroadcaster(IClientManager clientManager) : IMessageBroadcaster
{
    public async Task BroadcastAsync(byte[] message)
    {
        foreach (var client in clientManager.GetAllClients())
        {
            await client.SendAsync(message);
        }
    }
}
