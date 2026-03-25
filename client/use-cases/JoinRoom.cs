using chat_app.client.ports;
using chat_app.protocol.Messages;
using chat_app.protocol.Serialization;
using System.Text;

namespace chat_app.client.use_cases;

public class JoinRoom(IChatClient chatClient)
{
    public async Task ExecuteAsync(string username)
    {
        var joinMsg = new JoinMessage(username);
        string json = MessageSerializer.Serialize(joinMsg);
        byte[] data = Encoding.UTF8.GetBytes(json);

        await chatClient.SendAsync(data);
    }
}