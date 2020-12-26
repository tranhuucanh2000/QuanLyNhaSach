namespace GUI
{
    partial class UC_LapBaoCaoCongNo
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
			this.dgv_listBaoCaoCongNo = new System.Windows.Forms.DataGridView();
			this.btn_LuuBaoCao = new System.Windows.Forms.Button();
			this.btn_XemBaoCao = new System.Windows.Forms.Button();
			this.dtp_NgayLap = new System.Windows.Forms.DateTimePicker();
			this.dtp_ThangBaoCao = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv_listBaoCaoCongNo)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_listBaoCaoCongNo
			// 
			this.dgv_listBaoCaoCongNo.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_listBaoCaoCongNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_listBaoCaoCongNo.Location = new System.Drawing.Point(45, 215);
			this.dgv_listBaoCaoCongNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dgv_listBaoCaoCongNo.Name = "dgv_listBaoCaoCongNo";
			this.dgv_listBaoCaoCongNo.RowHeadersWidth = 62;
			this.dgv_listBaoCaoCongNo.Size = new System.Drawing.Size(740, 339);
			this.dgv_listBaoCaoCongNo.TabIndex = 4;
			this.dgv_listBaoCaoCongNo.Text = "dataGridView1";
			// 
			// btn_LuuBaoCao
			// 
			this.btn_LuuBaoCao.BackColor = System.Drawing.Color.Teal;
			this.btn_LuuBaoCao.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_LuuBaoCao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_LuuBaoCao.Location = new System.Drawing.Point(672, 109);
			this.btn_LuuBaoCao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btn_LuuBaoCao.Name = "btn_LuuBaoCao";
			this.btn_LuuBaoCao.Size = new System.Drawing.Size(113, 57);
			this.btn_LuuBaoCao.TabIndex = 3;
			this.btn_LuuBaoCao.Text = "Lưu";
			this.btn_LuuBaoCao.UseVisualStyleBackColor = false;
			this.btn_LuuBaoCao.Click += new System.EventHandler(this.btn_LuuBaoCao_Click);
			// 
			// btn_XemBaoCao
			// 
			this.btn_XemBaoCao.BackColor = System.Drawing.Color.Teal;
			this.btn_XemBaoCao.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btn_XemBaoCao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_XemBaoCao.Location = new System.Drawing.Point(541, 109);
			this.btn_XemBaoCao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btn_XemBaoCao.Name = "btn_XemBaoCao";
			this.btn_XemBaoCao.Size = new System.Drawing.Size(113, 57);
			this.btn_XemBaoCao.TabIndex = 3;
			this.btn_XemBaoCao.Text = "Xem";
			this.btn_XemBaoCao.UseVisualStyleBackColor = false;
			this.btn_XemBaoCao.Click += new System.EventHandler(this.btn_XemBaoCao_Click);
			// 
			// dtp_NgayLap
			// 
			this.dtp_NgayLap.CustomFormat = "dd/MM/yyyy";
			this.dtp_NgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_NgayLap.Location = new System.Drawing.Point(300, 143);
			this.dtp_NgayLap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dtp_NgayLap.Name = "dtp_NgayLap";
			this.dtp_NgayLap.Size = new System.Drawing.Size(151, 27);
			this.dtp_NgayLap.TabIndex = 2;
			// 
			// dtp_ThangBaoCao
			// 
			this.dtp_ThangBaoCao.CustomFormat = "MM/yyyy";
			this.dtp_ThangBaoCao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_ThangBaoCao.Location = new System.Drawing.Point(300, 111);
			this.dtp_ThangBaoCao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dtp_ThangBaoCao.Name = "dtp_ThangBaoCao";
			this.dtp_ThangBaoCao.ShowUpDown = true;
			this.dtp_ThangBaoCao.Size = new System.Drawing.Size(151, 27);
			this.dtp_ThangBaoCao.TabIndex = 2;
			this.dtp_ThangBaoCao.ValueChanged += new System.EventHandler(this.DateTimePicker_ThangBaoCao_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(122, 143);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Ngày lập báo cáo:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(122, 111);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tháng:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label3.Location = new System.Drawing.Point(45, 39);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(234, 31);
			this.label3.TabIndex = 0;
			this.label3.Text = "Lập báo cáo công nợ";
			// 
			// UC_LapBaoCaoCongNo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtp_ThangBaoCao);
			this.Controls.Add(this.dtp_NgayLap);
			this.Controls.Add(this.btn_XemBaoCao);
			this.Controls.Add(this.btn_LuuBaoCao);
			this.Controls.Add(this.dgv_listBaoCaoCongNo);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "UC_LapBaoCaoCongNo";
			this.Size = new System.Drawing.Size(838, 598);
			this.Load += new System.EventHandler(this.UC_LapBaoCaoCongNo_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_listBaoCaoCongNo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_listBaoCaoCongNo;
        private System.Windows.Forms.Button btn_LuuBaoCao;
        private System.Windows.Forms.Button btn_XemBaoCao;
        private System.Windows.Forms.DateTimePicker dtp_NgayLap;
        private System.Windows.Forms.DateTimePicker dtp_ThangBaoCao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
