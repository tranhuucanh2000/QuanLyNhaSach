﻿using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhaSach.DAO;
using QuanLyNhaSach.DTO;

namespace QuanLyNhaSach
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void ptClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbQuenMatKhau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BẠN HÃY LIÊN HỆ VỚI QUẢN LÝ ĐỂ LẤY LẠI MẬT KHẨU", "QUÊN MẬT KHẨU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string usn = txbTaiKhoan.Text;
            string psw = txbMatKhau.Text;
            if (AccountDAO.Instance.isAccount(usn,psw))
            {
                Account account = AccountDAO.Instance.LayTaiKhoanTuTenDN(usn);
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
    }
}
