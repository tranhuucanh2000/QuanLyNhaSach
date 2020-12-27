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
        public TaiKhoan LoginAccount 
        { 
            get => loginAccount; 
            set { loginAccount = value; HienTen(); }
        }

        private TaiKhoan loginAccount;

        private event EventHandler<TaiKhoanSuKien> capNhatTaiKhoanEvent;
        public event EventHandler<TaiKhoanSuKien> CapNhatTaiKhoanEvent
        {
            add { capNhatTaiKhoanEvent += value; }
            remove { capNhatTaiKhoanEvent -= value; }
        }
        public UCTaiKhoan(TaiKhoan acc)
        {
            InitializeComponent();
            loginAccount = acc;
            HienTen();
            HienThiSuaTenDN();
            LayThongTinTaiKhoan(loginAccount);

        }
        void HienThiSuaTenDN()
        {
            if (loginAccount.Type == 1)
            {
                btnSuaTenDN.Visible = true;
            }
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

        void LayThongTinTaiKhoan(TaiKhoan acc)
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
                    MessageBox.Show("Cập nhật thành công");
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
        void CapNhatMaTaiKhoan()
        {
            string tenDN = txbTenDN.Text;
            
            string ma = txbMatKhau.Text;
            string maMoi = txbMatKhauMoi.Text;
            string laiMM = txbNhapLaiMKM.Text;
            if (!maMoi.Equals(laiMM))
            {
                DuaThongDiep("Vui lòng nhập mã xác nhận trùng với mã mới!", 1);
            }
            else
            {
                if (TaiKhoanDAO.Instance.CapNhatMaTaiKhoan(tenDN, ma, maMoi))
                {
                    DuaThongDiep("Cập nhật thành công!", 2);
                    MessageBox.Show("Cập nhật thành công");
                    if (capNhatTaiKhoanEvent != null)
                    {
                        capNhatTaiKhoanEvent(this, new TaiKhoanSuKien(TaiKhoanDAO.Instance.LayTaiKhoanTuTenDN(tenDN)));
                        btnSua.Text = "Sửa Mật Khẩu";
                    }
                }
                else
                {
                    DuaThongDiep("Vui lòng nhập lại mã!", 1);
                    txbMatKhau.Focus();
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (btnSua.Text == "Sửa Mật Khẩu")
            {
                CapNhatMaTaiKhoan();
                txbNhapLaiMKM.Text = txbMatKhauMoi.Text = txbMatKhau.Text = "";

            }
            else
            {
                CapNhatTaiKhoan();
                txbNhapLaiMKM.Text = txbMatKhauMoi.Text = txbMatKhau.Text = "";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa Mã")
            {
                txbTenHT.ReadOnly= txbTenDN.ReadOnly =  true;
                lbMK.Text = "Mã:";
                lbMKM.Text = "Mã Mới:";
                lbNL.Text = "Nhập Lại Mã:";
                btnSua.Text = "Sửa Mật Khẩu";
                txbMatKhau.Focus();
            }
            else
            {
                txbTenHT.ReadOnly = false;
                txbMatKhauMoi.Text = txbNhapLaiMKM.Text = "";
                lbMKM.Text = "Mật Khẩu Mới:";
                lbNL.Text = "Nhập Lại:";
                lbMK.Text = "Mật Khẩu:";
                btnSua.Text = "Sửa Mã";
            }
        }

        private void btnSuaTenDN_Click(object sender, EventArgs e)
        {
            FSuaTenDangNhap fSuaTenDangNhap = new FSuaTenDangNhap(loginAccount);
            fSuaTenDangNhap.SuaTenDN += FSuaTenDangNhap_SuaTenDN;
            fSuaTenDangNhap.ShowDialog();
        }

        private void FSuaTenDangNhap_SuaTenDN(object sender, SuaTenDN e)
        {
            LayThongTinTaiKhoan(e.Taikhoan);
        }

        private void ptbHoTro_Click(object sender, EventArgs e)
        {
            FThongTinPhanMem fThongTinPhanMem = new FThongTinPhanMem();
            fThongTinPhanMem.ShowDialog();
        }
    }
    public class TaiKhoanSuKien : EventArgs
    {
        private TaiKhoan acc;

        public TaiKhoan Acc
        {
            get => acc;
            set => acc = value;
        }
        public TaiKhoanSuKien(TaiKhoan account)
        {
            this.Acc = account;
        }
    }
}
