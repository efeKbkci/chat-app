using System.Text.Json.Serialization;

namespace chat_app.protocol.Messages;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(ChatMessage), typeDiscriminator: "chat")]
[JsonDerivedType(typeof(JoinMessage), typeDiscriminator: "join")]
[JsonDerivedType(typeof(LeaveMessage), typeDiscriminator: "leave")]
[JsonDerivedType(typeof(Discover), typeDiscriminator: "discover")]
[JsonDerivedType(typeof(RoomInfo), typeDiscriminator: "roomInfo")]
[JsonDerivedType(typeof(ServerAnnouncement), typeDiscriminator: "serverAnnouncement")]
public abstract class NetworkMessage(MessageType type)
{
    public MessageType Type { get; set; } = type;
}
