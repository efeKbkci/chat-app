using chat_app.server.adapters;
using chat_app.server.use_cases;

namespace chat_app
{
    public partial class ServerForm : Form
    {
        private ServerManagement _serverManagement;
        private bool _isServerRunning = false;

        public ServerForm()
        {
            InitializeComponent();
            SetupDependencies();
        }

        // Temiz Mimarinin kalbi burasıdır (Dependency Injection - Bağımlılık Enjeksiyonu).
        // En alt katmandan (veri/adaptör) en üst katmana (use-case) doğru nesneleri oluşturup birbirine veriyoruz.
        private void SetupDependencies()
        {
            var clientManager = new TcpClientManager();
            var broadcaster = new TcpMessageBroadcaster(clientManager);
            var sendMessage = new SendMessage(broadcaster);
            var processMessage = new ProcessMessage(sendMessage);

            // TcpServer artık clientManager'a ihtiyaç duyuyor
            var chatServer = new TcpServer(processMessage, clientManager);

            // Son olarak Use-Case'imizi oluşturuyoruz
            _serverManagement = new ServerManagement(chatServer);
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (_isServerRunning) return;

            Log("Sunucu başlatılıyor...");
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            _isServerRunning = true;

            try
            {
                // Sunucuyu 5000 portunda başlat (ExecuteAsync bitene kadar beklemez, arka planda dinler)
                _ = _serverManagement.ExecuteAsync(5000);
                Log("Sunucu 5000 portunda dinlemeye başladı.");
            }
            catch (Exception ex)
            {
                Log($"Hata: {ex.Message}");
                _isServerRunning = false;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_isServerRunning) return;

            Log("Sunucu durduruluyor...");
            _serverManagement.Stop();

            _isServerRunning = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            Log("Sunucu başarıyla durduruldu.");
        }

        // Arayüz thread'i çökmesin diye güvenli log yazdırma metodu
        private void Log(string message)
        {
            if (txtLogs.InvokeRequired)
            {
                txtLogs.Invoke(new Action(() => Log(message)));
            }
            else
            {
                txtLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            }
        }
    }
}