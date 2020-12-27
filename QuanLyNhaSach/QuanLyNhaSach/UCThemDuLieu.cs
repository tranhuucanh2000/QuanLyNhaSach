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

        private TaiKhoan loginAccount;
        public TaiKhoan LoginAccount
        {
            get => loginAccount;
            set => loginAccount = value;
        }
        public UCThemDuLieu(TaiKhoan acc)
        {
            InitializeComponent();
            loginAccount = acc;
            HienTen();


        }

        void TrangThaiSua()
        {
            txbDC1.ReadOnly = false;
            txbSo1.ReadOnly = false;
            txbTen1.ReadOnly = false;
            txbDC1.ForeColor = Color.Red;
            txbTen1.ForeColor = Color.Red;
            txbSo1.ForeColor = Color.Red;
            btnHuy.Visible = true;
            btnLuu.Visible = true;
            btnSua.Visible = false;
        }
        void TrangThaiChonSach()
        {
            txbDC1.ForeColor = Color.Black;
            txbTen1.ForeColor = Color.Black;
            txbSo1.ForeColor = Color.Black;
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnSua.Visible = false;
            txbDC1.ReadOnly = true;
            txbSo1.ReadOnly = true;
            txbTen1.ReadOnly = true;
        }
        void LamMoiTxb()
        {
            txbSo.Text = txbTen.Text = txbDC.Text = "";
        }
        void LamMoiTxb1()
        {
            txbSo1.Text = txbTen1.Text = txbDC1.Text = "";
        }
        void KetNoiKhoTacGia()
        {
            DataTable data = SachDAO.Instance.LayDSTacGia();
            dtgSach.DataSource = data;
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
            LamMoiTxb();
            txbSo.Visible = txbDC.Visible = pnTam.Visible = pnSo.Visible = lbSo.Visible = true;
            lbTen.Text = "Tên Tác Giả:";
            lbSo.Text = "Số Điện Thoại:";
            lbDiaChi.Visible = txbDC.Visible = pnTam.Visible = false;
        }
        void HienThiTTTheLoai()
        {
            LamMoiTxb();
            lbTen.Text = "Tên Thể Loại:";
            txbSo.Visible = txbDC.Visible = lbDiaChi.Visible = lbSo.Visible = pnSo.Visible = pnTam.Visible = false;
        }
        void HienThiNXB()
        {
            LamMoiTxb();
            txbSo.Visible = lbSo.Visible = lbDiaChi.Visible = txbDC.Visible = pnTam.Visible = pnSo.Visible = true;
            lbTen.Text = "Tên NXB:";
            lbSo.Text = "Số Điện Thoại:";
            lbDiaChi.Text = "Địa Chỉ:";

        }
        void HienThiTTTacGia1()
        {
            LamMoiTxb();
            txbSo1.Visible = txbDC1.Visible = panel7.Visible = panel6.Visible = lbSo1.Visible = true;
            lbTen1.Text = "Tên Tác Giả:";
            lbSo1.Text = "Số Điện Thoại:";
            lbDiaChi1.Visible = txbDC1.Visible = panel6.Visible = false;
            dtgSach.Columns[0].Width = 90;
            dtgSach.Columns[1].Width = 220;
            dtgSach.Columns[2].Width = 220;
        }
        void HienThiTTTheLoai1()
        {
            LamMoiTxb();
            lbTen1.Text = "Tên Thể Loại:";
            txbSo1.Visible = txbDC1.Visible = lbDiaChi1.Visible = lbSo1.Visible = panel6.Visible = panel7.Visible = false;
            dtgSach.Columns[0].Width = 90;
            dtgSach.Columns[1].Width = 440;
        }
        void HienThiNXB1()
        {
            dtgSach.Columns[0].Width = 92;
            dtgSach.Columns[1].Width = 120;
            dtgSach.Columns[2].Width = 185;
            dtgSach.Columns[3].Width = 122;
            LamMoiTxb();
            txbSo1.Visible = lbSo1.Visible = lbDiaChi1.Visible = txbDC1.Visible = panel7.Visible = panel6.Visible = true;
            lbTen1.Text = "Tên NXB:";
            lbSo1.Text = "Số Điện Thoại:";
            lbDiaChi1.Text = "Địa Chỉ:";

        }
        public void HienTen()
        {
            DuaThongDiep(string.Concat("Xin chào ", LoginAccount.Ten), 3);
        }
        private void cbThuocTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThuocTinh.SelectedItem.ToString() == "Tác Giả")
            {
                btnThem.Visible = true;
                HienThiTTTacGia();
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Thể Loại")
            {
                btnThem.Visible = true;
                HienThiTTTheLoai();
            }
            else
            {
                btnThem.Visible = true;
                HienThiNXB();
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

        private void ptbDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
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

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string sdt = txbSo.Text;
            if (cbThuocTinh.SelectedItem.ToString() == "Tác Giả")
            {
                int sodt;
                if ((int.TryParse(txbSo.Text, out sodt)||txbSo.Text=="")&&txbTen.Text!="")
                {
                    TacGiaDAO.Instance.ThemTacGia(txbTen.Text, txbSo.Text);
                    DuaThongDiep("Đã thêm tác giả thành công!", 1);
                    LamMoiDSMaTacGia();
                    LamMoiTxb();
                }
                else
                {
                    if(txbTen.Text == "")
                    {
                        DuaThongDiep("Bạn vui lòng nhập vào tên!", 2);
                        txbTen.Focus();
                    }
                    else
                    {
                        DuaThongDiep("Bạn vui lòng nhập lại số điện thoại!", 2);
                        txbSo.Focus();
                        txbSo.SelectAll();
                    }
                }
            }
            else if (cbThuocTinh.SelectedItem.ToString() == "Thể Loại")
            {
                if (txbTen.Text == "")
                {
                    DuaThongDiep("Vui lòng nhập đủ dữ liệu", 2);
                    txbTen.Focus();
                }
                else if (TheLoaiDAO.Instance.XacNhanTenTL(txbTen.Text) == true)
                {
                    DuaThongDiep("Đã có thể loại này trong danh sách ", 2);
                    LamMoiTxb();
                }
                else
                {
                    SachDAO.Instance.ThemTheLoai(txbTen.Text);
                    DuaThongDiep("Đã thêm thể loại thành công!", 1);
                    LamMoiDSMaTheLoai();
                    LamMoiTxb();
                }
            }
            else
            {
                int sodt;
                if((int.TryParse(sdt, out sodt)&&txbDC.Text!="")&&txbTen.Text!="")
                {
                    NhaXuatBanDAO.Instance.ThemNhaXuatBan(txbTen.Text, txbDC.Text, sdt);
                    DuaThongDiep("Đã thêm nhà xuất bản thành công!",1);
                }
                else
                {
                    if (txbTen.Text == "" || txbSo.Text == "" || txbDC.Text == "")
                    {
                        DuaThongDiep("Bạn vui lòng nhập đủ thông tin!", 2);
                    }
                    else if(!int.TryParse(sdt, out sodt))
                    {
                        DuaThongDiep("Bạn vui lòng nhập số điện thoại hợp lệ!", 2);
                        txbSo.Focus();
                        txbSo.SelectAll();
                    }
                }
            }
        }
            private void dtgSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                TrangThaiChonSach();
                if (cbThuocTinh1.SelectedItem.ToString() == "Tác Giả")
                {
                    int vitri = dtgSach.CurrentRow.Index;
                    DataGridViewRow row = dtgSach.Rows[vitri];
                    txbTen1.Text = row.Cells[1].Value.ToString();
                    txbSo1.Text = row.Cells[2].Value.ToString();
                    btnSua.Visible = true;
                }
                else if (cbThuocTinh1.SelectedItem.ToString() == "Thể Loại")
                {
                    int vitri = dtgSach.CurrentRow.Index;
                    DataGridViewRow row = dtgSach.Rows[vitri];
                    txbTen1.Text = row.Cells[1].Value.ToString();
                    btnSua.Visible = true;
                }
                else
                {
                    int vitri = dtgSach.CurrentRow.Index;
                    DataGridViewRow row = dtgSach.Rows[vitri];
                    txbTen1.Text = row.Cells[1].Value.ToString();
                    txbSo1.Text = row.Cells[3].Value.ToString();
                    txbDC1.Text = row.Cells[2].Value.ToString();
                    btnSua.Visible = true;
                }
            } 

        private void cbThuocTinh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThuocTinh1.SelectedItem.ToString() == "Tác Giả")
            {
                TrangThaiChonSach();
                KetNoiKhoTacGia();
                HienThiTTTacGia1();
                LamMoiTxb1();
            }
            else if (cbThuocTinh1.SelectedItem.ToString() == "Thể Loại")
            {
                TrangThaiChonSach();
                KetNoiKhoTheLoai();
                SachDAO.Instance.LayDSTheLoai();
                HienThiTTTheLoai1();
                LamMoiTxb1();
            }
            else
            {
                TrangThaiChonSach();
                KetNoiKhoNXB();
                SachDAO.Instance.LayDSNXB();
                HienThiNXB1();
                LamMoiTxb1();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            TrangThaiSua();

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (cbThuocTinh1.SelectedItem.ToString() == "Tác Giả")
            {
                int sodt;
                if ((int.TryParse(txbSo1.Text, out sodt)||txbSo1.Text=="")&&txbTen1.Text!="")
                {
                    DataTable TacGia = SachDAO.Instance.LayDSTacGia();
                    int vitri = dtgSach.CurrentRow.Index;
                    DataGridViewRow row = dtgSach.Rows[vitri];
                    string matacgia = row.Cells[0].Value.ToString();
                    TacGiaDAO.Instance.SuaTacGia(txbTen1.Text, txbSo1.Text, matacgia);
                    DuaThongDiep("Đã sửa tác giả thành công!", 1);
                    TrangThaiChonSach();
                    dtgSach.DataSource = SachDAO.Instance.LayDSTacGia();
                    LamMoiTxb1();
                    btnSua.Visible = false;
                }
                else
                {
                    if (txbTen1.Text == "") DuaThongDiep("Bạn vui lòng nhập tên tác giả!",2);
                    else
                    {
                        DuaThongDiep("Bạn vui lòng nhập lại số điện thoại!", 2);
                        txbSo1.Focus();
                        txbSo1.SelectAll();
                    }              
                }
            }
            else if (cbThuocTinh1.SelectedItem.ToString() == "Thể Loại")
            {
                DataTable TheLoai = SachDAO.Instance.LayDSTheLoai();
                int vitri = dtgSach.CurrentRow.Index;
                DataGridViewRow row = dtgSach.Rows[vitri];
                string matheloai = row.Cells[0].Value.ToString();
                if(TheLoaiDAO.Instance.XacNhanTenTL(txbTen1.Text) == false &&txbTen1.Text!="")
                {
                    TheLoaiDAO.Instance.SuaTheLoai(txbTen1.Text, matheloai);
                    DuaThongDiep("Đã sửa thể loại thành công!", 1);
                    TrangThaiChonSach();
                    dtgSach.DataSource = SachDAO.Instance.LayDSTheLoai();
                    LamMoiTxb1();
                    btnSua.Visible = false;
                }
                else
                {
                    if(txbTen1.Text == "")
                    {
                        DuaThongDiep("Bạn vui lòng nhập vào tên thể loại!", 2);
                        txbTen1.Focus();
                    }
                    else
                    {
                        DuaThongDiep("Thể loại này đã có!",2);
                        txbTen1.Focus();
                        txbTen1.SelectAll();
                    }    
                }
            }
            else
            {
                int sodt;
                if ((int.TryParse(txbSo1.Text, out sodt) && txbDC1.Text != "") && txbTen1.Text != "")
                {
                    DataTable TheLoai = SachDAO.Instance.LayDSNXB();
                    int vitri = dtgSach.CurrentRow.Index;
                    DataGridViewRow row = dtgSach.Rows[vitri];
                    string manxb = row.Cells[0].Value.ToString();
                    NhaXuatBanDAO.Instance.SuaNhaXuatBan(txbTen1.Text, txbSo1.Text, txbDC1.Text, manxb);
                    DuaThongDiep("Đã sửa nhà xuất bản thành công!", 1);
                    TrangThaiChonSach();
                    dtgSach.DataSource = SachDAO.Instance.LayDSNXB();
                    LamMoiTxb1();
                    btnSua.Visible = false;
                }
                else
                {
                    if (txbTen1.Text == "" || txbSo1.Text == "" || txbDC1.Text == "")
                    {
                        DuaThongDiep("Bạn vui lòng nhập đủ thông tin!", 2);
                    }
                    else if (!int.TryParse(txbSo1.Text, out sodt))
                    {
                        DuaThongDiep("Bạn vui lòng nhập số điện thoại hợp lệ!", 2);
                        txbSo.Focus();
                        txbSo.SelectAll();
                    }
                }
                //int sodt;
                //if (int.TryParse(txbSo1.Text, out sodt))
                //{
                //    DataTable TheLoai = SachDAO.Instance.LayDSNXB();
                //    int vitri = dtgSach.CurrentRow.Index;
                //    DataGridViewRow row = dtgSach.Rows[vitri];
                //    string manxb = row.Cells[0].Value.ToString();
                //    NhaXuatBanDAO.Instance.SuaNhaXuatBan(txbTen1.Text, txbSo1.Text, txbDC1.Text, manxb);
                //    DuaThongDiep("Đã sửa nhà xuất bản thành công!", 1);
                //    TrangThaiChonSach();
                //    dtgSach.DataSource = SachDAO.Instance.LayDSNXB();
                //    LamMoiTxb1();
                //    btnSua.Visible = false;
                //}
                //else
                //{
                //    DuaThongDiep("Bạn vui lòng nhập lại số điện thoại!", 2);
                //}
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TrangThaiChonSach();
            int vitri = dtgSach.CurrentRow.Index;
            DataGridViewRow row = dtgSach.Rows[vitri];
            btnSua.Visible = true;
            if (cbThuocTinh1.SelectedItem.ToString() == "Tác Giả")
            {
                txbTen1.Text = row.Cells[1].Value.ToString();
                txbSo1.Text = row.Cells[2].Value.ToString();
            }
            else if (cbThuocTinh1.SelectedItem.ToString() == "Thể Loại")
            {
                txbTen1.Text = row.Cells[1].Value.ToString();
            }
            else
            {
                txbTen1.Text = row.Cells[1].Value.ToString();
                txbSo1.Text = row.Cells[3].Value.ToString();
                txbDC1.Text = row.Cells[2].Value.ToString();
            }
        }

        private void ptbHoTro_Click(object sender, EventArgs e)
        {
            FThongTinPhanMem fThongTinPhanMem = new FThongTinPhanMem();
            fThongTinPhanMem.ShowDialog();
        }
    }





}
