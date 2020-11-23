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
    public partial class FChinh : Form
    {
        private Account loginAccount;

        public Account LoginAccount 
        { 
            get => loginAccount;
            set 
            {
                loginAccount = value;
            }
        }

        public FChinh(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            TrangThaiBanDau();
        }

        void ChuyenTrang(Button btn)
        {
            pnTrang.Top = btn.Top;
            pnTrang.Height = btn.Height;
        }
        void TrangThaiBanDau()
        {
            btnBanSach_Click(this, new EventArgs());
        }
        private void btnBanSach_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnBanSach);
            if (UCBanSach.Instance == null) UCBanSach.Instance = new UCBanSach(LoginAccount);
            if (!pnChinh.Controls.Contains(UCBanSach.Instance))
            {
                pnChinh.Controls.Add(UCBanSach.Instance);
                UCBanSach.Instance.Dock = DockStyle.Fill;
                UCBanSach.Instance.BringToFront();
            }
            else
            {
                UCBanSach.Instance.BringToFront();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Event click btnTaiKhoan
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnTaiKhoan);
        }

        //Event click btnThongKe
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnThongKe);
        }

        //Event click btnNhapSach
        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnNhapSach);
        }

        //Event click btnKeSach
        private void btnKeSach_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnKeSach);
        }

        //Event click btnThemDL
        private void btnThemDL_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnThemDL);
        }

        //Event click btnCaiDat
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnCaiDat);
        }
    }
}
