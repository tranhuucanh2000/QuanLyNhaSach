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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmCode_Click(object sender, EventArgs e)
        {
            if (txbCode.Text == File.ReadAllText("./txt/code.txt"))
            {
                pnNewPassword.Enabled = true;
                txbNewPass.Focus();
            }

            else
            {
                lbSupport.Text = "You have no code. Contact us or exit";
                lbSupport.ForeColor = Color.Red;
            }    
        }

        private void txbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmCode_Click(sender, e);
            }
        }

        private void btnCFNewPass_Click(object sender, EventArgs e)
        {
            if(txbRePass.Text==txbNewPass.Text)
            {
                //Xử lí sữa mật khẩu
                this.Close();
            }    
        }
    }
}
