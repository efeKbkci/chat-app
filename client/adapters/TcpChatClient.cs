// client/adapters/TcpChatClient.cs
using chat_app.client.ports;
using System.Net.Sockets;
using System.Text;

namespace chat_app.client.adapters;

public class TcpChatClient : IChatClient
{
    private TcpClient _client;
    private NetworkStream _stream;

    public event Action<string>? OnMessageReceived;

    public async Task ConnectAsync(string ip, int port)
    {
        _client = new TcpClient();
        await _client.ConnectAsync(ip, port);
        _stream = _client.GetStream();

        // Bağlantı kurulur kurulmaz dinlemeye başla (Fire and Forget)
        _ = ListenAsync();
    }

    public async Task SendAsync(byte[] data)
    {
        if (_stream != null && _stream.CanWrite)
        {
            await _stream.WriteAsync(data, 0, data.Length);
        }
    }

    public void Disconnect()
    {
        _stream?.Close();
        _client?.Close();
    }

    private async Task ListenAsync()
    {
        var buffer = new byte[4096];
        try
        {
            while (true)
            {
                var bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) break; // Sunucu kapandı

                string receivedJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // Mesaj geldiğini Use Case'e haber ver
                OnMessageReceived?.Invoke(receivedJson);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bağlantı koptu: {ex.Message}");
        }
        finally
        {
            Disconnect();
        }
    }
}