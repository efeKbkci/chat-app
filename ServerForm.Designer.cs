namespace chat_app
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLogs = new RichTextBox();
            btnStart = new Button();
            btnStop = new Button();
            SuspendLayout();
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(12, 12);
            txtLogs.Name = "txtLogs";
            txtLogs.Size = new Size(776, 219);
            txtLogs.TabIndex = 0;
            txtLogs.Text = "";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(49, 276);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(350, 50);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.FlatAppearance.BorderSize = 3;
            btnStop.Location = new Point(49, 345);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(350, 50);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop Server";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 450);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtLogs);
            Name = "ServerForm";
            Text = "ServerForm";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtLogs;
        private Button btnStart;
        private Button btnStop;
    }
}