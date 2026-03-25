namespace chat_app.protocol;

/*
  TODO : Her bir mesaj türü için ayrı bir sınıf oluşturur. 
* Bu sınıflara bir base class ata. Atanan base class, mesaj türünü saklayan bir özellik içerecek. 
* Bir serileştirme - deserileştirme sınıfı yaz. Bu sınıf, client - server arasında gönderilen mesajları serileştirmek ve deserileştirmekle sorumlu olacak.
 */

public enum MessageType 
{
    Join, // Client wants to join a chat room
    Leave, // Client wants to leave a chat room
    ChatMessage, // Client sends a chat message to the room
    ServerAnnouncement, // Server sends an announcement to all clients. For example, when a new user joins or leaves the room.
    Discover, // Client bir UDP broadcast mesajı göndererek mevcut chat odalarını keşfetmek ister.  
    RoomInfo // Bunu gören sunucu, odanın adını ve katılımcı sayısını içeren bir RoomInfo mesajıyla yanıt verir. 
    /*
     RoomInfo mesajı sayesinde belirli aralıklarla oda bilgisi paylaşılmasına gerek kalmaz, 
    bunun yerine her client oda keşfi yaptığında yanıt verilir. 
    */
}
