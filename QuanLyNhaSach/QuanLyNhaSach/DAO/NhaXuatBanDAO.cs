using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    public class NhaXuatBanDAO
    {
        private static NhaXuatBanDAO instance;

        public static NhaXuatBanDAO Instance 
        { 
            get { if (instance == null) instance = new NhaXuatBanDAO();return instance; }
            set => instance = value; 
        }

        public void ThemNhaXuatBan(string tennxb,string diachi,string sdt)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_ThemNhaXuatBan @tennxb , @diachi , @sdt ", new object[] { tennxb, diachi, sdt });
        }
        public void SuaNhaXuatBan(string tennxb,string sdt, string diachi, string manxb)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_SuaNhaXuatBan @tennxb , @sdt , @diachi , @manxb ", new object[] { tennxb, sdt, diachi, manxb });
        }
    }
}
