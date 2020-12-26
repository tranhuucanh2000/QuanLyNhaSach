using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhaSach.DAO;
using QuanLyNhaSach.DTO;

namespace QuanLyNhaSach
{
    public partial class FDangNhap : Form
    {
        public FDangNhap()
        {
            InitializeComponent();
        }

        private void ptClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbQuenMatKhau_Click(object sender, EventArgs e)
        {
            FQuenMatKhau fForgotPassword = new FQuenMatKhau();
            fForgotPassword.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string usn = txbTaiKhoan.Text;
            string psw = txbMatKhau.Text;
            if (TaiKhoanDAO.Instance.isAccount(usn,psw))
            {
                TaiKhoan account = TaiKhoanDAO.Instance.LayTaiKhoanTuTenDN(usn);
                //MainForm mainForm = new MainForm(account);
                //mainForm.ShowDialog();
                FChinh fChinh = new FChinh(account);
                fChinh.ShowDialog();
                this.Hide();
            }
            else
            {
                groupBox1.Text = "Sai Tài Khoản";
                groupBox1.ForeColor = Color.Red;
            } 
        }
      
        private void txbTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txbMatKhau.Focus();
            }    
        }

        private void txbMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
        // chạy concac
    }
}
