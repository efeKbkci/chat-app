using chat_app.server.ports;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace chat_app.server.adapters;

public class TcpClientConnection(TcpClient client) : IClientConnection
{
    private readonly TcpClient client = client;
    private readonly NetworkStream stream = client.GetStream();

    public Task<int> ReceiveAsync(byte[] buffer) => stream.ReadAsync(buffer, 0, buffer.Length);
    public Task SendAsync(byte[] data) => stream.WriteAsync(data, 0, data.Length);
    public void CloseConnection(){
        stream.Close();
        client.Close();
    }
}
