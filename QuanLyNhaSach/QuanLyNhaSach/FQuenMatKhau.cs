using QuanLyNhaSach.DAO;
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
    public partial class FQuenMatKhau : Form
    {
        public FQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT	* FROM TaiKhoan");
            foreach (DataRow item in data.Rows)
            {
                if (item["MaTK"].ToString() == txbMa.Text)
                {
                    pnNewPassword.Enabled = true;
                    pnMa.Enabled = false;
                    lbHoTro.Text = "Bạn đã nhập đúng mã!";
                    lbHoTro.TextAlign = ContentAlignment.MiddleCenter;
                    txbMatKhau.Focus();

                }
                lbHoTro.Text = "Bạn không có mã. Hãy liên hệ chúng tôi!";
                lbHoTro.ForeColor = Color.Red;
            }
            
        }


        private void btnXNMK_Click(object sender, EventArgs e)
        {
            if (txbXacNhanMK.Text == txbMatKhau.Text && txbXacNhanMK.Text.Length > 4)
            {
                SachDAO.Instance.QuenMatKhau(txbMatKhau.Text, txbMa.Text);
                this.Close();
            }
            else
            {
                lbHoTro.Text = "Bạn nhập mật khẩu không giống nhau kìa! Nhập lại đi nào!";
                txbXacNhanMK.Text = txbMatKhau.Text = "";
                txbMatKhau.Focus();
            }


        }
    }
}
