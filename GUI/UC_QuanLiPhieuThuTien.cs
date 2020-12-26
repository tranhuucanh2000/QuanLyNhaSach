using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using DTO;
using BUS;
using Utility;

namespace GUI
{
    public partial class UC_QuanLiPhieuThuTien : UserControl
    {

        private Result res;
        private PhieuThuTien_BUS phieuThuTienBUS;
        private List<PhieuThuTien_DTO> listPhieuThuTien;
        private PhieuThuTien_DTO phieuThuTienDTO;

        public UC_QuanLiPhieuThuTien()
        {
            InitializeComponent();
            phieuThuTienDTO = new PhieuThuTien_DTO();
            phieuThuTienBUS = new PhieuThuTien_BUS();
        }

        private void UC_QuanLiPhieuThuTien_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            lbl_XoaTimKiem.Visible = false;
            Reload_DataGridViewPhieuThuTien1();
        }

        private void txt_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "Tìm kiếm bằng Mã Phiếu Thu")
                txt_TimKiem.Text = "";
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            if ((txt_TimKiem.Text == ""))
            {
                lbl_XoaTimKiem.Visible = false;
                Reload_DataGridViewPhieuThuTien1();
                return;
            }
            else
                lbl_XoaTimKiem.Visible = true;


            if ((txt_TimKiem.Text == "Tìm kiếm bằng Mã Phiếu Thu"))
                return;

            try
            {
                int MaPhieuThuINT;
                if (int.TryParse(txt_TimKiem.Text, out MaPhieuThuINT) == false)
                    MaPhieuThuINT = -1;

                res = phieuThuTienBUS.SelectAll_ListPhieuThuTienByMaPhieu(MaPhieuThuINT);
                if ((res.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                listPhieuThuTien = (List<PhieuThuTien_DTO>)res.Obj1;
            }
            catch (Exception ex)
            {
            }

            dgv_PhieuThuTien.DataSource = listPhieuThuTien;
        }



        private void txt_TimKiem_Leave(object sender, EventArgs e)
        {
            if ((txt_TimKiem.Text == ""))
            {
                txt_TimKiem.Text = "Tìm kiếm bằng Mã Phiếu Thu";
                lbl_XoaTimKiem.Visible = false;
            }
            else
                lbl_XoaTimKiem.Visible = true;
        }



        private void Reload_DataGridViewPhieuThuTien1()
        {
            res = phieuThuTienBUS.SelectAll_ListPhieuThuTien();

            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listPhieuThuTien = (List<PhieuThuTien_DTO>)res.Obj1;

            dgv_PhieuThuTien.Columns.Clear();


            dgv_PhieuThuTien.AutoGenerateColumns = false;



            dgv_PhieuThuTien.DataSource = listPhieuThuTien;


            var clMaPhieu = new DataGridViewTextBoxColumn();
            {
                var withBlock = clMaPhieu;
                withBlock.Name = "MaPhieuThu";
                withBlock.DataPropertyName = "MaPhieuThu1";
                withBlock.HeaderText = "Mã phiếu";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_PhieuThuTien.Columns.Add(clMaPhieu);



            var clMaKH = new DataGridViewTextBoxColumn();
            {
                var withBlock = clMaKH;
                withBlock.Name = "MaKH";
                withBlock.DataPropertyName = "MaKhachHang1";
                withBlock.HeaderText = "Mã KH";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_PhieuThuTien.Columns.Add(clMaKH);



            var clHoTenKhachHang = new DataGridViewTextBoxColumn();
            {
                var withBlock = clHoTenKhachHang;
                withBlock.Name = "HoTenKhachHang";
                withBlock.DataPropertyName = "HoTenKhachHang1";
                withBlock.HeaderText = "Họ Tên";
            }
            dgv_PhieuThuTien.Columns.Add(clHoTenKhachHang);

            var clNgayThuTien = new DataGridViewTextBoxColumn();
            {
                var withBlock = clNgayThuTien;
                withBlock.Name = "NgayThuTien";
                withBlock.DataPropertyName = "NgayThuTien1";
                withBlock.HeaderText = "Ngày Thu Tiền";
            }
            dgv_PhieuThuTien.Columns.Add(clNgayThuTien);

            var clSoTienThu = new DataGridViewTextBoxColumn();
            {
                var withBlock = clSoTienThu;
                withBlock.Name = "SoTienThu";
                withBlock.DataPropertyName = "SoTienThu1";
                withBlock.HeaderText = "Số Tiền";
            }
            dgv_PhieuThuTien.Columns.Add(clSoTienThu);



            double rong = dgv_PhieuThuTien.Width;

            dgv_PhieuThuTien.Columns["MaPhieuThu"].Width = (int)(rong * 0.13);
            dgv_PhieuThuTien.Columns["MaKH"].Width = (int)(rong * 0.1);
            dgv_PhieuThuTien.Columns["HoTenKhachHang"].Width = (int)(rong * 0.37 - 20) ;
            dgv_PhieuThuTien.Columns["NgayThuTien"].Width = (int)(rong * 0.2);
            dgv_PhieuThuTien.Columns["SoTienThu"].Width = (int)(rong * 0.2);



            dgv_PhieuThuTien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv_PhieuThuTien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_PhieuThuTien.RowHeadersVisible = false;
        }

        private void dgv_PhieuThuTien_SelectionChanged(object sender, EventArgs e)
        {
            if (listPhieuThuTien.Count == 0)
            {
                txt_MaPhieuThu.Text = "";
                txt_MaKhachHang.Text = "";
                txt_HoTen.Text = "";
                txt_SoTienThu.Text = "";
                DateTimePicker_NgayThuTien.Value = DateTime.Now;
                return;
            }

           // 
            try
            {
                int IdDongHienTai = dgv_PhieuThuTien.CurrentRow.Index;

                if (IdDongHienTai == -1)
                    return;
                phieuThuTienDTO = (PhieuThuTien_DTO)dgv_PhieuThuTien.Rows[IdDongHienTai].DataBoundItem;

                {
                    var withBlock = phieuThuTienDTO;
                    txt_MaPhieuThu.Text = withBlock.MaPhieuThu1.ToString();
                    txt_MaKhachHang.Text = withBlock.MaKhachHang1.ToString();
                    txt_HoTen.Text = withBlock.HoTenKhachHang1;
                    txt_SoTienThu.Text = withBlock.SoTienThu1.ToString();
                    DateTimePicker_NgayThuTien.Value = DateTime.Parse(withBlock.NgayThuTien1.ToString());
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void lbl_XoaTimKiem_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "";
            lbl_XoaTimKiem.Visible = false;
        }


        private void txt_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txt_TimKiem.Text = "";
                dgv_PhieuThuTien.Focus();
            }
        }

    }
}
