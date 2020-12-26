using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    public class ChiTIetPhieuNhap_DTO
    {
        private int MaChiTietPhieuNhap;
        private int MaPhieuNhap;
        private int MaSach;
        private int SoLuongNhap;

        public ChiTIetPhieuNhap_DTO()
        {
        }

        public ChiTIetPhieuNhap_DTO(int ma, int mapn, int mas, int sl)
        {
            this.MaChiTietPhieuNhap = ma;
            this.MaPhieuNhap = mapn;
            this.MaSach = mas;
            this.SoLuongNhap = sl;
        }

        public int MaChiTietPhieuNhap1
        {
            get
            {
                return MaChiTietPhieuNhap;
            }
            set
            {
                MaChiTietPhieuNhap = value;
            }
        }

        public int MaPhieuNhap1
        {
            get
            {
                return MaPhieuNhap;
            }
            set
            {
                MaPhieuNhap = value;
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

        public int SoLuongNhap1
        {
            get
            {
                return SoLuongNhap;
            }
            set
            {
                SoLuongNhap = value;
            }
        }
    }

}
