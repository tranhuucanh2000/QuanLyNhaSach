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

        private TaiKhoan loginAccount;
        public TaiKhoan LoginAccount
        {
            get => loginAccount;
            set => loginAccount = value;
        }
        public UCNhapSach(TaiKhoan acc)
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
            cbSach.Items.Clear();
            DataTable data = SachDAO.Instance.LayDSSach();
            foreach(DataRow row in data.Rows)
            {
                string iteam = string.Concat( row["TenSach"].ToString().Trim(), " - ", row["MaSach"].ToString().Trim());
                cbSach.Items.Add(iteam);
                cbSach.AutoCompleteCustomSource.Add(iteam);
            }    
        }
        void TaiDanhSachTacGia()
        {
            cbTacGia.Items.Clear();
            DataTable data = SachDAO.Instance.LayDSTacGia();
            foreach (DataRow row in data.Rows)
            {
                string iteam = string.Concat( row["Tên Tác Giả"].ToString().Trim(), " - ", row["Mã Tác Giả"].ToString().Trim());
                cbTacGia.Items.Add(iteam);
            }
        }
        void TaiDanhSachTheLoai()
        {
            cbTheLoai.Items.Clear();
            DataTable data = SachDAO.Instance.LayDSTheLoai();
            foreach (DataRow row in data.Rows)
            {
                string iteam = string.Concat(row["Tên Thể Loại"].ToString().Trim(), " - ", row["Mã Thể Loại"].ToString().Trim());
                cbTheLoai.Items.Add(iteam);
            }
        }

        void TaiDanhSachNXB()
        {
            cbNXB.Items.Clear();
            DataTable data = SachDAO.Instance.LayDSNXB();
            foreach (DataRow row in data.Rows)
            {
                string iteam = string.Concat(row["Tên NXB"].ToString().Trim(), " - ", row["Mã NXB"].ToString().Trim() );
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
            string masach = str[1].Trim();
            string tensach = str[0].Trim();
            string command = string.Concat("SELECT * FROM Sach WHERE MaSach = N'", masach, "'");
            DataTable data = DataProvider.Instance.ExecuteQuery(command);
            DataRow sach = data.Rows[0];
            string manxb = sach["MaNXB"].ToString();
            int giatien = int.Parse(sach["GiaTien"].ToString());
            int soluong;

            DataTable PN = DataProvider.Instance.ExecuteQuery("select * from PhieuNhap");
            int soLuongPN = PN.Rows.Count;
            DataRow pnCuoi;
            string maPN;
            int soPNC;
            if (soLuongPN > 0)
            {
                pnCuoi = PN.Rows[soLuongPN - 1];
                maPN = pnCuoi["SoPN"].ToString();
                soPNC = int.Parse(maPN.Substring(3).ToString());
            }
            else
            {
                soPNC = 0;
            }

            soPNC++;
            string mapn;
            if (soPNC < 9) mapn = string.Concat("PN00", soPNC);
            else if (soPNC < 100) mapn = string.Concat("PN0", soPNC);
            else mapn = string.Concat("PN", soPNC);

            if (int.TryParse(txbSoLuong.Text,out soluong))
            {
                if (soluong > 0)
                {
                    SachDAO.Instance.ThemSLChoSach(mapn, soluong, masach, giatien, manxb);
                    DuaThongDiep("Đã nhập thêm số lượng thành công cho sách đã chọn", 1);
                    cbSach.ResetText();
                    txbSoLuong.Text = "";
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập số lượng lớn hơn 0!", 2);
                    txbSoLuong.Focus();
                    txbSoLuong.SelectAll();
                }
            }
            else
            {
                DuaThongDiep("Bạn vui lòng nhập lại số lượng!", 2);
                txbSoLuong.Focus();
                txbSoLuong.SelectAll();
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            DataTable Sach = SachDAO.Instance.LayDSSach();
            int soMSC;
            int soPNC;
            int soLuongSach = Sach.Rows.Count;
            DataRow sachCuoi;
            string maSachCuoi;
            if (soLuongSach > 0)
            {
                sachCuoi = Sach.Rows[soLuongSach - 1];
                maSachCuoi = sachCuoi["MaSach"].ToString();
                soMSC = int.Parse(maSachCuoi.Substring(1).ToString());
            }
            else
            {
                soMSC = 0;
            }    

            DataTable PN = DataProvider.Instance.ExecuteQuery("select * from PhieuNhap");
            int soLuongPN = PN.Rows.Count;
            DataRow pnCuoi;
            string maPN;
            if (soLuongPN > 0)
            {
                pnCuoi = PN.Rows[soLuongPN - 1];
                maPN = pnCuoi["SoPN"].ToString();
                soPNC = int.Parse(maPN.Substring(3).ToString());
            }
            else
            {
                soPNC = 0;
            }

            if (txbTen.Text == "")
            {
                DuaThongDiep("Bạn vui lòng nhập vào tên sách", 2);
            }
            else
            {
                string[] strtg = cbTacGia.SelectedItem.ToString().Split('-');
                string matg = strtg[1].Trim();
                string[] strtl = cbTheLoai.SelectedItem.ToString().Split('-');
                string matl = strtl[1].Trim();
                string[] strnxb = cbNXB.SelectedItem.ToString().Split('-');
                string mannxb = strnxb[1].Trim();
                int soluong;
                int giatien;
                string masach;
                string mapn;
                soMSC++;
                soPNC++;
                if (soLuongSach < 9) masach = string.Concat("S00", soMSC);
                else if (soLuongSach < 100) masach = string.Concat("S0", soMSC);
                else masach = string.Concat("S", soMSC);

                if (soLuongPN < 9) mapn = string.Concat("PN00", soPNC);
                else if (soLuongPN < 100) mapn = string.Concat("PN0", soPNC);
                else mapn = string.Concat("PN", soPNC);

                if (int.TryParse(txbSoLuongS.Text, out soluong))
                {
                    if (soluong > 0)
                    {
                        if (int.TryParse(txbGiaTien.Text, out giatien))
                        {
                            if (giatien > 0)
                            {
                                SachDAO.Instance.ThemSach(mapn, masach, txbTen.Text, matl, matg, mannxb, soluong, giatien);
                                DuaThongDiep("Đã thêm sách thành công!", 1);
                                cbNXB.ResetText();
                                cbSach.ResetText();
                                cbTheLoai.ResetText();
                                cbTacGia.ResetText();
                                txbTen.Text = txbGiaTien.Text = txbSoLuongS.Text = "";
                            }
                            else
                            {
                                DuaThongDiep("Bạn vui lòng nhập giá tiền lớn hơn 0!", 2);
                                txbGiaTien.Focus();
                                txbGiaTien.SelectAll();
                            }
                        }
                        else
                        {
                            DuaThongDiep("Bạn vui lòng nhập lại giá tiền!", 2);
                            txbGiaTien.Focus();
                            txbGiaTien.SelectAll();
                        }
                    }
                    else
                    {
                        DuaThongDiep("Bạn vui lòng nhập số lượng lớn hơn 0!", 2);
                        txbGiaTien.Focus();
                        txbGiaTien.SelectAll();
                    }
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số lượng!", 2);
                    txbSoLuongS.Focus();
                    txbSoLuong.SelectAll();
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
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDanhSachSach();
            TaiDanhSachTacGia();
            TaiDanhSachTheLoai();
            TaiDanhSachNXB();
        }
        private void txbGiaTien_TextChanged(object sender, EventArgs e)
        {
        }

        private void ptbHoTro_Click(object sender, EventArgs e)
        {
            FThongTinPhanMem fThongTinPhanMem = new FThongTinPhanMem();
            fThongTinPhanMem.ShowDialog();
        }
    }
}
