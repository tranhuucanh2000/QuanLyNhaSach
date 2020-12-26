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
    public partial class UCThongKe : UserControl
    {
        private static UCThongKe instance;
        public static UCThongKe Instance
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
        public UCThongKe(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
        }

        //void LayDSHoaDon()
        //{
        //    DataTable data = HoaDonDAO.Instance.LayDSHoaDon();
        //    dtgvThongKe.DataSource = data;
        //}
        private void cbThuocTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region methods
        //void LayDSHoaDon(DateTime NgayLap, DateTime NgayBan)
        //{
        //    DataTable data = HoaDonDAO.Instance.LayDSHoaDon(NgayLap,NgayBan);
        //    dtgvThongKe.DataSource = data;
        //}
        #endregion
        #region events
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime NgayLap;
            DateTime NgayBan;
            NgayLap = dateNgayLap.Value;
            NgayBan = dateNgayBan.Value;
            dtgvThongKe.DataSource = HoaDonDAO.Instance.LayDSHoaDon(NgayLap, NgayBan);
        }
        #endregion



        public void CheckOut(int id, int discount, float totalPrice)
        {
            //string query = "UPDATE dbo.ChiTietHoaDon SET NgayBan = GETDATE(), totalPrice = " + totalPrice + " WHERE id = " + id;
            //DataProvider.Instance.ExecuteNonQuery(query);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
