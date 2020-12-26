using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DTO;
using BUS;
using Utility;

namespace GUI
{
    public partial class UC_QuanLiKhachHang : UserControl
    {
        public UC_QuanLiKhachHang()
        {
            InitializeComponent();
            lbl_XoaTimKiem.Visible = false;
        }

        private Result res;
        private KhachHang_BUS khachHangBUS = new KhachHang_BUS();
        private List<KhachHang_DTO> listKhachHang;

        private KhachHang_DTO khachHangDTO = new KhachHang_DTO();


        private void btn_ThemKhachHang_Click(object sender, EventArgs e)
        {
            frm_ThemKhachHang frm = new frm_ThemKhachHang();
            frm.ShowDialog();
            Reload_DataGridViewListKhachHang();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            frm_CapNhatKhachHang f = new frm_CapNhatKhachHang(khachHangDTO);
            f.ShowDialog();

            Reload_DataGridViewListKhachHang(); // load lại dữ liệu
        }

        private void UC_QuanLiKhachHang_Load(object sender, EventArgs e)
        {
            lbl_XoaTimKiem.Visible = false;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            Reload_DataGridViewListKhachHang();
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
            dgv_ListKhachHang.Columns["HoTenKhachHang1"].Width = (int)(rong * 0.28 - 20);
            dgv_ListKhachHang.Columns["DiaChi1"].Width = (int)(rong * 0.15);
            dgv_ListKhachHang.Columns["DienThoai1"].Width = (int)(rong * 0.15);
            dgv_ListKhachHang.Columns["Email1"].Width = (int)(rong * 0.2);
            dgv_ListKhachHang.Columns["TienNo1"].Width = (int)(rong * 0.12);




            dgv_ListKhachHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv_ListKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_ListKhachHang.RowHeadersVisible = false;
        }

        private void dgv_ListKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (listKhachHang.Count == 0)
            {
                txt_MaKhachHang.Text = "";
                txt_HoTen.Text = "";
                txt_TienNo.Text = "";
                txt_DiaChi.Text = "";
                txt_DienThoai.Text = "";
                txt_Email.Text = "";
                return;
            }

            try
            {
                int IdDongHienTai = dgv_ListKhachHang.CurrentRow.Index;

                if (IdDongHienTai == -1)
                    return;

                khachHangDTO = (KhachHang_DTO)dgv_ListKhachHang.Rows[IdDongHienTai].DataBoundItem;

                {
                    var withBlock = khachHangDTO;
                    txt_MaKhachHang.Text = withBlock.MaKH1.ToString();
                    txt_HoTen.Text = withBlock.HoTenKhachHang1;
                    txt_TienNo.Text = withBlock.TienNo1.ToString();
                    txt_DiaChi.Text = withBlock.DiaChi1;
                    txt_DienThoai.Text = withBlock.DienThoai1;
                    txt_Email.Text = withBlock.Email1;
                }
            }
            catch (Exception ex)
            {
            }
        }



        private void txt_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "Tìm kiếm bằng Mã KH, Họ tên hoặc SĐT...")
                txt_TimKiem.Text = "";
        }


        private void txt_TimKiem_Leave(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "")
            {
                txt_TimKiem.Text = "Tìm kiếm bằng Mã KH, Họ tên hoặc SĐT...";
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
                Reload_DataGridViewListKhachHang();
                return;
            }
            else
                lbl_XoaTimKiem.Visible = true;


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


        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult resDialog = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ((resDialog == DialogResult.Yes))
            {
                Result res = khachHangBUS.deleteByKhachHang(khachHangDTO);

                if ((res.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show(res.ApplicationMessage, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Reload_DataGridViewListKhachHang();
                }
            }
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
                dgv_ListKhachHang.Focus();
            }
        }

       
    }
}