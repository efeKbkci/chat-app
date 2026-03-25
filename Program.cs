namespace chat_app
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) // argümanlarý yakalamak için 'args' eklendi
        {
            ApplicationConfiguration.Initialize();

            // 1. Terminalden parametre girildiyse:
            if (args.Length > 0)
            {
                string mode = args[0].ToLower();

                if (mode == "-s")
                {
                    Application.Run(new ServerForm());
                }
                else if (mode == "-c")
                {
                    Application.Run(new ClientForm());
                }
                else
                {
                    MessageBox.Show("Geçersiz parametre! Lütfen '-s' (Server) veya '-c' (Client) kullanýn.",
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 2. Parametre girilmeden (örn. çift týklanarak) açýldýysa:
            else
            {
                DialogResult result = MessageBox.Show(
                    "Uygulamayý Sunucu (Server) olarak baþlatmak ister misiniz?\n\nEvet = Sunucu, Hayýr = Ýstemci",
                    "Baþlatma Modu Seçimi",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Run(new ServerForm());
                }
                else if (result == DialogResult.No)
                {
                    Application.Run(new ClientForm());
                }
                // Cancel seçilirse hiçbir þey yapmaz ve uygulama kapanýr.
            }
        }
    }
}