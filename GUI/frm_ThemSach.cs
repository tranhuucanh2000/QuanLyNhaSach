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
    public partial class frm_ThemSach : Form
    {

        private Sach_DTO sachDTO = new Sach_DTO();
        private Sach_BUS sachBUS = new Sach_BUS();
        private Result res; // Biến nhận kết quả của kiểm tra nhập


        public frm_ThemSach()
        {
            InitializeComponent();
        }
        private void frm_ThemSach_Load(object sender, EventArgs e)
        {
            ReloadMaSach();
            ReloadTheLoai();
            
        }

        private void ReloadTheLoai()
        {
            res = sachBUS.SelectALL_ListTheLoai();
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu load thất bại
            }

            List<string> ListTheLoai;
            ListTheLoai = (List<string>)res.Obj1;

            cbb_TheLoai.DataSource = ListTheLoai;
            cbb_TheLoai.DisplayMember = "TheLoai";
            cbb_TheLoai.Text = "";
        }

        public void ReloadMaSach()
        {
            // Hiển thị mã sách dự định
            res = sachBUS.GetNextIncrement();
            if ((res.FlagResult == false))
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if ((res.Obj1 != null/* TODO Change to default(_) if this is not a reference type */))
                txt_MaSach.Text = System.Convert.ToInt32(res.Obj1).ToString();
        }





        private void btn_Luu_Click(object sender, EventArgs e)
        {
            res = sachBUS.isValidTenSach(txt_TenSach.Text);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_TenSach.Focus();
                return;
            }

            res = sachBUS.isValidTheLoai(cbb_TheLoai.Text);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbb_TheLoai.Focus();

                return;
            }

            res = sachBUS.isValidTacGia(txt_TacGia.Text);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_TacGia.Focus();
                return;
            }

            res = sachBUS.isValidLuongTon(txt_SoLuongTon.Text);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SoLuongTon.Focus();
                return;
            }

            res = sachBUS.isValidDonGia(txt_DonGia.Text);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_DonGia.Focus();
                return;
            }

            {
                var withBlock = sachDTO;
                withBlock.TenSach1 = txt_TenSach.Text;
                withBlock.TheLoai1 = cbb_TheLoai.Text;
                withBlock.TacGia1 = txt_TacGia.Text;
                withBlock.SoLuongTon1 = int.Parse(txt_SoLuongTon.Text);
                withBlock.DonGia1 = float.Parse(txt_DonGia.Text);
            }


            res = sachBUS.insertSach(sachDTO);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                MessageBox.Show(res.ApplicationMessage, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReloadMaSach();
            ReloadTheLoai();

            txt_DonGia.Text = "";
            txt_TacGia.Text = "";
            txt_TenSach.Text = "";
        }

        private void btn_LuuVaThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void frm_ThemSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

	}
}
