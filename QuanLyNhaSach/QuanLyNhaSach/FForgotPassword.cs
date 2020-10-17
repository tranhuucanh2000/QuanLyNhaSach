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
        public FForgotPassword()
        {
            InitializeComponent();
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
            if(txbXNMK.Text==txbMKM.Text)
            {
                //Xử lí sữa mật khẩu
                this.Close();
            }    
        }
    }
}
