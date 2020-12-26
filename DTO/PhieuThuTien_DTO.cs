using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    using System;

    public class PhieuThuTien_DTO
    {
        private int MaPhieuThu;
        private int MaKhachHang;
        private DateTime NgayThuTien;
        private double SoTienThu;
        private string HoTenKhachHang;

        public PhieuThuTien_DTO()
        {
        }

        public PhieuThuTien_DTO(int maPhieuThu, int maKhachHang, DateTime ngayThuTien, double soTienThu,string hoTenKhachHang)
        {
            this.MaPhieuThu = maPhieuThu;
            this.MaKhachHang = maKhachHang;
            this.NgayThuTien = ngayThuTien;
            this.SoTienThu = soTienThu;
            this.HoTenKhachHang = hoTenKhachHang;
        }

        public int MaPhieuThu1
        {
            get
            {
                return MaPhieuThu;
            }
            set
            {
                MaPhieuThu = value;
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

        public DateTime NgayThuTien1
        {
            get
            {
                return NgayThuTien;
            }
            set
            {
                NgayThuTien = value;
            }
        }

        public double SoTienThu1
        {
            get
            {
                return SoTienThu;
            }
            set
            {
                SoTienThu = value;
            }
        }
        public string HoTenKhachHang1
        {
            get
            {
                return HoTenKhachHang;
            }
            set
            {
                HoTenKhachHang = value;
            }
        }
    }

}
