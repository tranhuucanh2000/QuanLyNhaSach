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
    public partial class UCBanSach : UserControl
    {
        private TaiKhoan loginAccount;
        public UCBanSach(TaiKhoan acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            KetNoiKhoSach();
            HienTen();
            DuaVeTrangThaiTimKiem();
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
        }
        private static UCBanSach instance;
        public static UCBanSach Instance { 
            get { /*if (instance == null) instance = new UCBanSach()*/return instance; }
            set => instance = value; 
        }

        public TaiKhoan LoginAccount 
        { 
            get => loginAccount; 
            set => loginAccount = value; 
        }
        void LamMoiTxb()
        {
            txbTenSach.Text = txbSoLuong.Text = txbID.Text = txbGiaTien.Text = "";
        }

        #region Method

        void KetNoiKhoSach()
        {
            DataTable data = SachDAO.Instance.LayDSSach();
            dtgSach.DataSource = data;
            dtgSach.DataSource = data;
            dtgSach.Columns[0].HeaderText = "Mã";
            dtgSach.Columns[1].HeaderText = "Tên Sách";
            dtgSach.Columns[2].HeaderText = "Tác Giả";
            dtgSach.Columns[3].HeaderText = "Thể Loại";
            dtgSach.Columns[4].HeaderText = "NXB";
            dtgSach.Columns[5].HeaderText = "Số Lượng";
            dtgSach.Columns[6].HeaderText = "Giá Tiền";
            dtgSach.Columns[0].Width = 50;
            dtgSach.Columns[1].Width = 197;
            dtgSach.Columns[2].Width = 90;
            dtgSach.Columns[3].Width = 90;
            dtgSach.Columns[4].Width = 90;
            dtgSach.Columns[5].Width = 59;
            dtgSach.Columns[6].Width = 65;
        }
        void DuaVeTrangThaiTimKiem()
        {
            ckbTacGia.Checked = false;
            ckbTenSach.Checked = false;
            ckbTheLoai.Checked = false;
            txbTenSachT.Text = "";
            txbTheLoai.Text = "";
            txbTacGia.Text = "";
            txbTenSachT.Focus();
        }
        //Để xuất thông báo
        public void DuaThongDiep(string str, int mucDo)
        {
            string ThongDiep = String.Concat("BỒ CÂU: \"", str, "\"");
            if (mucDo == 1) lbHoTro.ForeColor = Color.FromArgb(102, 255, 102);
            if (mucDo == 2) lbHoTro.ForeColor = Color.FromArgb(255, 255, 102);
            if (mucDo == 3) lbHoTro.ForeColor = Color.White;
            lbHoTro.Text = ThongDiep;
        }
        void HienTen()
        {
            DuaThongDiep(string.Concat("Xin chào ", LoginAccount.Ten), 3);
        }
        void LamMoiTongTien()
        {
            int tongtien = 0;
            if (dtgThanhToan.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dtgThanhToan.Rows)
                {
                    if (row.Index < dtgThanhToan.Rows.Count - 1)
                    {
                        int tien = 0;
                        tien = int.Parse(row.Cells[4].Value.ToString());
                        tongtien += tien;
                    }
                }
            }
            txbThanhTien.Text = tongtien.ToString();
        }
        #endregion

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
                txbTenSach.Text = row.Cells[1].Value.ToString();
                txbGiaTien.Text = row.Cells[6].Value.ToString();
                txbID.Text = row.Cells[0].Value.ToString();
                txbSoLuong.Text = "";
                lbHoTroSuaSach.Text = "";
                txbSoLuong.Focus();
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnThem.Visible = true;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenSach = txbTenSachT.Text;
            string tacGia = txbTacGia.Text;
            string theLoai = txbTheLoai.Text;
            if (ckbTenSach.Checked == false && ckbTacGia.Checked == false && ckbTheLoai.Checked == false)
            {
                DuaThongDiep("Bạn vui lòng đánh dấu các thông tin cần tìm!", 2);
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
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = false;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DuaThongDiep("Tôi đã vừa làm mới lại danh sách giúp bạn!", 1);
            DuaVeTrangThaiTimKiem();
            KetNoiKhoSach();
            LamMoiTxb();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int soLuong; 
            int giaTien = int.Parse(txbGiaTien.Text);
            if (txbSoLuong.Text != "" && int.TryParse(txbSoLuong.Text.ToString(), out soLuong) == true )
            {
                DataTable sach = SachDAO.Instance.TimSachQuaTen(txbTenSach.Text);
                DataRow row= sach.Rows[0];
                int slSach = int.Parse(row["SoLuongTon"].ToString());
                if (soLuong > 0 && soLuong <= slSach) 
                {
                    int tien = soLuong * giaTien;
                    bool trangthai = true;
                    int i= 0;
                    foreach(DataGridViewRow row1 in dtgThanhToan.Rows)
                    {
                        if (i < dtgThanhToan.Rows.Count - 1)
                        {
                            if (txbID.Text == row1.Cells[0].Value.ToString()) trangthai = false;
                        }
                        i++;
                    }
                    if (trangthai == true)
                    {
                        dtgThanhToan.Rows.Add(new object[] { txbID.Text, txbTenSach.Text, txbSoLuong.Text, txbGiaTien.Text, tien.ToString() });
                        LamMoiTongTien();
                        txbSoLuong.Text = "";
                        LamMoiTxb();
                        DuaThongDiep("Bạn vừa thêm sách vào danh sách thanh toán!", 1);
                        btnThem.Visible = btnXoa.Visible = btnSua.Visible = false;
                        lbHoTroSuaSach.Text = "Bạn vừa thêm sách vào danh sách thanh toán!";
                        lbHoTroSuaSach.ForeColor = Color.FromArgb(102, 255, 102);
                        DuaVeTrangThaiTimKiem();
                    }
                    else
                    {
                        DuaThongDiep("Sách này đã có trong danh sách thanh toán!", 2);
                    }
                }
                else
                {
                    if(soLuong<=0)
                    {
                        DuaThongDiep("Bạn vui lòng nhập số lượng lớn hơn 0", 2);
                        lbHoTroSuaSach.Text = "Bạn vui lòng nhập số lượng lớn hơn 0";
                        lbHoTroSuaSach.ForeColor = Color.Red;
                    }
                    else
                    {
                        DuaThongDiep("Không đủ số lượng sách bán", 2);
                        lbHoTroSuaSach.Text = "Không đủ số lượng sách bán";
                        lbHoTroSuaSach.ForeColor = Color.Red;
                    }
                }                    
            }
            else
            {
                if (txbSoLuong.Text == "")
                {
                    DuaThongDiep("Bạn vui lòng nhập vào số lượng sách!", 2);
                    lbHoTroSuaSach.Text = "Bạn vui lòng nhập vào số lượng sách!";
                    lbHoTroSuaSach.ForeColor = Color.Red;
                    txbSoLuong.Focus();
                }
                else if(int.TryParse(txbSoLuong.Text.ToString(), out soLuong) == false)
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số lượng sách!", 2);
                    lbHoTroSuaSach.Text = "Bạn vui lòng nhập lại số lượng sách!";
                    lbHoTroSuaSach.ForeColor = Color.Red;
                    txbSoLuong.Focus();
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("Mã");
            data.Columns.Add("Tên Sách"); 
            data.Columns.Add("Số lượng");
            data.Columns.Add("Đơn Giá");
            data.Columns.Add("Tiền");
            for (int i = 0; i < dtgThanhToan.Rows.Count - 1; i++)
            {
                data.Rows.Add(new object[] { dtgThanhToan.Rows[i].Cells[0].Value, dtgThanhToan.Rows[i].Cells[1].Value, dtgThanhToan.Rows[i].Cells[2].Value, dtgThanhToan.Rows[i].Cells[3].Value, dtgThanhToan.Rows[i].Cells[4].Value });
            }
            FHoaDonTT fHoaDonTT = new FHoaDonTT(data, loginAccount);
            fHoaDonTT.ThanhToan += FHoaDonTT_ThanhToan;
            fHoaDonTT.ShowDialog();
        }

        private void FHoaDonTT_ThanhToan(object sender, EventArgs e)
        {
            DuaThongDiep("Bạn đã thanh toán thành công!", 1);
            dtgThanhToan.Rows.Clear();
            dtgThanhToan.Refresh();
            //data.Columns.Add("Mã");
            //data.Columns.Add("Tên Sách");
            //data.Columns.Add("Số lượng");
            //data.Columns.Add("Đơn Giá");
            //data.Columns.Add("Tiền");
            LamMoiTxb();
            LamMoiTongTien();
            lbHoTroSuaSach.Text = "";
            DuaVeTrangThaiTimKiem();
            KetNoiKhoSach();
        }

        private void dtgThanhToan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgThanhToan.Rows.Count > 1)
            {
                if (dtgThanhToan.SelectedCells.Count > 0)
                {
                    DataGridViewRow row = dtgThanhToan.Rows[dtgThanhToan.CurrentCell.RowIndex];
                    if (row != null)
                    {
                        txbID.Text = row.Cells[0].Value.ToString();
                        txbTenSach.Text = row.Cells[1].Value.ToString();
                        txbSoLuong.Text = row.Cells[2].Value.ToString();
                        txbSoLuong.Focus();
                        txbGiaTien.Text = row.Cells[3].Value.ToString();
                        lbHoTroSuaSach.Text = "";
                        btnThem.Visible = false;
                        btnSua.Visible = btnXoa.Visible = true;
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int soLuong;
            int giaTien = int.Parse(txbGiaTien.Text);
            if (txbSoLuong.Text != "" && int.TryParse(txbSoLuong.Text.ToString(), out soLuong) == true)
            {
                DataTable sach = SachDAO.Instance.TimSachQuaTen(txbTenSach.Text);
                DataRow row = sach.Rows[0];
                int slSach = int.Parse(row["SoLuongTon"].ToString());
                if (soLuong > 0 && soLuong <= slSach)
                {
                    int tien = soLuong * giaTien;
                    dtgThanhToan.Rows[dtgThanhToan.CurrentCell.RowIndex].SetValues(new object[] { txbID.Text, txbTenSach.Text, txbSoLuong.Text, txbGiaTien.Text, tien });
                    LamMoiTongTien();
                    txbSoLuong.Text = "";
                    LamMoiTxb();
                    DuaThongDiep("Bạn đã sửa thành công!", 1);
                    btnThem.Visible = btnXoa.Visible = btnSua.Visible = false;
                    lbHoTroSuaSach.Text = "Bạn đã sửa thành công!";
                    lbHoTroSuaSach.ForeColor = Color.FromArgb(102, 255, 102);
                    DuaVeTrangThaiTimKiem();
                }
                else
                {
                    if (soLuong <= 0)
                    {
                        DuaThongDiep("Bạn vui lòng nhập số lượng lớn hơn 0", 2);
                        lbHoTroSuaSach.Text = "Bạn vui lòng nhập số lượng lớn hơn 0";
                        lbHoTroSuaSach.ForeColor = Color.Red;
                    }
                    else
                    {
                        DuaThongDiep("Không đủ số lượng sách bán", 2);
                        lbHoTroSuaSach.Text = "Không đủ số lượng sách bán";
                        lbHoTroSuaSach.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                if (txbSoLuong.Text == "")
                {
                    DuaThongDiep("Bạn vui lòng nhập vào số lượng sách!", 2);
                    lbHoTroSuaSach.Text = "Bạn vui lòng nhập vào số lượng sách!";
                    lbHoTroSuaSach.ForeColor = Color.Red;
                    txbSoLuong.Focus();
                }
                else if (int.TryParse(txbSoLuong.Text.ToString(), out soLuong) == false)
                {
                    DuaThongDiep("Bạn vui lòng nhập lại số lượng sách!", 2);
                    lbHoTroSuaSach.Text = "Bạn vui lòng nhập lại số lượng sách!";
                    lbHoTroSuaSach.ForeColor = Color.Red;
                    txbSoLuong.Focus();
                }
            }
            //int soLuong;
            //int giaTien = int.Parse(txbGiaTien.Text);
            //int tien = 0;
            //if (int.TryParse(txbSoLuong.Text.ToString(), out soLuong) == true)
            //{
            //    DataTable sach = SachDAO.Instance.TimSachQuaTen(txbTenSach.Text);
            //    DataRow row = sach.Rows[0];
            //    int slSach = int.Parse(row["Số Lượng Tồn"].ToString());
            //    tien = soLuong * giaTien;
            //    dtgThanhToan.Rows[dtgThanhToan.CurrentCell.RowIndex].SetValues(new object[] { txbID.Text, txbTenSach.Text, txbSoLuong.Text, txbGiaTien.Text, tien });
            //    DuaThongDiep("Bạn đã sửa thành công!", 1);
            //    lbHoTroSuaSach.Text = "Bạn đã sửa thành công!";
            //    lbHoTroSuaSach.ForeColor = Color.FromArgb(102, 255, 102);
            //    LamMoiTxb();
            //    btnThem.Visible = btnXoa.Visible = btnSua.Visible = false;
            //    LamMoiTongTien();
            //}
            //else
            //{
            //    DuaThongDiep("Bạn vui lòng nhập lại số lượng!", 2);
            //    lbHoTroSuaSach.Text = "Bạn vui lòng nhập lại số lượng!";
            //    lbHoTroSuaSach.ForeColor = Color.Red;
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int viTri = dtgThanhToan.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin này", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtgThanhToan.Rows.RemoveAt(viTri);
                DuaThongDiep("Bạn đã xóa thành công!", 1);
                lbHoTroSuaSach.Text = "Bạn đã xóa thành công!";
                LamMoiTxb();
                LamMoiTongTien();
                btnThem.Visible = btnXoa.Visible = btnSua.Visible = false;
            }
        }

        private void FInfomation_CapNhatTaiKhoanEvent(object sender, TaiKhoanSuKien e)
        {
            DuaThongDiep(string.Concat("Xin chào ", e.Acc.Ten), 3);
        }

        private void txbTenSachT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ckbTenSach.Checked = true;
                btnTimKiem_Click(sender, e);
            }
        }

        private void txbTheLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ckbTheLoai.Checked = true;
                btnTimKiem_Click(sender, e);
            }
        }

        private void txbTacGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ckbTacGia.Checked = true;
                btnTimKiem_Click(sender, e);
            }
        }

        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void txbTenSachT_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                ckbTenSach.Checked = true;
                btnTimKiem_Click(sender, e);
            }    
        }

        private void txbTheLoai_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ckbTheLoai.Checked = true;
                btnTimKiem_Click(sender, e);
            }
        }

        private void txbTacGia_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ckbTheLoai.Checked = true;
                btnTimKiem_Click(sender, e);
            }
        }

        private void txbSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(btnThem.Visible == true)
                {
                    btnThem_Click(sender, e);
                }
                else
                {
                    btnSua_Click(sender, e);
                }    
            }
        }

        private void ptbHoTro_Click(object sender, EventArgs e)
        {
            FThongTinPhanMem fThongTinPhanMem = new FThongTinPhanMem();
            fThongTinPhanMem.ShowDialog();
        }
    }
}
