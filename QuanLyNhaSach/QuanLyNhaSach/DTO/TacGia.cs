using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DTO
{
    public class TacGia
    {
        private string ma;
        private string tenTG;
        private string lienLac;

        public string Ma { get => ma; set => ma = value; }
        public string TenTG { get => tenTG; set => tenTG = value; }
        public string LienLac { get => lienLac; set => lienLac = value; }

        public TacGia() { }
        public TacGia(string matg, string tentg, string lienlac)
        {
            this.ma = matg;
            this.tenTG = tentg;
            this.lienLac = lienlac;
        }
        public TacGia(DataRow row)
        {
            this.ma = row["MaTG"].ToString();
            this.tenTG = row["TenTG"].ToString();
            this.lienLac = row["LienLac"].ToString();
        }
    }
}
