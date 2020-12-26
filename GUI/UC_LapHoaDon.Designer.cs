namespace GUI
{
    partial class UC_LapHoaDon
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
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txt_MaHoaDon = new System.Windows.Forms.TextBox();
			this.txt_MaKH = new System.Windows.Forms.TextBox();
			this.txt_HoTenKH = new System.Windows.Forms.TextBox();
			this.txt_SoTienNo = new System.Windows.Forms.TextBox();
			this.dtp_NgayLap = new System.Windows.Forms.DateTimePicker();
			this.dgv_listSach = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_TongTien = new System.Windows.Forms.TextBox();
			this.btn_XoaDongLoi = new System.Windows.Forms.Button();
			this.btn_LapHoaDon = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_listSach)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label1.Location = new System.Drawing.Point(46, 43);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(246, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lập hóa đơn bán sách";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(76, 127);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mã hóa đơn:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(76, 168);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Ngày nhập:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(76, 206);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "Mã khách hàng:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(76, 247);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 20);
			this.label6.TabIndex = 1;
			this.label6.Text = "Họ tên khách hàng:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(458, 127);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(79, 20);
			this.label7.TabIndex = 1;
			this.label7.Text = "Số tiền nợ:";
			// 
			// txt_MaHoaDon
			// 
			this.txt_MaHoaDon.Location = new System.Drawing.Point(233, 124);
			this.txt_MaHoaDon.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaHoaDon.Name = "txt_MaHoaDon";
			this.txt_MaHoaDon.ReadOnly = true;
			this.txt_MaHoaDon.Size = new System.Drawing.Size(178, 27);
			this.txt_MaHoaDon.TabIndex = 2;
			this.txt_MaHoaDon.TextChanged += new System.EventHandler(this.txt_MaKH_TextChanged);
			// 
			// txt_MaKH
			// 
			this.txt_MaKH.Location = new System.Drawing.Point(233, 203);
			this.txt_MaKH.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaKH.Name = "txt_MaKH";
			this.txt_MaKH.Size = new System.Drawing.Size(178, 27);
			this.txt_MaKH.TabIndex = 2;
			this.txt_MaKH.TextChanged += new System.EventHandler(this.txt_MaKH_TextChanged);
			// 
			// txt_HoTenKH
			// 
			this.txt_HoTenKH.Location = new System.Drawing.Point(233, 244);
			this.txt_HoTenKH.Margin = new System.Windows.Forms.Padding(2);
			this.txt_HoTenKH.Name = "txt_HoTenKH";
			this.txt_HoTenKH.ReadOnly = true;
			this.txt_HoTenKH.Size = new System.Drawing.Size(178, 27);
			this.txt_HoTenKH.TabIndex = 2;
			// 
			// txt_SoTienNo
			// 
			this.txt_SoTienNo.Location = new System.Drawing.Point(585, 124);
			this.txt_SoTienNo.Margin = new System.Windows.Forms.Padding(2);
			this.txt_SoTienNo.Name = "txt_SoTienNo";
			this.txt_SoTienNo.ReadOnly = true;
			this.txt_SoTienNo.Size = new System.Drawing.Size(178, 27);
			this.txt_SoTienNo.TabIndex = 2;
			// 
			// dtp_NgayLap
			// 
			this.dtp_NgayLap.CustomFormat = "dd/MM/yyyy";
			this.dtp_NgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_NgayLap.Location = new System.Drawing.Point(233, 163);
			this.dtp_NgayLap.Margin = new System.Windows.Forms.Padding(2);
			this.dtp_NgayLap.Name = "dtp_NgayLap";
			this.dtp_NgayLap.Size = new System.Drawing.Size(178, 27);
			this.dtp_NgayLap.TabIndex = 3;
			// 
			// dgv_listSach
			// 
			this.dgv_listSach.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_listSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_listSach.Location = new System.Drawing.Point(46, 306);
			this.dgv_listSach.Margin = new System.Windows.Forms.Padding(2);
			this.dgv_listSach.Name = "dgv_listSach";
			this.dgv_listSach.RowHeadersWidth = 62;
			this.dgv_listSach.Size = new System.Drawing.Size(741, 209);
			this.dgv_listSach.TabIndex = 4;
			this.dgv_listSach.Text = "dataGridView1";
			this.dgv_listSach.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_listSach_CellValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(560, 535);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 20);
			this.label4.TabIndex = 1;
			this.label4.Text = "Tổng tiền:";
			// 
			// txt_TongTien
			// 
			this.txt_TongTien.Location = new System.Drawing.Point(644, 535);
			this.txt_TongTien.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TongTien.Name = "txt_TongTien";
			this.txt_TongTien.ReadOnly = true;
			this.txt_TongTien.Size = new System.Drawing.Size(143, 27);
			this.txt_TongTien.TabIndex = 2;
			// 
			// btn_XoaDongLoi
			// 
			this.btn_XoaDongLoi.BackColor = System.Drawing.Color.Teal;
			this.btn_XoaDongLoi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_XoaDongLoi.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_XoaDongLoi.Location = new System.Drawing.Point(458, 174);
			this.btn_XoaDongLoi.Margin = new System.Windows.Forms.Padding(2);
			this.btn_XoaDongLoi.Name = "btn_XoaDongLoi";
			this.btn_XoaDongLoi.Size = new System.Drawing.Size(305, 44);
			this.btn_XoaDongLoi.TabIndex = 5;
			this.btn_XoaDongLoi.Text = "Xóa tất cả dòng lỗi";
			this.btn_XoaDongLoi.UseVisualStyleBackColor = false;
			this.btn_XoaDongLoi.Click += new System.EventHandler(this.btn_XoaDongLoi_Click);
			// 
			// btn_LapHoaDon
			// 
			this.btn_LapHoaDon.BackColor = System.Drawing.Color.Teal;
			this.btn_LapHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_LapHoaDon.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_LapHoaDon.Location = new System.Drawing.Point(458, 227);
			this.btn_LapHoaDon.Margin = new System.Windows.Forms.Padding(2);
			this.btn_LapHoaDon.Name = "btn_LapHoaDon";
			this.btn_LapHoaDon.Size = new System.Drawing.Size(305, 44);
			this.btn_LapHoaDon.TabIndex = 5;
			this.btn_LapHoaDon.Text = "Lập hóa đơn";
			this.btn_LapHoaDon.UseVisualStyleBackColor = false;
			this.btn_LapHoaDon.Click += new System.EventHandler(this.btn_Nhap_Click);
			// 
			// UC_LapHoaDon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btn_LapHoaDon);
			this.Controls.Add(this.btn_XoaDongLoi);
			this.Controls.Add(this.dgv_listSach);
			this.Controls.Add(this.dtp_NgayLap);
			this.Controls.Add(this.txt_SoTienNo);
			this.Controls.Add(this.txt_HoTenKH);
			this.Controls.Add(this.txt_TongTien);
			this.Controls.Add(this.txt_MaKH);
			this.Controls.Add(this.txt_MaHoaDon);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UC_LapHoaDon";
			this.Size = new System.Drawing.Size(838, 598);
			this.Load += new System.EventHandler(this.UC_LapHoaDon_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_listSach)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_MaHoaDon;
        private System.Windows.Forms.TextBox txt_MaKH;
        private System.Windows.Forms.TextBox txt_HoTenKH;
        private System.Windows.Forms.TextBox txt_SoTienNo;
        private System.Windows.Forms.DateTimePicker dtp_NgayLap;
        private System.Windows.Forms.DataGridView dgv_listSach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_TongTien;
        private System.Windows.Forms.Button btn_XoaDongLoi;
        private System.Windows.Forms.Button btn_LapHoaDon;
    }
}
