using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.protocol.Messages;

public class LeaveMessage() : NetworkMessage(MessageType.Leave)
{ 
    public string Username { get; set; } = string.Empty;
    public string Announcement => $"{Username} has left the chat.";
}
