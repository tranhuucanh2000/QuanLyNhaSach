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
            btnXoa.Visible = true;
            pnMK.Visible = false;
            txbTenDN.ReadOnly = true;
            txbTenHT.ReadOnly = true;
            btnLuu.Visible = true;
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
                if (txbMa.Text != "" && txbMatKhau.Text != "" && txbNhapLaiMKM.Text != "" && txbTenHT.Text!="" && txbTenDN.Text!="")
                {
                    int bansach = ckbBanSach.Checked == true ? 1 : 0;
                    int kesach = ckbKeSach.Checked == true ? 1 : 0;
                    int nhapsach = ckbNhapSach.Checked == true ? 1 : 0;
                    int tttaikhoan = ckbTaiKhoan.Checked == true ? 1 : 0;
                    int themdl = ckbThemDL.Checked == true ? 1 : 0;
                    int thongke = ckbThongKe.Checked == true ? 1 : 0;
                    string ma = txbMa.Text;
                    bool trungtendn=false;
                    DataTable data = DataProvider.Instance.ExecuteQuery("select * from TaiKhoan");
                    foreach(DataRow row in data.Rows)
                    {
                        if (txbTenDN.Text == row["TenDN"].ToString()) trungtendn = true;
                    }
                    if (trungtendn == true)
                    {
                        DuaThongDiep("Trùng tên đăng nhập!",2);
                        txbTenDN.Focus();
                        txbTenDN.SelectAll();
                    }
                    else if (txbMatKhau.Text != txbNhapLaiMKM.Text) DuaThongDiep("Bạn vui lòng nhập đúng xác nhận mật khẩu!", 2);
                    else
                    {
                        TaiKhoanDAO.Instance.ThemTaiKhoan(txbTenDN.Text, txbMatKhau.Text, txbTenHT.Text, nhapsach, thongke, kesach, themdl, bansach, tttaikhoan, ma);
                        DuaThongDiep("Đã thêm tài khoản thành công!", 1);
                        pnMK.Visible = false;
                        btnLuu.Visible = false;
                        cbTaiKhoan.Items.Clear();
                        LayDuLieuTaiKhoan();
                        txbMatKhau.Text = txbNhapLaiMKM.Text = txbTenDN.Text = txbTenHT.Text = txbMa.Text = "";
                    }                     
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập đủ thông tin!", 2);
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
            cbTaiKhoan.Text = "";
            txbTenDN.ReadOnly = false;
            txbTenHT.ReadOnly = false;
            btnXoa.Visible = false;
            pnMK.Visible = true;
            btnLuu.Visible = true;
            TrangThaiNhap();

        }

        private void FInfomation_CapNhatTaiKhoanEvent(object sender, TaiKhoanSuKien e)
        {
            DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbTaiKhoan.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa tài khoản này!", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DataProvider.Instance.ExecuteQuery("USP_XoaTaiKhoan @tenDN", new object[] { cbTaiKhoan.SelectedItem.ToString() });
                    DuaThongDiep("Bạn đã xóa thành công tài khoản", 1);
                    cbTaiKhoan.Items.Clear();
                    cbTaiKhoan.Text = "";
                    LayDuLieuTaiKhoan();
                    TrangThaiNhap();
                    cbTaiKhoan.Focus();
                    pnMK.Visible = false;
                    btnLuu.Visible = false;
                    btnXoa.Visible = false;
                }
            }
        }

        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ptbHoTro_Click(object sender, EventArgs e)
        {
            FThongTinPhanMem fThongTinPhanMem = new FThongTinPhanMem();
            fThongTinPhanMem.ShowDialog();
        }
    }
}
