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
using BUS;
using DTO;
using Utility;

namespace GUI
{
	public partial class frm_ThemKhachHang : Form
	{
        private KhachHang_DTO khachHangDTO = new KhachHang_DTO();
        private KhachHang_BUS khachHangBUS = new KhachHang_BUS();
        private Result res;

        public frm_ThemKhachHang()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.


            //Panel_ThanhTrangThaiTren.Controls.Add(new ThanhTrangThaiTren("Phần mềm quản lí nhà sách"));
        }



        public void ReloadMaKH()
        {
            // Hiển thị mã sách dự định
            res = khachHangBUS.GetNextIncrement();
            if ((res.FlagResult == false))
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if ((res.Obj1 != null/* TODO Change to default(_) if this is not a reference type */))
                txt_MaKhachHang.Text = System.Convert.ToInt32(res.Obj1).ToString();
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


            res = khachHangBUS.insert(khachHangDTO);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                MessageBox.Show(res.ApplicationMessage, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReloadMaKH();


            txt_DiaChi.Text = "";
            txt_DienThoai.Text = "";
            txt_Email.Text = "";
            txt_HoTen.Text = "";
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ThemKhachHang_Load(object sender, EventArgs e)
        {
            ReloadMaKH();
        }

        private void frm_ThemKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
	}
}
