using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    public class SachDAO
    {
        private static SachDAO instance;
        public static SachDAO Instance
        { 
            get { if (instance == null) instance = new SachDAO(); return instance; }
            private set => instance = value; 
        }

        public DataTable LayDSSach()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_HienThiSach");
            return data;
        }
        public DataTable TimSachQuaTen(string tenSach)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSach_TenSach @tenSach", new object[] { tenSach });   
            return data;
        }
        public DataTable TimSachQuaTheLoai(string theLoai)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSach_TheLoai @theLoai", new object[] { theLoai });
            return data;
        }
        public DataTable TimSachQuaTacGia(string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSach_TacGia @tacGia", new object[] { tacGia });
            return data;
        }

        public DataTable TimSachQuaTenVaTacGia(string ten, string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSach_TenSach_TacGia @tenSach , @tacGia", new object[] { ten , tacGia});
            return data;
        }
        public DataTable TimSachQuaTenVaTheLoai(string ten, string theLoai)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSach_TenSach_TheLoai @tenSach , @theLoai", new object[] { ten,theLoai });
            return data;
        }
        public DataTable TimSachQuaTheLoaiVaTacGia(string theLoai, string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSach_TacGia_TheLoai @tacGia , @theLoai", new object[] { tacGia,theLoai });
            return data;
        }
        public DataTable TimSachQuaTenVaTheLoaiVaTacGia(string ten, string theLoai, string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSach_TenSach_TacGia_TheLoai @tenSach , @tacGia , @theLoai", new object[] { ten,tacGia,theLoai });
            return data;
        }
        public void ThanhToanSach(string maSach, string soLuong)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_ThanhToanSach @maSach , @soLuong", new object[] { maSach, int.Parse(soLuong) });
        }
        public DataTable LayDSSachTK()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_HIenThiSachTimKiem");
            return data;
        }
        public DataTable LayDSTacGia()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_HienThiTacGia");
            return data;
        }
        public DataTable LayDSTheLoai()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_HienThiTheLoai");
            return data;
        }
        public DataTable LayDSNXB()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_HienThiNhaXuatBan");
            return data;
        }
        public void ThemSLChoSach(string masach, int soluong)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_ThemSLChoSach @maSach , @soluong", new object[] { soluong,masach });
        }
        public void ThemSach(string masach, string tensach, string sopn, string matl, string matg, string manxb, int soluong, int giatien)
        {
            string date = DateTime.Today.ToShortDateString();
            DataProvider.Instance.ExecuteNonQuery("USP_ThemSach @masach , @tenSach , @sopn , @soluong , @giatien , @matl , @matg , @manxb , @ngaynhap", new object[] { masach, tensach, sopn, soluong, giatien, matl, matg, manxb, date });
        }
    }
}
