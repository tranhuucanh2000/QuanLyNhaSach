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
            HienThiAdmin();
        }
        #region Methods
        void KetNoiKhoSach()
        {
            DataTable data = SachDAO.Instance.LayDSSach();
            dtgSach.DataSource = data;
        }
        void HienThiAdmin()
        {
            if (AccountDAO.Type == true) ptbAdmin.Visible = true;
            else
                ptbAdmin.Visible = false;
        }
        //Để xuất thông báo
        void DuaThongDiep(string str, int mucDo)
        {
            string ThongDiep = String.Concat("BỒ CÂU: \"", str, "\"");
            if (mucDo == 1) lbHoTro.ForeColor = Color.Green;
            if (mucDo == 2) lbHoTro.ForeColor = Color.Violet;
            if (mucDo == 3) lbHoTro.ForeColor = Color.Red;
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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenSach = txbTenSachT.Text;
            string tacGia = txbTacGia.Text;
            string theLoai = txbTheLoai.Text;
            if (ckbTenSach.Checked == false && ckbTacGia.Checked == false && ckbTheLoai.Checked == false)
            {
                DuaThongDiep("Bạn vui lòng đánh dấu các thông tin cần tìm!",2);
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
            DuaThongDiep("Tôi đã vừa làm mới lại danh sách giúp bạn!", 1);
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
                DuaThongDiep("Bạn vừa thêm sách vào danh sách thanh toán!", 1);
            }
            else
            {
                if (txbSoLuong.Text == "")
                {
                    DuaThongDiep("Bạn vui lòng nhập vào số lượng sách!",2);
                    txbSoLuong.Focus();
                }
                if (int.TryParse(txbSoLuong.Text.ToString(), out soLuong) == false)
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số lượng sách!",2);
                    txbSoLuong.Focus();
                }
                if (int.TryParse(txbGiaTien.Text.ToString(), out giaTien) == false)
                {
                    DuaThongDiep("Bạn vui lòng nhập lại giá tiền!",2);
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
            DuaThongDiep("Bạn đã thanh toán thành công!", 1);
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
            DuaThongDiep("Bạn đã sửa thành công!", 1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int viTri = dtgThanhToan.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin này", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtgThanhToan.Rows.RemoveAt(viTri);
                DuaThongDiep("Bạn đã xóa thành công!",1);
            }
        }

<<<<<<< HEAD
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgvSearchBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

=======
        #endregion

        private void ptbDangXuat_Click(object sender, EventArgs e)
        {
            FLogin login = new FLogin();
            login.ShowDialog();
            this.Close();
>>>>>>> ThietKeLaiGiaoDien
        }

        private void ptbThongTin_Click(object sender, EventArgs e)
        {
            FInfomationAccount fInfomation = new FInfomationAccount();
            fInfomation.ShowDialog();
        }
    }
}
