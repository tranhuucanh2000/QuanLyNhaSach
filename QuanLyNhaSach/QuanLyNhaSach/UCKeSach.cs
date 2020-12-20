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
            HienTen();
        }

        void LamMoiTxb()
        {
            txbGiaTien.Text = txbMa.Text = txbNXB.Text = txbSo.Text = txbTacGia.Text = txbTen.Text = txbTheLoai.Text = "";
        }
        void HienThiTTSach()
        {
            pnAn.Visible = true;
            lbTen.Text = "Tên Sách:";
            lbMa.Text = "Mã Sách:";
            lbSo.Text = "Số Lượng:";
            lbNXB.Text = "Nhà Xuất Bản:";
            txbSo.Visible = lbSo.Visible = pnSo.Visible = true;
            txbNXB.Visible = lbNXB.Visible = pnNXB.Visible = true;
            lbSoLuong.Text = (dtgSach.Rows.Count-1).ToString();
        }
        void HienThiTTTacGia()
        {
            pnAn.Visible = false;
            lbTen.Text = "Tên Tác Giả:";
            lbMa.Text = "Mã Tác Giả:";
            lbSo.Text = "Số Điện Thoại:";
            txbSo.Visible = lbSo.Visible = pnSo.Visible = true;
            txbNXB.Visible = lbNXB.Visible = pnNXB.Visible = false;
            lbSoLuong.Text = (dtgSach.Rows.Count - 1).ToString();
        }

        void HienThiTTTheLoai()
        {
            pnAn.Visible = false;
            lbTen.Text = "Tên Thể Loại:";
            lbMa.Text = "Mã Thể Loại";
            txbSo.Visible = lbSo.Visible = pnSo.Visible = false;
            txbNXB.Visible = lbNXB.Visible = pnNXB.Visible = false;
            lbSoLuong.Text = (dtgSach.Rows.Count - 1).ToString();
        }
        void HienThiNXB()
        {
            pnAn.Visible = false;
            lbTen.Text = "Tên NXB:";
            lbMa.Text = "Mã NXB:";
            lbSo.Text = "Số Điện Thoại:";
            lbNXB.Text = "Địa chỉ: ";
            txbSo.Visible = lbSo.Visible = pnSo.Visible = true;
            txbNXB.Visible = lbNXB.Visible = pnNXB.Visible = true;
            lbSoLuong.Text = (dtgSach.Rows.Count - 1).ToString();
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
        void KetNoiKhoSach()
        {
            DataTable data = SachDAO.Instance.LayDSSach();
            dtgSach.DataSource = data;
        }

        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void cbThuocTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXoa.Visible = false;
            btnLuu.Visible = false;
            btnSua.Visible = false;
            txbTen.ReadOnly = true;
            txbGiaTien.ReadOnly = true;
            txbSo.ReadOnly = true;
            LamMoiTxb();
            if (cbThuocTinh.SelectedItem.ToString()=="Sách")
            {
                dtgSach.DataSource = null;
                dtgSach.DataSource = SachDAO.Instance.LayDSSach();
                HienThiTTSach();
            }
            else if(cbThuocTinh.SelectedItem.ToString()=="Tác Giả")
            {
                dtgSach.DataSource = null;
                dtgSach.DataSource = SachDAO.Instance.LayDSTacGia();
                HienThiTTTacGia();
            }
            else if(cbThuocTinh.SelectedItem.ToString()=="Thể Loại")
            {
                dtgSach.DataSource = null;
                dtgSach.DataSource = SachDAO.Instance.LayDSTheLoai();
                HienThiTTTheLoai();
            }
            else
            {
                dtgSach.DataSource = null;
                dtgSach.DataSource = SachDAO.Instance.LayDSNXB();
                HienThiNXB();
            }
        }

        private void dtgSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLuu.Visible = true;
            btnXoa.Visible = true;
            btnSua.Visible = true;
            if (cbThuocTinh.SelectedItem.ToString() == "Sách")
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbMa.Text = row.Cells[0].Value.ToString();
                txbTen.Text = row.Cells[1].Value.ToString();
                txbTacGia.Text = row.Cells[2].Value.ToString();
                txbTheLoai.Text = row.Cells[3].Value.ToString();
                txbNXB.Text = row.Cells[4].Value.ToString();
                txbSo.Text = row.Cells[5].Value.ToString();
                txbGiaTien.Text = row.Cells[6].Value.ToString();
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Tác Giả")
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbMa.Text = row.Cells[0].Value.ToString();
                txbTen.Text = row.Cells[1].Value.ToString();
                txbSo.Text = row.Cells[2].Value.ToString();
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Thể Loại")
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbMa.Text = row.Cells[0].Value.ToString();
                txbTen.Text = row.Cells[1].Value.ToString();
            }
            else
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbMa.Text = row.Cells[0].Value.ToString();
                txbTen.Text = row.Cells[1].Value.ToString();
                txbSo.Text = row.Cells[3].Value.ToString();
                txbNXB.Text = row.Cells[2].Value.ToString();
            }
        }
<<<<<<< HEAD
=======

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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn chắc chắn xóa chứ ", "Cảnh Báo");
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
                DuaThongDiep("Bạn đã xóa sách thành công ", 1);
                dtgSach.DataSource = SachDAO.Instance.LayDSSach();
            }
            else
            {
                DuaThongDiep("Không thể xóa sách này ", 2);
            }

        }
>>>>>>> c9beb7bae7f5473f60a7b39f59cf465d19a54b48
    }
}
