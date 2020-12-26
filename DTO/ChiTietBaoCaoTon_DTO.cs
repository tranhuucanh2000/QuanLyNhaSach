using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;


namespace DTO
{
    public class ChiTietBaoCaoTon_DTO
    {
        private int MaChiTietBaoCaoTon;
        private int MaBaoCaoTon;
        private int MaSach;
        private int TonDau;
        private int PhatSinh;
        private int TonCuoi;

        public ChiTietBaoCaoTon_DTO(int maBaoCaoTon, int maSach, int tonDau, int phatSinh, int tonCuoi)
        {
            this.MaBaoCaoTon = maBaoCaoTon;
            this.MaSach = maSach;
            this.TonDau = tonDau;
            this.PhatSinh = phatSinh;
            this.TonCuoi = tonCuoi;
        }

        public int MaChiTietBaoCaoTon1
        {
            get
            {
                return MaChiTietBaoCaoTon;
            }
            set
            {
                MaChiTietBaoCaoTon = value;
            }
        }

        public int MaBaoCaoTon1
        {
            get
            {
                return MaBaoCaoTon;
            }
            set
            {
                MaBaoCaoTon = value;
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

        public int TonDau1
        {
            get
            {
                return TonDau;
            }
            set
            {
                TonDau = value;
            }
        }

        public int PhatSinh1
        {
            get
            {
                return PhatSinh;
            }
            set
            {
                PhatSinh = value;
            }
        }

        public int TonCuoi1
        {
            get
            {
                return TonCuoi;
            }
            set
            {
                TonCuoi = value;
            }
        }
    }

}
