using QuanLyNhaSach.DAO;
using QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class FQuenMatKhau : Form
    {
        public FQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (TaiKhoanDAO.Instance.XacNhanTaiKhoan(txbTenDN.Text, txbMa.Text) == true) pnMatKhauMoi.Visible = true;
            else
            {
                lbHoTro.Text = "Mã bạn nhập không đúng!Vui lòng nhập lại!";
                pnMatKhauMoi.Visible = false;
            }
        }


        private void btnXNMK_Click(object sender, EventArgs e)
        {
            if (txbXacNhanMK.Text == txbMatKhau.Text && txbXacNhanMK.Text.Length > 4)
            {
                
            }
            else
            {
                lbHoTro.Text = "Bạn nhập mật khẩu không giống nhau kìa! Nhập lại đi nào!";
                txbXacNhanMK.Text = txbMatKhau.Text = "";
                txbMatKhau.Focus();
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
