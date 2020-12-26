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
using BUS;
using DTO;
using Utility;

namespace GUI
{
    public partial class UC_LapPhieuThuTien : UserControl
    {
        private PhieuThuTien_BUS phieuThuTienBUS = new PhieuThuTien_BUS();
        private Result res;
        private KhachHang_BUS khachHangBUS = new KhachHang_BUS();
        private List<KhachHang_DTO> listKhachHang;
        private KhachHang_DTO khachHangDTO;
        private PhieuThuTien_DTO phieuThuTienDTO = new PhieuThuTien_DTO();
        public UC_LapPhieuThuTien()
        {
            InitializeComponent();
        }

        private void UC_LapPhieuThuTien_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            Reload_MaPhieuThuTiepTheo();

            Reload_DataGridViewListKhachHang();
            lbl_XoaTimKiem.Visible = false;
        }

        private void Reload_MaPhieuThuTiepTheo()
        {
            Result Res = phieuThuTienBUS.GetNextIncrement();
            if ((Res.FlagResult == false))
                MessageBox.Show(Res.ApplicationMessage + Environment.NewLine + Res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if ((Res.Obj1 != null/* TODO Change to default(_) if this is not a reference type */))
                txt_MaPhieuThu.Text = System.Convert.ToInt32(Res.Obj1).ToString();
        }

        private void btn_LapPhieu_Click(object sender, EventArgs e)
        {
            lbl_XoaTimKiem.Visible = false;
            res = phieuThuTienBUS.IsValidSoTienThu(txt_SoTienThu.Text, double.Parse(txt_TienNo.Text));
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SoTienThu.Focus();
                return;
            }

            {
                var withBlock = phieuThuTienDTO;
                withBlock.MaKhachHang1 = khachHangDTO.MaKH1;
                withBlock.SoTienThu1 = double.Parse(txt_SoTienThu.Text);
                withBlock.NgayThuTien1 = dtp_NgayThuTien.Value;
            }


            res = phieuThuTienBUS.insert(phieuThuTienDTO);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            khachHangDTO.TienNo1 -= phieuThuTienDTO.SoTienThu1;
            res = khachHangBUS.update(khachHangDTO);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgv_ListKhachHang.Refresh();
            txt_TienNo.Text = khachHangDTO.TienNo1.ToString();

            MessageBox.Show("Đã thêm phiếu thu tiền mới thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reload_MaPhieuThuTiepTheo();
            txt_SoTienThu.Text = "";
        }



        private void Reload_DataGridViewListKhachHang()
        {
            res = khachHangBUS.SelectALL_ListKhachHang();

            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listKhachHang = (List<KhachHang_DTO>)res.Obj1;

            dgv_ListKhachHang.Columns.Clear();

            dgv_ListKhachHang.AutoGenerateColumns = false;

            dgv_ListKhachHang.DataSource = listKhachHang;


            var clMaKH = new DataGridViewTextBoxColumn();
            {
                var withBlock = clMaKH;
                withBlock.Name = "MaKH1";
                withBlock.DataPropertyName = "MaKH1";
                withBlock.HeaderText = "Mã KH";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_ListKhachHang.Columns.Add(clMaKH);

            var clHoTenKhachHang = new DataGridViewTextBoxColumn();
            {
                var withBlock = clHoTenKhachHang;
                withBlock.Name = "HoTenKhachHang1";
                withBlock.DataPropertyName = "HoTenKhachHang1";
                withBlock.HeaderText = "Họ Tên";
            }
            dgv_ListKhachHang.Columns.Add(clHoTenKhachHang);

            var clDiaChi = new DataGridViewTextBoxColumn();
            {
                var withBlock = clDiaChi;
                withBlock.Name = "DiaChi1";
                withBlock.DataPropertyName = "DiaChi1";
                withBlock.HeaderText = "Địa chỉ";
            }
            dgv_ListKhachHang.Columns.Add(clDiaChi);

            var clDienThoai = new DataGridViewTextBoxColumn();
            {
                var withBlock = clDienThoai;
                withBlock.Name = "DienThoai1";
                withBlock.DataPropertyName = "DienThoai1";
                withBlock.HeaderText = "Điện thoại";
            }
            dgv_ListKhachHang.Columns.Add(clDienThoai);




            var clEmail = new DataGridViewTextBoxColumn();
            {
                var withBlock = clEmail;
                withBlock.Name = "Email1";
                withBlock.DataPropertyName = "Email1";
                withBlock.HeaderText = "Email";
            }
            dgv_ListKhachHang.Columns.Add(clEmail);



            var clTienNo = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTienNo;
                withBlock.Name = "TienNo1";
                withBlock.DataPropertyName = "TienNo1";
                withBlock.HeaderText = "Tiền nợ";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            }
            dgv_ListKhachHang.Columns.Add(clTienNo);



            double rong = dgv_ListKhachHang.Width;

            dgv_ListKhachHang.Columns["MaKH1"].Width = (int)(rong * 0.1);
            dgv_ListKhachHang.Columns["HoTenKhachHang1"].Width = (int)(rong * 0.28 - 20) ;
            dgv_ListKhachHang.Columns["DiaChi1"].Width = (int)(rong * 0.15) ;
            dgv_ListKhachHang.Columns["DienThoai1"].Width = (int)(rong * 0.15) ;
            dgv_ListKhachHang.Columns["Email1"].Width = (int)(rong * 0.2);
            dgv_ListKhachHang.Columns["TienNo1"].Width = (int)(rong * 0.12) ;




            dgv_ListKhachHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv_ListKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_ListKhachHang.RowHeadersVisible = false;
        }


        private void txt_TimKiem_Click(object sender, EventArgs e)
        {
            if ((txt_TimKiem.Text == "Tìm kiếm bằng Mã KH, Họ tên hoặc SĐT..."))
            {
                txt_TimKiem.Text = "";
                lbl_XoaTimKiem.Visible = false;
            }
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            if ((txt_TimKiem.Text == ""))
            {
                Reload_DataGridViewListKhachHang();
                return;
            }

            if ((txt_TimKiem.Text == "Tìm kiếm bằng Mã KH, Họ tên hoặc SĐT..."))
                return;

            res = khachHangBUS.SelectALL_ListKhachHangByStringMaKHHoTenSDT(txt_TimKiem.Text);

            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listKhachHang = (List<KhachHang_DTO>)res.Obj1;


            dgv_ListKhachHang.DataSource = listKhachHang;
        }


        private void txt_TimKiem_Leave(object sender, EventArgs e)
        {
            if ((txt_TimKiem.Text == ""))
            {
                txt_TimKiem.Text = "Tìm kiếm bằng Mã KH, Họ tên hoặc SĐT...";
                lbl_XoaTimKiem.Visible = false;
            }
            else
                lbl_XoaTimKiem.Visible = true;
        }


        private void dgv_ListKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (listKhachHang.Count == 0)
            {
                txt_MaKhachHang.Text = "";
                txt_HoTen.Text = "";
                txt_TienNo.Text = "";
            }
            else
                lbl_XoaTimKiem.Visible = true;


            if ((txt_TimKiem.Text == "Tìm kiếm bằng Mã KH, Họ tên hoặc SĐT..."))
                lbl_XoaTimKiem.Visible = false;


            int IdDongHienTai = dgv_ListKhachHang.CurrentRow.Index;
            if (IdDongHienTai == -1)
                return;

            khachHangDTO = (KhachHang_DTO)dgv_ListKhachHang.Rows[IdDongHienTai].DataBoundItem;

            {
                var withBlock = khachHangDTO;
                txt_MaKhachHang.Text = withBlock.MaKH1.ToString();
                txt_HoTen.Text = withBlock.HoTenKhachHang1;
                txt_TienNo.Text = withBlock.TienNo1.ToString();
            }
        }
        private void lbl_XoaTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txt_TimKiem.Text = "";
            lbl_XoaTimKiem.Visible = false;
        }

        private void txt_SoTienThu_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txt_TimKiem.Text = "";
                dgv_ListKhachHang.Focus();
            }
        }
    }
}
