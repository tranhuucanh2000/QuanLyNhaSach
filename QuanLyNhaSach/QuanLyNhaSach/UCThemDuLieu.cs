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
            txbMa.Text = txbSo.Text = txbTen.Text =txbDC.Text= "";
        }
       
        
        void HienThiTTTacGia()
        {

            lbTen.Text = "Tên Tác Giả:";
            lbMa.Text = "Mã Tác Giả:";
            lbSo.Text = "Số Điện Thoại:";
            panelTG.Visible = true;
            panelTL.Visible = false;
            txbSo.Visible = true;

        }
        void HienThiTTTheLoai()
        {
            lbTen.Text = "Tên Thể Loại:";
            lbMa.Text = "Mã Thể Loại";
            panelTG.Visible = txbSo.Visible=txbDC.Visible=false;
            panelTL.Visible = true;
        }
        void HienThiNXB()
        {
            txbSo.Visible = lbSo.Visible = lbDC.Visible = txbDC.Visible = true;
            lbTen.Text = "Tên NXB:";
            lbMa.Text = "Mã NXB:";
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
                txbMa.Text = row.Cells[0].Value.ToString();
                txbTen.Text = row.Cells[1].Value.ToString();
                txbSo.Text = row.Cells[2].Value.ToString();
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Thể Loại")
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbMa.Text = row.Cells[0].Value.ToString();
                txbTen.Text = row.Cells[1].Value.ToString();
            }
            else
            {
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                txbMa.Text = row.Cells[0].Value.ToString();
                txbTen.Text = row.Cells[1].Value.ToString();
                txbSo.Text = row.Cells[3].Value.ToString();

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
            string ma = txbMa.Text;
            string diachi = txbDC.Text;
            string sdt = txbSo.Text;

            if (panelTG.Visible == true&&panelTL.Visible==false)
            {
                SachDAO.Instance.ThemTacGia(ten,ma,sdt);
                DuaThongDiep("Đã thêm tác giả thành công!", 1);
                LamMoiDSMaTacGia();

            }
            else if (panelTL.Visible == true&&panelTG.Visible==false)
            {
                SachDAO.Instance.ThemTheLoai(ten,ma);
                DuaThongDiep("Đã thêm thể loại thành công!", 1);
                LamMoiDSMaTheLoai();
            }
            else
            {
                SachDAO.Instance.ThemNXB(ten,ma,diachi,sdt);
                DuaThongDiep("Đã thêm nhà xuất bản thành công!", 1);
                LamMoiDSMaNXB();
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

    }

}
