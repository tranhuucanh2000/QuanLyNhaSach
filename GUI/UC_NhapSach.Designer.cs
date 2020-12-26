namespace GUI
{
    partial class UC_NhapSach
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
			this.dgv_listSachNhap = new System.Windows.Forms.DataGridView();
			this.btn_XoaDongLoi = new System.Windows.Forms.Button();
			this.btn_NhapSach = new System.Windows.Forms.Button();
			this.dtp_NgayNhap = new System.Windows.Forms.DateTimePicker();
			this.txt_SLtonToiDa = new System.Windows.Forms.TextBox();
			this.txt_SLnhapToiThieu = new System.Windows.Forms.TextBox();
			this.txt_MaPhieuNhap = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv_listSachNhap)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_listSachNhap
			// 
			this.dgv_listSachNhap.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_listSachNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_listSachNhap.Location = new System.Drawing.Point(53, 267);
			this.dgv_listSachNhap.Margin = new System.Windows.Forms.Padding(2);
			this.dgv_listSachNhap.Name = "dgv_listSachNhap";
			this.dgv_listSachNhap.RowHeadersWidth = 62;
			this.dgv_listSachNhap.Size = new System.Drawing.Size(725, 279);
			this.dgv_listSachNhap.TabIndex = 4;
			this.dgv_listSachNhap.Text = "dataGridView1";
			this.dgv_listSachNhap.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_listSach_CellValueChanged);
			// 
			// btn_XoaDongLoi
			// 
			this.btn_XoaDongLoi.BackColor = System.Drawing.Color.Teal;
			this.btn_XoaDongLoi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_XoaDongLoi.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_XoaDongLoi.Location = new System.Drawing.Point(552, 107);
			this.btn_XoaDongLoi.Margin = new System.Windows.Forms.Padding(2);
			this.btn_XoaDongLoi.Name = "btn_XoaDongLoi";
			this.btn_XoaDongLoi.Size = new System.Drawing.Size(171, 60);
			this.btn_XoaDongLoi.TabIndex = 5;
			this.btn_XoaDongLoi.Text = "Xóa tất cả dòng lỗi";
			this.btn_XoaDongLoi.UseVisualStyleBackColor = false;
			this.btn_XoaDongLoi.Click += new System.EventHandler(this.btn_XoaDongLoi_Click);
			// 
			// btn_NhapSach
			// 
			this.btn_NhapSach.BackColor = System.Drawing.Color.Teal;
			this.btn_NhapSach.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_NhapSach.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_NhapSach.Location = new System.Drawing.Point(552, 182);
			this.btn_NhapSach.Margin = new System.Windows.Forms.Padding(2);
			this.btn_NhapSach.Name = "btn_NhapSach";
			this.btn_NhapSach.Size = new System.Drawing.Size(171, 59);
			this.btn_NhapSach.TabIndex = 5;
			this.btn_NhapSach.Text = "Nhập sách";
			this.btn_NhapSach.UseVisualStyleBackColor = false;
			this.btn_NhapSach.Click += new System.EventHandler(this.btn_NhapSach_Click);
			// 
			// dtp_NgayNhap
			// 
			this.dtp_NgayNhap.CustomFormat = "dd/MM/yyyy";
			this.dtp_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_NgayNhap.Location = new System.Drawing.Point(291, 142);
			this.dtp_NgayNhap.Margin = new System.Windows.Forms.Padding(2);
			this.dtp_NgayNhap.Name = "dtp_NgayNhap";
			this.dtp_NgayNhap.Size = new System.Drawing.Size(161, 27);
			this.dtp_NgayNhap.TabIndex = 3;
			// 
			// txt_SLtonToiDa
			// 
			this.txt_SLtonToiDa.Location = new System.Drawing.Point(291, 214);
			this.txt_SLtonToiDa.Margin = new System.Windows.Forms.Padding(2);
			this.txt_SLtonToiDa.Name = "txt_SLtonToiDa";
			this.txt_SLtonToiDa.ReadOnly = true;
			this.txt_SLtonToiDa.Size = new System.Drawing.Size(162, 27);
			this.txt_SLtonToiDa.TabIndex = 2;
			// 
			// txt_SLnhapToiThieu
			// 
			this.txt_SLnhapToiThieu.Location = new System.Drawing.Point(291, 179);
			this.txt_SLnhapToiThieu.Margin = new System.Windows.Forms.Padding(2);
			this.txt_SLnhapToiThieu.Name = "txt_SLnhapToiThieu";
			this.txt_SLnhapToiThieu.ReadOnly = true;
			this.txt_SLnhapToiThieu.Size = new System.Drawing.Size(162, 27);
			this.txt_SLnhapToiThieu.TabIndex = 2;
			// 
			// txt_MaPhieuNhap
			// 
			this.txt_MaPhieuNhap.Location = new System.Drawing.Point(291, 107);
			this.txt_MaPhieuNhap.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaPhieuNhap.Name = "txt_MaPhieuNhap";
			this.txt_MaPhieuNhap.ReadOnly = true;
			this.txt_MaPhieuNhap.Size = new System.Drawing.Size(161, 27);
			this.txt_MaPhieuNhap.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(96, 217);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Số lượng tồn tối đa:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(96, 182);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Số lượng nhập tối thiểu:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(96, 147);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "Ngày nhập:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(96, 110);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(111, 20);
			this.label6.TabIndex = 1;
			this.label6.Text = "Mã phiếu nhập:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label7.Location = new System.Drawing.Point(35, 39);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(232, 31);
			this.label7.TabIndex = 0;
			this.label7.Text = "Lập phiếu nhập sách";
			// 
			// UC_NhapSach
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_MaPhieuNhap);
			this.Controls.Add(this.txt_SLnhapToiThieu);
			this.Controls.Add(this.txt_SLtonToiDa);
			this.Controls.Add(this.dtp_NgayNhap);
			this.Controls.Add(this.btn_NhapSach);
			this.Controls.Add(this.btn_XoaDongLoi);
			this.Controls.Add(this.dgv_listSachNhap);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UC_NhapSach";
			this.Size = new System.Drawing.Size(838, 598);
			this.Load += new System.EventHandler(this.UC_NhapSach_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_listSachNhap)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_listSachNhap;
        private System.Windows.Forms.Button btn_XoaDongLoi;
        private System.Windows.Forms.Button btn_NhapSach;
        private System.Windows.Forms.DateTimePicker dtp_NgayNhap;
        private System.Windows.Forms.TextBox txt_SLtonToiDa;
        private System.Windows.Forms.TextBox txt_SLnhapToiThieu;
        private System.Windows.Forms.TextBox txt_MaPhieuNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_XoaTatCaDongLoi;
    }
}
