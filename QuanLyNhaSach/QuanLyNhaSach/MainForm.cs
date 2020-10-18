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
            Application.Exit();
        }
        private void label1_Click(object sender, EventArgs e)
        {

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
            if (txbLoaiSach.Text!=""&&txbTenSach.Text!=""&&txbTacGia.Text!=""&&txbNXB.Text!=""&&txbSoLuong.Text!=""&&txbGiaTien.Text!="")
            {
                try
                {
                    int soLuong = int.Parse(txbSoLuong.Text);
                    try
                    {
                        int giaTien = int.Parse(txbGiaTien.Text);
                        dtgSach.Rows.Add(txbLoaiSach.Text, txbTenSach.Text, txbTacGia.Text, txbNXB.Text, txbSoLuong.Text, txbGiaTien.Text);
                        DuaThongDiep("Bạn đã thêm sách thành công!");
                        lbHoTro.ForeColor = Color.BlueViolet;
                        TroVeTrangThaiNhap();
                    }
                    catch (FormatException)
                    {
                        DuaThongDiep("Bạn đã nhập sai dữ liệu giá tiền!");
                        lbHoTro.ForeColor = Color.Red;
                    }


                }    
                catch(FormatException)
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            int viTri = dtgSach.CurrentCell.RowIndex;
            dtgSach[0, viTri].Value = txbLoaiSach.Text;
            dtgSach[1, viTri].Value = txbTenSach.Text;
            dtgSach[2, viTri].Value = txbTacGia.Text;
            dtgSach[3, viTri].Value = txbNXB.Text;
            dtgSach[4, viTri].Value = txbSoLuong.Text;
            dtgSach[5, viTri].Value = txbGiaTien.Text;
            DuaThongDiep("Bạn đã sửa thành công!");
            lbHoTro.ForeColor = Color.BlueViolet;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int viTri = dtgSach.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin này", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                dtgSach.Rows.RemoveAt(viTri);
                DuaThongDiep("Bạn đã xóa thành công!");
                lbHoTro.ForeColor = Color.BlueViolet;
            }
        }

        private void dtgSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgSach.SelectedCells.Count>0)
            {
                DataGridViewRow row = dtgSach.Rows[dtgSach.CurrentCell.RowIndex];
                txbLoaiSach.Text = row.Cells[0].Value.ToString();
                txbTenSach.Text = row.Cells[1].Value.ToString();
                txbTacGia.Text = row.Cells[2].Value.ToString();
                txbNXB.Text = row.Cells[3].Value.ToString();
                txbSoLuong.Text = row.Cells[4].Value.ToString();
                txbGiaTien.Text = row.Cells[5].Value.ToString();
            }    
        }
    }
}
