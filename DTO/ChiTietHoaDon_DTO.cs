using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    public class ChiTietHoaDon_DTO
    {
        private int MaChiTietHoaDon;
        private int MaHoaDon;
        private int MaSach;
        private int SoLuongban;
        private double DonGiaBan;

        public ChiTietHoaDon_DTO()
        {
        }

        public ChiTietHoaDon_DTO(int mact, int mahd, int masach, int sl)
        {
            this.MaChiTietHoaDon1 = mact;
            this.MaHoaDon1 = mahd;
            this.MaSach1 = masach;
            this.SoLuongban1 = sl;
        }

        public int MaChiTietHoaDon1
        {
            get
            {
                return MaChiTietHoaDon;
            }
            set
            {
                MaChiTietHoaDon = value;
            }
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

        public int MaSach1
        {
            get
            {
                return MaSach;
            }
            set
            {
                MaSach = value;
            }
        }

        public int SoLuongban1
        {
            get
            {
                return SoLuongban;
            }
            set
            {
                SoLuongban = value;
            }
        }

        public double DonGiaBan1
        {
            get
            {
                return DonGiaBan;
            }
            set
            {
                DonGiaBan = value;
            }
        }
    }

}
