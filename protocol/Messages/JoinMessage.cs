using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.protocol.Messages;
public class JoinMessage(string username) : NetworkMessage(MessageType.Join)
{
    public string Username { get; set; } = username;
    public string Announcement => $"{Username} has joined the chat.";
}
