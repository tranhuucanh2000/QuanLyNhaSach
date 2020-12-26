using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    public class TacGiaDAO
    {
        private static TacGiaDAO instance;

        public static TacGiaDAO Instance 
        { 
            get { if (instance == null) instance = new TacGiaDAO();return instance; } 
            set => instance = value; 
        }

        public void ThemTacGia(string ten, string sdt)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_ThemTacGia @tentg , @sdt ", new object[] { ten, sdt });
        }
        public void SuaTacGia(string tentg,string sdt, string matg)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_SuaTacGia @tentg , @sdt , @matg ", new object[] { tentg, sdt, matg });
        }
    }
}
