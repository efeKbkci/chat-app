using chat_app.client.ports;
using chat_app.protocol.Messages;
using chat_app.protocol.Serialization;
using System.Text;

namespace chat_app.client.use_cases;

public class LeaveRoom(IChatClient chatClient)
{
    public async Task ExecuteAsync(string username)
    {
        // Kullanıcı adını vererek LeaveMessage objesi oluşturuyoruz
        var leaveMsg = new LeaveMessage { Username = username };

        string json = MessageSerializer.Serialize(leaveMsg);
        byte[] data = Encoding.UTF8.GetBytes(json);

        // Mesajı sunucuya gönder
        await chatClient.SendAsync(data);
    }
}