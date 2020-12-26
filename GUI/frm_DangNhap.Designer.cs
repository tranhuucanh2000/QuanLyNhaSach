namespace GUI
{
    partial class frm_DangNhap
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
			this.label1 = new System.Windows.Forms.Label();
			this.txt_TenDangNhap = new System.Windows.Forms.TextBox();
			this.txt_MatKhau = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_DangNhap = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(126, 28);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(322, 45);
			this.label1.TabIndex = 0;
			this.label1.Text = "Đăng nhập hệ thống";
			// 
			// txt_TenDangNhap
			// 
			this.txt_TenDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.txt_TenDangNhap.Location = new System.Drawing.Point(210, 136);
			this.txt_TenDangNhap.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TenDangNhap.Name = "txt_TenDangNhap";
			this.txt_TenDangNhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txt_TenDangNhap.Size = new System.Drawing.Size(262, 27);
			this.txt_TenDangNhap.TabIndex = 1;
			this.txt_TenDangNhap.Text = "admin";
			this.txt_TenDangNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TenDangNhap_KeyPress);
			// 
			// txt_MatKhau
			// 
			this.txt_MatKhau.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.txt_MatKhau.Location = new System.Drawing.Point(210, 166);
			this.txt_MatKhau.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MatKhau.Name = "txt_MatKhau";
			this.txt_MatKhau.PasswordChar = '•';
			this.txt_MatKhau.Size = new System.Drawing.Size(262, 27);
			this.txt_MatKhau.TabIndex = 1;
			this.txt_MatKhau.Enter += new System.EventHandler(this.txt_MatKhau_Enter);
			this.txt_MatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MatKhau_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(97, 141);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tên đăng nhập:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(97, 171);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Mật khẩu:";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// btn_DangNhap
			// 
			this.btn_DangNhap.BackColor = System.Drawing.Color.Teal;
			this.btn_DangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_DangNhap.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_DangNhap.Location = new System.Drawing.Point(348, 223);
			this.btn_DangNhap.Margin = new System.Windows.Forms.Padding(2);
			this.btn_DangNhap.Name = "btn_DangNhap";
			this.btn_DangNhap.Size = new System.Drawing.Size(124, 58);
			this.btn_DangNhap.TabIndex = 2;
			this.btn_DangNhap.Text = "Đăng nhập";
			this.btn_DangNhap.UseVisualStyleBackColor = false;
			this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Teal;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(-7, -1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(614, 105);
			this.panel1.TabIndex = 3;
			// 
			// frm_DangNhap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(548, 303);
			this.Controls.Add(this.btn_DangNhap);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_MatKhau);
			this.Controls.Add(this.txt_TenDangNhap);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "frm_DangNhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đăng nhập";
			this.Load += new System.EventHandler(this.frm_DangNhap_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_DangNhap_KeyDown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_TenDangNhap;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DangNhap;
		private System.Windows.Forms.Panel panel1;
	}
}