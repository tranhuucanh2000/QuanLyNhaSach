using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using Utility;


namespace GUI
{
    public partial class UC_LapBaoCaoCongNo : UserControl
    {
        public UC_LapBaoCaoCongNo()
        {
            InitializeComponent();
        }
        private Result res;
        private ChiTietBaoCaoCongNo_BUS chiTietBaoCaoCongNoBUS = new ChiTietBaoCaoCongNo_BUS();
        private List<object> listChiTietBaoCao;
        private BaoCaoCongNo_BUS baoCaoCongNoBUS = new BaoCaoCongNo_BUS();



        private void UC_LapBaoCaoCongNo_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            InitDataGridViewBaoCaoCongNo();
            btn_LuuBaoCao.Enabled = false;
            btn_LuuBaoCao.BackColor = Color.LightGray;
        }


        public void InitDataGridViewBaoCaoCongNo()
        {
            dgv_listBaoCaoCongNo.Columns.Clear();

            dgv_listBaoCaoCongNo.AutoGenerateColumns = false;

            dgv_listBaoCaoCongNo.DataSource = listChiTietBaoCao;

            var clSTT = new DataGridViewTextBoxColumn();
            {
                var withBlock = clSTT;
                withBlock.Name = "STT";
                withBlock.DataPropertyName = "STT";
                withBlock.HeaderText = "STT";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoCongNo.Columns.Add(clSTT);

            var clMaSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = clMaSach;
                withBlock.Name = "MaKhachHang";
                withBlock.DataPropertyName = "MaKhachHang";
                withBlock.HeaderText = "Mã khách hàng";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoCongNo.Columns.Add(clMaSach);

            var clTenSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTenSach;
                withBlock.Name = "HoTenKhachHang";
                withBlock.DataPropertyName = "HoTenKhachHang";
                withBlock.HeaderText = "Tên khách hàng";
            }
            dgv_listBaoCaoCongNo.Columns.Add(clTenSach);

            var clTonDau = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTonDau;
                withBlock.Name = "NoDau";
                withBlock.DataPropertyName = "NoDau";
                withBlock.HeaderText = "Nợ đầu";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoCongNo.Columns.Add(clTonDau);

            var clPhatSinh = new DataGridViewTextBoxColumn();
            {
                var withBlock = clPhatSinh;
                withBlock.Name = "PhatSinh";
                withBlock.DataPropertyName = "PhatSinh";
                withBlock.HeaderText = "Phát sinh";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoCongNo.Columns.Add(clPhatSinh);



            var clTonCuoi = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTonCuoi;
                withBlock.Name = "NoCuoi";
                withBlock.DataPropertyName = "NoCuoi";
                withBlock.HeaderText = "Nợ cuối";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoCongNo.Columns.Add(clTonCuoi);


            double rong = dgv_listBaoCaoCongNo.Width;

            dgv_listBaoCaoCongNo.Columns["STT"].Width = (int)(rong * 0.1);
            dgv_listBaoCaoCongNo.Columns["MaKhachHang"].Width = (int)(rong * 0.15);
            dgv_listBaoCaoCongNo.Columns["HoTenKhachHang"].Width = (int)(rong * 0.3 - 20);
            dgv_listBaoCaoCongNo.Columns["NoDau"].Width = (int)(rong * 0.15);
            dgv_listBaoCaoCongNo.Columns["PhatSinh"].Width = (int)(rong * 0.15);
            dgv_listBaoCaoCongNo.Columns["NoCuoi"].Width = (int)(rong * 0.15);




            dgv_listBaoCaoCongNo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv_listBaoCaoCongNo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_listBaoCaoCongNo.RowHeadersVisible = false;
        }



        private void btn_XemBaoCao_Click(object sender, EventArgs e)
        {
            res = chiTietBaoCaoCongNoBUS.ThongKeBaoCaoCongNo(dtp_ThangBaoCao.Value.Month, dtp_ThangBaoCao.Value.Year);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listChiTietBaoCao = (List<object>)res.Obj1;

            InitDataGridViewBaoCaoCongNo();

            if (dgv_listBaoCaoCongNo.RowCount == 0)
                MessageBox.Show("Tháng này không có sự thay đổi về công nợ!");
            else
                btn_LuuBaoCao.Enabled = true;// xem xong mới cho lưu
                btn_LuuBaoCao.BackColor = Color.Teal;
        }



        private void DateTimePicker_ThangBaoCao_ValueChanged(object sender, EventArgs e)
        {
            btn_LuuBaoCao.Enabled = false;
            btn_LuuBaoCao.BackColor = Color.LightGray;
        }

        private void btn_LuuBaoCao_Click(object sender, EventArgs e)
        {
            res = baoCaoCongNoBUS.GetNextIncrement();
            int MaBaoCaoCongNo = System.Convert.ToInt32(res.Obj1);

            res = baoCaoCongNoBUS.insert(new BaoCaoCongNo_DTO(dtp_ThangBaoCao.Value, dtp_NgayLap.Value));
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            foreach (object chitiet in listChiTietBaoCao)
            {
                res = chiTietBaoCaoCongNoBUS.insert(new ChiTietBaoCaoCongNo_DTO(MaBaoCaoCongNo, Convert.ToInt32(chitiet.GetType().GetProperty("MaKhachHang").GetValue(chitiet, null)), Convert.ToInt32(chitiet.GetType().GetProperty("NoDau").GetValue(chitiet, null)), Convert.ToInt32(chitiet.GetType().GetProperty("PhatSinh").GetValue(chitiet, null)), Convert.ToInt32(chitiet.GetType().GetProperty("NoCuoi").GetValue(chitiet, null))));
                if ((res.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            btn_LuuBaoCao.Enabled = false;
            btn_LuuBaoCao.BackColor = Color.LightGray;
            MessageBox.Show("Lưu báo cáo công nợ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
