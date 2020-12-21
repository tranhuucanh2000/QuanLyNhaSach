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
            if (TaiKhoanDAO.Instance.XacNhanTaiKhoan(txbTenDN.Text, txbMa.Text) == true) 
            {
                pnMatKhauMoi.Visible = true;
                txbTenDN.ReadOnly = true;
                txbMa.ReadOnly = true;
                txbMatKhau.Focus();
                lbHoTro.Text = "Bạn đã nhập đúng mã! Hãy tạo mật khẩu mới!";
                lbHoTro.ForeColor = Color.Violet;
                btnLuu.Visible = btnThoat.Visible = false;
                pnMa.Enabled = false;
            } 
            else
            {
                lbHoTro.Text = "Mã bạn nhập không đúng! Vui lòng nhập lại!";
                pnMatKhauMoi.Visible = false;
                lbHoTro.ForeColor = Color.Red;
            }
        }


        private void btnXNMK_Click(object sender, EventArgs e)
        {
            if (txbXacNhanMK.Text == txbMatKhau.Text && txbXacNhanMK.Text.Length > 4)
            {
                TaiKhoanDAO.Instance.QuenMatKhau(txbTenDN.Text, txbXacNhanMK.Text);
                lbHoTro.Text = "Đã cập nhật mật khẩu thành công!";
                lbHoTro.ForeColor = Color.Violet;
            }
            else
            {
                if(txbXacNhanMK.Text.Length>4)
                {
                    lbHoTro.Text = "Bạn nhập mật khẩu không giống nhau kìa! Nhập lại đi nào!";
                    lbHoTro.ForeColor = Color.Red;
                    txbXacNhanMK.Text = txbMatKhau.Text = "";
                    txbMatKhau.Focus();
                }    
                else
                {
                    lbHoTro.Text = "Bạn vui lòng nhập mật khẩu dài hơn 4 kí tự!";
                    lbHoTro.ForeColor = Color.Red;
                    txbXacNhanMK.Text = txbMatKhau.Text = "";
                    txbMatKhau.Focus();
                }    
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
