using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.server.ports;

public interface IClientConnection
{
    Task<int> ReceiveAsync(byte[] buffer);
    Task SendAsync(byte[] data);
    void CloseConnection();
}
