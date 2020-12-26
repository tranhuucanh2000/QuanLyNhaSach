using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    public class Sach_DTO
    {
        private int MaSach;
        private string TenSach;
        private string TheLoai;
        private string TacGia;
        private int SoLuongTon;
        private float DonGia;

        public Sach_DTO()
        {

        }


        public Sach_DTO(int ma, string ten, string loai, string tacGia, int slTon, float gia)
        {
            this.MaSach = ma;
            this.TenSach = ten;
            this.TheLoai = loai;
            this.TacGia = tacGia;
            this.SoLuongTon = slTon;
            this.DonGia = gia;
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

        public string TenSach1
        {
            get
            {
                return TenSach;
            }
            set
            {
                TenSach = value;
            }
        }

        public string TheLoai1
        {
            get
            {
                return TheLoai;
            }
            set
            {
                TheLoai = value;
            }
        }

        public string TacGia1
        {
            get
            {
                return TacGia;
            }
            set
            {
                TacGia = value;
            }
        }

        public int SoLuongTon1
        {
            get
            {
                return SoLuongTon;
            }
            set
            {
                SoLuongTon = value;
            }
        }

        public float DonGia1
        {
            get
            {
                return DonGia;
            }
            set
            {
                DonGia = value;
            }
        }
    }

}
