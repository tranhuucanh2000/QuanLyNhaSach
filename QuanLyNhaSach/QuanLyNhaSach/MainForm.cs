using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pctCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void LayTaiKhoan()
        {
            SqlConnection sqlConnection = new SqlConnection();
        }
        private void ptClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
