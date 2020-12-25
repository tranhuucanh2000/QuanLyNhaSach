using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DTO
{
    public class Sach
    {
        private string maSach;
        private string tenSach;
        private int soLuongTon;
        private string maTL;
        private string maTG;
        private string maNXB;
        private int giaTien;
        private string kinhDoanh;

        public string TenSach { get => tenSach; set => tenSach = value; }
        public string MaSach { get => maSach; set => maSach = value; }

        public string MaTL { get => maTL; set => maTL = value; }
        public int SoLuongTon { get => soLuongTon; set => soLuongTon = value; }
        public string MaTG { get => maTG; set => maTG = value; }
        public string MaNXB { get => maNXB; set => maNXB = value; }
        public int GiaTien { get => giaTien; set => giaTien = value; }
        public string KinhDoanh { get => kinhDoanh; set => kinhDoanh = value; }

        public Sach() { }
        public Sach(string masach,string tensach, int soluongton, string matl, string matg, string manxb, int giatien, string kinhdoanh)
        {
            this.maSach = masach;
            this.tenSach = tensach;
            this.soLuongTon = soluongton;
            this.maTL = matl;
            this.maTG = matg;
            this.maNXB = manxb;
            this.giaTien = giatien;
            this.kinhDoanh = kinhdoanh;
        }
        public Sach(DataRow row)
        {
            this.maSach = row["MaSach"].ToString();
            this.tenSach = row["TenSach"].ToString();
            this.soLuongTon = int.Parse(row["SoLuongTon"].ToString());
            this.maTL = row["MaTL"].ToString();
            this.maTG = row["MaTG"].ToString();
            this.maNXB = row["MaNXB"].ToString();
            this.giaTien = int.Parse(row["GiaTien"].ToString());
            this.kinhDoanh = row["KinhDoanh"].ToString();
        }
    }
}
