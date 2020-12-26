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
    public partial class UC_TraCuuSach : UserControl
    {
        private Sach_BUS sachBUS = new Sach_BUS();
        private Sach_DTO sachDTO;
        private Result Res;
        private List<Sach_DTO> listSach;

        public UC_TraCuuSach()
        {
            InitializeComponent();
        }


        private void ReloadTheLoai()
        {
        Res = sachBUS.SelectALL_ListTheLoai();
        if ((Res.FlagResult == false))
        {
            MessageBox.Show(Res.ApplicationMessage + Environment.NewLine + Res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        List<string> ListTheLoai;
        ListTheLoai = (List<string>)Res.Obj1;
        ListTheLoai.Insert(0, "-----Tất cả-----");


        cbb_TheLoai.DataSource = ListTheLoai;
        cbb_TheLoai.DisplayMember = "TheLoai";
        cbb_TheLoai.Text = "-----Tất cả-----";
        }

        private void UC_TraCuuSach_Load(object sender, EventArgs e)
        {
            lbl_XoaTimKiem.Visible = false;

            ReloadTheLoai();
            Reload_DataGridViewListSach();
        }

        private void Reload_DataGridViewListSach()
        {
            string textTimKiem = "";
            if ((txt_TimKiem.Text == "Tìm kiếm bằng Mã Sách hoặc Tên sách..."))
                textTimKiem = "";
            else
                textTimKiem = txt_TimKiem.Text;


            string AdvancedSQL = "";

            if ((cbb_TheLoai.Text != "-----Tất cả-----"))
            {
                string Advanced_Like_TheLoai = cbb_TheLoai.Text;

                Advanced_Like_TheLoai = " " + Advanced_Like_TheLoai + " ";
                while ((Advanced_Like_TheLoai.IndexOf("  ") != -1))
                    Advanced_Like_TheLoai = Advanced_Like_TheLoai.Replace("  ", " ");

                while ((Advanced_Like_TheLoai.IndexOf(" ") != -1))
                    Advanced_Like_TheLoai = Advanced_Like_TheLoai.Replace(" ", "%");

                AdvancedSQL += "AND ( (     [TheLoai] = N'" + cbb_TheLoai.Text + "' ) OR (   [TheLoai] <> N'" + cbb_TheLoai.Text + "'  AND [TheLoai] like '" + Advanced_Like_TheLoai + "'  )   )";
            }

            Res = sachBUS.SelectALL_ListSachByStringMaSachTenSach_Advanced(textTimKiem, AdvancedSQL);

            if ((Res.FlagResult == false))
            {
                MessageBox.Show(Res.ApplicationMessage + Environment.NewLine + Res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listSach = (List<Sach_DTO>)Res.Obj1;


            dgv_ListSach.Columns.Clear();
            dgv_ListSach.DataSource = listSach;




            try
            {
                dgv_ListSach.Columns["MaSach1"].HeaderText = "Mã";
                dgv_ListSach.Columns["MaSach1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung

                dgv_ListSach.Columns["TenSach1"].HeaderText = "Tên sách";
                dgv_ListSach.Columns["TheLoai1"].HeaderText = "Thể loại";
                dgv_ListSach.Columns["TacGia1"].HeaderText = "Tác giả";

                {
                    var withBlock = dgv_ListSach.Columns["SoLuongTon1"];
                    withBlock.HeaderText = "Tồn";
                    withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội 
                }

                {
                    var withBlock = dgv_ListSach.Columns["DonGia1"];
                    withBlock.HeaderText = "Đơn giá";
                    withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }




                double rong = dgv_ListSach.Width;


                dgv_ListSach.Columns["MaSach1"].Width = (int)(rong*0.1);
                dgv_ListSach.Columns["TenSach1"].Width = (int)(rong * 0.37 - 20);
                dgv_ListSach.Columns["TheLoai1"].Width = (int)(rong * 0.15);
                dgv_ListSach.Columns["TacGia1"].Width = (int)(rong * 0.2);
                dgv_ListSach.Columns["SoLuongTon1"].Width = (int)(rong * 0.08);
                dgv_ListSach.Columns["DonGia1"].Width = (int)(rong * 0.1);

                dgv_ListSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
                dgv_ListSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                dgv_ListSach.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dgv_ListSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbl_XoaTimKiem_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "";
            lbl_XoaTimKiem.Visible = false;
        }
        private void txt_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "Tìm kiếm bằng Mã Sách hoặc Tên sách...")
                txt_TimKiem.Text = "";
        }

        private void txt_TimKiem_Leave(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "")
            {
                txt_TimKiem.Text = "Tìm kiếm bằng Mã Sách hoặc Tên sách...";
                lbl_XoaTimKiem.Visible = false;
            }
            else
                lbl_XoaTimKiem.Visible = true;
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "")
                lbl_XoaTimKiem.Visible = false;
            else
                lbl_XoaTimKiem.Visible = true;

            Reload_DataGridViewListSach();

            return;
        }

        private void lbl_XoaTimKiem_MouseHover(object sender, EventArgs e)
        {
            lbl_XoaTimKiem.BackColor = Color.WhiteSmoke;
        }

        private void lbl_XoaTimKiem_MouseLeave(object sender, EventArgs e)
        {
            lbl_XoaTimKiem.BackColor = Color.White;
        }

        private void txt_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txt_TimKiem.Text = "";
                dgv_ListSach.Focus();
            }
        }

    }
}
