using chat_app.client.use_cases;
using chat_app.protocol;
using chat_app.protocol.Messages;
using chat_app.protocol.Serialization;
using System.Text;

namespace chat_app.server.use_cases;

public class ProcessMessage(SendMessage sendMessage)
{
    public async Task Execute(string message)
    {
        NetworkMessage networkMessage = MessageSerializer.Deserialize(message);

        switch (networkMessage)
        {
            case ChatMessage chatMessage:
                byte[] data = Encoding.UTF8.GetBytes(chatMessage.Content);
                await sendMessage.ExecuteAsync(data);
                break;
            case JoinMessage userJoinedMessage:
                byte[] joined = Encoding.UTF8.GetBytes(userJoinedMessage.Announcement);
                await sendMessage.ExecuteAsync(joined);
                break;
            case LeaveMessage userLeftMessage:
                byte[] left = Encoding.UTF8.GetBytes(userLeftMessage.Announcement);
                await sendMessage.ExecuteAsync(left);
                break;
            case Discover _:
                Console.WriteLine("Received discover message.");
                break;
            default:
                Console.WriteLine("Unknown message type received.");
                break;
        }
    }
}
