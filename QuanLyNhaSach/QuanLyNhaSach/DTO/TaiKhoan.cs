using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DTO
{
    public class TaiKhoan
    {
        private int nhapSach;
        private int thongKe;
        private int keSach;
        private int themDuLieu;
        private string tenDN;
        private string ten;
        private string passWord;
        private int type;
        private int caiDat;
        private int banSach;
        private int ttTaiKhoan;
        private string ma;
        public string TenDN { get => tenDN; set => tenDN = value; }
        public string Ten { get => ten; set => ten = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
        public int NhapSach { get => nhapSach; set => nhapSach = value; }
        public int ThongKe { get => thongKe; set => thongKe = value; }
        public int KeSach { get => keSach; set => keSach = value; }
        public int ThemDuLieu { get => themDuLieu; set => themDuLieu = value; }
        public int CaiDat { get => caiDat; set => caiDat = value; }
        public int BanSach { get => banSach; set => banSach = value; }
        public int TtTaiKhoan { get => ttTaiKhoan; set => ttTaiKhoan = value; }
        //public string Ma { get => ma; set => ma = value;

        public TaiKhoan () { }
        public TaiKhoan(string tendn,string ten, int type , int thongke, int nhapsach,int kesach,int themdulieu, int caidat, int tttaikhoan, int bansach, string pass = null)
        {
            this.TenDN = tendn;
            this.Ten = ten;
            this.PassWord = pass;
            this.Type = type;
            this.KeSach = kesach;
            this.NhapSach = nhapsach;
            this.ThemDuLieu = themdulieu;
            this.ThongKe = thongke;
            this.TtTaiKhoan = ttTaiKhoan;
            this.banSach = bansach;
            this.caiDat = caidat;
        }
        public TaiKhoan(DataRow row)
        {
            this.TenDN = row["TenDN"].ToString();
            this.Ten = row["HoTen"].ToString();
            this.PassWord = row["MatKhau"].ToString();
            this.Type = int.Parse(row["Loai"].ToString());
            this.NhapSach = int.Parse(row["NhapSach"].ToString());
            this.ThemDuLieu = int.Parse(row["ThongKe"].ToString());
            this.KeSach = int.Parse(row["KeSach"].ToString());
            this.ThongKe = int.Parse(row["ThongKe"].ToString());
            this.caiDat = int.Parse(row["CaiDat"].ToString());
            this.banSach = int.Parse(row["BanSach"].ToString());
            this.TtTaiKhoan = int.Parse(row["TTTaiKhoan"].ToString());
            this.ma = row["Ma"].ToString();
        }
    }
}
