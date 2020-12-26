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
    public partial class UCCaiDat : UserControl
    {
        private static UCCaiDat instance;
        public static UCCaiDat Instance 
        { 
            get => instance; 
            set => instance = value; 
        }

        private TaiKhoan loginAccount;
        public TaiKhoan LoginAccount 
        { 
            get => loginAccount; 
            set => loginAccount = value; 
        }

        public UCCaiDat(TaiKhoan acc)
        {
            InitializeComponent();
            loginAccount = acc;
            LayDuLieuTaiKhoan();
            HienTen();
            cbTaiKhoan.Focus();
        }

        void LayDuLieuTaiKhoan()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT	* FROM TaiKhoan");
            foreach(DataRow item in data.Rows)
            {
                if(item["Loai"].ToString() == "0") cbTaiKhoan.Items.Add(item["TenDN"]);
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

        private void cbTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnMK.Visible = false;
            txbTenDN.ReadOnly = true;
            txbTenHT.ReadOnly = true;
            btnLuu.Text = "LƯU";
            TaiKhoan account = TaiKhoanDAO.Instance.LayTaiKhoanTuTenDN(cbTaiKhoan.SelectedItem.ToString());
            txbTenDN.Text = account.TenDN;
            txbTenHT.Text = account.Ten;
            txbMatKhau.Text = account.PassWord;
            ckbBanSach.Checked = (account.BanSach == 1);
            ckbKeSach.Checked = (account.KeSach == 1);
            ckbNhapSach.Checked = (account.NhapSach == 1);
            ckbTaiKhoan.Checked = (account.TtTaiKhoan == 1);
            ckbThemDL.Checked = (account.ThemDuLieu == 1);
            ckbThongKe.Checked = (account.ThongKe == 1);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnLuu.Text == "LƯU")
            {
                    int bansach = ckbBanSach.Checked == true ? 1 : 0;
                    int kesach = ckbKeSach.Checked == true ? 1 : 0;
                    int nhapsach = ckbNhapSach.Checked == true ? 1 : 0;
                    int tttaikhoan = ckbTaiKhoan.Checked == true ? 1 : 0;
                    int themdl = ckbThemDL.Checked == true ? 1 : 0;
                    int thongke = ckbThongKe.Checked == true ? 1 : 0;
                    TaiKhoanDAO.Instance.UpdateTaiKhoan(txbTenDN.Text , nhapsach, thongke, kesach, themdl, bansach, tttaikhoan);
                    DuaThongDiep(string.Concat("Đã lưu cài đặt cho tài khoản ", cbTaiKhoan.SelectedItem.ToString()), 1);
                    TaiKhoan account = TaiKhoanDAO.Instance.LayTaiKhoanTuTenDN(cbTaiKhoan.SelectedItem.ToString());
                    txbTenDN.Text = account.TenDN;
                    txbTenHT.Text = account.Ten;
                    txbMatKhau.Text = account.PassWord;
                    ckbBanSach.Checked = (account.BanSach == 1);
                    ckbKeSach.Checked = (account.KeSach == 1);
                    ckbNhapSach.Checked = (account.NhapSach == 1);
                    ckbTaiKhoan.Checked = (account.TtTaiKhoan == 1);
                    ckbThemDL.Checked = (account.ThemDuLieu == 1);
                    ckbThongKe.Checked = (account.ThongKe == 1);
            }
            else
            {
                if (txbMatKhau.Text == txbNhapLaiMKM.Text)
                {
                    int bansach = ckbBanSach.Checked == true ? 1 : 0;
                    int kesach = ckbKeSach.Checked == true ? 1 : 0;
                    int nhapsach = ckbNhapSach.Checked == true ? 1 : 0;
                    int tttaikhoan = ckbTaiKhoan.Checked == true ? 1 : 0;
                    int themdl = ckbThemDL.Checked == true ? 1 : 0;
                    int thongke = ckbThongKe.Checked == true ? 1 : 0;
                    string ma = txbMa.Text;
                    TaiKhoanDAO.Instance.ThemTaiKhoan(txbTenDN.Text, txbMatKhau.Text, txbTenHT.Text, nhapsach, thongke, kesach, themdl, bansach, tttaikhoan, ma);
                    DuaThongDiep("Đã thêm tài khoản thành công!", 1);
                    cbTaiKhoan.Items.Clear();
                    LayDuLieuTaiKhoan();
                    txbMatKhau.Text = txbNhapLaiMKM.Text = txbTenDN.Text = txbTenHT.Text = txbMa.Text = "";
                }
                else
                {
                    DuaThongDiep("Vui lòng nhập mật khẩu và xác nhận mật khẩu giống nhau!", 2);
                }

            }    
            
        }

        void TrangThaiNhap()
        {
            txbTenDN.Text = txbTenHT.Text = txbMatKhau.Text = txbNhapLaiMKM.Text = "";
            ckbBanSach.Checked = ckbTaiKhoan.Checked = ckbKeSach.Checked = true;
            ckbThemDL.Checked = ckbThongKe.Checked = ckbNhapSach.Checked = false;
            txbTenDN.Focus();
        }
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            btnLuu.Text = "Thêm Tài Khoản";
            txbTenDN.ReadOnly = false;
            txbTenHT.ReadOnly = false;
            pnMK.Visible = true;
            TrangThaiNhap();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa tài khoản này!", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                DataProvider.Instance.ExecuteQuery("USP_XoaTaiKhoan @tenDN", new object[] { cbTaiKhoan.SelectedItem.ToString() });
                DuaThongDiep("Bạn đã xóa thành công tài khoản", 1);
                cbTaiKhoan.Items.Clear();
                LayDuLieuTaiKhoan();
                TrangThaiNhap();
                cbTaiKhoan.Focus();
            }
        }

        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
