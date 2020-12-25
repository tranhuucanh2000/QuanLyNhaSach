using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance 
        { 
            get { if (instance == null) instance = new HoaDonDAO(); return instance; } 
            set => instance = value; 
        }

        public void ThemHoaDon(string sohd, DateTime ngay)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_ThemHoaDon @soHD , @ngay", new object[] { sohd, ngay });
        }
        public void ThemChiTietHD(string sohd, string masach, int soluong, int gia)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_ThemChiTietHoaDon @maSach , @soHD , @soLuongBan , @giaBan", new object[] { masach, sohd, soluong, gia });
        }
        //đm sao nó k đc v :v
       public DataTable LayDSHoaDon()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_HienThiHoaDon");
            return data;
        }

    }
}
