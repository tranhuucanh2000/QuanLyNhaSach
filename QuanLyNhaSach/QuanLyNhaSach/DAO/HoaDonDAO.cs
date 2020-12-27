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

        public void ThemHoaDon(string sohd, DateTime ngay,int tongtien, string tenkh, string tennv)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_ThemHoaDon @soHD , @ngay , @tongTien , @tenkh , @tennv", new object[] { sohd, ngay, tongtien,tenkh, tennv });
        }
        public void ThemChiTietHD(string masach, string sohd, int soluong, int giaban)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_ThemChiTietHoaDon @maSach , @soHD , @soLuongBan , @giaBan ", new object[] { masach, sohd, soluong, giaban });
        }
        public void XemChiTietHD(string sohd, string masach, int soluong, int gia)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_ThemChiTietHoaDon @maSach , @soHD , @soLuongBan , @giaBan", new object[] { masach, sohd, soluong, gia });
        }

        public DataTable XemThongTinHoaDon(string mahd)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_XemThongTinHD @mahd", new object[] { mahd });
            return data;
        }
       public DataTable LayDSHoaDon(DateTime NgayBan1, DateTime NgayBan2)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_HienThiHoaDon @NgayBan1 , @NgayBan2", new object[] { NgayBan1 , NgayBan2 });
            return data;
        }
        public void CheckOut(int SoHD, float TongTriGia)
        {
            string query = "UPDATE dbo.HoaDon SET NgayBan = GETDATE(), TongTriGia = " + TongTriGia + " WHERE SoHD = " + SoHD;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

    }
}
