namespace GUI
{
    partial class frm_ThemSach
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txt_MaSach = new System.Windows.Forms.TextBox();
			this.txt_TenSach = new System.Windows.Forms.TextBox();
			this.txt_TacGia = new System.Windows.Forms.TextBox();
			this.txt_SoLuongTon = new System.Windows.Forms.TextBox();
			this.txt_DonGia = new System.Windows.Forms.TextBox();
			this.btn_Luu = new System.Windows.Forms.Button();
			this.btn_LuuVaThoat = new System.Windows.Forms.Button();
			this.cbb_TheLoai = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(36, 146);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã sách:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(36, 189);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tên sách:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(36, 276);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tác giả:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label4.Location = new System.Drawing.Point(36, 233);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Thể loại:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label5.Location = new System.Drawing.Point(36, 321);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(113, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Số lượng tồn:\r\n";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label6.Location = new System.Drawing.Point(36, 362);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Đơn giá:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label7.Location = new System.Drawing.Point(277, 56);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(175, 31);
			this.label7.TabIndex = 0;
			this.label7.Text = "Thêm sách mới";
			// 
			// txt_MaSach
			// 
			this.txt_MaSach.Location = new System.Drawing.Point(153, 142);
			this.txt_MaSach.Margin = new System.Windows.Forms.Padding(2);
			this.txt_MaSach.Name = "txt_MaSach";
			this.txt_MaSach.ReadOnly = true;
			this.txt_MaSach.Size = new System.Drawing.Size(325, 27);
			this.txt_MaSach.TabIndex = 1;
			// 
			// txt_TenSach
			// 
			this.txt_TenSach.Location = new System.Drawing.Point(153, 188);
			this.txt_TenSach.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TenSach.Name = "txt_TenSach";
			this.txt_TenSach.Size = new System.Drawing.Size(325, 27);
			this.txt_TenSach.TabIndex = 1;
			// 
			// txt_TacGia
			// 
			this.txt_TacGia.Location = new System.Drawing.Point(153, 275);
			this.txt_TacGia.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TacGia.Name = "txt_TacGia";
			this.txt_TacGia.Size = new System.Drawing.Size(325, 27);
			this.txt_TacGia.TabIndex = 1;
			// 
			// txt_SoLuongTon
			// 
			this.txt_SoLuongTon.Location = new System.Drawing.Point(153, 320);
			this.txt_SoLuongTon.Margin = new System.Windows.Forms.Padding(2);
			this.txt_SoLuongTon.Name = "txt_SoLuongTon";
			this.txt_SoLuongTon.Size = new System.Drawing.Size(325, 27);
			this.txt_SoLuongTon.TabIndex = 1;
			this.txt_SoLuongTon.Text = "0";
			// 
			// txt_DonGia
			// 
			this.txt_DonGia.Location = new System.Drawing.Point(153, 361);
			this.txt_DonGia.Name = "txt_DonGia";
			this.txt_DonGia.Size = new System.Drawing.Size(325, 27);
			this.txt_DonGia.TabIndex = 1;
			// 
			// btn_Luu
			// 
			this.btn_Luu.BackColor = System.Drawing.Color.Teal;
			this.btn_Luu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_Luu.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_Luu.Location = new System.Drawing.Point(531, 142);
			this.btn_Luu.Margin = new System.Windows.Forms.Padding(2);
			this.btn_Luu.Name = "btn_Luu";
			this.btn_Luu.Size = new System.Drawing.Size(123, 104);
			this.btn_Luu.TabIndex = 2;
			this.btn_Luu.Text = "Lưu";
			this.btn_Luu.UseVisualStyleBackColor = false;
			this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
			// 
			// btn_LuuVaThoat
			// 
			this.btn_LuuVaThoat.BackColor = System.Drawing.Color.Teal;
			this.btn_LuuVaThoat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_LuuVaThoat.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btn_LuuVaThoat.Location = new System.Drawing.Point(531, 284);
			this.btn_LuuVaThoat.Margin = new System.Windows.Forms.Padding(2);
			this.btn_LuuVaThoat.Name = "btn_LuuVaThoat";
			this.btn_LuuVaThoat.Size = new System.Drawing.Size(123, 104);
			this.btn_LuuVaThoat.TabIndex = 2;
			this.btn_LuuVaThoat.Text = "Thoát";
			this.btn_LuuVaThoat.UseVisualStyleBackColor = false;
			this.btn_LuuVaThoat.Click += new System.EventHandler(this.btn_LuuVaThoat_Click);
			// 
			// cbb_TheLoai
			// 
			this.cbb_TheLoai.FormattingEnabled = true;
			this.cbb_TheLoai.Location = new System.Drawing.Point(153, 232);
			this.cbb_TheLoai.Margin = new System.Windows.Forms.Padding(2);
			this.cbb_TheLoai.Name = "cbb_TheLoai";
			this.cbb_TheLoai.Size = new System.Drawing.Size(325, 28);
			this.cbb_TheLoai.TabIndex = 3;
			// 
			// frm_ThemSach
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(706, 444);
			this.Controls.Add(this.cbb_TheLoai);
			this.Controls.Add(this.btn_LuuVaThoat);
			this.Controls.Add(this.btn_Luu);
			this.Controls.Add(this.txt_DonGia);
			this.Controls.Add(this.txt_SoLuongTon);
			this.Controls.Add(this.txt_TacGia);
			this.Controls.Add(this.txt_TenSach);
			this.Controls.Add(this.txt_MaSach);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "frm_ThemSach";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thêm sách";
			this.Load += new System.EventHandler(this.frm_ThemSach_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ThemSach_KeyDown);
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
        private System.Windows.Forms.TextBox txt_SoLuongTon;
        private System.Windows.Forms.TextBox txt_DonGia;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_LuuVaThoat;
        private System.Windows.Forms.ComboBox cbb_TheLoai;
    }
}