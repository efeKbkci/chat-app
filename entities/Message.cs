using System;

namespace chat_app.entities;

public class Message(string content, string senderID)
{
    public Guid ID { get; private set; } = Guid.NewGuid();
    public string Content { get; private set; } = content;
    public string SenderID { get; private set; } = senderID;    
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
}

