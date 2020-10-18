using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuanLyNhaSach
{
    public partial class FForgotPassword : Form
    {
        string Ten ;
        string TenTaiKhoan ;
        string MatKhau;
        public FForgotPassword()
        {
            InitializeComponent();
            DongBoTaiKhoanVoiFile();
        }
        void DongBoTaiKhoanVoiFile()
        {
            string[] TaiKhoan = File.ReadAllText("./txt/account.txt").Split('\t');
            Ten = TaiKhoan[0];
            TenTaiKhoan = TaiKhoan[1];
            MatKhau = TaiKhoan[2];
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhanMa_Click(object sender, EventArgs e)
        {
            if (txbMa.Text == File.ReadAllText("./txt/code.txt"))
            {
                pnNewPassword.Enabled = true;
                pnMa.Enabled = false;
                lbHoTro.Text = "Bạn đã nhập đúng mã!";
                lbHoTro.TextAlign = ContentAlignment.MiddleCenter;
                txbMKM.Focus();
            }

            else
            {
                lbHoTro.Text = "Bạn không có mã. Hãy liên hệ chúng tôi!";
                lbHoTro.ForeColor = Color.Red;
            }    
        }

        private void txbMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXacNhanMa_Click(sender, e);
            }
        }

        private void btnXNMK_Click(object sender, EventArgs e)
        {
            if(txbXNMK.Text==txbMKM.Text && txbXNMK.Text.Length>4)
            {
                string text = String.Concat(Ten, '\t', TenTaiKhoan, '\t', txbXNMK.Text);
                File.WriteAllText("./txt/account.txt", text);
                this.Close();
            }
            else
            {
                lbHoTro.Text = "Bạn nhập mật khẩu không giống nhau kìa! Nhập lại đi nào!";
                txbMKM.Text = txbXNMK.Text = "";
                txbMKM.Focus();
            }
        }

        private void ptClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txbMKM_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txbXNMK.Focus();
            }    
        }

        private void txbXNMK_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnXNMK_Click(sender, e);
            }    
        }
    }
}
