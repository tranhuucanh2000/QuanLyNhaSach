using QuanLyNhaSach.DAO;
using QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class UCThongKe : UserControl
    {
        private static UCThongKe instance;
        public static UCThongKe Instance
        {
            get => instance;
            set => instance = value;
        }

        bool trangthai = true;
        private TaiKhoan loginAccount;
        public TaiKhoan LoginAccount
        {
            get => loginAccount;
            set => loginAccount = value;
        }
        public void DuaThongDiep(string str, int mucDo)
        {
            string ThongDiep = String.Concat("BỒ CÂU: \"", str, "\"");
            if (mucDo == 1) lbHoTro.ForeColor = Color.FromArgb(102, 255, 102);
            if (mucDo == 2) lbHoTro.ForeColor = Color.FromArgb(255, 255, 102);
            if (mucDo == 3) lbHoTro.ForeColor = Color.White;
            lbHoTro.Text = ThongDiep;
        }
        public UCThongKe(TaiKhoan acc)
        {
            InitializeComponent();
            loginAccount = acc;
            dtpNgayDau.MaxDate = DateTime.Now;
            dtpNgayCuoi.MaxDate = DateTime.Now;
            dtpNgayCuoi.MinDate = dtpNgayDau.Value;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (trangthai == true)
            {
                dtgThongKe.DataSource = HoaDonDAO.Instance.LayDSHoaDon(dtpNgayDau.Value.Date, dtpNgayCuoi.Value.Date);
                ChinhDTGV();
                TinhDoanhThu();
            }
            else
            {
                dtgThongKe.DataSource = PhieuNhapDAO.Instance.XemPhieuNhap(dtpNgayDau.Value.Date, dtpNgayCuoi.Value.Date);
                ChinhDTGV();
               

            }
        }

        void TinhDoanhThu()
        {
            int doanhthu = 0;
            int buoc = dtgThongKe.Rows.Count;
            int i = 0;
            foreach(DataGridViewRow row in dtgThongKe.Rows)
            {
                if (i<buoc - 1)
                {
                    doanhthu += int.Parse(row.Cells[2].Value.ToString());
                }
                i++;
            }
            txbDoanhThu.Text = doanhthu.ToString();
        }    
        void ChinhDTGV()
        {
            if(trangthai == true )
            {
                dtgThongKe.Columns[0].Width = 100;
                dtgThongKe.Columns[1].Width = 250;
                dtgThongKe.Columns[2].Width = 248;
                dtgThongKe.Columns[3].Width = 200;
                dtgThongKe.Columns[4].Width = 200;
            }
            else
            {
                dtgThongKe.Columns[0].HeaderText = "Tên Sách";
                dtgThongKe.Columns[1].HeaderText = "Số Lượng Nhập";
                dtgThongKe.Columns[2].HeaderText = "Giá Tiền";
                dtgThongKe.Columns[3].HeaderText = "Thành Tiền";
                dtgThongKe.Columns[4].HeaderText = "Ngày Nhập";
                dtgThongKe.Columns[5].HeaderText = "Tên Nhà Xuất Bản";

                dtgThongKe.Columns[0].Width = 250;
                dtgThongKe.Columns[1].Width = 100;
                dtgThongKe.Columns[2].Width = 100;
                dtgThongKe.Columns[3].Width = 100;
                dtgThongKe.Columns[4].Width = 200;
                dtgThongKe.Columns[5].Width = 248;

            }
        }
        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            trangthai = true;
            lbHienThi.Text = "Danh sách hóa đơn";
            btnDoanhThu.Size = new System.Drawing.Size(205, 65);
            btnPhieuNhap.Size = new System.Drawing.Size(160, 45);
            pnThongTin.Visible = true;
            pnDoanhThu.Visible = true;
            dtgThongKe.DataSource = null;
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            trangthai = false;
            lbHienThi.Text = "Danh sách phiếu nhập";
            btnDoanhThu.Size = new System.Drawing.Size(160, 45);
            btnPhieuNhap.Size = new System.Drawing.Size(205, 65);
            pnThongTin.Visible = false;
            pnDoanhThu.Visible = false;
            dtgThongKe.DataSource = null;
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (trangthai == true)
            {
                if (txbMaHD.Text != "")
                {
                    DataTable data = HoaDonDAO.Instance.XemThongTinHoaDon(txbMaHD.Text);
                    DataTable table = DataProvider.Instance.ExecuteQuery(string.Concat("SELECT * FROM dbo.HoaDon WHERE SoHD = N'", txbMaHD.Text, "'"));
                    DataRow row = table.Rows[0];
                    string[] ngay = row[1].ToString().Split(' ');
                    DateTime ngayhd = DateTime.Parse(ngay[0]);
                    FHoaDonTT fHoaDon = new FHoaDonTT(data, txbNhanVien.Text, txbKhachHang.Text, ngayhd);
                    fHoaDon.ShowDialog();
                }
            }
        }

        private void dtgThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (trangthai == true)
            {
                DataGridViewRow row = dtgThongKe.Rows[dtgThongKe.CurrentCell.RowIndex];
                txbMaHD.Text = row.Cells[0].Value.ToString();
                txbNhanVien.Text = row.Cells[4].Value.ToString();
                txbKhachHang.Text = row.Cells[3].Value.ToString();
            }
            else
            {

            }    
        }

        private void ptbHoTro_Click(object sender, EventArgs e)
        {
            FThongTinPhanMem fThongTinPhanMem = new FThongTinPhanMem();
            fThongTinPhanMem.ShowDialog();
        }

        private void dtpNgayDau_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayCuoi.MinDate = dtpNgayDau.Value;
        }

        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
