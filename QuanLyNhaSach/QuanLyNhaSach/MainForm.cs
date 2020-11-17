using QuanLyNhaSach.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            InitializeComponent();
            KetNoiKhoSach();
        }
        #region Methods
        void KetNoiKhoSach()
        {
            DataTable data = SachDAO.Instance.LayDSSach();
            dtgSach.DataSource = data;
        }
        bool isAdmin()
        {
            //Xử lý xem có phải admin hay không
            return true;
        }
        //Để xuất thông báo
        void DuaThongDiep(string str)
        {
            string ThongDiep = String.Concat("BỒ CÂU: \"", str, "\"");
            lbHoTro.Text = ThongDiep;
        }
        void LamMoiTongTien()
        {
            int tongtien = 0;
            if(dtgThanhToan.Rows.Count>1)
            {
                foreach (DataGridViewRow row in dtgThanhToan.Rows)
                {
                    if (row.Index < dtgThanhToan.Rows.Count - 1)
                    {
                        int tien = 0;
                        tien = int.Parse(row.Cells[3].Value.ToString());
                        tongtien += tien;
                    }
                }
            }
            txbThanhTien.Text = tongtien.ToString();
        }
        #endregion
        #region Events
        private void pctCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ptClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Sự kiện click vào dtgSach
        private void dtgSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSach.SelectedCells.Count > 0)
            {
                DataGridViewRow row = dtgSach.Rows[dtgSach.CurrentCell.RowIndex];
                txbTenSach.Text = row.Cells[0].Value.ToString();
                txbGiaTien.Text = row.Cells[5].Value.ToString();
            }
        }
        //void ThemDuLieuVaoCSDL(string tensach,string tacgia,string theloai, string nxb, int soluong,int giatien)
        //{
        //    string query = String.Concat("INSERT INTO dbo.Sach",@"(TheLoai, TenSach, TacGia, NhaXuatBan, SoLuong, GiaTien) VALUES (N'",theloai, @"', N'", tensach, @"', N'", tacgia, @"', N'", nxb, @"', N'", soluong, @"', N'", giatien, "')");
        //    DataProvider.Instance.ExecuteNonQuery(query);
        //}       
        //void TroVeTrangThaiNhap()
        //{
        //    txbLoaiSach.Text = ""; 
        //    txbTenSach.Text = ""; 
        //    txbTacGia.Text = ""; 
        //    txbNXB.Text = ""; 
        //    txbSoLuong.Text = ""; 
        //    txbGiaTien.Text = "";
        //    txbLoaiSach.Focus();
        //}
        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    if (txbLoaiSach.Text != "" && txbTenSach.Text != "" && txbTacGia.Text != "" && txbNXB.Text != "" && txbSoLuong.Text != "" && txbGiaTien.Text != "")
        //    {
        //        try
        //        {
        //            int soLuong = int.Parse(txbSoLuong.Text);
        //            try
        //            {
        //                int giaTien = int.Parse(txbGiaTien.Text);
        //                ThemDuLieuVaoCSDL(txbTenSach.Text.ToString(), txbTacGia.Text.ToString(), txbLoaiSach.Text.ToString(), txbNXB.Text.ToString(), int.Parse(txbSoLuong.Text.ToString()), int.Parse(txbGiaTien.Text.ToString()));
        //                DuaThongDiep("Bạn đã thêm thành công!");
        //                dtgSach.Refresh();
        //                KetNoiKhoSach();
        //                TroVeTrangThaiNhap();
        //            }
        //            catch (FormatException)
        //            {
        //                DuaThongDiep("Bạn đã nhập sai dữ liệu giá tiền!");
        //                lbHoTro.ForeColor = Color.Red;
        //            }
        //        }
        //        catch (FormatException)
        //        {
        //            DuaThongDiep("Bạn đã nhập sai dữ liệu số lượng!");
        //            lbHoTro.ForeColor = Color.Red;
        //        }
        //    }
        //    else
        //    {
        //        DuaThongDiep("Bạn nhập thiếu thông tin");
        //    }
        //}
        //void LamMoi()
        //{
        //    DataProvider.Instance.ExecuteNonQuery("delete from dbo.Sach");
        //    ThemDuLieuTuDtgSangCSDL();
        //}
        //void ThemDuLieuTuDtgSangCSDL()
        //{
        //    int n = dtgSach.RowCount;
        //    for (int i = 0; i < n - 1;i++)
        //    {
        //        ThemDuLieuVaoCSDL(dtgSach[0, i].Value.ToString(), dtgSach[1, i].Value.ToString(),  dtgSach[3, i].Value.ToString(), dtgSach[2, i].Value.ToString(), int.Parse(dtgSach[4, i].Value.ToString()), int.Parse(dtgSach[5, i].Value.ToString()));
        //    }    
        //}
        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    int viTri = dtgSach.CurrentCell.RowIndex;
        //    dtgSach[0, viTri].Value = txbTenSach.Text;
        //    dtgSach[1, viTri].Value = txbTacGia.Text;
        //    dtgSach[2, viTri].Value = txbNXB.Text;
        //    dtgSach[3, viTri].Value = txbLoaiSach.Text;
        //    dtgSach[4, viTri].Value = txbSoLuong.Text;
        //    dtgSach[5, viTri].Value = txbGiaTien.Text;
        //    DuaThongDiep("Bạn đã sửa thành công!");
        //    lbHoTro.ForeColor = Color.BlueViolet;
        //    LamMoi();
        //    TroVeTrangThaiNhap();
        //}

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    int viTri = dtgSach.CurrentCell.RowIndex;
        //    if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin này", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
        //    {
        //        dtgSach.Rows.RemoveAt(viTri);
        //        DuaThongDiep("Bạn đã xóa thành công!");
        //        lbHoTro.ForeColor = Color.BlueViolet;
        //        LamMoi();
        //        TroVeTrangThaiNhap();
        //    }
        //}
        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenSach = txbTenSachT.Text;
            string tacGia = txbTacGia.Text;
            string theLoai = txbTheLoai.Text;
            if (ckbTenSach.Checked == false && ckbTacGia.Checked == false && ckbTheLoai.Checked == false)
            {
                DuaThongDiep("Bạn vui lòng đánh dấu các thông tin cần tìm!");
            }
            if (ckbTenSach.Checked == true && ckbTacGia.Checked == false && ckbTheLoai.Checked == false)
            {
                dtgSach.DataSource = SachDAO.Instance.TimSachQuaTen(tenSach);
            }
            if (ckbTenSach.Checked == false && ckbTacGia.Checked == true && ckbTheLoai.Checked == false)
            {
                dtgSach.DataSource = SachDAO.Instance.TimSachQuaTacGia(tacGia);
            }
            if (ckbTenSach.Checked == false && ckbTacGia.Checked == false && ckbTheLoai.Checked == true)
            {
                dtgSach.DataSource = SachDAO.Instance.TimSachQuaTheLoai(theLoai);
            }
            if (ckbTenSach.Checked == true && ckbTacGia.Checked == true && ckbTheLoai.Checked == false)
            {
                dtgSach.DataSource = SachDAO.Instance.TimSachQuaTenVaTacGia(tenSach, tacGia);
            }
            if (ckbTenSach.Checked == true && ckbTacGia.Checked == false && ckbTheLoai.Checked == true)
            {
                dtgSach.DataSource = SachDAO.Instance.TimSachQuaTenVaTheLoai(tenSach, theLoai);
            }
            if (ckbTenSach.Checked == false && ckbTacGia.Checked == true && ckbTheLoai.Checked == true)
            {
                dtgSach.DataSource = SachDAO.Instance.TimSachQuaTheLoaiVaTacGia(theLoai, tacGia);
            }
            if (ckbTenSach.Checked == true && ckbTacGia.Checked == true && ckbTheLoai.Checked == true)
            {
                dtgSach.DataSource = SachDAO.Instance.TimSachQuaTenVaTheLoaiVaTacGia(tenSach, theLoai, tacGia);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            KetNoiKhoSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int soLuong, giaTien;
            if(txbSoLuong.Text != "" && int.TryParse(txbSoLuong.Text.ToString(), out soLuong) == true && int.TryParse(txbGiaTien.Text.ToString(), out giaTien) == true)
            {
                int tien = soLuong * giaTien;
                dtgThanhToan.Rows.Add(new object[] { txbTenSach.Text, txbSoLuong.Text, txbGiaTien.Text, tien.ToString() });
                LamMoiTongTien();
                txbSoLuong.Text = "";
            }
            else
            {
                if (txbSoLuong.Text == "")
                {
                    DuaThongDiep("Bạn vui lòng nhập vào số lượng sách!");
                    txbSoLuong.Focus();
                }
                if (int.TryParse(txbSoLuong.Text.ToString(), out soLuong) == false)
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số lượng sách!");
                    txbSoLuong.Focus();
                }
                if (int.TryParse(txbGiaTien.Text.ToString(), out giaTien) == false)
                {
                    DuaThongDiep("Bạn vui lòng nhập lại giá tiền!");
                    txbGiaTien.Focus();
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtgThanhToan.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dtgThanhToan.Rows)
                {
                    if (row.Index < dtgThanhToan.Rows.Count - 1)
                    {
                        SachDAO.Instance.ThanhToanSach(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                    }
                }
            }
            KetNoiKhoSach();
            dtgThanhToan.Rows.Clear();
        }

        private void dtgThanhToan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgThanhToan.SelectedCells.Count > 0)
            {
                DataGridViewRow row = dtgThanhToan.Rows[dtgThanhToan.CurrentCell.RowIndex];
                txbTenSach.Text = row.Cells[0].Value.ToString();
                txbSoLuong.Text = row.Cells[1].Value.ToString();
                txbGiaTien.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int soLuong, giaTien;
            int tien = 0;
            int.TryParse(txbSoLuong.Text.ToString(), out soLuong);
            int.TryParse(txbGiaTien.Text.ToString(), out giaTien);
            tien = soLuong * giaTien;
            dtgThanhToan.Rows[dtgThanhToan.CurrentCell.RowIndex].SetValues(new object[] { txbTenSach.Text, txbSoLuong.Text, txbGiaTien.Text, tien });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int viTri = dtgThanhToan.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin này", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtgThanhToan.Rows.RemoveAt(viTri);
                DuaThongDiep("Bạn đã xóa thành công!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgvSearchBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
