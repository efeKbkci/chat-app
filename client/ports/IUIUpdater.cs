namespace chat_app.client.ports;

public interface IUIUpdater
{
    // Arayüze (Listbox veya RichTextBox'a) mesaj yazdırmak için
    void DisplayMessage(string message);
}