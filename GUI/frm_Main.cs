using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using Microsoft.VisualBasic;


namespace GUI
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void btn_TraCuuSach_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_TraCuuSach());
        }

        private void btn_QuanLiSach_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_QuanLiSach());
        }

        private void btn_LapHoaDonBanSach_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_LapHoaDon());
        }

        private void btn_btn_QuanLiKhachHang_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_QuanLiKhachHang_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_QuanLiKhachHang());
        }

        private void btn_LapPhieuThuTien_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_LapPhieuThuTien());
        }

        private void btn_QuanLiPhieuThuTien_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_QuanLiPhieuThuTien());
        }

        private void btn_LapBaoCaoTon_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_LapBaoCaoTon());
        }

        private void btn_LapBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_LapBaoCaoCongNo());
        }

        private void btn_ThayDoiQuiDinh_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_ThayDoiQuyDinh());
        }

        private void btn_LapPhieuNhapSach_Click(object sender, EventArgs e)
        {
            Panel_LoadUC.Controls.Clear();
            Panel_LoadUC.Controls.Add(new UC_NhapSach());
        }

		private void btn_TraCuuSach_MouseHover(object sender, EventArgs e)
		{
            btn_TraCuuSach.BackColor = Color.White;
            btn_TraCuuSach.ForeColor = Color.DarkSlateGray;
        }

		private void btn_TraCuuSach_MouseLeave(object sender, EventArgs e)
		{
            btn_TraCuuSach.BackColor = Color.Teal;
            btn_TraCuuSach.ForeColor = Color.White;
        }
        private void btn_QuanLiSach_MouseHover(object sender, EventArgs e)
        {
            btn_QuanLiSach.BackColor = Color.White;
            btn_QuanLiSach.ForeColor = Color.DarkSlateGray;
        }

        private void btn_QuanLiSach_MouseLeave(object sender, EventArgs e)
        {
            btn_QuanLiSach.BackColor = Color.Teal;
            btn_QuanLiSach.ForeColor = Color.White;
        }
        private void btn_LapPhieuNhapSach_MouseHover(object sender, EventArgs e)
        {
            btn_LapPhieuNhapSach.BackColor = Color.White;
            btn_LapPhieuNhapSach.ForeColor = Color.DarkSlateGray;
        }

        private void btn_LapPhieuNhapSach_MouseLeave(object sender, EventArgs e)
        {
            btn_LapPhieuNhapSach.BackColor = Color.Teal;
            btn_LapPhieuNhapSach.ForeColor = Color.White;
        }
        private void btn_LapHoaDonBanSach_MouseHover(object sender, EventArgs e)
        {
            btn_LapHoaDonBanSach.BackColor = Color.White;
            btn_LapHoaDonBanSach.ForeColor = Color.DarkSlateGray;
        }

        private void btn_LapHoaDonBanSach_MouseLeave(object sender, EventArgs e)
        {
            btn_LapHoaDonBanSach.BackColor = Color.Teal;
            btn_LapHoaDonBanSach.ForeColor = Color.White;
        }
        private void btn_QuanLiKhachHang_MouseHover(object sender, EventArgs e)
        {
            btn_QuanLiKhachHang.BackColor = Color.White;
            btn_QuanLiKhachHang.ForeColor = Color.DarkSlateGray;
        }

        private void btn_QuanLiKhachHang_MouseLeave(object sender, EventArgs e)
        {
            btn_QuanLiKhachHang.BackColor = Color.Teal;
            btn_QuanLiKhachHang.ForeColor = Color.White;
        }
        private void btn_LapPhieuThuTien_MouseHover(object sender, EventArgs e)
        {
            btn_LapPhieuThuTien.BackColor = Color.White;
            btn_LapPhieuThuTien.ForeColor = Color.DarkSlateGray;
        }

        private void btn_LapPhieuThuTien_MouseLeave(object sender, EventArgs e)
        {
            btn_LapPhieuThuTien.BackColor = Color.Teal;
            btn_LapPhieuThuTien.ForeColor = Color.White;
        }
        private void btn_QuanLiPhieuThuTien_MouseHover(object sender, EventArgs e)
        {
            btn_QuanLiPhieuThuTien.BackColor = Color.White;
            btn_QuanLiPhieuThuTien.ForeColor = Color.DarkSlateGray;
        }

        private void btn_QuanLiPhieuThuTien_MouseLeave(object sender, EventArgs e)
        {
            btn_QuanLiPhieuThuTien.BackColor = Color.Teal;
            btn_QuanLiPhieuThuTien.ForeColor = Color.White;
        }
        private void btn_LapBaoCaoTon_MouseHover(object sender, EventArgs e)
        {
            btn_LapBaoCaoTon.BackColor = Color.White;
            btn_LapBaoCaoTon.ForeColor = Color.DarkSlateGray;
        }

        private void btn_LapBaoCaoTon_MouseLeave(object sender, EventArgs e)
        {
            btn_LapBaoCaoTon.BackColor = Color.Teal;
            btn_LapBaoCaoTon.ForeColor = Color.White;
        }
        private void btn_LapBaoCaoCongNo_MouseHover(object sender, EventArgs e)
        {
            btn_LapBaoCaoCongNo.BackColor = Color.White;
            btn_LapBaoCaoCongNo.ForeColor = Color.DarkSlateGray;
        }

        private void btn_LapBaoCaoCongNo_MouseLeave(object sender, EventArgs e)
        {
            btn_LapBaoCaoCongNo.BackColor = Color.Teal;
            btn_LapBaoCaoCongNo.ForeColor = Color.White;
        }
        private void btn_ThayDoiQuiDinh_MouseHover(object sender, EventArgs e)
        {
            btn_ThayDoiQuiDinh.BackColor = Color.White;
            btn_ThayDoiQuiDinh.ForeColor = Color.DarkSlateGray;
        }

        private void btn_ThayDoiQuiDinh_MouseLeave(object sender, EventArgs e)
        {
            btn_ThayDoiQuiDinh.BackColor = Color.Teal;
            btn_ThayDoiQuiDinh.ForeColor = Color.White;
        }
    }

}
