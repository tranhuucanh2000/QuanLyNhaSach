namespace GUI
{
    partial class UC_QuanLiPhieuThuTien
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
			this.dgv_PhieuThuTien = new System.Windows.Forms.DataGridView();
			this.txt_TimKiem = new System.Windows.Forms.TextBox();
			this.txt_SoTienThu = new System.Windows.Forms.TextBox();
			this.txt_HoTen = new System.Windows.Forms.TextBox();
			this.txt_MaKhachHang = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.DateTimePicker_NgayThuTien = new System.Windows.Forms.DateTimePicker();
			this.txt_MaPhieuThu = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl_XoaTimKiem = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv_PhieuThuTien)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgv_PhieuThuTien
			// 
			this.dgv_PhieuThuTien.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_PhieuThuTien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_PhieuThuTien.Location = new System.Drawing.Point(57, 294);
			this.dgv_PhieuThuTien.Margin = new System.Windows.Forms.Padding(2);
			this.dgv_PhieuThuTien.Name = "dgv_PhieuThuTien";
			this.dgv_PhieuThuTien.RowHeadersWidth = 62;
			this.dgv_PhieuThuTien.Size = new System.Drawing.Size(724, 260);
			this.dgv_PhieuThuTien.TabIndex = 4;
			this.dgv_PhieuThuTien.Text = "dataGridView1";
			this.dgv_PhieuThuTien.SelectionChanged += new System.EventHandler(this.dgv_PhieuThuTien_SelectionChanged);
			// 
			// txt_TimKiem
			// 
			this.txt_TimKiem.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.txt_TimKiem.Location = new System.Drawing.Point(57, 245);
			this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TimKiem.Name = "txt_TimKiem";
			this.txt_TimKiem.Size = new System.Drawing.Size(724, 27);
			this.txt_TimKiem.TabIndex = 2;
			this.txt_TimKiem.Text = "Tìm kiếm bằng Mã Phiếu Thu";
			this.txt_TimKiem.Click += new System.EventHandler(this.txt_TimKiem_Click);
			this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
			this.txt_TimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TimKiem_KeyDown);
			// 
			// txt_SoTienThu
			// 
			this.txt_SoTienThu.Location = new System.Drawing.Point(487, 66);
			this.txt_SoTienThu.Margin = new System.Windows.Forms.Padding(2);
			this.txt_SoTienThu.Name = "txt_SoTienThu";
			this.txt_SoTienThu.ReadOnly = true;
			this.txt_SoTienThu.Size = new System.Drawing.Size(191, 27);
			this.txt_SoTienThu.TabIndex = 1;
			// 
			// txt_HoTen
			// 
			this.txt_HoTen.Location = new System.Drawing.Point(137, 99);
			this.txt_HoTen.Margin = new System.Windows.Forms.Padding(2);
			this.txt_HoTen.Name = "txt_HoTen";
			this.txt_HoTen.ReadOnly = true;
			this.txt_HoTen.Size = new System.Drawing.Size(191, 27);
			this.txt_HoTen.TabIndex = 1;
			// 
			// txt_MaKhachHang
			// 
			this.txt_MaKhachHang.Location = new System.Drawing.Point(137, 66);
			this.txt_MaKhachHang.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaKhachHang.Name = "txt_MaKhachHang";
			this.txt_MaKhachHang.ReadOnly = true;
			this.txt_MaKhachHang.Size = new System.Drawing.Size(191, 27);
			this.txt_MaKhachHang.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(368, 69);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "Số tiền thu:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 102);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 20);
			this.label5.TabIndex = 0;
			this.label5.Text = "Họ tên:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 69);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 20);
			this.label6.TabIndex = 0;
			this.label6.Text = "Mã KH:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label7.Location = new System.Drawing.Point(35, 27);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(249, 31);
			this.label7.TabIndex = 0;
			this.label7.Text = "Quản lí phiếu thu tiền";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.DateTimePicker_NgayThuTien);
			this.groupBox2.Controls.Add(this.txt_SoTienThu);
			this.groupBox2.Controls.Add(this.txt_HoTen);
			this.groupBox2.Controls.Add(this.txt_MaPhieuThu);
			this.groupBox2.Controls.Add(this.txt_MaKhachHang);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(57, 83);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(724, 144);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin phiếu thu tiền";
			// 
			// DateTimePicker_NgayThuTien
			// 
			this.DateTimePicker_NgayThuTien.CustomFormat = "dd/MM/yyyy";
			this.DateTimePicker_NgayThuTien.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.DateTimePicker_NgayThuTien.Location = new System.Drawing.Point(487, 34);
			this.DateTimePicker_NgayThuTien.Margin = new System.Windows.Forms.Padding(2);
			this.DateTimePicker_NgayThuTien.Name = "DateTimePicker_NgayThuTien";
			this.DateTimePicker_NgayThuTien.Size = new System.Drawing.Size(191, 27);
			this.DateTimePicker_NgayThuTien.TabIndex = 2;
			// 
			// txt_MaPhieuThu
			// 
			this.txt_MaPhieuThu.Location = new System.Drawing.Point(137, 34);
			this.txt_MaPhieuThu.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaPhieuThu.Name = "txt_MaPhieuThu";
			this.txt_MaPhieuThu.ReadOnly = true;
			this.txt_MaPhieuThu.Size = new System.Drawing.Size(191, 27);
			this.txt_MaPhieuThu.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(368, 37);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Ngày thu tiền:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 39);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã phiếu thu:";
			// 
			// lbl_XoaTimKiem
			// 
			this.lbl_XoaTimKiem.AutoSize = true;
			this.lbl_XoaTimKiem.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.lbl_XoaTimKiem.Location = new System.Drawing.Point(759, 249);
			this.lbl_XoaTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_XoaTimKiem.Name = "lbl_XoaTimKiem";
			this.lbl_XoaTimKiem.Size = new System.Drawing.Size(18, 20);
			this.lbl_XoaTimKiem.TabIndex = 5;
			this.lbl_XoaTimKiem.Text = "X";
			this.lbl_XoaTimKiem.Click += new System.EventHandler(this.lbl_XoaTimKiem_Click);
			// 
			// UC_QuanLiPhieuThuTien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbl_XoaTimKiem);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txt_TimKiem);
			this.Controls.Add(this.dgv_PhieuThuTien);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UC_QuanLiPhieuThuTien";
			this.Size = new System.Drawing.Size(838, 598);
			this.Load += new System.EventHandler(this.UC_QuanLiPhieuThuTien_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_PhieuThuTien)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_PhieuThuTien;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.TextBox txt_SoTienThu;
        private System.Windows.Forms.TextBox txt_HoTen;
        private System.Windows.Forms.TextBox txt_MaKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker DateTimePicker_NgayThuTien;
        private System.Windows.Forms.TextBox txt_MaPhieuThu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_XoaTimKiem;
    }
}
