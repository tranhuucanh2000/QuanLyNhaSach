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
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach ");
            return data;
        }
        public DataTable TimSachQuaTen(string tenSach)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSachQuaTenSach @tenSach", new object[] { tenSach });   
            return data;
        }
        public DataTable TimSachQuaTheLoai(string theLoai)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSachQuaTheLoai @theLoai", new object[] { theLoai });
            return data;
        }
        public DataTable TimSachQuaTacGia(string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSachQuaTacGia @tacGia", new object[] { tacGia });
            return data;
        }

        public DataTable TimSachQuaTenVaTacGia(string ten, string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSachQuaTenVaTacGia @tenSach , @tacGia", new object[] { ten , tacGia});
            return data;
        }
        public DataTable TimSachQuaTenVaTheLoai(string ten, string theLoai)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSachQuaTenVaTheloai @tenSach , @theLoai", new object[] { ten,theLoai });
            return data;
        }
        public DataTable TimSachQuaTheLoaiVaTacGia(string theLoai, string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSachQuaTheLoaiVaTacGia @tacGia , @theLoai", new object[] { tacGia,theLoai });
            return data;
        }
        public DataTable TimSachQuaTenVaTheLoaiVaTacGia(string ten, string theLoai, string tacGia)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_TimSachQuaTenVaTheLoaiVaTacGia @tacGia , @theLoai , @tenSach", new object[] { tacGia,theLoai,ten });
            return data;
        }
        public void ThanhToanSach(string tenSach, string soLuong)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USN_ThanhToanSach @tenSach , @soLuong", new object[] { tenSach, int.Parse(soLuong) });
        }
    }
}
