using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    public class TheLoaiDAO
    {
        private static TheLoaiDAO instance;

        public static TheLoaiDAO Instance 
        { 
            get { if (instance == null) instance = new TheLoaiDAO(); return instance; } 
            set => instance = value; 
        }

        public void ThemTheLoai(string tentl)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_ThemTheLoai @tentl ", new object[] { tentl });
        }
        public void SuaTheLoai(string tentl, string matl)
        {
            SachDAO.Instance.SuaTheLoai(tentl, matl);
        }
    }
}
