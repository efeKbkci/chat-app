// client/use-cases/ReceiveMessage.cs
using chat_app.client.ports;
using chat_app.protocol.Messages;
using chat_app.protocol.Serialization;

namespace chat_app.client.use_cases;

public class ReceiveMessage(IUIUpdater uiUpdater)
{
    // TcpChatClient'tan gelen JSON string buraya düşecek
    public void Execute(string jsonMessage)
    {
        try
        {
            NetworkMessage networkMessage = MessageSerializer.Deserialize(jsonMessage);

            switch (networkMessage)
            {
                case ChatMessage chatMsg:
                    uiUpdater.DisplayMessage($"[{chatMsg.Sender}]: {chatMsg.Content}");
                    break;
                case JoinMessage joinMsg:
                    uiUpdater.DisplayMessage($"Sistem: {joinMsg.Announcement}");
                    break;
                case LeaveMessage leaveMsg:
                    uiUpdater.DisplayMessage($"Sistem: {leaveMsg.Announcement}");
                    break;
                    // Diğer durumlar eklenebilir...
            }
        }
        catch (Exception)
        {
            // JSON parse hatası veya bilinmeyen mesaj formatı
            uiUpdater.DisplayMessage("Sistem: Anlaşılamayan bir mesaj alındı.");
        }
    }
}