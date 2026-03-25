using chat_app.protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.server.ports;

public interface IClientManager
{
    void AddClient(IClientConnection client);
    void RemoveClient(IClientConnection client);
    IReadOnlyList<IClientConnection> GetAllClients();
}
