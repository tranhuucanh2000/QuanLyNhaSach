using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DAL;
using DTO;
using Utility;
using BUS;


namespace GUI
{
    

    public partial class UC_QuanLiSach : UserControl
    {
        private Sach_DTO sachDTO;
        private Sach_BUS sachBUS;
        private Result res;
        private List<Sach_DTO> listSach;

        private bool Click_txt_TimKiem = false;
        public UC_QuanLiSach()
        {
            InitializeComponent();

            sachDTO = new Sach_DTO();
            sachBUS = new Sach_BUS();
        }

        public void reload_GUI()
        {
            this.Width = this.Parent.Size.Width;
            this.Height = this.Parent.Size.Height;
        }

        private void UC_QuanLiSach_Load(object sender, EventArgs e)
        {
            lbl_XoaTimKiem.Visible = false;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;


            Reload_DataGridViewListSach();
        }


        private void Reload_DataGridViewListSach()
        {
            res = sachBUS.SelectALL_ListSach();

            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listSach = (List<Sach_DTO>)res.Obj1;

            dgv_ListSach.Columns.Clear();

            dgv_ListSach.DataSource = listSach;





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


            dgv_ListSach.Columns["MaSach1"].Width = (int)(rong * 0.1);
            dgv_ListSach.Columns["TenSach1"].Width = (int)(rong * 0.37 - 20);
            dgv_ListSach.Columns["TheLoai1"].Width = (int)(rong * 0.15);
            dgv_ListSach.Columns["TacGia1"].Width = (int)(rong * 0.2);
            dgv_ListSach.Columns["SoLuongTon1"].Width = (int)(rong * 0.08);
            dgv_ListSach.Columns["DonGia1"].Width = (int)(rong * 0.1);




            dgv_ListSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv_ListSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_ListSach.RowHeadersVisible = false;
        }



        private void Reload_DataGridViewListSach1()
        {
            res = sachBUS.SelectALL_ListSach();

            if ((res.FlagResult == false))
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            listSach = (List<Sach_DTO>)res.Obj1;

            dgv_ListSach.Columns.Clear();
            dgv_ListSach.AutoGenerateColumns = false;
            dgv_ListSach.AllowUserToAddRows = false;

            dgv_ListSach.DataSource = listSach;


            var clMaSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = clMaSach;
                withBlock.Name = "MaSach";
                withBlock.HeaderText = "Mã sách";
                withBlock.DataPropertyName = "MaSach1";
            }
            dgv_ListSach.Columns.Add(clMaSach);


            var clTenSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTenSach;
                withBlock.Name = "TenSach";
                withBlock.HeaderText = "Tên sách";
                withBlock.DataPropertyName = "TenSach1";
            }
            dgv_ListSach.Columns.Add(clTenSach);

            var clTheLoai = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTheLoai;
                withBlock.Name = "TheLoai";
                withBlock.HeaderText = "Thể loại";
                withBlock.DataPropertyName = "TheLoai1";
            }
            dgv_ListSach.Columns.Add(clTheLoai);
        }

        private void btn_ThemSach_Click(object sender, EventArgs e)
        {
            frm_ThemSach f = new frm_ThemSach();
            f.ShowDialog();

            Reload_DataGridViewListSach(); // load lại dữ liệu
        }



        private void dgv_ListSach_SelectionChanged(object sender, EventArgs e)
        {
            if (listSach.Count == 0)
            {
                txt_TenSach.Text = "";
                txt_MaSach.Text = "";
                txt_TacGia.Text = "";
                txt_TheLoai.Text = "";
                txt_SoLuongTon.Text = "";
                txt_DonGia.Text = "";
                return;
            }

            try
            {
                int IdDongHienTai = dgv_ListSach.CurrentRow.Index;

                if (IdDongHienTai == -1)
                    return;

                sachDTO = (Sach_DTO)dgv_ListSach.Rows[IdDongHienTai].DataBoundItem;

                {
                    var withBlock = sachDTO;
                    txt_TenSach.Text = withBlock.TenSach1;
                    txt_MaSach.Text = withBlock.MaSach1.ToString();
                    txt_TacGia.Text = withBlock.TacGia1;
                    txt_TheLoai.Text = withBlock.TheLoai1;
                    txt_SoLuongTon.Text = withBlock.SoLuongTon1.ToString();
                    txt_DonGia.Text = Math.Round(withBlock.DonGia1, 3).ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            frm_CapNhatSach f = new frm_CapNhatSach(sachDTO);
            f.ShowDialog();

            Reload_DataGridViewListSach(); // load lại dữ liệu
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult resDialog = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ((resDialog == DialogResult.Yes))
            {
                Result res = sachBUS.deleteSach(sachDTO);

                if ((res.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show(res.ApplicationMessage, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Reload_DataGridViewListSach();
                }
            }
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
            if ((txt_TimKiem.Text == ""))
            {
                lbl_XoaTimKiem.Visible = false;
                Reload_DataGridViewListSach();
                return;
            }
            else
                lbl_XoaTimKiem.Visible = true;


            if ((txt_TimKiem.Text == "Tìm kiếm bằng Mã Sách hoặc Tên sách..."))
                return;



            res = sachBUS.SelectALL_ListSachByStringMaSachTenSach(txt_TimKiem.Text);

            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listSach = (List<Sach_DTO>)res.Obj1;



            dgv_ListSach.DataSource = listSach;
        }


        private void lbl_XoaTimKiem_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "";
            lbl_XoaTimKiem.Visible = false;
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
