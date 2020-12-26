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
using GUI;
using System.Xml;
using DTO;
using BUS;
using System.Security.Cryptography;
using Utility;

namespace GUI
{
    public partial class frm_DangNhap : Form
    {
        private int count = 0;
        private DangNhap_DTO dangNhapDTO = new DangNhap_DTO();
        private DangNhap_BUS dangNhapBUS = new DangNhap_BUS();
        private Result Res;
        public string Salt = "-#-@PhanMemQuanLySach@-#-;";

        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }


        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            {
                var withBlock = dangNhapDTO;
                withBlock.TenDangNhap1 = txt_TenDangNhap.Text;
                withBlock.MatKhau1 = txt_MatKhau.Text;
            }
            Res = dangNhapBUS.KiemTraDangNhap(dangNhapDTO);
            if ((Res.FlagResult == false))
            {
                txt_MatKhau.Focus();
                MessageBox.Show(Res.ApplicationMessage + Res.SystemMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frm_Main f = new frm_Main();
                f.Show();
                //this.Close();
            }
        }



        private void frm_DangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_DangNhap.PerformClick();
        }


        private void txt_TenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                btn_DangNhap.PerformClick();
                e.Handled = true;
            }
        }

        private void txt_MatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                btn_DangNhap.PerformClick();
                e.Handled = true;
            }
        }

        private void txt_MatKhau_Enter(object sender, EventArgs e)
        {
            txt_MatKhau.SelectAll();
        }
    }
}
