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
        private TaiKhoan loginAccount;
        public TaiKhoan LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
            }
        }

        public FChinh(TaiKhoan acc)
        {
            InitializeComponent();
            loginAccount = acc;
            this.ShowInTaskbar = false;
            QuyenTruyCap();
            TaiUCTrang();
            TrangThaiBanDau();
        }

        void QuyenTruyCap()
        {
            if (loginAccount.Type == 0) btnCaiDat.Visible = false;
            if (loginAccount.ThongKe == 0) btnThongKe.Visible = false;
            if (loginAccount.NhapSach == 0) btnNhapSach.Visible = false;
            if (loginAccount.ThemDuLieu == 0) btnThemDL.Visible = false;
            if (loginAccount.KeSach == 0) btnKeSach.Visible = false;
            if (loginAccount.TtTaiKhoan == 0) btnTaiKhoan.Visible = false;
            if (loginAccount.BanSach == 0) btnBanSach.Visible = false;
        }
        void TaiUCTrang()
        {
            UCBanSach.Instance = new UCBanSach(LoginAccount);
            UCTaiKhoan.Instance = new UCTaiKhoan(LoginAccount);
            UCCaiDat.Instance = new UCCaiDat(LoginAccount);
            UCKeSach.Instance = new UCKeSach(LoginAccount);
            UCNhapSach.Instance = new UCNhapSach(LoginAccount);
            UCThemDuLieu.Instance = new UCThemDuLieu(LoginAccount);
            UCThongKe.Instance = new UCThongKe(LoginAccount);

            pnChinh.Controls.Add(UCBanSach.Instance);
            pnChinh.Controls.Add(UCCaiDat.Instance);
            pnChinh.Controls.Add(UCTaiKhoan.Instance);
            pnChinh.Controls.Add(UCKeSach.Instance);
            pnChinh.Controls.Add(UCNhapSach.Instance);
            pnChinh.Controls.Add(UCThemDuLieu.Instance);
            pnChinh.Controls.Add(UCThongKe.Instance);

            UCTaiKhoan.Instance.CapNhatTaiKhoanEvent += Instance_CapNhatTaiKhoanEvent;
        }

        private void Instance_CapNhatTaiKhoanEvent(object sender, TaiKhoanSuKien e)
        {
            UCBanSach.Instance.DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
            UCTaiKhoan.Instance.DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
            UCCaiDat.Instance.DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
            UCKeSach.Instance.DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
            UCNhapSach.Instance.DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
            UCThemDuLieu.Instance.DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
            UCThongKe.Instance.DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
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
            //if (UCBanSach.Instance == null) UCBanSach.Instance = new UCBanSach(LoginAccount);
            //if (!pnChinh.Controls.Contains(UCBanSach.Instance))
            //{
            //    pnChinh.Controls.Add(UCBanSach.Instance);
            //    UCBanSach.Instance.Dock = DockStyle.Fill;
            //    UCBanSach.Instance.BringToFront();
            //}
            //else
            //{
            //    UCBanSach.Instance.BringToFront();
            //}
            UCBanSach.Instance.BringToFront();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Event click btnTaiKhoan
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnTaiKhoan);
            UCTaiKhoan.Instance.BringToFront();
        }

        //Event click btnThongKe
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnThongKe);
            UCThongKe.Instance.BringToFront();
        }

        //Event click btnNhapSach
        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnNhapSach);
            UCNhapSach.Instance.BringToFront();
        }

        //Event click btnKeSach
        private void btnKeSach_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnKeSach);
            UCKeSach.Instance.BringToFront();
        }

        //Event click btnThemDL
        private void btnThemDL_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnThemDL);
            UCThemDuLieu.Instance.BringToFront();
        }

        //Event click btnCaiDat
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            ChuyenTrang(btnCaiDat);
            UCCaiDat.Instance.BringToFront();
        }


    }
}
