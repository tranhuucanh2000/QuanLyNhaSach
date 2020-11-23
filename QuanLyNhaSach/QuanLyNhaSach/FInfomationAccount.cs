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

        private event EventHandler<TaiKhoanSuKien> capNhatTaiKhoanEvent;
        public event EventHandler<TaiKhoanSuKien> CapNhatTaiKhoanEvent
        {
            add { capNhatTaiKhoanEvent += value; }
            remove { capNhatTaiKhoanEvent -= value; }
        }

        void CapNhatTaiKhoan()
        {
            string tenDN = txbTenDN.Text;
            string tenHT = txbTenHT.Text;
            string matKhau = txbMatKhau.Text;
            string matKhauMoi = txbMatKhauMoi.Text;
            string laiMKM = txbNhapLaiMKM.Text;
            if(!matKhauMoi.Equals(laiMKM))
            {
                MessageBox.Show("Mật khẩu với và xác nhận mật khẩu mới không trùng nhau!");
            }
            else
            {
                if (AccountDAO.Instance.CapNhatTaiKhoan(tenDN, tenHT, matKhau, matKhauMoi))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    if(capNhatTaiKhoanEvent!=null)
                    {
                        capNhatTaiKhoanEvent(this, new TaiKhoanSuKien(AccountDAO.Instance.LayTaiKhoanTuTenDN(tenDN)));
                    }   
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu!");
                }    
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CapNhatTaiKhoan();
        }
    }
    public class TaiKhoanSuKien:EventArgs
    {
        private Account acc;

        public Account Acc 
        {   get => acc; 
            set => acc = value; 
        }
        public TaiKhoanSuKien(Account account)
        {
            this.Acc = account;
        }
    }
}
