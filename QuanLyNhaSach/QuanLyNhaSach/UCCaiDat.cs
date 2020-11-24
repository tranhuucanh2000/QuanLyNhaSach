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

        private Account loginAccount;
        public Account LoginAccount 
        { 
            get => loginAccount; 
            set => loginAccount = value; 
        }

        void KetNoiTaiKhoan()
        {
            dtgCaiDatTaiKhoan.DataSource = AccountDAO.Instance.CaiDatTaiKhoan();
        }    
        public UCCaiDat(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            KetNoiTaiKhoan();
            HienTen();
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

    }
}
