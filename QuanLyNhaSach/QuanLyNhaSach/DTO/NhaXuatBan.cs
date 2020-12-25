using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DTO
{
    public class NhaXuatBan
    {
        private string ma;
        private string tenNXB;
        private string diaChiNXB;
        private string dienThoai;
        public string Ma { get => ma; set => ma = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }
        public string DiaChiNXB { get => diaChiNXB; set => diaChiNXB = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }

        public NhaXuatBan() { }
        public NhaXuatBan(string manxb, string tennxb, string diachi, string dienthoai)
        {
            this.ma = manxb;
            this.tenNXB = tennxb;
            this.diaChiNXB = diachi;
            this.dienThoai = dienthoai;
        }
        public NhaXuatBan(DataRow row)
        {
            this.ma = row["MaNXB"].ToString();
            this.tenNXB = row["TenNXB"].ToString();
            this.diaChiNXB = row["DiaChiNXB"].ToString();
            this.dienThoai = row["DienThoai"].ToString();
        }
    }
}
