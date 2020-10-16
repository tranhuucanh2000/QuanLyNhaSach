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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isTrueAccount(string usn, string psw)
        {
            return true;
        }

        private void ptClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbForgotPass_Click(object sender, EventArgs e)
        {
            FForgotPassword fForgotPassword = new FForgotPassword();
            fForgotPassword.ShowDialog();
        }
    }
}
