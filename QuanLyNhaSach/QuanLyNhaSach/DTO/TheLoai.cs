using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DTO
{
    class TheLoai
    {
        private string maTL;
        private string tenTL;

        public string MaTL { get => maTL; set => maTL = value; }
        public string TenTL { get => tenTL; set => tenTL = value; }
        public TheLoai() {  }
        public TheLoai(string matl, string tentl)
        {
            this.maTL = matl;
            this.tenTL = tenTL;
        }
        public TheLoai(DataRow row)
        {
            this.maTL = row["MaTL"].ToString();
            this.tenTL = row["TenTL"].ToString();
        }
    }
}
