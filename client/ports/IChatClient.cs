namespace chat_app.client.ports;

public interface IChatClient
{
    Task ConnectAsync(string ip, int port);
    Task SendAsync(byte[] data);
    void Disconnect();

    // Ağdan bir mesaj geldiğinde üst katmanlara haber vermek için bir Event
    event Action<string> OnMessageReceived;
}