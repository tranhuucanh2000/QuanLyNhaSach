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

        bool isAdmin()
        {
            //Xử lý xem có phải admin hay không
            return true;
        }
        private void pctCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ptClose_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.ExecuteNonQuery("delete from dbo.Sach");
            ThemDuLieuTuDtgSangCSDL();
            Application.Exit();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        void ThemDuLieuVaoCSDL(string tensach,string tacgia,string theloai, string nxb, int soluong,int giatien)
        {
            string query = String.Concat("INSERT INTO dbo.Sach",@"(TheLoai, TenSach, TacGia, NhaXuatBan, SoLuong, GiaTien) VALUES (N'",theloai, @"', N'", tensach, @"', N'", tacgia, @"', N'", nxb, @"', N'", soluong, @"', N'", giatien, "')");
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        void DuaThongDiep(string str)
        {
            string ThongDiep = String.Concat("BỒ CÂU: \"", str, "\"");
            lbHoTro.Text = ThongDiep;
        }
        void TroVeTrangThaiNhap()
        {
            txbLoaiSach.Text = ""; 
            txbTenSach.Text = ""; 
            txbTacGia.Text = ""; 
            txbNXB.Text = ""; 
            txbSoLuong.Text = ""; 
            txbGiaTien.Text = "";
            txbLoaiSach.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txbLoaiSach.Text != "" && txbTenSach.Text != "" && txbTacGia.Text != "" && txbNXB.Text != "" && txbSoLuong.Text != "" && txbGiaTien.Text != "")
            {
                try
                {
                    int soLuong = int.Parse(txbSoLuong.Text);
                    try
                    {
                        int giaTien = int.Parse(txbGiaTien.Text);
                        ThemDuLieuVaoCSDL(txbTenSach.Text.ToString(), txbTacGia.Text.ToString(), txbLoaiSach.Text.ToString(), txbNXB.Text.ToString(), int.Parse(txbSoLuong.Text.ToString()), int.Parse(txbGiaTien.Text.ToString()));
                        DuaThongDiep("Bạn đã thêm thành công!");
                        dtgSach.Refresh();
                        KetNoiKhoSach();
                    }
                    catch (FormatException)
                    {
                        DuaThongDiep("Bạn đã nhập sai dữ liệu giá tiền!");
                        lbHoTro.ForeColor = Color.Red;
                    }
                }
                catch (FormatException)
                {
                    DuaThongDiep("Bạn đã nhập sai dữ liệu số lượng!");
                    lbHoTro.ForeColor = Color.Red;
                }
            }
            else
            {
                DuaThongDiep("Bạn nhập thiếu thông tin");
            }
        }
        void LamMoi()
        {
            DataProvider.Instance.ExecuteNonQuery("delete from dbo.Sach");
            ThemDuLieuTuDtgSangCSDL();
        }
        void ThemDuLieuTuDtgSangCSDL()
        {
            int n = dtgSach.RowCount;
            for (int i = 0; i < n - 1;i++)
            {
                ThemDuLieuVaoCSDL(dtgSach[0, i].Value.ToString(), dtgSach[1, i].Value.ToString(),  dtgSach[3, i].Value.ToString(), dtgSach[2, i].Value.ToString(), int.Parse(dtgSach[4, i].Value.ToString()), int.Parse(dtgSach[5, i].Value.ToString()));
            }    
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int viTri = dtgSach.CurrentCell.RowIndex;
            dtgSach[0, viTri].Value = txbTenSach.Text;
            dtgSach[1, viTri].Value = txbTacGia.Text;
            dtgSach[2, viTri].Value = txbNXB.Text;
            dtgSach[3, viTri].Value = txbLoaiSach.Text;
            dtgSach[4, viTri].Value = txbSoLuong.Text;
            dtgSach[5, viTri].Value = txbGiaTien.Text;
            DuaThongDiep("Bạn đã sửa thành công!");
            lbHoTro.ForeColor = Color.BlueViolet;
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int viTri = dtgSach.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin này", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                dtgSach.Rows.RemoveAt(viTri);
                DuaThongDiep("Bạn đã xóa thành công!");
                lbHoTro.ForeColor = Color.BlueViolet;
                LamMoi();
            }
        }

        private void dtgSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgSach.SelectedCells.Count>0)
            {
                DataGridViewRow row = dtgSach.Rows[dtgSach.CurrentCell.RowIndex];
                txbTenSach.Text = row.Cells[0].Value.ToString();
                txbTacGia.Text = row.Cells[1].Value.ToString();
                txbNXB.Text = row.Cells[2].Value.ToString();
                txbLoaiSach.Text = row.Cells[3].Value.ToString();
                txbSoLuong.Text = row.Cells[4].Value.ToString();
                txbGiaTien.Text = row.Cells[5].Value.ToString();
            }    
        }
        void KetNoiKhoSach()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach ");
            dtgSach.DataSource = data;
        }

        private void txbLoaiSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbTenSach.Focus();
        }

        private void txbTenSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbTacGia.Focus();
        }

        private void txbTacGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbNXB.Focus();
        }

        private void txbNXB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSoLuong.Focus();
        }

        private void txbSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbGiaTien.Focus();
        }
    }
}
