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
    public partial class UCTaiKhoan : UserControl
    {
        private static UCTaiKhoan instance;

        public static UCTaiKhoan Instance 
        { 
            get => instance; 
            set => instance = value; 
        }
        public Account LoginAccount 
        { 
            get => loginAccount; 
            set { loginAccount = value; HienTen(); }
        }

        private Account loginAccount;

        private event EventHandler<TaiKhoanSuKien> capNhatTaiKhoanEvent;
        public event EventHandler<TaiKhoanSuKien> CapNhatTaiKhoanEvent
        {
            add { capNhatTaiKhoanEvent += value; }
            remove { capNhatTaiKhoanEvent -= value; }
        }
        public UCTaiKhoan(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            HienTen();
            LayThongTinTaiKhoan(loginAccount);
        }

        public void HienTen()
        {
            DuaThongDiep(string.Concat("Xin chào ", LoginAccount.Ten), 3);
        }
        public void DuaThongDiep(string str, int mucDo)
        {
            string ThongDiep = String.Concat("BỒ CÂU: \"", str, "\"");
            if (mucDo == 1) lbHoTro.ForeColor = Color.FromArgb(102, 255, 102);
            if (mucDo == 2) lbHoTro.ForeColor = Color.FromArgb(255, 255, 102);
            if (mucDo == 3) lbHoTro.ForeColor = Color.White;
            lbHoTro.Text = ThongDiep;
        }
        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        void LayThongTinTaiKhoan(Account acc)
        {
            txbTenDN.Text = acc.TenDN;
            txbTenHT.Text = acc.Ten;
            if (acc.Type == 1) lbChucVu.Text = "Quản Lý";
            else { lbChucVu.Text = "Nhân Viên"; }
        }

        void CapNhatTaiKhoan()
        {
            string tenDN = txbTenDN.Text;
            string tenHT = txbTenHT.Text;
            string matKhau = txbMatKhau.Text;
            string matKhauMoi = txbMatKhauMoi.Text;
            string laiMKM = txbNhapLaiMKM.Text;
            if (!matKhauMoi.Equals(laiMKM))
            {
                DuaThongDiep("Vui lòng nhập mật khẩu xác nhận trùng với mật khẩu mới!", 1);
            }
            else
            {
                if (TaiKhoanDAO.Instance.CapNhatTaiKhoan(tenDN, tenHT, matKhau, matKhauMoi))
                {
                    DuaThongDiep("Cập nhật thành công!", 2);
                    if (capNhatTaiKhoanEvent != null)
                    {
                        capNhatTaiKhoanEvent(this, new TaiKhoanSuKien(TaiKhoanDAO.Instance.LayTaiKhoanTuTenDN(tenDN)));
                    }
                }
                else
                {
                    DuaThongDiep("Vui lòng nhập lại mật khẩu!", 1);
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            CapNhatTaiKhoan();
            txbTenHT.Text = txbNhapLaiMKM.Text = txbMatKhauMoi.Text = txbMatKhau.Text = txbTenDN.Text = "";
        }
    }
    public class TaiKhoanSuKien : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get => acc;
            set => acc = value;
        }
        public TaiKhoanSuKien(Account account)
        {
            this.Acc = account;
        }
    }
}
