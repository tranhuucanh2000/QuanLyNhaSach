using QuanLyNhaSach.DAO;
using QuanLyNhaSach.DTO;
using QuanLyNhaSach.Properties;
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
    public partial class FHoaDonTT : Form
    {
        private TaiKhoan loginAcc;
        int trangthai = 0;
        public FHoaDonTT(DataTable data, TaiKhoan acc)
        {
            InitializeComponent();
            dtgHoaDon.DataSource = data;
            loginAcc = acc;
            txbTenNV.Text = loginAcc.Ten;
            pnTien.Visible = true;
            HienThiDanhSachDonHang();
            LamMoiTongTien();
            trangthai = 0;
            txbTen.ReadOnly = false;
            dtpNgay.MaxDate = DateTime.Now;
            dtpNgay.Value = DateTime.Now;
        }

        public FHoaDonTT(DataTable data, string tennv, string tenkh, DateTime ngayhd)
        {
            InitializeComponent();
            dtgHoaDon.DataSource = data;
            HienThiDanhSachSach();
            txbTenNV.Text = tennv;
            txbTen.Text = tenkh;
            pnTien.Visible = false;
            LamMoiTongTienHD();
            txbTienNhan.Text = txbThanhTien.Text;
            dtpNgay.Value = ngayhd;
            txbTen.ReadOnly = true;
            trangthai = 1;
        }

        void HienThiDanhSachSach()
        {
            dtgHoaDon.Columns[0].HeaderText = "Tên Sách";
            dtgHoaDon.Columns[1].HeaderText = "Số Lượng";
            dtgHoaDon.Columns[2].HeaderText = "Đơn Giá";
            dtgHoaDon.Columns[3].HeaderText = "Tiền";
            dtgHoaDon.Columns[0].Width = 300;
            dtgHoaDon.Columns[1].Width = 100;
            dtgHoaDon.Columns[2].Width = 100;
            dtgHoaDon.Columns[3].Width = 150;
        }

        void LamMoiTongTienHD()
        {
            int tongtien = 0;
            if (dtgHoaDon.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dtgHoaDon.Rows)
                {
                    if (row.Index < dtgHoaDon.Rows.Count - 1)
                    {
                        string[] tient = row.Cells[3].Value.ToString().Split('.');
                        int tien = 0;
                        tien = int.Parse(tient[0]);
                        tongtien += tien;
                    }
                }
            }
            txbThanhTien.Text = tongtien.ToString();
        }
        void LamMoiTongTien()
        {
            int tongtien = 0;
            if (dtgHoaDon.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dtgHoaDon.Rows)
                {
                    if (row.Index < dtgHoaDon.Rows.Count - 1)
                    {
                        int tien = 0;
                        tien = int.Parse(row.Cells[4].Value.ToString());
                        tongtien += tien;
                    }
                }
            }
            txbThanhTien.Text = tongtien.ToString();
        }
        void HienThiDanhSachDonHang()
        {
            dtgHoaDon.Columns[0].HeaderText = "Mã";
            dtgHoaDon.Columns[1].HeaderText = "Tên Sách";
            dtgHoaDon.Columns[2].HeaderText = "Số Lượng";
            dtgHoaDon.Columns[3].HeaderText = "Đơn Giá";
            dtgHoaDon.Columns[4].HeaderText = "Tiền";
            dtgHoaDon.Columns[0].Width = 75;
            dtgHoaDon.Columns[1].Width = 290;
            dtgHoaDon.Columns[2].Width = 75;
            dtgHoaDon.Columns[3].Width = 100;
            dtgHoaDon.Columns[4].Width = 100;
        }
        private void ptClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (trangthai == 0)
            {
                Image image = Resources.logo;
                e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                e.Graphics.DrawString("NHÀ SÁCH KVC", new Font("Segoe UI", 40, FontStyle.Bold), Brushes.Black, new Point(195, 30));
                if (dtpNgay.Value.Date == DateTime.Now.Date)
                {
                    e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString(), new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 40));
                }
                else
                {
                    e.Graphics.DrawString("Ngày: " + dtpNgay.Value.ToString(), new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 40));
                }
                e.Graphics.DrawString("Tên khách hàng: " + txbTen.Text, new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 80));
                e.Graphics.DrawString("Tên nhân viên: " + txbTenNV.Text, new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 120));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + 180));
                e.Graphics.DrawString("Tên Sách", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 200));
                e.Graphics.DrawString("SL", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(440, image.Height + 200));
                e.Graphics.DrawString("Giá", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(550, image.Height + 200));
                e.Graphics.DrawString("T.Tiền", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(680, image.Height + 200));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + 230));
                int yPoint = 250;
                int tongtien = 0;
                for (int i = 0; i < dtgHoaDon.Rows.Count - 1; i++)
                {
                    string tensach = dtgHoaDon.Rows[i].Cells[1].Value.ToString();
                    string tenht = tensach;
                    if (tensach.Length > 26)
                    {
                        tenht = tenht.Substring(0, 26);
                        tenht = tenht + "...";
                    }
                    e.Graphics.DrawString(tenht, new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint));
                    e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[2].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(440, image.Height + yPoint));
                    e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[3].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(550, image.Height + yPoint));
                    e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[4].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(680, image.Height + yPoint));
                    int ttien = int.Parse(dtgHoaDon.Rows[i].Cells[4].Value.ToString());
                    tongtien += ttien;
                    yPoint += 30;
                }
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint));
                e.Graphics.DrawString("Tổng tiền: ", new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(450, image.Height + yPoint + 30));
                e.Graphics.DrawString(tongtien.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(680, image.Height + yPoint + 30));
                int tam = (tongtien + 500) / 1000;
                int tongtienlt = tam * 1000;
                e.Graphics.DrawString("Thanh toán: ", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(400, image.Height + yPoint + 90));
                e.Graphics.DrawString("(Đã làm tròn)", new Font("Segoe UI", 22, FontStyle.Italic), Brushes.Black, new Point(400, image.Height + yPoint + 120));
                e.Graphics.DrawString(tongtienlt.ToString(), new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(630, image.Height + yPoint + 90));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint + 150));
                e.Graphics.DrawString("Tiền mặt: ", new Font("Segoe UI", 22, FontStyle.Regular), Brushes.Black, new Point(450, image.Height + yPoint + 170));
                e.Graphics.DrawString(txbTienNhan.Text, new Font("Segoe UI", 22, FontStyle.Regular), Brushes.Black, new Point(630, image.Height + yPoint + 170));
                e.Graphics.DrawString("Tiền thối lại: ", new Font("Segoe UI", 22, FontStyle.Regular), Brushes.Black, new Point(410, image.Height + yPoint + 200));
                int tienthoi = int.Parse(txbTienNhan.Text) - tongtienlt;
                e.Graphics.DrawString(tienthoi.ToString(), new Font("Segoe UI", 22, FontStyle.Regular), Brushes.Black, new Point(630, image.Height + yPoint + 200));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint + 230));
                e.Graphics.DrawString("----------------------------------Nhà Sách KVC--------------------------------------", new Font("Segoe UI", 18, FontStyle.Regular), Brushes.Black, new Point(0, 970));
                e.Graphics.DrawString("Địa chỉ: 28/11 đường số 1, Tăng Nhơn Phú B, Quận 9, Hồ Chí Minh", new Font("Segoe UI", 19, FontStyle.Italic), Brushes.Black, new Point(45, 1000));
                e.Graphics.DrawString("Số điện thoại: 0989777999", new Font("Segoe UI", 19, FontStyle.Italic), Brushes.Black, new Point(290, 1040));
            }
            else
            {
                Image image = Resources.logo;
                e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                e.Graphics.DrawString("NHÀ SÁCH KVC", new Font("Segoe UI", 40, FontStyle.Bold), Brushes.Black, new Point(195, 30));
                e.Graphics.DrawString("Ngày: " + dtpNgay.Value.ToString(), new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 40));
                e.Graphics.DrawString("Tên khách hàng: " + txbTen.Text, new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 80));
                e.Graphics.DrawString("Tên nhân viên: " + txbTenNV.Text, new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 120));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + 180));
                e.Graphics.DrawString("Tên Sách", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 200));
                e.Graphics.DrawString("SL", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(440, image.Height + 200));
                e.Graphics.DrawString("Giá", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(550, image.Height + 200));
                e.Graphics.DrawString("T.Tiền", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(680, image.Height + 200));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + 230));
                int yPoint = 250;
                int tongtien = 0;
                for (int i = 0; i < dtgHoaDon.Rows.Count - 1; i++)
                {
                    string tensach = dtgHoaDon.Rows[i].Cells[0].Value.ToString();
                    string tenht = tensach;
                    if (tensach.Length > 26)
                    {
                        tenht = tenht.Substring(0, 26);
                        tenht = tenht + "...";
                    }
                    e.Graphics.DrawString(tenht, new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint));
                    e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[1].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(440, image.Height + yPoint));
                    e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[2].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(550, image.Height + yPoint));
                    e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[3].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(680, image.Height + yPoint));
                    int ttien = int.Parse(dtgHoaDon.Rows[i].Cells[3].Value.ToString());
                    tongtien += ttien;
                    yPoint += 30;
                }
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint));
                e.Graphics.DrawString("Tổng tiền: ", new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(450, image.Height + yPoint + 30));
                e.Graphics.DrawString(tongtien.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(680, image.Height + yPoint + 30));
                int tam = (tongtien + 500) / 1000;
                int tongtienlt = tam * 1000;
                e.Graphics.DrawString("Thanh toán: ", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(400, image.Height + yPoint + 90));
                e.Graphics.DrawString("(Đã làm tròn)", new Font("Segoe UI", 22, FontStyle.Italic), Brushes.Black, new Point(400, image.Height + yPoint + 120));
                e.Graphics.DrawString(tongtienlt.ToString(), new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(630, image.Height + yPoint + 90));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint + 150));
                e.Graphics.DrawString("Tiền mặt: ", new Font("Segoe UI", 22, FontStyle.Regular), Brushes.Black, new Point(450, image.Height + yPoint + 170));
                e.Graphics.DrawString(txbTienNhan.Text, new Font("Segoe UI", 22, FontStyle.Regular), Brushes.Black, new Point(630, image.Height + yPoint + 170));
                e.Graphics.DrawString("Tiền thối lại: ", new Font("Segoe UI", 22, FontStyle.Regular), Brushes.Black, new Point(410, image.Height + yPoint + 200));
                int tienthoi = int.Parse(txbTienNhan.Text) - tongtienlt;
                e.Graphics.DrawString(tienthoi.ToString(), new Font("Segoe UI", 22, FontStyle.Regular), Brushes.Black, new Point(630, image.Height + yPoint + 200));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint + 230));
                e.Graphics.DrawString("----------------------------------Nhà Sách KVC--------------------------------------", new Font("Segoe UI", 18, FontStyle.Regular), Brushes.Black, new Point(0, 970));
                e.Graphics.DrawString("Địa chỉ: 28/11 đường số 1, Tăng Nhơn Phú B, Quận 9, Hồ Chí Minh", new Font("Segoe UI", 19, FontStyle.Italic), Brushes.Black, new Point(45, 1000));
                e.Graphics.DrawString("Số điện thoại: 0989777999", new Font("Segoe UI", 19, FontStyle.Italic), Brushes.Black, new Point(290, 1040));
            }
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            if (trangthai == 0)
            {
                int tiennhan;
                if (int.TryParse(txbTienNhan.Text, out tiennhan) == true)
                {
                    if (int.Parse(txbThanhTien.Text) <= tiennhan)
                    {
                        DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM HoaDon");
                        int slhd = data.Rows.Count;
                        string mahd = "HD";
                        if (slhd > 0)
                        {
                            DataRow row = data.Rows[slhd - 1];
                            string mahdc = row[0].ToString();
                            int tthd = int.Parse(mahdc.Substring(2));
                            tthd++;
                            if (tthd < 10)
                            {
                                mahd += "00" + tthd;
                            }
                            else if (tthd < 100)
                            {
                                mahd += "0" + tthd;
                            }
                            else
                            {
                                mahd += tthd;
                            }
                        }
                        else
                        {
                            mahd += "001";
                        }
                        HoaDonDAO.Instance.ThemHoaDon(mahd, dtpNgay.Value.Date, int.Parse(txbThanhTien.Text), txbTen.Text, txbTenNV.Text);
                        if (dtgHoaDon.Rows.Count > 1)
                        {
                            foreach (DataGridViewRow row in dtgHoaDon.Rows)
                            {
                                if (row.Index < dtgHoaDon.Rows.Count - 1)
                                {
                                    SachDAO.Instance.ThanhToanSach(row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString());
                                    HoaDonDAO.Instance.ThemChiTietHD(row.Cells[0].Value.ToString(), mahd, int.Parse(row.Cells[2].Value.ToString()), int.Parse(row.Cells[3].Value.ToString()));
                                }
                            }
                        }
                        InHoaDon.Print();
                        thanhToan(sender, e);
                    }

                    else
                    {
                        MessageBox.Show("Số tiền nhận không đủ!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn vui lòng nhập tiền đúng định dạng");
                }
            }
            else
            {
                InHoaDon.Print();
            }
        }

        private void txbTienNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnIN_Click(sender, e);
        }

        private void txbTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txbTienNhan.Focus();
        }

        private event EventHandler thanhToan;
        public event EventHandler ThanhToan
        {
            add { thanhToan += value; }
            remove { thanhToan -= value; }
        }
    }
}
