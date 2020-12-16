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
    public partial class UCNhapSach : UserControl
    {
        private static UCNhapSach instance;
        public static UCNhapSach Instance
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
        public UCNhapSach(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            HienTen();
            TaiDanhSachSach();
            TaiDanhSachTacGia();
            TaiDanhSachTheLoai();
            TaiDanhSachNXB();
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
        void TaiDanhSachSach()
        {
            DataTable data = SachDAO.Instance.LayDSSach();
            foreach(DataRow row in data.Rows)
            {
                string iteam = string.Concat(row["ID"].ToString().Trim(), " - ", row["Tên Sách"].ToString().Trim());
                cbSach.Items.Add(iteam);
            }    
        }
        void TaiDanhSachTacGia()
        {
            DataTable data = SachDAO.Instance.LayDSTacGia();
            foreach (DataRow row in data.Rows)
            {
                string iteam = string.Concat(row["Mã Tác Giả"].ToString().Trim(), " - ", row["Tên Tác Giả"].ToString().Trim());
                cbTacGia.Items.Add(iteam);
            }
        }
        void TaiDanhSachTheLoai()
        {
            DataTable data = SachDAO.Instance.LayDSTheLoai();
            foreach (DataRow row in data.Rows)
            {
                string iteam = string.Concat(row["Mã Thể Loại"].ToString().Trim(), " - ", row["Tên Thể Loại"].ToString().Trim());
                cbTheLoai.Items.Add(iteam);
            }
        }

        void TaiDanhSachNXB()
        {
            DataTable data = SachDAO.Instance.LayDSNXB();
            foreach (DataRow row in data.Rows)
            {
                string iteam = string.Concat(row["Mã NXB"].ToString().Trim(), " - ", row["Tên NXB"].ToString().Trim());
                cbNXB.Items.Add(iteam);
            }
        }

        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnThemDC_Click(object sender, EventArgs e)
        {
            string[] str = cbSach.SelectedItem.ToString().Split('-');
            string masach = str[0].Trim();
            int soluong;
            if(int.TryParse(txbSoLuong.Text,out soluong))
            {
                SachDAO.Instance.ThemSLChoSach(masach,soluong);
                DuaThongDiep("Đã nhập thêm số lượng thành công cho sách đã chọn", 1);
            }
            else
            {
                DuaThongDiep("Bạn vui lòng nhập lại số lượng!", 2);
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            
            if (txbTen.Text == "")
            {
                DuaThongDiep("Bạn vui lòng nhập vào tên sách", 2);
            }
            else
            {
                string[] strtg = cbTacGia.SelectedItem.ToString().Split('-');
                string matg = strtg[0].Trim();
                string[] strtl = cbTheLoai.SelectedItem.ToString().Split('-');
                string matl = strtl[0].Trim();
                string[] strnxb = cbNXB.SelectedItem.ToString().Split('-');
                string mannxb = strnxb[0].Trim();
                int soluong;
                int giatien;
                if (int.TryParse(txbSoLuongS.Text, out soluong))
                {
                    if (int.TryParse(txbGiaTien.Text, out giatien))
                    {
                        SachDAO.Instance.ThemSach(txbTen.Text, matl, matg, mannxb, soluong, giatien);
                        DuaThongDiep("Đã thêm sách thành công!", 1);
                    }
                    else
                    {
                        DuaThongDiep("Bạn vui lòng nhập lại gia tien!", 2);
                    }
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số lượng!", 2);
                }
            }          
        }
        List<string> dsMaSach = new List<string>();
        List<string> dsMaPN = new List<string>();
        void LamMoiDSMaSach()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Sach");
            dsMaSach.Clear();
            foreach (DataRow row in data.Rows)
            {
                string iteam = row["MaSach"].ToString().Trim();
                dsMaSach.Add(iteam);
            }
        }
        void LamMoiDSMaPN()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM PhieuNhap");
            dsMaPN.Clear();
            foreach (DataRow row in data.Rows)
            {
                string iteam = row["SoPN"].ToString().Trim();
                dsMaPN.Add(iteam);
            }
        }
    }
}
