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
    public partial class FSuaTenDangNhap : Form
    {
        private TaiKhoan TaiKhoanDN; 
        public FSuaTenDangNhap(TaiKhoan taikhoan)
        {
            InitializeComponent();
            TaiKhoanDN = taikhoan;
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (txbMatKhau.Text == TaiKhoanDN.PassWord)
            {
                DataProvider.Instance.ExecuteQuery("EXEC USP_CapNhatTenDNAdmin @tendncu , @tendnmoi , @mk", new object[] { TaiKhoanDN.TenDN, txbTenDN.Text, txbMatKhau.Text });
                MessageBox.Show("Bạn đã thay đổi tên đăng nhập thành công!");
                /*if (suaTenDN != null) */suaTenDN(sender, new SuaTenDN(TaiKhoanDAO.Instance.LayTaiKhoanTuTenDN(txbTenDN.Text)));
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai mật khẩu! Vui lòng nhập lại!");
            }
        }

        private void lbThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private event EventHandler<SuaTenDN> suaTenDN;
        public event EventHandler<SuaTenDN> SuaTenDN
        {
            add { suaTenDN += value; }
            remove { suaTenDN -= value; }
        }
    }

    public class SuaTenDN : EventArgs
    {
        private TaiKhoan taikhoan;

        public TaiKhoan Taikhoan { get => taikhoan; set => taikhoan = value; }

        public SuaTenDN(TaiKhoan tkhoan)
        {
            taikhoan = tkhoan;
        }
    }
}
