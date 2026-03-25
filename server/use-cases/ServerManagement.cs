using chat_app.server.ports;

namespace chat_app.server.use_cases;

public class ServerManagement(IChatServer chatServer)
{
    public async Task ExecuteAsync(int port = 5000)
    {
        await chatServer.StartServerAsync(port);
    }

    public void Stop()
    {
        chatServer.StopServer();
    }
}
