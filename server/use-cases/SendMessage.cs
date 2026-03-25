using chat_app.server.ports;

namespace chat_app.server.use_cases;

public class SendMessage(IMessageBroadcaster broadcaster)
{
    public async Task ExecuteAsync(byte[] message)
    {
        await broadcaster.BroadcastAsync(message);
    }
}
