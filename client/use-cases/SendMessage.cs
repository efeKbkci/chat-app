// client/use-cases/SendMessage.cs
using chat_app.client.ports;
using chat_app.protocol.Messages;
using chat_app.protocol.Serialization;
using System.Text;

namespace chat_app.client.use_cases;

public class SendMessage(IChatClient chatClient)
{
    public async Task ExecuteAsync(string username, string content)
    {
        var chatMsg = new ChatMessage(username, content);
        string json = MessageSerializer.Serialize(chatMsg);
        byte[] data = Encoding.UTF8.GetBytes(json);

        await chatClient.SendAsync(data);
    }
}