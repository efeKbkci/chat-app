namespace chat_app
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            btnConnect = new Button();
            btnSend = new Button();
            txtMessage = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            username = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(282, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(493, 310);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(3, 146);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(208, 46);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(681, 328);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(282, 330);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(393, 27);
            txtMessage.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 27);
            textBox2.TabIndex = 4;
            textBox2.Text = "127.0.0.1";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(3, 57);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(208, 27);
            textBox3.TabIndex = 5;
            textBox3.Text = "5000";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(username, 0, 2);
            tableLayoutPanel1.Controls.Add(textBox2, 0, 0);
            tableLayoutPanel1.Controls.Add(textBox3, 0, 1);
            tableLayoutPanel1.Controls.Add(btnConnect, 0, 3);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 56.9444427F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.0555573F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            tableLayoutPanel1.Size = new Size(232, 239);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // username
            // 
            username.Location = new Point(3, 98);
            username.Name = "username";
            username.Size = new Size(125, 27);
            username.TabIndex = 7;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(richTextBox1);
            Name = "ClientForm";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button btnConnect;
        private Button btnSend;
        private TextBox txtMessage;
        private TextBox textBox2;
        private TextBox textBox3;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox username;
    }
}
