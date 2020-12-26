using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;


namespace DTO
{

    public class HoaDon_DTO
    {
        private int MaHoaDon;
        private DateTime NgayLapHoaDon;
        private int MaKhachHang;

        public HoaDon_DTO(int ma, DateTime ngaylap, int makh)
        {
            this.MaHoaDon = ma;
            this.NgayLapHoaDon = ngaylap;
            this.MaKhachHang = makh;
        }

        public HoaDon_DTO()
        {
        }

        public int MaHoaDon1
        {
            get
            {
                return MaHoaDon;
            }
            set
            {
                MaHoaDon = value;
            }
        }

        public DateTime NgayLapHoaDon1
        {
            get
            {
                return NgayLapHoaDon;
            }
            set
            {
                NgayLapHoaDon = value;
            }
        }

        public int MaKhachHang1
        {
            get
            {
                return MaKhachHang;
            }
            set
            {
                MaKhachHang = value;
            }
        }
    }

}
