namespace GUI
{
    partial class UC_TraCuuSach
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
			this.txt_TimKiem = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbb_TheLoai = new System.Windows.Forms.ComboBox();
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
			this.label1.Location = new System.Drawing.Point(34, 27);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(145, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tra cứu sách";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(60, 101);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tìm kiếm:";
			// 
			// txt_TimKiem
			// 
			this.txt_TimKiem.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.txt_TimKiem.Location = new System.Drawing.Point(142, 99);
			this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(2);
			this.txt_TimKiem.Name = "txt_TimKiem";
			this.txt_TimKiem.Size = new System.Drawing.Size(403, 27);
			this.txt_TimKiem.TabIndex = 1;
			this.txt_TimKiem.Text = "Tìm kiếm bằng Mã Sách hoặc Tên sách...";
			this.txt_TimKiem.Click += new System.EventHandler(this.txt_TimKiem_Click);
			this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
			this.txt_TimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TimKiem_KeyDown);
			this.txt_TimKiem.Leave += new System.EventHandler(this.txt_TimKiem_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(566, 101);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Thể loại:";
			// 
			// cbb_TheLoai
			// 
			this.cbb_TheLoai.FormattingEnabled = true;
			this.cbb_TheLoai.Location = new System.Drawing.Point(635, 97);
			this.cbb_TheLoai.Margin = new System.Windows.Forms.Padding(2);
			this.cbb_TheLoai.Name = "cbb_TheLoai";
			this.cbb_TheLoai.Size = new System.Drawing.Size(146, 28);
			this.cbb_TheLoai.TabIndex = 3;
			this.cbb_TheLoai.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
			// 
			// dgv_ListSach
			// 
			this.dgv_ListSach.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_ListSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_ListSach.Location = new System.Drawing.Point(57, 147);
			this.dgv_ListSach.Margin = new System.Windows.Forms.Padding(2);
			this.dgv_ListSach.Name = "dgv_ListSach";
			this.dgv_ListSach.RowHeadersWidth = 62;
			this.dgv_ListSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_ListSach.Size = new System.Drawing.Size(724, 406);
			this.dgv_ListSach.TabIndex = 4;
			this.dgv_ListSach.Text = "dataGridView1";
			this.dgv_ListSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ListSach_CellContentClick);
			// 
			// lbl_XoaTimKiem
			// 
			this.lbl_XoaTimKiem.AutoSize = true;
			this.lbl_XoaTimKiem.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.lbl_XoaTimKiem.Location = new System.Drawing.Point(524, 102);
			this.lbl_XoaTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_XoaTimKiem.Name = "lbl_XoaTimKiem";
			this.lbl_XoaTimKiem.Size = new System.Drawing.Size(18, 20);
			this.lbl_XoaTimKiem.TabIndex = 5;
			this.lbl_XoaTimKiem.Text = "X";
			this.lbl_XoaTimKiem.Visible = false;
			this.lbl_XoaTimKiem.Click += new System.EventHandler(this.lbl_XoaTimKiem_Click);
			this.lbl_XoaTimKiem.MouseLeave += new System.EventHandler(this.lbl_XoaTimKiem_MouseLeave);
			this.lbl_XoaTimKiem.MouseHover += new System.EventHandler(this.lbl_XoaTimKiem_MouseHover);
			// 
			// UC_TraCuuSach
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbl_XoaTimKiem);
			this.Controls.Add(this.dgv_ListSach);
			this.Controls.Add(this.cbb_TheLoai);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_TimKiem);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UC_TraCuuSach";
			this.Size = new System.Drawing.Size(838, 598);
			this.Load += new System.EventHandler(this.UC_TraCuuSach_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_ListSach)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_TheLoai;
        private System.Windows.Forms.DataGridView dgv_ListSach;
        private System.Windows.Forms.Label lbl_XoaTimKiem;
    }
}
