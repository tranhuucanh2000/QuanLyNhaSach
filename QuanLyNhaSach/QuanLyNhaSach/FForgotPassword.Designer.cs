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
            this.txbCode = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnNewPassword = new System.Windows.Forms.Panel();
            this.btnCFNewPass = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbNewPass = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbRePass = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConfirmCode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSupport = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnNewPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(53, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Code:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(130, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 1);
            this.panel1.TabIndex = 2;
            // 
            // txbCode
            // 
            this.txbCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.txbCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbCode.Location = new System.Drawing.Point(138, 311);
            this.txbCode.Name = "txbCode";
            this.txbCode.Size = new System.Drawing.Size(356, 27);
            this.txbCode.TabIndex = 3;
            this.txbCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCode_KeyDown);
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
            this.pnNewPassword.Controls.Add(this.btnCFNewPass);
            this.pnNewPassword.Controls.Add(this.label2);
            this.pnNewPassword.Controls.Add(this.label1);
            this.pnNewPassword.Controls.Add(this.txbNewPass);
            this.pnNewPassword.Controls.Add(this.panel2);
            this.pnNewPassword.Controls.Add(this.txbRePass);
            this.pnNewPassword.Controls.Add(this.panel3);
            this.pnNewPassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnNewPassword.Enabled = false;
            this.pnNewPassword.Location = new System.Drawing.Point(0, 480);
            this.pnNewPassword.Name = "pnNewPassword";
            this.pnNewPassword.Size = new System.Drawing.Size(581, 240);
            this.pnNewPassword.TabIndex = 5;
            // 
            // btnCFNewPass
            // 
            this.btnCFNewPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(29)))));
            this.btnCFNewPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCFNewPass.ForeColor = System.Drawing.Color.White;
            this.btnCFNewPass.Location = new System.Drawing.Point(145, 169);
            this.btnCFNewPass.Name = "btnCFNewPass";
            this.btnCFNewPass.Size = new System.Drawing.Size(290, 40);
            this.btnCFNewPass.TabIndex = 6;
            this.btnCFNewPass.Text = "Confirm";
            this.btnCFNewPass.UseVisualStyleBackColor = false;
            this.btnCFNewPass.Click += new System.EventHandler(this.btnCFNewPass_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Re-Enter Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Password";
            // 
            // txbNewPass
            // 
            this.txbNewPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.txbNewPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbNewPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbNewPass.Location = new System.Drawing.Point(190, 36);
            this.txbNewPass.Name = "txbNewPass";
            this.txbNewPass.Size = new System.Drawing.Size(350, 27);
            this.txbNewPass.TabIndex = 3;
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
            // txbRePass
            // 
            this.txbRePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.txbRePass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbRePass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbRePass.Location = new System.Drawing.Point(189, 100);
            this.txbRePass.Name = "txbRePass";
            this.txbRePass.Size = new System.Drawing.Size(350, 27);
            this.txbRePass.TabIndex = 3;
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
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(314, 394);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(221, 40);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConfirmCode
            // 
            this.btnConfirmCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(29)))));
            this.btnConfirmCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmCode.ForeColor = System.Drawing.Color.White;
            this.btnConfirmCode.Location = new System.Drawing.Point(45, 394);
            this.btnConfirmCode.Name = "btnConfirmCode";
            this.btnConfirmCode.Size = new System.Drawing.Size(221, 40);
            this.btnConfirmCode.TabIndex = 6;
            this.btnConfirmCode.Text = "Confirm";
            this.btnConfirmCode.UseVisualStyleBackColor = false;
            this.btnConfirmCode.Click += new System.EventHandler(this.btnConfirmCode_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // lbSupport
            // 
            this.lbSupport.AutoSize = true;
            this.lbSupport.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSupport.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbSupport.Location = new System.Drawing.Point(150, 256);
            this.lbSupport.Name = "lbSupport";
            this.lbSupport.Size = new System.Drawing.Size(274, 23);
            this.lbSupport.TabIndex = 8;
            this.lbSupport.Text = "Don\'t worry if you have the code";
            // 
            // FForgotPassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(581, 720);
            this.Controls.Add(this.lbSupport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConfirmCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnNewPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txbCode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbCode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbRePass;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfirmCode;
        private System.Windows.Forms.Button btnCFNewPass;
        private System.Windows.Forms.TextBox txbNewPass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSupport;
    }
}