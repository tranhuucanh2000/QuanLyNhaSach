using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DTO;
using Utility;


namespace GUI
{
    public partial class frm_CapNhatSach : Form
    {



        private Sach_DTO sachDTO;
        private Sach_BUS sachBUS;
        private Result res; // Biến nhận kết quả của kiểm tra nhập


        public frm_CapNhatSach()
        {
            InitializeComponent();
            sachDTO = new Sach_DTO();
            sachBUS = new Sach_BUS();
        }

    

        private void frm_CapNhatSach_Load(object sender, EventArgs e)
        {
            ReloadTheLoai();
            LoadDTOtoGUI();
        }
        private void LoadDTOtoGUI()
        {
            {
                var withBlock = sachDTO;
                txt_MaSach.Text = withBlock.MaSach1.ToString();
                txt_TenSach.Text = withBlock.TenSach1;
                cbb_TheLoai.Text = withBlock.TheLoai1;
                txt_TacGia.Text = withBlock.TacGia1;
                txt_SoLuongTon.Text = withBlock.SoLuongTon1.ToString();
                txt_DonGia.Text = Math.Round(withBlock.DonGia1, 3).ToString();
            }
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


        public frm_CapNhatSach(Sach_DTO x)
        {
            InitializeComponent();

            sachDTO = x;
            sachBUS = new Sach_BUS();
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
                withBlock.MaSach1 = int.Parse(txt_MaSach.Text);
                withBlock.TenSach1 = txt_TenSach.Text;
                withBlock.TheLoai1 = cbb_TheLoai.Text;
                withBlock.TacGia1 = txt_TacGia.Text;
                withBlock.SoLuongTon1 = int.Parse(txt_SoLuongTon.Text);
                withBlock.DonGia1 = float.Parse(txt_DonGia.Text);
            }


            res = sachBUS.updateSach(sachDTO);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                MessageBox.Show(res.ApplicationMessage, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReloadTheLoai();
            cbb_TheLoai.Text = sachDTO.TheLoai1;
        }

        private void btn_LuuVaThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_CapNhatSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
