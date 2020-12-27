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
        public void TTKinhDoanhSach(string masach)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_TTKinhDoanhSach @maSach", new object[] { masach });
        }
        public void NgungKinhDoanhSach(string masach)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_NgungKinhDoanhSach @maSach", new object[] { masach });
        }
        public DataTable LayTatCaSach()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_LayTatCaSach");
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
        public DataTable TimKiemSach_QuaTen(string tenSach)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimKiemSach_TenSach @tenSach", new object[] { tenSach });
            return data;
        }

        public DataTable TimKiemSach_QuaTacGia(string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimKiemSach_TacGia @tacGia", new object[] { tacGia });
            return data;
        }

        public DataTable TimKiemSach_QuaTheLoai(string theLoai)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimKiemSach_TheLoai @theLoai", new object[] { theLoai });
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
        public void ThemSLChoSach(string sopn, int soluong, string masach, int giatien, string manxb)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_ThemSLChoSach @soPn , @maSach , @soluong , @giatien , @ngaynhap , @manxb ", new object[] {  sopn, masach,soluong,giatien,DateTime.Now.Date,manxb});
        }
        public void ThemSach(string sopn, string masach, string tensach, string matl, string matg, string manxb, int soluong, int giatien)
        {
            string date = string.Concat(DateTime.Today.Day, "-",DateTime.Today.Month, "-", DateTime.Today.Year);
            DataProvider.Instance.ExecuteNonQuery("USP_ThemSach @soPn , @maSach , @tenSach , @soluong , @giatien , @matl , @matg , @manxb , @ngaynhap", new object[] { sopn, masach , tensach, soluong, giatien, matl, matg, manxb, DateTime.Today });
        }
        public void ThemTacGia(string tentg, string sdt)
        {

            DataProvider.Instance.ExecuteNonQuery("USP_ThemTacGia @tentg , @sdt ", new object[] { tentg, sdt });
        }
        public void ThemTheLoai(string tentl)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_ThemTheLoai @tentl ", new object[] { tentl });
        }
        public void ThemNhaXuatBan(string tennxb,string diachi,string sdt)
        {
          
            DataProvider.Instance.ExecuteNonQuery("USP_ThemNhaXuatBan @tennxb , @diachi , @sdt ", new object[] { tennxb, diachi, sdt });
        }
        public void SuaTheLoai(String tentl, string matl)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_SuaTheLoai @tentl , @matl ", new object[] { tentl, matl });
        }
        public void SuaTacGia(string tentg, string sdt, string matg)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_SuaTacGia @tentg , @sdt , @matg ", new object[] { tentg, sdt, matg });
        }
        public void SuaNhaXuatBan(String tennxb, string sdt, string diachi, string manxb)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_SuaNhaXuatBan @tennxb , @sdt , @diachi , @manxb ", new object[] { tennxb, sdt, diachi, manxb });
        }
        public void SuaSach(string tensach, string soluong, string giatien, string masach)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_SuaSach @tensach , @soluong , @giatien , @masach ", new object[] { tensach, soluong, giatien, masach });
        }
        public void XoaSach(string masach)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_XoaSach @masach ", new object[] { masach });
        }
        public void QuenMatKhau(string mkmoi, string matk)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_CapNhatMatKhau @mkmoi , @matk ", new object[] { mkmoi, matk });
        }
       
    }
}
