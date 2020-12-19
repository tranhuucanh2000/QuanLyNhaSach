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
    public partial class UCThemDuLieu : UserControl
    {
        private static UCThemDuLieu instance;
        public static UCThemDuLieu Instance
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
        public UCThemDuLieu(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            HienTen();
        }
        void LamMoiTxb()
        {
           txbSo.Text = txbTen.Text =txbDC.Text= "";
        }

        void KetNoiKhoTacGia()
        {
            DataTable data = SachDAO.Instance.LayDSTacGia();
            dtgSach.DataSource = data;
            dtgSach.Columns[0].FillWeight = 90;
        }
        void KetNoiKhoTheLoai()
        {
            DataTable data = SachDAO.Instance.LayDSTheLoai();
            dtgSach.DataSource = data;
            dtgSach.Columns[0].FillWeight = 90;
        }
        void KetNoiKhoNXB()
        {
            DataTable data = SachDAO.Instance.LayDSNXB();
            dtgSach.DataSource = data;
            dtgSach.Columns[0].FillWeight = 90;
        }
        void HienThiTTTacGia()
        {
            lbTen.Text = "Tên Tác Giả:";
            lbSo.Text = "Số Điện Thoại:";
            panelTG.Visible = true;
            panelTL.Visible = false;
            txbSo.Visible = true;

        }
        void HienThiTTTheLoai()
        {
            lbTen.Text = "Tên Thể Loại:";
            panelTG.Visible = txbSo.Visible=txbDC.Visible=false;
            panelTL.Visible = true;
        }
        void HienThiNXB()
        {
            txbSo.Visible = lbSo.Visible = lbDC.Visible = txbDC.Visible = true;
            lbTen.Text = "Tên NXB:";
            lbSo.Text = "Số Điện Thoại:";
            lbDC.Text = "Địa Chỉ:";
            panelTG.Visible = panelTL.Visible = false;

        }
        public void HienTen()
        {
            DuaThongDiep(string.Concat("Xin chào ", LoginAccount.Ten), 3);
        }
        private void dtgSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cbThuocTinh.SelectedItem.ToString() == "Tác Giả")
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbTen.Text = row.Cells[1].Value.ToString();
                txbSo.Text = row.Cells[2].Value.ToString();
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Thể Loại")
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbTen.Text = row.Cells[1].Value.ToString();
            }
            else
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbTen.Text = row.Cells[1].Value.ToString();
                txbSo.Text = row.Cells[3].Value.ToString();
                txbDC.Text = row.Cells[2].Value.ToString();
            }
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
    

        private void cbThuocTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbThuocTinh.SelectedItem.ToString() == "Tác Giả")
            {
                dtgSach.DataSource = null;
                dtgSach.DataSource = SachDAO.Instance.LayDSTacGia();
                HienThiTTTacGia();
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Thể Loại")
            {
                dtgSach.DataSource = null;
                dtgSach.DataSource = SachDAO.Instance.LayDSTheLoai();
                HienThiTTTheLoai();
            }
            else
            {
                dtgSach.DataSource = null;
                dtgSach.DataSource = SachDAO.Instance.LayDSNXB();
                HienThiNXB();
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txbTen.Text;
            string diachi = txbDC.Text;
            string sdt = txbSo.Text;

            if (cbThuocTinh.SelectedItem.ToString() == "Tác Giả")
            {
                int sodt;
                if (int.TryParse(txbSo.Text, out sodt))
                {
                    SachDAO.Instance.ThemTacGia(ten, sdt);
                    DuaThongDiep("Đã thêm tác giả thành công!", 1);
                    LamMoiDSMaTacGia();
                    LamMoiTxb();
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số điện thoại!", 2);
                }
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Thể Loại")
            {
                SachDAO.Instance.ThemTheLoai(ten);
                DuaThongDiep("Đã thêm thể loại thành công!", 1);
                LamMoiDSMaTheLoai();
                LamMoiTxb();
            }
            else
            {
                int sodt;
                if (int.TryParse(txbSo.Text, out sodt))
                {
                    SachDAO.Instance.ThemNhaXuatBan(ten, diachi, sdt);

                    DuaThongDiep("Đã thêm nhà xuất bản thành công!", 1);
                    LamMoiDSMaNXB();
                    LamMoiTxb();
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số điện thoại!", 2);
                }
            }
        }
        List<string> dsMatg = new List<string>();
        List<string> dsMaTL = new List<string>();
        List<string> dsMaNXB = new List<string>();
        void LamMoiDSMaTacGia()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TacGia");
            dsMatg.Clear();
            foreach (DataRow row in data.Rows)
            {
                string iteam = row["MaTG"].ToString().Trim();
                dsMatg.Add(iteam);
            }
        }
        void LamMoiDSMaTheLoai()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TheLoai");
            dsMaTL.Clear();
            foreach (DataRow row in data.Rows)
            {
                string iteam = row["MaTL"].ToString().Trim();
                dsMaTL.Add(iteam);
            }
        }
        void LamMoiDSMaNXB()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM NhaXuatBan");
            dsMaNXB.Clear();
            foreach (DataRow row in data.Rows)
            {
                string iteam = row["MaNXB"].ToString().Trim();
                dsMaNXB.Add(iteam);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cbThuocTinh.SelectedItem.ToString() == "Tác Giả")
            {
                int sodt;
                if (int.TryParse(txbSo.Text, out sodt))
                {
                    DataTable TacGia = SachDAO.Instance.LayDSTacGia();
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                string matacgia = row.Cells[0].Value.ToString();
                SachDAO.Instance.SuaTacGia(txbTen.Text, txbSo.Text, matacgia);
                DuaThongDiep("Đã sửa tác giả thành công!", 1);
                LamMoiTxb();
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số điện thoại!", 2);
                }
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Thể Loại")
            {
                DataTable TheLoai = SachDAO.Instance.LayDSTheLoai();
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                string matheloai = row.Cells[0].Value.ToString();
                SachDAO.Instance.SuaTheLoai(txbTen.Text, matheloai);
                DuaThongDiep("Đã sửa thể loại thành công!", 1);
                LamMoiTxb();
            }
            else
            {
                int sodt;
                if (int.TryParse(txbSo.Text, out sodt))
                {
                    DataTable TheLoai = SachDAO.Instance.LayDSNXB();
                    int vitri = dtgSach.CurrentRow.Index;
                    DataGridViewRow row = dtgSach.Rows[vitri];
                    string manxb = row.Cells[0].Value.ToString();
                    SachDAO.Instance.SuaNhaXuatBan(txbTen.Text, txbSo.Text, txbDC.Text, manxb);
                    DuaThongDiep("Đã sửa nhà xuất bản thành công!", 1);
                    LamMoiTxb();
                }
                else
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số điện thoại!", 2);
                }
            }
            
        }

    }

}
