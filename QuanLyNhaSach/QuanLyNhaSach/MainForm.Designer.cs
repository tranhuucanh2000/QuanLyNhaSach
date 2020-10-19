namespace QuanLyNhaSach
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbHoTro = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ptClose = new System.Windows.Forms.PictureBox();
            this.tabTaiKhoan = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtgSach = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbGiaTien = new System.Windows.Forms.TextBox();
            this.txbTacGia = new System.Windows.Forms.TextBox();
            this.txbSoLuong = new System.Windows.Forms.TextBox();
            this.txbTenSach = new System.Windows.Forms.TextBox();
            this.txbNXB = new System.Windows.Forms.TextBox();
            this.txbLoaiSach = new System.Windows.Forms.TextBox();
            this.lbGiaTien = new System.Windows.Forms.Label();
            this.lbTacGia = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.lbNXB = new System.Windows.Forms.Label();
            this.lbLoaiSach = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptClose)).BeginInit();
            this.tabTaiKhoan.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSach)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(182)))));
            this.panel1.Controls.Add(this.lbHoTro);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 70);
            this.panel1.TabIndex = 0;
            // 
            // lbHoTro
            // 
            this.lbHoTro.AutoSize = true;
            this.lbHoTro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoTro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbHoTro.Location = new System.Drawing.Point(108, 23);
            this.lbHoTro.Name = "lbHoTro";
            this.lbHoTro.Size = new System.Drawing.Size(340, 28);
            this.lbHoTro.TabIndex = 1;
            this.lbHoTro.Text = "BỒ CÂU: \"Tôi ở đây để hổ trợ bạn\"";
            this.lbHoTro.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ptClose
            // 
            this.ptClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(182)))));
            this.ptClose.Image = ((System.Drawing.Image)(resources.GetObject("ptClose.Image")));
            this.ptClose.Location = new System.Drawing.Point(1132, 1);
            this.ptClose.Name = "ptClose";
            this.ptClose.Size = new System.Drawing.Size(68, 50);
            this.ptClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptClose.TabIndex = 1;
            this.ptClose.TabStop = false;
            this.ptClose.Click += new System.EventHandler(this.ptClose_Click);
            // 
            // tabTaiKhoan
            // 
            this.tabTaiKhoan.Controls.Add(this.tabPage1);
            this.tabTaiKhoan.Controls.Add(this.tabPage2);
            this.tabTaiKhoan.Controls.Add(this.tabPage3);
            this.tabTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTaiKhoan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTaiKhoan.ItemSize = new System.Drawing.Size(55, 40);
            this.tabTaiKhoan.Location = new System.Drawing.Point(0, 70);
            this.tabTaiKhoan.Margin = new System.Windows.Forms.Padding(0);
            this.tabTaiKhoan.Name = "tabTaiKhoan";
            this.tabTaiKhoan.Padding = new System.Drawing.Point(108, 6);
            this.tabTaiKhoan.SelectedIndex = 0;
            this.tabTaiKhoan.Size = new System.Drawing.Size(1200, 650);
            this.tabTaiKhoan.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1192, 602);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kho Sách";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dtgSach);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 271);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1186, 328);
            this.panel9.TabIndex = 1;
            // 
            // dtgSach
            // 
            this.dtgSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSach.BackgroundColor = System.Drawing.Color.White;
            this.dtgSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgSach.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dtgSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSach.DefaultCellStyle = dataGridViewCellStyle26;
            this.dtgSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSach.Location = new System.Drawing.Point(0, 0);
            this.dtgSach.Margin = new System.Windows.Forms.Padding(0);
            this.dtgSach.Name = "dtgSach";
            this.dtgSach.ReadOnly = true;
            this.dtgSach.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dtgSach.RowHeadersVisible = false;
            this.dtgSach.RowHeadersWidth = 51;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgSach.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dtgSach.RowTemplate.Height = 24;
            this.dtgSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSach.Size = new System.Drawing.Size(1186, 328);
            this.dtgSach.TabIndex = 0;
            this.dtgSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSach_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txbGiaTien);
            this.panel2.Controls.Add(this.txbTacGia);
            this.panel2.Controls.Add(this.txbSoLuong);
            this.panel2.Controls.Add(this.txbTenSach);
            this.panel2.Controls.Add(this.txbNXB);
            this.panel2.Controls.Add(this.txbLoaiSach);
            this.panel2.Controls.Add(this.lbGiaTien);
            this.panel2.Controls.Add(this.lbTacGia);
            this.panel2.Controls.Add(this.lbSoLuong);
            this.panel2.Controls.Add(this.lbTenSach);
            this.panel2.Controls.Add(this.lbNXB);
            this.panel2.Controls.Add(this.lbLoaiSach);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 268);
            this.panel2.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Location = new System.Drawing.Point(714, 220);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(240, 1);
            this.panel8.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(200, 220);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 1);
            this.panel5.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(714, 148);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 1);
            this.panel7.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(200, 148);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 1);
            this.panel4.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(714, 69);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(240, 1);
            this.panel6.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(200, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 1);
            this.panel3.TabIndex = 7;
            // 
            // txbGiaTien
            // 
            this.txbGiaTien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbGiaTien.Location = new System.Drawing.Point(714, 193);
            this.txbGiaTien.Name = "txbGiaTien";
            this.txbGiaTien.Size = new System.Drawing.Size(240, 27);
            this.txbGiaTien.TabIndex = 6;
            // 
            // txbTacGia
            // 
            this.txbTacGia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTacGia.Location = new System.Drawing.Point(200, 193);
            this.txbTacGia.Name = "txbTacGia";
            this.txbTacGia.Size = new System.Drawing.Size(240, 27);
            this.txbTacGia.TabIndex = 3;
            this.txbTacGia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTacGia_KeyDown);
            // 
            // txbSoLuong
            // 
            this.txbSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbSoLuong.Location = new System.Drawing.Point(714, 121);
            this.txbSoLuong.Name = "txbSoLuong";
            this.txbSoLuong.Size = new System.Drawing.Size(240, 27);
            this.txbSoLuong.TabIndex = 5;
            this.txbSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSoLuong_KeyDown);
            // 
            // txbTenSach
            // 
            this.txbTenSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTenSach.Location = new System.Drawing.Point(200, 121);
            this.txbTenSach.Name = "txbTenSach";
            this.txbTenSach.Size = new System.Drawing.Size(240, 27);
            this.txbTenSach.TabIndex = 2;
            this.txbTenSach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTenSach_KeyDown);
            // 
            // txbNXB
            // 
            this.txbNXB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbNXB.Location = new System.Drawing.Point(714, 42);
            this.txbNXB.Name = "txbNXB";
            this.txbNXB.Size = new System.Drawing.Size(240, 27);
            this.txbNXB.TabIndex = 4;
            this.txbNXB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbNXB_KeyDown);
            // 
            // txbLoaiSach
            // 
            this.txbLoaiSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbLoaiSach.Location = new System.Drawing.Point(200, 42);
            this.txbLoaiSach.Name = "txbLoaiSach";
            this.txbLoaiSach.Size = new System.Drawing.Size(240, 27);
            this.txbLoaiSach.TabIndex = 1;
            this.txbLoaiSach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbLoaiSach_KeyDown);
            // 
            // lbGiaTien
            // 
            this.lbGiaTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaTien.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbGiaTien.Location = new System.Drawing.Point(558, 192);
            this.lbGiaTien.Name = "lbGiaTien";
            this.lbGiaTien.Size = new System.Drawing.Size(150, 30);
            this.lbGiaTien.TabIndex = 5;
            this.lbGiaTien.Text = "Giá Tiền:";
            this.lbGiaTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTacGia
            // 
            this.lbTacGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTacGia.ForeColor = System.Drawing.Color.Navy;
            this.lbTacGia.Location = new System.Drawing.Point(43, 192);
            this.lbTacGia.Name = "lbTacGia";
            this.lbTacGia.Size = new System.Drawing.Size(150, 30);
            this.lbTacGia.TabIndex = 5;
            this.lbTacGia.Text = "Tác giả:";
            this.lbTacGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbSoLuong.Location = new System.Drawing.Point(558, 118);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(150, 30);
            this.lbSoLuong.TabIndex = 5;
            this.lbSoLuong.Text = "Số Lượng:";
            this.lbSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTenSach
            // 
            this.lbTenSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.ForeColor = System.Drawing.Color.Navy;
            this.lbTenSach.Location = new System.Drawing.Point(43, 118);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(150, 30);
            this.lbTenSach.TabIndex = 5;
            this.lbTenSach.Text = "Tên Sách:";
            this.lbTenSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbNXB
            // 
            this.lbNXB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNXB.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbNXB.Location = new System.Drawing.Point(558, 42);
            this.lbNXB.Name = "lbNXB";
            this.lbNXB.Size = new System.Drawing.Size(150, 30);
            this.lbNXB.TabIndex = 5;
            this.lbNXB.Text = "Nhà Xuất Bản:";
            this.lbNXB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLoaiSach
            // 
            this.lbLoaiSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiSach.ForeColor = System.Drawing.Color.Navy;
            this.lbLoaiSach.Location = new System.Drawing.Point(43, 42);
            this.lbLoaiSach.Name = "lbLoaiSach";
            this.lbLoaiSach.Size = new System.Drawing.Size(150, 30);
            this.lbLoaiSach.TabIndex = 5;
            this.lbLoaiSach.Text = "Loại Sách:";
            this.lbLoaiSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(50)))), ((int)(((byte)(49)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.Location = new System.Drawing.Point(1052, 192);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 40);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(238)))), ((int)(((byte)(24)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSua.Location = new System.Drawing.Point(1052, 114);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 40);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(175)))), ((int)(((byte)(75)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.Location = new System.Drawing.Point(1052, 36);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 40);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1192, 602);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bán Sách";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1192, 602);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Thống Kê";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.tabTaiKhoan);
            this.Controls.Add(this.ptClose);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptClose)).EndInit();
            this.tabTaiKhoan.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSach)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ptClose;
        private System.Windows.Forms.TabControl tabTaiKhoan;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbGiaTien;
        private System.Windows.Forms.TextBox txbTacGia;
        private System.Windows.Forms.TextBox txbSoLuong;
        private System.Windows.Forms.TextBox txbTenSach;
        private System.Windows.Forms.TextBox txbNXB;
        private System.Windows.Forms.TextBox txbLoaiSach;
        private System.Windows.Forms.Label lbGiaTien;
        private System.Windows.Forms.Label lbTacGia;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Label lbNXB;
        private System.Windows.Forms.Label lbLoaiSach;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dtgSach;
        private System.Windows.Forms.Label lbHoTro;
    }
}