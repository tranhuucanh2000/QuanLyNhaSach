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

        private TaiKhoan loginAccount;
        public TaiKhoan LoginAccount
        {
            get => loginAccount;
            set => loginAccount = value;
        }
        public void DuaThongDiep(string str, int mucDo)
        {
            string ThongDiep = String.Concat("BỒ CÂU: \"", str, "\"");
            if (mucDo == 1) lbHoTro.ForeColor = Color.FromArgb(102, 255, 102);
            if (mucDo == 2) lbHoTro.ForeColor = Color.FromArgb(255, 255, 102);
            if (mucDo == 3) lbHoTro.ForeColor = Color.White;
            lbHoTro.Text = ThongDiep;
        }
        public UCThongKe(TaiKhoan acc)
        {
            InitializeComponent();
            loginAccount = acc;
        }

        //void LayDSHoaDon()
        //{
        //    DataTable data = HoaDonDAO.Instance.LayDSHoaDon();
        //    dtgvThongKe.DataSource = data;
        //}
        void LayDSHoaDon()
        {
            //DataTable data = HoaDonDAO.Instance.LayDSHoaDon();
            //dataGridView1.DataSource = data;
        }
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
            DateTime NgayBan1;
            DateTime NgayBan2;
            NgayBan1 = dateNgayLap.Value;
            NgayBan2 = dateNgayBan.Value;
            dtgvThongKe.DataSource = HoaDonDAO.Instance.LayDSHoaDon(NgayBan1, NgayBan2);
        }
        #endregion


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
