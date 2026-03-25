using chat_app.server.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.server.adapters;

public class TcpClientManager : IClientManager
{
    private readonly List<IClientConnection> _clients = [];

    public void AddClient(IClientConnection client)
    {
        lock (_clients) // Race condition önlemek için kilitleme mekanizması kullanıyoruz
        {
            _clients.Add(client);
        }
    }

    public IReadOnlyList<IClientConnection> GetAllClients()
    {
        return _clients.AsReadOnly();
    }

    public void RemoveClient(IClientConnection client)
    {
        lock (_clients)
        { 
            _clients.Remove(client);
        }
    }
}
