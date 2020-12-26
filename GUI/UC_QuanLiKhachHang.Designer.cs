namespace GUI
{
    partial class UC_QuanLiKhachHang
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txt_MaKhachHang = new System.Windows.Forms.TextBox();
			this.txt_HoTen = new System.Windows.Forms.TextBox();
			this.txt_DiaChi = new System.Windows.Forms.TextBox();
			this.txt_DienThoai = new System.Windows.Forms.TextBox();
			this.txt_Email = new System.Windows.Forms.TextBox();
			this.txt_TienNo = new System.Windows.Forms.TextBox();
			this.txt_TimKiem = new System.Windows.Forms.TextBox();
			this.btn_ThemKhachHang = new System.Windows.Forms.Button();
			this.btn_CapNhat = new System.Windows.Forms.Button();
			this.btn_Xoa = new System.Windows.Forms.Button();
			this.dgv_ListKhachHang = new System.Windows.Forms.DataGridView();
			this.lbl_XoaTimKiem = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv_ListKhachHang)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label1.Location = new System.Drawing.Point(25, 25);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(221, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Quản lí khách hàng";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(59, 81);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mã KH:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(59, 113);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Họ tên:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(59, 145);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 20);
			this.label4.TabIndex = 1;
			this.label4.Text = "Địa chỉ:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(373, 81);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "Điện thoại:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(373, 113);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 20);
			this.label6.TabIndex = 1;
			this.label6.Text = "Email:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(373, 145);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 20);
			this.label7.TabIndex = 1;
			this.label7.Text = "Tiền nợ:";
			// 
			// txt_MaKhachHang
			// 
			this.txt_MaKhachHang.Location = new System.Drawing.Point(140, 78);
			this.txt_MaKhachHang.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaKhachHang.Name = "txt_MaKhachHang";
			this.txt_MaKhachHang.ReadOnly = true;
			this.txt_MaKhachHang.Size = new System.Drawing.Size(180, 27);
			this.txt_MaKhachHang.TabIndex = 2;
			// 
			// txt_HoTen
			// 
			this.txt_HoTen.Location = new System.Drawing.Point(140, 110);
			this.txt_HoTen.Margin = new System.Windows.Forms.Padding(2);
			this.txt_HoTen.Name = "txt_HoTen";
			this.txt_HoTen.ReadOnly = true;
			this.txt_HoTen.Size = new System.Drawing.Size(180, 27);
			this.txt_HoTen.TabIndex = 2;
			// 
			// txt_DiaChi
			// 
			this.txt_DiaChi.Location = new System.Drawing.Point(140, 142);
			this.txt_DiaChi.Margin = new System.Windows.Forms.Padding(2);
			this.txt_DiaChi.Name = "txt_DiaChi";
			this.txt_DiaChi.ReadOnly = true;
			this.txt_DiaChi.Size = new System.Drawing.Size(180, 27);
			this.txt_DiaChi.TabIndex = 2;
			// 
			// txt_DienThoai
			// 
			this.txt_DienThoai.Location = new System.Drawing.Point(476, 78);
			this.txt_DienThoai.Margin = new System.Windows.Forms.Padding(2);
			this.txt_DienThoai.Name = "txt_DienThoai";
			this.txt_DienThoai.ReadOnly = true;
			this.txt_DienThoai.Size = new System.Drawing.Size(180, 27);
			this.txt_DienThoai.TabIndex = 2;
			// 
			// txt_Email
			// 
			this.txt_Email.Location = new System.Drawing.Point(476, 110);
			this.txt_Email.Margin = new System.Windows.Forms.Padding(2);
			this.txt_Email.Name = "txt_Email";
			this.txt_Email.ReadOnly = true;
			this.txt_Email.Size = new System.Drawing.Size(180, 27);
			this.txt_Email.TabIndex = 2;
			// 
			// txt_TienNo
			// 
			this.txt_TienNo.Location = new System.Drawing.Point(476, 142);
			this.txt_TienNo.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TienNo.Name = "txt_TienNo";
			this.txt_TienNo.ReadOnly = true;
			this.txt_TienNo.Size = new System.Drawing.Size(180, 27);
			this.txt_TienNo.TabIndex = 2;
			// 
			// txt_TimKiem
			// 
			this.txt_TimKiem.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.txt_TimKiem.Location = new System.Drawing.Point(59, 198);
			this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TimKiem.Name = "txt_TimKiem";
			this.txt_TimKiem.Size = new System.Drawing.Size(597, 27);
			this.txt_TimKiem.TabIndex = 2;
			this.txt_TimKiem.Text = "Tìm kiếm bằng Mã KH, Họ tên hoặc SĐT...";
			this.txt_TimKiem.Click += new System.EventHandler(this.txt_TimKiem_Click);
			this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
			this.txt_TimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TimKiem_KeyDown);
			this.txt_TimKiem.Leave += new System.EventHandler(this.txt_TimKiem_Leave);
			// 
			// btn_ThemKhachHang
			// 
			this.btn_ThemKhachHang.BackColor = System.Drawing.Color.Teal;
			this.btn_ThemKhachHang.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_ThemKhachHang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btn_ThemKhachHang.Location = new System.Drawing.Point(693, 78);
			this.btn_ThemKhachHang.Margin = new System.Windows.Forms.Padding(2);
			this.btn_ThemKhachHang.Name = "btn_ThemKhachHang";
			this.btn_ThemKhachHang.Size = new System.Drawing.Size(90, 46);
			this.btn_ThemKhachHang.TabIndex = 3;
			this.btn_ThemKhachHang.Text = "Thêm KH";
			this.btn_ThemKhachHang.UseVisualStyleBackColor = false;
			this.btn_ThemKhachHang.Click += new System.EventHandler(this.btn_ThemKhachHang_Click);
			// 
			// btn_CapNhat
			// 
			this.btn_CapNhat.BackColor = System.Drawing.Color.Teal;
			this.btn_CapNhat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_CapNhat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btn_CapNhat.Location = new System.Drawing.Point(693, 128);
			this.btn_CapNhat.Margin = new System.Windows.Forms.Padding(2);
			this.btn_CapNhat.Name = "btn_CapNhat";
			this.btn_CapNhat.Size = new System.Drawing.Size(90, 46);
			this.btn_CapNhat.TabIndex = 3;
			this.btn_CapNhat.Text = "Cập nhật";
			this.btn_CapNhat.UseVisualStyleBackColor = false;
			this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
			// 
			// btn_Xoa
			// 
			this.btn_Xoa.BackColor = System.Drawing.Color.Teal;
			this.btn_Xoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_Xoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btn_Xoa.Location = new System.Drawing.Point(693, 179);
			this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2);
			this.btn_Xoa.Name = "btn_Xoa";
			this.btn_Xoa.Size = new System.Drawing.Size(90, 46);
			this.btn_Xoa.TabIndex = 3;
			this.btn_Xoa.Text = "Xóa";
			this.btn_Xoa.UseVisualStyleBackColor = false;
			this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
			// 
			// dgv_ListKhachHang
			// 
			this.dgv_ListKhachHang.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_ListKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_ListKhachHang.Location = new System.Drawing.Point(59, 246);
			this.dgv_ListKhachHang.Margin = new System.Windows.Forms.Padding(2);
			this.dgv_ListKhachHang.Name = "dgv_ListKhachHang";
			this.dgv_ListKhachHang.RowHeadersWidth = 62;
			this.dgv_ListKhachHang.Size = new System.Drawing.Size(724, 304);
			this.dgv_ListKhachHang.TabIndex = 4;
			this.dgv_ListKhachHang.Text = "dataGridView1";
			this.dgv_ListKhachHang.SelectionChanged += new System.EventHandler(this.dgv_ListKhachHang_SelectionChanged);
			// 
			// lbl_XoaTimKiem
			// 
			this.lbl_XoaTimKiem.AutoSize = true;
			this.lbl_XoaTimKiem.BackColor = System.Drawing.SystemColors.ControlLight;
			this.lbl_XoaTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_XoaTimKiem.Location = new System.Drawing.Point(634, 202);
			this.lbl_XoaTimKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_XoaTimKiem.Name = "lbl_XoaTimKiem";
			this.lbl_XoaTimKiem.Size = new System.Drawing.Size(18, 18);
			this.lbl_XoaTimKiem.TabIndex = 14;
			this.lbl_XoaTimKiem.Text = "X";
			this.lbl_XoaTimKiem.Click += new System.EventHandler(this.lbl_XoaTimKiem_Click);
			this.lbl_XoaTimKiem.MouseLeave += new System.EventHandler(this.lbl_XoaTimKiem_MouseLeave);
			this.lbl_XoaTimKiem.MouseHover += new System.EventHandler(this.lbl_XoaTimKiem_MouseHover);
			// 
			// UC_QuanLiKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbl_XoaTimKiem);
			this.Controls.Add(this.dgv_ListKhachHang);
			this.Controls.Add(this.btn_Xoa);
			this.Controls.Add(this.btn_CapNhat);
			this.Controls.Add(this.btn_ThemKhachHang);
			this.Controls.Add(this.txt_TienNo);
			this.Controls.Add(this.txt_TimKiem);
			this.Controls.Add(this.txt_DiaChi);
			this.Controls.Add(this.txt_Email);
			this.Controls.Add(this.txt_DienThoai);
			this.Controls.Add(this.txt_HoTen);
			this.Controls.Add(this.txt_MaKhachHang);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UC_QuanLiKhachHang";
			this.Size = new System.Drawing.Size(838, 598);
			this.Load += new System.EventHandler(this.UC_QuanLiKhachHang_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_ListKhachHang)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_MaKhachHang;
        private System.Windows.Forms.TextBox txt_HoTen;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.TextBox txt_DienThoai;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_TienNo;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Button btn_ThemKhachHang;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.DataGridView dgv_ListKhachHang;
        private System.Windows.Forms.Label lbl_XoaTimKiem;
    }
}
