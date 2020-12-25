using QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        internal static TaiKhoanDAO Instance 
        {
            get { if (instance == null) instance = new TaiKhoanDAO();return instance; }
            private set => instance = value; 
        }

        public static bool Type { get => type; set => type = value; }

        private static bool type;
        public bool isAccount(string usn, string psw)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_DangNhap @userName , @passWord", new object[] { usn, psw });
            if(data.Rows.Count>0)
            {
                DataRow row = data.Rows[0];
                if (row["Loai"].ToString() == "1") Type = true;
                else Type = false;
                return true;
            }
            return false;
        }
        public TaiKhoan LayTaiKhoanTuTenDN(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from TaiKhoan where TenDN = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new TaiKhoan(item);
            }
            return null;
        }
        public bool CapNhatTaiKhoan(string usn, string name, string psw, string pswn)
        {
            int data = DataProvider.Instance.ExecuteNonQuery("EXEC USP_SuaTaiKhoan @tenDN , @tenHT , @matKhau , @matKhauMoi", new object[] { usn, name, psw, pswn });
            return data > 0;
        }
        public bool CapNhatMaTaiKhoan(string usn, string ma, string mamoi)
        {
            int data = DataProvider.Instance.ExecuteNonQuery("EXEC USP_SuaMaTaiKhoan @tenDN , @ma , @maMoi", new object[] { usn, ma, mamoi });
            return data > 0;
        }
        public DataTable CaiDatTaiKhoan()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_CaiDatTaiKhoan");
            return data;
        }

        public bool XacNhanTaiKhoan(string tendn, string ma)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_XacNhanTaiKhoanQuaMa @tendn , @ma", new object[] { tendn, ma });
            if (data.Rows.Count > 0) return true;
            return false;
        }
        public void QuenMatKhau(string tendn, string matkhaumoi)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_QuenMatKhau @tendn , @matkhaumoi", new object[] { tendn, matkhaumoi });
        }    

        public void ThemTaiKhoan(string tendn, string matkhau, string tenht , int nhapsach, int thongke, int kesach, int themdl, int bansach, int tttaikhoan, string ma)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_ThemTaiKhoan @tendn , @matkhau , @tenht , @loai , @nhapsach , @thongke , @kesach , @themdl , @bansach , @tttaikhoan , @ma", new object[] { tendn, matkhau, tenht, 0, nhapsach, thongke, kesach, themdl, bansach, tttaikhoan, ma });
        }
        public void UpdateTaiKhoan(string tendn, int nhapsach, int thongke, int kesach, int themdl, int bansach, int tttaikhoan)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_CapNhatTaiKhoan @tendn , @nhapsach , @thongke , @kesach , @themdl , @bansach , @tttaikhoan ", new object[] { tendn, nhapsach, thongke, kesach, themdl, bansach, tttaikhoan }); 
        }
    }
}
