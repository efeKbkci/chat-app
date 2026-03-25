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
        try
        {
            NetworkMessage networkMessage = MessageSerializer.Deserialize(message);

            switch (networkMessage)
            {
                case ChatMessage chatMessage:
                    // Mesajın içeriğini değil, objenin tamamını tekrar JSON'a çevirip gönderiyoruz
                    string chatJson = MessageSerializer.Serialize(chatMessage);
                    byte[] chatData = Encoding.UTF8.GetBytes(chatJson);
                    await sendMessage.ExecuteAsync(chatData);
                    break;

                case JoinMessage userJoinedMessage:
                    Console.WriteLine($"User joined: {userJoinedMessage.Username}");

                    // Client'ların da anlayabilmesi için objeyi serileştirerek yayınlıyoruz
                    string joinJson = MessageSerializer.Serialize(userJoinedMessage);
                    byte[] joinData = Encoding.UTF8.GetBytes(joinJson);
                    await sendMessage.ExecuteAsync(joinData);
                    break;

                case LeaveMessage userLeftMessage:
                    Console.WriteLine($"User left: {userLeftMessage.Username}");

                    string leftJson = MessageSerializer.Serialize(userLeftMessage);
                    byte[] leftData = Encoding.UTF8.GetBytes(leftJson);
                    await sendMessage.ExecuteAsync(leftData);
                    break;

                case Discover _:
                    Console.WriteLine("Received discover message.");
                    // İleride buraya RoomInfo mesajı oluşturup geri gönderme mantığı eklenebilir
                    break;

                default:
                    Console.WriteLine("Unknown message type received.");
                    break;
            }
        }
        catch (Exception ex)
        {
            // Client'tan hatalı veya bozuk bir veri gelirse sunucunun çökmemesi için try-catch ekledik
            Console.WriteLine($"Mesaj işlenirken hata oluştu: {ex.Message}");
        }
    }
}