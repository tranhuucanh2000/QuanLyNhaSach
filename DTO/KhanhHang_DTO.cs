using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    public class KhachHang_DTO
    {
        private int MaKH;
        private string HoTenKhachHang;
        private string DiaChi;
        private string DienThoai;
        private string Email;
        private double TienNo;


        public KhachHang_DTO()
        {
        }

        public KhachHang_DTO(int maKH, string hoTenKhachHang, string diaChi, string dienThoai, string email, double tienNo)
        {
            this.MaKH = maKH;
            this.HoTenKhachHang = hoTenKhachHang;
            this.DiaChi = diaChi;
            this.DienThoai = dienThoai;
            this.Email = email;
            this.TienNo = tienNo;
        }

        public int MaKH1
        {
            get
            {
                return MaKH;
            }
            set
            {
                MaKH = value;
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

        public double TienNo1
        {
            get
            {
                return TienNo;
            }
            set
            {
                TienNo = value;
            }
        }

        public string DiaChi1
        {
            get
            {
                return DiaChi;
            }
            set
            {
                DiaChi = value;
            }
        }

        public string DienThoai1
        {
            get
            {
                return DienThoai;
            }
            set
            {
                DienThoai = value;
            }
        }

        public string Email1
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }
    }

}
