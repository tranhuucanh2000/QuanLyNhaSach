namespace GUI
{
    partial class UC_LapPhieuThuTien
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_TienNo = new System.Windows.Forms.TextBox();
			this.txt_HoTen = new System.Windows.Forms.TextBox();
			this.txt_MaKhachHang = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dtp_NgayThuTien = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txt_SoTienThu = new System.Windows.Forms.TextBox();
			this.txt_MaPhieuThu = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_TimKiem = new System.Windows.Forms.TextBox();
			this.btn_LapPhieu = new System.Windows.Forms.Button();
			this.dgv_ListKhachHang = new System.Windows.Forms.DataGridView();
			this.lbl_XoaTimKiem = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_ListKhachHang)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label1.Location = new System.Drawing.Point(46, 36);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(210, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lập phiếu thu tiền";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txt_TienNo);
			this.groupBox1.Controls.Add(this.txt_HoTen);
			this.groupBox1.Controls.Add(this.txt_MaKhachHang);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(46, 102);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(318, 144);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin khách hàng";
			// 
			// txt_TienNo
			// 
			this.txt_TienNo.Location = new System.Drawing.Point(89, 109);
			this.txt_TienNo.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TienNo.Name = "txt_TienNo";
			this.txt_TienNo.ReadOnly = true;
			this.txt_TienNo.Size = new System.Drawing.Size(211, 27);
			this.txt_TienNo.TabIndex = 1;
			// 
			// txt_HoTen
			// 
			this.txt_HoTen.Location = new System.Drawing.Point(89, 72);
			this.txt_HoTen.Margin = new System.Windows.Forms.Padding(2);
			this.txt_HoTen.Name = "txt_HoTen";
			this.txt_HoTen.ReadOnly = true;
			this.txt_HoTen.Size = new System.Drawing.Size(211, 27);
			this.txt_HoTen.TabIndex = 1;
			// 
			// txt_MaKhachHang
			// 
			this.txt_MaKhachHang.Location = new System.Drawing.Point(89, 34);
			this.txt_MaKhachHang.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaKhachHang.Name = "txt_MaKhachHang";
			this.txt_MaKhachHang.ReadOnly = true;
			this.txt_MaKhachHang.Size = new System.Drawing.Size(211, 27);
			this.txt_MaKhachHang.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 109);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "Tiền nợ:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 72);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "Họ tên:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 34);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã KH:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dtp_NgayThuTien);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txt_SoTienThu);
			this.groupBox2.Controls.Add(this.txt_MaPhieuThu);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(388, 102);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(269, 144);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin phiếu thu tiền";
			// 
			// dtp_NgayThuTien
			// 
			this.dtp_NgayThuTien.CustomFormat = "dd/MM/yyyy";
			this.dtp_NgayThuTien.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_NgayThuTien.Location = new System.Drawing.Point(129, 109);
			this.dtp_NgayThuTien.Margin = new System.Windows.Forms.Padding(2);
			this.dtp_NgayThuTien.Name = "dtp_NgayThuTien";
			this.dtp_NgayThuTien.Size = new System.Drawing.Size(122, 27);
			this.dtp_NgayThuTien.TabIndex = 2;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(26, 109);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(101, 20);
			this.label7.TabIndex = 0;
			this.label7.Text = "Ngày thu tiền:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(26, 72);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(83, 20);
			this.label6.TabIndex = 0;
			this.label6.Text = "Số tiền thu:";
			// 
			// txt_SoTienThu
			// 
			this.txt_SoTienThu.Location = new System.Drawing.Point(127, 72);
			this.txt_SoTienThu.Margin = new System.Windows.Forms.Padding(2);
			this.txt_SoTienThu.Name = "txt_SoTienThu";
			this.txt_SoTienThu.Size = new System.Drawing.Size(123, 27);
			this.txt_SoTienThu.TabIndex = 1;
			this.txt_SoTienThu.TextChanged += new System.EventHandler(this.txt_SoTienThu_TextChanged);
			// 
			// txt_MaPhieuThu
			// 
			this.txt_MaPhieuThu.Location = new System.Drawing.Point(127, 34);
			this.txt_MaPhieuThu.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaPhieuThu.Name = "txt_MaPhieuThu";
			this.txt_MaPhieuThu.ReadOnly = true;
			this.txt_MaPhieuThu.Size = new System.Drawing.Size(123, 27);
			this.txt_MaPhieuThu.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(26, 34);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 20);
			this.label5.TabIndex = 0;
			this.label5.Text = "Mã phiếu thu:";
			// 
			// txt_TimKiem
			// 
			this.txt_TimKiem.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.txt_TimKiem.Location = new System.Drawing.Point(46, 271);
			this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TimKiem.Name = "txt_TimKiem";
			this.txt_TimKiem.Size = new System.Drawing.Size(742, 27);
			this.txt_TimKiem.TabIndex = 2;
			this.txt_TimKiem.Text = "Tìm kiếm bằng Mã KH, Họ tên hoặc SĐT...";
			this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
			// 
			// btn_LapPhieu
			// 
			this.btn_LapPhieu.BackColor = System.Drawing.Color.Teal;
			this.btn_LapPhieu.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_LapPhieu.ForeColor = System.Drawing.SystemColors.InactiveBorder;
			this.btn_LapPhieu.Location = new System.Drawing.Point(680, 111);
			this.btn_LapPhieu.Margin = new System.Windows.Forms.Padding(2);
			this.btn_LapPhieu.Name = "btn_LapPhieu";
			this.btn_LapPhieu.Size = new System.Drawing.Size(108, 135);
			this.btn_LapPhieu.TabIndex = 3;
			this.btn_LapPhieu.Text = "Lập phiếu";
			this.btn_LapPhieu.UseVisualStyleBackColor = false;
			this.btn_LapPhieu.Click += new System.EventHandler(this.btn_LapPhieu_Click);
			// 
			// dgv_ListKhachHang
			// 
			this.dgv_ListKhachHang.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_ListKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_ListKhachHang.Location = new System.Drawing.Point(46, 317);
			this.dgv_ListKhachHang.Margin = new System.Windows.Forms.Padding(2);
			this.dgv_ListKhachHang.Name = "dgv_ListKhachHang";
			this.dgv_ListKhachHang.RowHeadersWidth = 62;
			this.dgv_ListKhachHang.Size = new System.Drawing.Size(742, 237);
			this.dgv_ListKhachHang.TabIndex = 4;
			this.dgv_ListKhachHang.Text = "dataGridView1";
			this.dgv_ListKhachHang.SelectionChanged += new System.EventHandler(this.dgv_ListKhachHang_SelectionChanged);
			// 
			// lbl_XoaTimKiem
			// 
			this.lbl_XoaTimKiem.AutoSize = true;
			this.lbl_XoaTimKiem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.lbl_XoaTimKiem.Location = new System.Drawing.Point(765, 274);
			this.lbl_XoaTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_XoaTimKiem.Name = "lbl_XoaTimKiem";
			this.lbl_XoaTimKiem.Size = new System.Drawing.Size(18, 20);
			this.lbl_XoaTimKiem.TabIndex = 5;
			this.lbl_XoaTimKiem.Text = "X";
			this.lbl_XoaTimKiem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbl_XoaTimKiem_MouseClick);
			// 
			// UC_LapPhieuThuTien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbl_XoaTimKiem);
			this.Controls.Add(this.dgv_ListKhachHang);
			this.Controls.Add(this.btn_LapPhieu);
			this.Controls.Add(this.txt_TimKiem);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UC_LapPhieuThuTien";
			this.Size = new System.Drawing.Size(838, 598);
			this.Load += new System.EventHandler(this.UC_LapPhieuThuTien_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_ListKhachHang)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_TienNo;
        private System.Windows.Forms.TextBox txt_HoTen;
        private System.Windows.Forms.TextBox txt_MaKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_NgayThuTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_SoTienThu;
        private System.Windows.Forms.TextBox txt_MaPhieuThu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Button btn_LapPhieu;
        private System.Windows.Forms.DataGridView dgv_ListKhachHang;
        private System.Windows.Forms.Label lbl_XoaTimKiem;
    }
}
