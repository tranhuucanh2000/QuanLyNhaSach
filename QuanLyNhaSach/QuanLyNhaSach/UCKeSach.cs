﻿using QuanLyNhaSach.DAO;
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
    public partial class UCKeSach : UserControl
    {

        private static UCKeSach instance;
        public static UCKeSach Instance
        {
            get => instance;
            set => instance = value;
        }

        private Account loginAccount;
        public Account LoginAccount
        {
            get => loginAccount;
            set => loginAccount = value;
        }
        public UCKeSach(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            TrangThaiBanDau();
            HienTen();
            KetNoiKhoSach();

        }
        void TrangThaiBanDau()
        {
            btnLuu.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnHuy.Visible = false;
            btnXoa.Visible = false;
            btnNgung.Visible = false;
            btnKinhDoanh.Visible = false;
        }
        void TrangThaiSua()
        {
            txbGiaTien.ForeColor = Color.DarkViolet;
            txbTen.ForeColor = Color.DarkViolet;
            txbSo.ForeColor = Color.DarkViolet;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnNgung.Visible = false;
            btnKinhDoanh.Visible = false;
        }
        void TrangThaiChonSach()
        {
            txbGiaTien.ForeColor = Color.Black;
            txbTen.ForeColor = Color.Black;
            txbSo.ForeColor = Color.Black;
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnNgung.Visible = false;
            btnKinhDoanh.Visible = false;
            txbGiaTien.ReadOnly = true;
            txbTen.ReadOnly = true;
            txbSo.ReadOnly = true;
        }
        void KetNoiKhoSach()
        {
            DataTable data = SachDAO.Instance.LayTatCaSach();
            dtgSach.DataSource = data;
            dtgSach.Columns[0].HeaderText = "Mã";
            dtgSach.Columns[1].HeaderText = "Tên Sách";
            dtgSach.Columns[2].HeaderText = "Tác Giả";
            dtgSach.Columns[3].HeaderText = "Thể Loại";
            dtgSach.Columns[4].HeaderText = "Nhà Xuất Bản";
            dtgSach.Columns[5].HeaderText = "Số Lượng Tồn";
            dtgSach.Columns[6].HeaderText = "Giá Tiền";
            dtgSach.Columns[7].HeaderText = "Kinh Doanh";
            dtgSach.Columns[0].Width = 50;
            dtgSach.Columns[1].Width = 287;
            dtgSach.Columns[2].Width = 120;
            dtgSach.Columns[3].Width = 120;
            dtgSach.Columns[4].Width = 120;
            dtgSach.Columns[5].Width = 100;
            dtgSach.Columns[6].Width = 100;
            dtgSach.Columns[7].Width = 100;
        }
        void LamMoiTxb()
        {
            txbGiaTien.Text = txbMa.Text = txbNXB.Text = txbSo.Text = txbTacGia.Text = txbTen.Text = txbTheLoai.Text = "";
        }
        public void HienTen()
        {
            DuaThongDiep(string.Concat("Xin chào ", LoginAccount.Ten), 3);
        }
        public void DuaThongDiep(string str, int mucDo)
        {
            string ThongDiep = String.Concat("BỒ CÂU: \"", str, "\"");
            if (mucDo == 1) lbHoTro.ForeColor = Color.FromArgb(102, 255, 102);
            if (mucDo == 2) lbHoTro.ForeColor = Color.FromArgb(255, 255, 102);
            if (mucDo == 3) lbHoTro.ForeColor = Color.White;
            lbHoTro.Text = ThongDiep;
        }
       

        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    
        private void dtgSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TrangThaiChonSach();
            int vitri = dtgSach.CurrentRow.Index;
            DataGridViewRow row = dtgSach.Rows[vitri];
            if (row.Cells[7].Value.ToString() == "Còn")
            {
                btnKinhDoanh.Visible = false;
                btnNgung.Visible = true;
            }
            else
            {
                btnKinhDoanh.Visible = true;
                btnNgung.Visible = false;
            }
            txbMa.Text = row.Cells[0].Value.ToString();
            txbTen.Text = row.Cells[1].Value.ToString();
            txbTacGia.Text = row.Cells[2].Value.ToString();
            txbTheLoai.Text = row.Cells[3].Value.ToString();
            txbNXB.Text = row.Cells[4].Value.ToString();
            txbSo.Text = row.Cells[5].Value.ToString();
            txbGiaTien.Text = row.Cells[6].Value.ToString();             
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int giatien;
            int soluong;
            if(txbTen.Text=="")
            {
                DuaThongDiep("Bạn vui lòng nhập tên sách ", 2);
            }
            else if (int.TryParse(txbSo.Text, out soluong))
            {
                if (int.TryParse(txbGiaTien.Text, out giatien))
                {
                    SachDAO.Instance.SuaSach(txbTen.Text, txbSo.Text, txbGiaTien.Text, txbMa.Text);
                    DuaThongDiep("Đã sửa sách thành công ", 1);
                    dtgSach.DataSource = SachDAO.Instance.LayDSSach();
                    LamMoiTxb();
                    txbTen.ReadOnly = true;
                    txbGiaTien.ReadOnly = true;
                    txbSo.ReadOnly = true;
                    btnLuu.Visible = false;
                    TrangThaiChonSach();
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập lại giá tiền!", 2);
                }
            }
            else
            {
                DuaThongDiep("Bạn vui lòng nhập lại số lượng!", 2);
            }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txbTen.ReadOnly = false;
            txbGiaTien.ReadOnly = false;
            txbSo.ReadOnly = false;
            TrangThaiSua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xóa chứ ", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("SELECT	* FROM ChiTietHoaDon");
                bool flag = true;
                foreach (DataRow item in data.Rows)
                {
                    if (item["MaSach"].ToString().Equals(txbMa.Text))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    SachDAO.Instance.XoaSach(txbMa.Text);
                    DuaThongDiep("Bạn đã xóa sách thành công!", 1);
                    dtgSach.DataSource = SachDAO.Instance.LayDSSach();
                    TrangThaiBanDau();
                }
                else
                {
                    DuaThongDiep("Sách đã bán ra nên bạn chỉ có thể ngừng kinh doanh sách này!", 2);
                }
            }
            else
            {
                DuaThongDiep("Bạn đã hủy thao tác xóa sách!", 2);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TrangThaiChonSach();
            int vitri = dtgSach.CurrentRow.Index;
            DataGridViewRow row = dtgSach.Rows[vitri];
            if (row.Cells[7].Value.ToString() == "Còn")
            {
                btnKinhDoanh.Visible = false;
                btnNgung.Visible = true;
            }
            else
            {
                btnKinhDoanh.Visible = true;
                btnNgung.Visible = false;
            }
            txbMa.Text = row.Cells[0].Value.ToString();
            txbTen.Text = row.Cells[1].Value.ToString();
            txbTacGia.Text = row.Cells[2].Value.ToString();
            txbTheLoai.Text = row.Cells[3].Value.ToString();
            txbNXB.Text = row.Cells[4].Value.ToString();
            txbSo.Text = row.Cells[5].Value.ToString();
            txbGiaTien.Text = row.Cells[6].Value.ToString();
        }

        private void btnKinhDoanh_Click(object sender, EventArgs e)
        {
            SachDAO.Instance.TTKinhDoanhSach(txbMa.Text);
            KetNoiKhoSach();
            TrangThaiBanDau();
            LamMoiTxb();
        }

        private void btnNgung_Click(object sender, EventArgs e)
        {
            SachDAO.Instance.NgungKinhDoanhSach(txbMa.Text);
            KetNoiKhoSach();
            TrangThaiBanDau();
            LamMoiTxb();
        }
    }
}
