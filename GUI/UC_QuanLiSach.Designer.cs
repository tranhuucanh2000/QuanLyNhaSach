namespace GUI
{
    partial class UC_QuanLiSach
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
			this.txt_MaSach = new System.Windows.Forms.TextBox();
			this.txt_TenSach = new System.Windows.Forms.TextBox();
			this.txt_TacGia = new System.Windows.Forms.TextBox();
			this.txt_TheLoai = new System.Windows.Forms.TextBox();
			this.txt_SoLuongTon = new System.Windows.Forms.TextBox();
			this.txt_DonGia = new System.Windows.Forms.TextBox();
			this.txt_TimKiem = new System.Windows.Forms.TextBox();
			this.btn_ThemSach = new System.Windows.Forms.Button();
			this.btn_CapNhat = new System.Windows.Forms.Button();
			this.btn_Xoa = new System.Windows.Forms.Button();
			this.dgv_ListSach = new System.Windows.Forms.DataGridView();
			this.lbl_XoaTimKiem = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv_ListSach)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label1.Location = new System.Drawing.Point(33, 25);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Quản lí sách";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(63, 81);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã sách:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(63, 113);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tên sách:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(63, 144);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "Tác giả:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(359, 81);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 20);
			this.label5.TabIndex = 0;
			this.label5.Text = "Thể loại:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(359, 113);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98, 20);
			this.label6.TabIndex = 0;
			this.label6.Text = "Số lượng tồn:\r\n";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(359, 144);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 20);
			this.label7.TabIndex = 0;
			this.label7.Text = "Đơn giá:";
			// 
			// txt_MaSach
			// 
			this.txt_MaSach.Location = new System.Drawing.Point(140, 78);
			this.txt_MaSach.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaSach.Name = "txt_MaSach";
			this.txt_MaSach.ReadOnly = true;
			this.txt_MaSach.Size = new System.Drawing.Size(180, 27);
			this.txt_MaSach.TabIndex = 1;
			// 
			// txt_TenSach
			// 
			this.txt_TenSach.Location = new System.Drawing.Point(140, 110);
			this.txt_TenSach.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TenSach.Name = "txt_TenSach";
			this.txt_TenSach.ReadOnly = true;
			this.txt_TenSach.Size = new System.Drawing.Size(180, 27);
			this.txt_TenSach.TabIndex = 1;
			// 
			// txt_TacGia
			// 
			this.txt_TacGia.Location = new System.Drawing.Point(140, 141);
			this.txt_TacGia.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TacGia.Name = "txt_TacGia";
			this.txt_TacGia.ReadOnly = true;
			this.txt_TacGia.Size = new System.Drawing.Size(180, 27);
			this.txt_TacGia.TabIndex = 1;
			// 
			// txt_TheLoai
			// 
			this.txt_TheLoai.Location = new System.Drawing.Point(476, 78);
			this.txt_TheLoai.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TheLoai.Name = "txt_TheLoai";
			this.txt_TheLoai.ReadOnly = true;
			this.txt_TheLoai.Size = new System.Drawing.Size(180, 27);
			this.txt_TheLoai.TabIndex = 1;
			// 
			// txt_SoLuongTon
			// 
			this.txt_SoLuongTon.Location = new System.Drawing.Point(476, 109);
			this.txt_SoLuongTon.Margin = new System.Windows.Forms.Padding(2);
			this.txt_SoLuongTon.Name = "txt_SoLuongTon";
			this.txt_SoLuongTon.ReadOnly = true;
			this.txt_SoLuongTon.Size = new System.Drawing.Size(180, 27);
			this.txt_SoLuongTon.TabIndex = 1;
			// 
			// txt_DonGia
			// 
			this.txt_DonGia.Location = new System.Drawing.Point(476, 141);
			this.txt_DonGia.Margin = new System.Windows.Forms.Padding(2);
			this.txt_DonGia.Name = "txt_DonGia";
			this.txt_DonGia.ReadOnly = true;
			this.txt_DonGia.Size = new System.Drawing.Size(180, 27);
			this.txt_DonGia.TabIndex = 1;
			// 
			// txt_TimKiem
			// 
			this.txt_TimKiem.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.txt_TimKiem.Location = new System.Drawing.Point(59, 198);
			this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TimKiem.Name = "txt_TimKiem";
			this.txt_TimKiem.Size = new System.Drawing.Size(598, 27);
			this.txt_TimKiem.TabIndex = 1;
			this.txt_TimKiem.Text = "Tìm kiếm bằng Mã Sách hoặc Tên Sách....";
			this.txt_TimKiem.Click += new System.EventHandler(this.txt_TimKiem_Click);
			this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
			this.txt_TimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TimKiem_KeyDown);
			this.txt_TimKiem.Leave += new System.EventHandler(this.txt_TimKiem_Leave);
			// 
			// btn_ThemSach
			// 
			this.btn_ThemSach.BackColor = System.Drawing.Color.Teal;
			this.btn_ThemSach.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_ThemSach.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_ThemSach.Location = new System.Drawing.Point(693, 78);
			this.btn_ThemSach.Margin = new System.Windows.Forms.Padding(2);
			this.btn_ThemSach.Name = "btn_ThemSach";
			this.btn_ThemSach.Size = new System.Drawing.Size(90, 46);
			this.btn_ThemSach.TabIndex = 2;
			this.btn_ThemSach.Text = "Thêm sách";
			this.btn_ThemSach.UseVisualStyleBackColor = false;
			this.btn_ThemSach.Click += new System.EventHandler(this.btn_ThemSach_Click);
			// 
			// btn_CapNhat
			// 
			this.btn_CapNhat.BackColor = System.Drawing.Color.Teal;
			this.btn_CapNhat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_CapNhat.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_CapNhat.Location = new System.Drawing.Point(693, 131);
			this.btn_CapNhat.Margin = new System.Windows.Forms.Padding(2);
			this.btn_CapNhat.Name = "btn_CapNhat";
			this.btn_CapNhat.Size = new System.Drawing.Size(90, 46);
			this.btn_CapNhat.TabIndex = 2;
			this.btn_CapNhat.Text = "Cập Nhật";
			this.btn_CapNhat.UseVisualStyleBackColor = false;
			this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
			// 
			// btn_Xoa
			// 
			this.btn_Xoa.BackColor = System.Drawing.Color.Teal;
			this.btn_Xoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_Xoa.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_Xoa.Location = new System.Drawing.Point(693, 181);
			this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2);
			this.btn_Xoa.Name = "btn_Xoa";
			this.btn_Xoa.Size = new System.Drawing.Size(90, 46);
			this.btn_Xoa.TabIndex = 2;
			this.btn_Xoa.Text = "Xóa";
			this.btn_Xoa.UseVisualStyleBackColor = false;
			this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
			// 
			// dgv_ListSach
			// 
			this.dgv_ListSach.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_ListSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_ListSach.Location = new System.Drawing.Point(59, 246);
			this.dgv_ListSach.Margin = new System.Windows.Forms.Padding(2);
			this.dgv_ListSach.MultiSelect = false;
			this.dgv_ListSach.Name = "dgv_ListSach";
			this.dgv_ListSach.ReadOnly = true;
			this.dgv_ListSach.RowHeadersWidth = 62;
			this.dgv_ListSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_ListSach.Size = new System.Drawing.Size(724, 304);
			this.dgv_ListSach.TabIndex = 3;
			this.dgv_ListSach.Text = "dataGridView1";
			this.dgv_ListSach.SelectionChanged += new System.EventHandler(this.dgv_ListSach_SelectionChanged);
			// 
			// lbl_XoaTimKiem
			// 
			this.lbl_XoaTimKiem.AutoSize = true;
			this.lbl_XoaTimKiem.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.lbl_XoaTimKiem.Location = new System.Drawing.Point(636, 201);
			this.lbl_XoaTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_XoaTimKiem.Name = "lbl_XoaTimKiem";
			this.lbl_XoaTimKiem.Size = new System.Drawing.Size(18, 20);
			this.lbl_XoaTimKiem.TabIndex = 5;
			this.lbl_XoaTimKiem.Text = "X";
			this.lbl_XoaTimKiem.Click += new System.EventHandler(this.lbl_XoaTimKiem_Click);
			this.lbl_XoaTimKiem.MouseLeave += new System.EventHandler(this.lbl_XoaTimKiem_MouseLeave);
			this.lbl_XoaTimKiem.MouseHover += new System.EventHandler(this.lbl_XoaTimKiem_MouseHover);
			// 
			// UC_QuanLiSach
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbl_XoaTimKiem);
			this.Controls.Add(this.dgv_ListSach);
			this.Controls.Add(this.btn_Xoa);
			this.Controls.Add(this.btn_CapNhat);
			this.Controls.Add(this.btn_ThemSach);
			this.Controls.Add(this.txt_DonGia);
			this.Controls.Add(this.txt_TimKiem);
			this.Controls.Add(this.txt_TacGia);
			this.Controls.Add(this.txt_SoLuongTon);
			this.Controls.Add(this.txt_TheLoai);
			this.Controls.Add(this.txt_TenSach);
			this.Controls.Add(this.txt_MaSach);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UC_QuanLiSach";
			this.Size = new System.Drawing.Size(838, 598);
			this.Load += new System.EventHandler(this.UC_QuanLiSach_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_ListSach)).EndInit();
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
        private System.Windows.Forms.TextBox txt_MaSach;
        private System.Windows.Forms.TextBox txt_TenSach;
        private System.Windows.Forms.TextBox txt_TacGia;
        private System.Windows.Forms.TextBox txt_TheLoai;
        private System.Windows.Forms.TextBox txt_SoLuongTon;
        private System.Windows.Forms.TextBox txt_DonGia;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Button btn_ThemSach;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.DataGridView dgv_ListSach;
        private System.Windows.Forms.Label lbl_XoaTimKiem;
    }
}
