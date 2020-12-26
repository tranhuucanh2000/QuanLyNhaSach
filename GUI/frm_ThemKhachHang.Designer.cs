namespace GUI
{
	partial class frm_ThemKhachHang
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


        #region Component Designer generated code
        private void InitializeComponent()
        {
			this.Label7 = new System.Windows.Forms.Label();
			this.txt_Email = new System.Windows.Forms.TextBox();
			this.txt_TienNo = new System.Windows.Forms.TextBox();
			this.txt_DienThoai = new System.Windows.Forms.TextBox();
			this.txt_MaKhachHang = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.txt_HoTen = new System.Windows.Forms.TextBox();
			this.btn_Thoat = new System.Windows.Forms.Button();
			this.btn_Luu = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txt_DiaChi = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.Label7.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.Label7.Location = new System.Drawing.Point(226, 57);
			this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(252, 31);
			this.Label7.TabIndex = 1;
			this.Label7.Text = "Thêm khách hàng mới";
			// 
			// txt_Email
			// 
			this.txt_Email.Location = new System.Drawing.Point(153, 312);
			this.txt_Email.Name = "txt_Email";
			this.txt_Email.Size = new System.Drawing.Size(325, 27);
			this.txt_Email.TabIndex = 11;
			// 
			// txt_TienNo
			// 
			this.txt_TienNo.Location = new System.Drawing.Point(153, 354);
			this.txt_TienNo.Name = "txt_TienNo";
			this.txt_TienNo.ReadOnly = true;
			this.txt_TienNo.Size = new System.Drawing.Size(325, 27);
			this.txt_TienNo.TabIndex = 13;
			this.txt_TienNo.Text = "0";
			// 
			// txt_DienThoai
			// 
			this.txt_DienThoai.Location = new System.Drawing.Point(153, 270);
			this.txt_DienThoai.Name = "txt_DienThoai";
			this.txt_DienThoai.Size = new System.Drawing.Size(325, 27);
			this.txt_DienThoai.TabIndex = 9;
			// 
			// txt_MaKhachHang
			// 
			this.txt_MaKhachHang.Location = new System.Drawing.Point(153, 142);
			this.txt_MaKhachHang.Name = "txt_MaKhachHang";
			this.txt_MaKhachHang.ReadOnly = true;
			this.txt_MaKhachHang.Size = new System.Drawing.Size(325, 27);
			this.txt_MaKhachHang.TabIndex = 3;
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Label6.Location = new System.Drawing.Point(54, 143);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(65, 23);
			this.Label6.TabIndex = 2;
			this.Label6.Text = "Mã KH:";
			// 
			// txt_HoTen
			// 
			this.txt_HoTen.Location = new System.Drawing.Point(153, 185);
			this.txt_HoTen.Name = "txt_HoTen";
			this.txt_HoTen.Size = new System.Drawing.Size(325, 27);
			this.txt_HoTen.TabIndex = 5;
			// 
			// btn_Thoat
			// 
			this.btn_Thoat.BackColor = System.Drawing.Color.Teal;
			this.btn_Thoat.FlatAppearance.BorderSize = 0;
			this.btn_Thoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btn_Thoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btn_Thoat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_Thoat.ForeColor = System.Drawing.Color.White;
			this.btn_Thoat.Location = new System.Drawing.Point(531, 277);
			this.btn_Thoat.Name = "btn_Thoat";
			this.btn_Thoat.Size = new System.Drawing.Size(123, 104);
			this.btn_Thoat.TabIndex = 15;
			this.btn_Thoat.Text = "Thoát";
			this.btn_Thoat.UseVisualStyleBackColor = false;
			this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
			// 
			// btn_Luu
			// 
			this.btn_Luu.BackColor = System.Drawing.Color.Teal;
			this.btn_Luu.FlatAppearance.BorderSize = 0;
			this.btn_Luu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btn_Luu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btn_Luu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_Luu.ForeColor = System.Drawing.Color.White;
			this.btn_Luu.Location = new System.Drawing.Point(531, 142);
			this.btn_Luu.Name = "btn_Luu";
			this.btn_Luu.Size = new System.Drawing.Size(123, 104);
			this.btn_Luu.TabIndex = 14;
			this.btn_Luu.Text = "Lưu";
			this.btn_Luu.UseVisualStyleBackColor = false;
			this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Label1.Location = new System.Drawing.Point(54, 184);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(66, 23);
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Họ tên:";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Label3.Location = new System.Drawing.Point(55, 226);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(66, 23);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Địa chỉ:";
			// 
			// txt_DiaChi
			// 
			this.txt_DiaChi.Location = new System.Drawing.Point(153, 228);
			this.txt_DiaChi.Name = "txt_DiaChi";
			this.txt_DiaChi.Size = new System.Drawing.Size(325, 27);
			this.txt_DiaChi.TabIndex = 7;
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Label8.Location = new System.Drawing.Point(55, 355);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(71, 23);
			this.Label8.TabIndex = 12;
			this.Label8.Text = "Tiền nợ:";
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Label9.Location = new System.Drawing.Point(54, 311);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(55, 23);
			this.Label9.TabIndex = 10;
			this.Label9.Text = "Email:";
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Label10.Location = new System.Drawing.Point(54, 269);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(93, 23);
			this.Label10.TabIndex = 8;
			this.Label10.Text = "Điện thoại:";
			// 
			// frm_ThemKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(706, 444);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.txt_Email);
			this.Controls.Add(this.txt_TienNo);
			this.Controls.Add(this.txt_DienThoai);
			this.Controls.Add(this.txt_MaKhachHang);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.txt_DiaChi);
			this.Controls.Add(this.txt_HoTen);
			this.Controls.Add(this.btn_Thoat);
			this.Controls.Add(this.btn_Luu);
			this.KeyPreview = true;
			this.Name = "frm_ThemKhachHang";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Thêm khách hàng";
			this.Load += new System.EventHandler(this.frm_ThemKhachHang_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ThemKhachHang_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_TienNo;
        private System.Windows.Forms.TextBox txt_DienThoai;
        private System.Windows.Forms.TextBox txt_MaKhachHang;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txt_HoTen;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Label Label10;
    }
}