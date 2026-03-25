// Form1.cs (Özet Gösterim)
using chat_app.client.adapters;
using chat_app.client.ports;
using chat_app.client.use_cases;
using System.Windows.Forms;

namespace chat_app
{
    // Form sýnýfý IUIUpdater'ý miras alýr
    public partial class ClientForm : Form, IUIUpdater
    {
        private readonly IChatClient _chatClient;
        private readonly SendMessage _sendMessageUseCase;
        private readonly JoinRoom _joinRoomUseCase;
        private readonly ReceiveMessage _receiveMessageUseCase;

        public ClientForm()
        {
            InitializeComponent();

            // Dependency Injection (Uygulamanýn çalýþacaðý modülleri birleþtiriyoruz)
            _chatClient = new TcpChatClient();

            _receiveMessageUseCase = new ReceiveMessage(this); // UI Güncelleyici olarak Form1'in kendisini veriyoruz
            _sendMessageUseCase = new SendMessage(_chatClient);
            _joinRoomUseCase = new JoinRoom(_chatClient);

            // Aðdan mesaj geldiðinde ReceiveMessage UseCase'i tetiklensin
            _chatClient.OnMessageReceived += (json) =>
            {
                // UI thread'ine dönmek için Invoke gerekir
                this.Invoke((MethodInvoker)delegate {
                    _receiveMessageUseCase.Execute(json);
                });
            };
        }

        // IUIUpdater Port Ýmplementasyonu
        public void DisplayMessage(string message)
        {
            // richTextBox1 arayüzde oluþturduðun mesaj kutusu varsayýlarak yazýlmýþtýr
            richTextBox1.AppendText(message + Environment.NewLine);
        }

        // Bir "Baðlan" butonuna týklandýðýnda:
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            await _chatClient.ConnectAsync("127.0.0.1", 5000);
            await _joinRoomUseCase.ExecuteAsync(username.Text); // Username alýnabilir
        }

        // Bir "Gönder" butonuna týklandýðýnda:
        private async void btnSend_Click(object sender, EventArgs e)
        {
            await _sendMessageUseCase.ExecuteAsync(username.Text, txtMessage.Text);
            txtMessage.Clear();
        }
    }
}