using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    public class ChiTietBaoCaoCongNo_DTO
    {
        private int MaChiTietBaoCaoCongNo;
        private int MaBaoCaoCongNo;
        private int MaKhachHang;
        private int NoDau;
        private int PhatSinh;
        private int NoCuoi;

        public ChiTietBaoCaoCongNo_DTO(int maBaoCaoCongNo, int maKH, int noDau, int phatSinh, int noCuoi)
        {
            this.MaBaoCaoCongNo1 = maBaoCaoCongNo;
            this.MaKhachHang1 = maKH;
            this.NoDau1 = noDau;
            this.PhatSinh1 = phatSinh;
            this.NoCuoi1 = noCuoi;
        }

        public int MaChiTietBaoCaoCongNo1
        {
            get
            {
                return MaChiTietBaoCaoCongNo;
            }
            set
            {
                MaChiTietBaoCaoCongNo = value;
            }
        }



        public int NoDau1
        {
            get
            {
                return NoDau;
            }
            set
            {
                NoDau = value;
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

        public int NoCuoi1
        {
            get
            {
                return NoCuoi;
            }
            set
            {
                NoCuoi = value;
            }
        }

        public int MaBaoCaoCongNo1
        {
            get
            {
                return MaBaoCaoCongNo;
            }
            set
            {
                MaBaoCaoCongNo = value;
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
