using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using Utility;
using BUS;

namespace GUI
{
	public partial class frm_CapNhatKhachHang : Form
	{
		public frm_CapNhatKhachHang()
		{
			InitializeComponent();
		}
        private KhachHang_DTO khachHangDTO;
        private KhachHang_BUS khachHangBUS = new KhachHang_BUS();
        private Result res; // Biến nhận kết quả của kiểm tra nhập


        public frm_CapNhatKhachHang(KhachHang_DTO x)
        {
            InitializeComponent();
            //Panel_ThanhTrangThaiTren.Controls.Add(new ThanhTrangThaiTren("Phần mềm quản lí nhà sách"));
            khachHangDTO = x;
        }


        private void LoadDTOtoGUI()
        {
            {
                var withBlock = khachHangDTO;
				txt_MaKhachHang.Text = withBlock.MaKH1.ToString();
                txt_HoTen.Text = withBlock.HoTenKhachHang1;
                txt_DiaChi.Text = withBlock.DiaChi1;
                txt_DienThoai.Text = withBlock.DienThoai1;
                txt_Email.Text = withBlock.Email1;
                txt_TienNo.Text = Math.Round(withBlock.TienNo1, 3).ToString();
            }
        }

        private void frm_CapNhatKhachHang_Load(object sender, EventArgs e)
        {
            

            LoadDTOtoGUI();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            res = khachHangBUS.isValidHoTen(txt_HoTen.Text);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_HoTen.Focus();
                return;
            }


            res = khachHangBUS.isValidDienThoai(txt_DienThoai.Text);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_DienThoai.Focus();
                return;
            }

            res = khachHangBUS.isValidEmail(txt_Email.Text);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Email.Focus();
                return;
            }


            {
                var withBlock = khachHangDTO;
                withBlock.HoTenKhachHang1 = txt_HoTen.Text;
                withBlock.TienNo1 = double.Parse(txt_TienNo.Text);
                withBlock.DiaChi1 = txt_DiaChi.Text;
                withBlock.DienThoai1 = txt_DienThoai.Text;
                withBlock.Email1 = txt_Email.Text;
            }



            res = khachHangBUS.update(khachHangDTO);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                MessageBox.Show(res.ApplicationMessage, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_CapNhatKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
