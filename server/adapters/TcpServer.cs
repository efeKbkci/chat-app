using chat_app.protocol.Messages;
using chat_app.server.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using chat_app.server.use_cases;

namespace chat_app.server.adapters;

// Bir kullanıcı bağlandıktan sonra, bir katılma mesajı gönderecek. Gönderilen mesaj kullanıcı hakkında bilgi içerecek

public class TcpServer(ProcessMessage processMessage, IClientManager clientManager, int port = 5000) : IChatServer
{
    private readonly TcpListener Listener = new(IPAddress.Any, port);
    private readonly ProcessMessage processMessage = processMessage;
    private readonly IClientManager clientManager = clientManager;
    private bool _isRunning;

    public async Task StartServerAsync(int port = 5000)
    {
        Listener.Start();
        _isRunning = true;

        Console.WriteLine($"TCP Server started on port {port}");

        while (_isRunning)
        {
            try
            {
                var tcpClient = await Listener.AcceptTcpClientAsync();
                var clientConnection = new TcpClientConnection(tcpClient);
                clientManager.AddClient(clientConnection);
                _ = ListenClientAsync(clientConnection);
            }
            catch (ObjectDisposedException)
            {
                // Server durdurulduğunda _listener kapandığı için bu hata fırlatılır, normaldir döngüden çıkılır.
                break;
            }
        }
    }
    public void StopServer()
    {
        Listener.Stop();
        _isRunning = false;

        foreach (var client in clientManager.GetAllClients())
        {
            client.CloseConnection();
        }
    }
    private async Task ListenClientAsync(TcpClientConnection client)
    {
        var buffer = new byte[4096];

        try
        {
            while (true)
            {
                var bytesRead = await client.ReceiveAsync(buffer);
                string received = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (bytesRead == 0)
                    break;

                // Mesajlar use case katmanında işlenecek
                _ = processMessage.Execute(received);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Client error: {ex.Message}");
        }
        finally // Silinecek, client bağlantıyı kendisi kapatacak
        {
            clientManager.RemoveClient(client);
            client.CloseConnection();
            Console.WriteLine("Client disconnected");
        }
    }

}
