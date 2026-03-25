namespace chat_app.protocol.Messages;

public class ChatMessage(string sender, string content) : NetworkMessage(MessageType.ChatMessage)
{
    public string Sender { get; set; } = sender;
    public string Content { get; set; } = content;  
}
