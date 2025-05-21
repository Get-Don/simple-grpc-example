namespace ChatClient
{
    partial class Form1
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnDisconnect = new Button();
            label1 = new Label();
            btnConnect = new Button();
            tbxName = new TextBox();
            lbxChatLog = new ListBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tbxMessage = new TextBox();
            btnSend = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btnDisconnect, 3, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnConnect, 2, 0);
            tableLayoutPanel1.Controls.Add(tbxName, 1, 0);
            tableLayoutPanel1.Location = new Point(265, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(520, 31);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Dock = DockStyle.Fill;
            btnDisconnect.Enabled = false;
            btnDisconnect.Location = new Point(393, 3);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(124, 25);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "접속 종료";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(124, 31);
            label1.TabIndex = 0;
            label1.Text = "이름";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnConnect
            // 
            btnConnect.Dock = DockStyle.Fill;
            btnConnect.Location = new Point(263, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(124, 25);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "접속";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // tbxName
            // 
            tbxName.Dock = DockStyle.Fill;
            tbxName.Location = new Point(133, 3);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(124, 23);
            tbxName.TabIndex = 1;
            // 
            // lbxChatLog
            // 
            lbxChatLog.FormattingEnabled = true;
            lbxChatLog.HorizontalScrollbar = true;
            lbxChatLog.Location = new Point(12, 51);
            lbxChatLog.Name = "lbxChatLog";
            lbxChatLog.Size = new Size(776, 334);
            lbxChatLog.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.Controls.Add(tbxMessage, 0, 0);
            tableLayoutPanel2.Controls.Add(btnSend, 1, 0);
            tableLayoutPanel2.Location = new Point(12, 391);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(776, 27);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tbxMessage
            // 
            tbxMessage.Dock = DockStyle.Fill;
            tbxMessage.Enabled = false;
            tbxMessage.Location = new Point(3, 3);
            tbxMessage.Name = "tbxMessage";
            tbxMessage.Size = new Size(692, 23);
            tbxMessage.TabIndex = 0;
            tbxMessage.KeyDown += tbxMessage_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Dock = DockStyle.Fill;
            btnSend.Enabled = false;
            btnSend.Location = new Point(701, 3);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(72, 21);
            btnSend.TabIndex = 1;
            btnSend.Text = "전송";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 426);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(lbxChatLog);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Client";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button btnConnect;
        private TextBox tbxName;
        private ListBox lbxChatLog;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox tbxMessage;
        private Button btnSend;
        private Button btnDisconnect;
    }
}
