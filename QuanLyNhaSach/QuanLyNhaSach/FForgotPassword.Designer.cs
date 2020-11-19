namespace QuanLyNhaSach
{
    partial class FForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FForgotPassword));
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbMa = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnNewPassword = new System.Windows.Forms.Panel();
            this.btnXNMK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMKM = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbXNMK = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnXacNhanMa = new System.Windows.Forms.Button();
            this.lbHoTro = new System.Windows.Forms.Label();
            this.pnMa = new System.Windows.Forms.Panel();
            this.ptClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnNewPassword.SuspendLayout();
            this.pnMa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(107, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 1);
            this.panel1.TabIndex = 2;
            // 
            // txbMa
            // 
            this.txbMa.BackColor = System.Drawing.Color.White;
            this.txbMa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbMa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbMa.Location = new System.Drawing.Point(115, 80);
            this.txbMa.Name = "txbMa";
            this.txbMa.Size = new System.Drawing.Size(356, 27);
            this.txbMa.TabIndex = 3;
            this.txbMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMa_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(200, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pnNewPassword
            // 
            this.pnNewPassword.Controls.Add(this.btnXNMK);
            this.pnNewPassword.Controls.Add(this.label2);
            this.pnNewPassword.Controls.Add(this.label1);
            this.pnNewPassword.Controls.Add(this.txbMKM);
            this.pnNewPassword.Controls.Add(this.panel2);
            this.pnNewPassword.Controls.Add(this.txbXNMK);
            this.pnNewPassword.Controls.Add(this.panel3);
            this.pnNewPassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnNewPassword.Enabled = false;
            this.pnNewPassword.Location = new System.Drawing.Point(0, 480);
            this.pnNewPassword.Name = "pnNewPassword";
            this.pnNewPassword.Size = new System.Drawing.Size(581, 240);
            this.pnNewPassword.TabIndex = 5;
            // 
            // btnXNMK
            // 
            this.btnXNMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(29)))));
            this.btnXNMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXNMK.ForeColor = System.Drawing.Color.White;
            this.btnXNMK.Location = new System.Drawing.Point(145, 169);
            this.btnXNMK.Name = "btnXNMK";
            this.btnXNMK.Size = new System.Drawing.Size(290, 40);
            this.btnXNMK.TabIndex = 6;
            this.btnXNMK.Text = "Xác Nhận";
            this.btnXNMK.UseVisualStyleBackColor = false;
            this.btnXNMK.Click += new System.EventHandler(this.btnXNMK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xác Nhận Mật Khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật Khẩu Mới:";
            // 
            // txbMKM
            // 
            this.txbMKM.BackColor = System.Drawing.Color.White;
            this.txbMKM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbMKM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbMKM.Location = new System.Drawing.Point(190, 36);
            this.txbMKM.Name = "txbMKM";
            this.txbMKM.Size = new System.Drawing.Size(350, 27);
            this.txbMKM.TabIndex = 3;
            this.txbMKM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMKM_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(191, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 1);
            this.panel2.TabIndex = 2;
            // 
            // txbXNMK
            // 
            this.txbXNMK.BackColor = System.Drawing.Color.White;
            this.txbXNMK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbXNMK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbXNMK.Location = new System.Drawing.Point(189, 100);
            this.txbXNMK.Name = "txbXNMK";
            this.txbXNMK.Size = new System.Drawing.Size(350, 27);
            this.txbXNMK.TabIndex = 3;
            this.txbXNMK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbXNMK_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(190, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 1);
            this.panel3.TabIndex = 2;
            // 
            // btnXacNhanMa
            // 
            this.btnXacNhanMa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(29)))));
            this.btnXacNhanMa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanMa.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanMa.Location = new System.Drawing.Point(115, 169);
            this.btnXacNhanMa.Name = "btnXacNhanMa";
            this.btnXacNhanMa.Size = new System.Drawing.Size(290, 40);
            this.btnXacNhanMa.TabIndex = 6;
            this.btnXacNhanMa.Text = "Xác Nhận";
            this.btnXacNhanMa.UseVisualStyleBackColor = false;
            this.btnXacNhanMa.Click += new System.EventHandler(this.btnXacNhanMa_Click);
            // 
            // lbHoTro
            // 
            this.lbHoTro.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoTro.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbHoTro.Location = new System.Drawing.Point(3, 4);
            this.lbHoTro.Name = "lbHoTro";
            this.lbHoTro.Size = new System.Drawing.Size(527, 23);
            this.lbHoTro.TabIndex = 8;
            this.lbHoTro.Text = "Đừng lo lắng nếu bạn có mã!";
            this.lbHoTro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnMa
            // 
            this.pnMa.Controls.Add(this.txbMa);
            this.pnMa.Controls.Add(this.lbHoTro);
            this.pnMa.Controls.Add(this.label3);
            this.pnMa.Controls.Add(this.btnXacNhanMa);
            this.pnMa.Controls.Add(this.panel1);
            this.pnMa.Location = new System.Drawing.Point(24, 242);
            this.pnMa.Name = "pnMa";
            this.pnMa.Size = new System.Drawing.Size(533, 237);
            this.pnMa.TabIndex = 9;
            // 
            // ptClose
            // 
            this.ptClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptClose.Image = ((System.Drawing.Image)(resources.GetObject("ptClose.Image")));
            this.ptClose.Location = new System.Drawing.Point(531, 0);
            this.ptClose.Name = "ptClose";
            this.ptClose.Size = new System.Drawing.Size(50, 50);
            this.ptClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptClose.TabIndex = 11;
            this.ptClose.TabStop = false;
            this.ptClose.Click += new System.EventHandler(this.ptClose_Click);
            // 
            // FForgotPassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(581, 720);
            this.Controls.Add(this.ptClose);
            this.Controls.Add(this.pnMa);
            this.Controls.Add(this.pnNewPassword);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FForgotPassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FForgotPassword";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnNewPassword.ResumeLayout(false);
            this.pnNewPassword.PerformLayout();
            this.pnMa.ResumeLayout(false);
            this.pnMa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbMa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbXNMK;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnXacNhanMa;
        private System.Windows.Forms.Button btnXNMK;
        private System.Windows.Forms.TextBox txbMKM;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbHoTro;
        private System.Windows.Forms.Panel pnMa;
        private System.Windows.Forms.PictureBox ptClose;
    }
}