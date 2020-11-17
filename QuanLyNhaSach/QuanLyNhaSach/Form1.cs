using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuanLyNhaSach.DAO;

namespace QuanLyNhaSach
{
    public partial class Form1 : Form
    {
        string username;
        string password;
        public Form1()
        {
            InitializeComponent();
        }
        bool isTrueAccount(string usn, string psw)
        {
            if (usn == username && psw == password)
                return true;
            return false;
        }

        private void ptClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbQuenMatKhau_Click(object sender, EventArgs e)
        {
            FForgotPassword fForgotPassword = new FForgotPassword();
            fForgotPassword.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string usn = txbTaiKhoan.Text;
            string psw = txbMatKhau.Text;
            if (AccountDAO.Instance.isAccount(usn,psw))
            {
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
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
    }
}
