using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    public class PhieuNhapDAO
    {
        private static PhieuNhapDAO instance;

        public static PhieuNhapDAO Instance 
        { 
            get { if (instance == null) instance = new PhieuNhapDAO();return instance; } 
            set => instance = value; 
        }

        public DataTable XemPhieuNhap(DateTime ngaydau, DateTime ngaycuoi)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(" EXEC USP_HienThiPhieuNhap @NgayDau , @NgayCuoi", new object[] { ngaydau, ngaycuoi });
            return data;
        }

        public DataTable XemTTPhieuNhap(string mapn)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_XemTTPhieuNhap @soPN", new object[] { mapn });
            return data;
        }
    }
}
