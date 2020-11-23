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
    public class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO();return instance; }
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
        public Account LayTaiKhoanTuTenDN(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from TaiKhoan where TenDN = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool CapNhatTaiKhoan(string usn, string name, string psw, string pswn)
        {
            int data = DataProvider.Instance.ExecuteNonQuery("EXEC USP_CapNhatTaiKhoan @tenDN , @tenHT , @matKhau , @matKhauMoi", new object[] { usn, name, psw, pswn });
            return data > 0;
        }
    }
}
