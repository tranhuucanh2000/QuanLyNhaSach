using QuanLyNhaSach.DAO;
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
            LayTaiKhoan();
        }

        bool isAdmin()
        {
            //Xử lý xem có phải admin hay không
            return true;
        }
        private void pctCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ptClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void LayTaiKhoan()
        {
            dtgTaiKhoan.DataSource= DataProvider.Instance.ExecuteQuery("SELECT TenDangNhap as [Tên Đăng Nhập], Ten as [Tên], MatKhau as [Mật Khẩu] FROM dbo.TaiKhoan");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
