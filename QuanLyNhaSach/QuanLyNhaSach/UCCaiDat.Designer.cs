
namespace QuanLyNhaSach
{
    partial class UCCaiDat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCaiDat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbDangXuat = new System.Windows.Forms.PictureBox();
            this.lbHoTro = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgCaiDatTaiKhoan = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDangXuat)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCaiDatTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.pbDangXuat);
            this.panel1.Controls.Add(this.lbHoTro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 50);
            this.panel1.TabIndex = 2;
            // 
            // pbDangXuat
            // 
            this.pbDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("pbDangXuat.Image")));
            this.pbDangXuat.Location = new System.Drawing.Point(950, 0);
            this.pbDangXuat.Name = "pbDangXuat";
            this.pbDangXuat.Size = new System.Drawing.Size(50, 50);
            this.pbDangXuat.TabIndex = 2;
            this.pbDangXuat.TabStop = false;
            // 
            // lbHoTro
            // 
            this.lbHoTro.AutoSize = true;
            this.lbHoTro.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoTro.ForeColor = System.Drawing.Color.White;
            this.lbHoTro.Location = new System.Drawing.Point(3, 12);
            this.lbHoTro.Name = "lbHoTro";
            this.lbHoTro.Size = new System.Drawing.Size(325, 25);
            this.lbHoTro.TabIndex = 1;
            this.lbHoTro.Text = "BỒ CÂU: \"Xin chào Trần Hữu Cảnh\"";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 670);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 570);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 100);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgCaiDatTaiKhoan);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 570);
            this.panel4.TabIndex = 1;
            // 
            // dtgCaiDatTaiKhoan
            // 
            this.dtgCaiDatTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCaiDatTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.dtgCaiDatTaiKhoan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgCaiDatTaiKhoan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCaiDatTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCaiDatTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCaiDatTaiKhoan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCaiDatTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCaiDatTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.dtgCaiDatTaiKhoan.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCaiDatTaiKhoan.Name = "dtgCaiDatTaiKhoan";
            this.dtgCaiDatTaiKhoan.ReadOnly = true;
            this.dtgCaiDatTaiKhoan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCaiDatTaiKhoan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCaiDatTaiKhoan.RowHeadersVisible = false;
            this.dtgCaiDatTaiKhoan.RowHeadersWidth = 51;
            this.dtgCaiDatTaiKhoan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgCaiDatTaiKhoan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCaiDatTaiKhoan.RowTemplate.Height = 24;
            this.dtgCaiDatTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCaiDatTaiKhoan.Size = new System.Drawing.Size(1000, 570);
            this.dtgCaiDatTaiKhoan.TabIndex = 3;
            // 
            // UCCaiDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCCaiDat";
            this.Size = new System.Drawing.Size(1000, 720);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDangXuat)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCaiDatTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbDangXuat;
        private System.Windows.Forms.Label lbHoTro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgCaiDatTaiKhoan;
    }
}
