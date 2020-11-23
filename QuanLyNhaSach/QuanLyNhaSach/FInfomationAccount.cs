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
    public partial class FInfomationAccount : Form
    {

        public FInfomationAccount(Account account)
        {
            InitializeComponent();
            LayThongTinTaiKhoan(account);
        }
        void LayThongTinTaiKhoan(Account acc)
        {
            txbTenDN.Text = acc.TenDN;
            txbTenHT.Text = acc.Ten;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
