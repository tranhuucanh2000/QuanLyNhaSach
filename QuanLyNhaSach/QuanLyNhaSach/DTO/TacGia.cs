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
        private string maTG;
        private string tenTG;
        private string lienLac;


        public string TenTG { get => tenTG; set => tenTG = value; }
        public string LienLac { get => lienLac; set => lienLac = value; }
        public string MaTG { get => maTG; set => maTG = value; }

        public TacGia() { }
        public TacGia(string matg, string tentg, string lienlac)
        {
            this.maTG = matg;
            this.tenTG = tentg;
            this.lienLac = lienlac;
        }
        public TacGia(DataRow row)
        {
            this.maTG = row["MaTG"].ToString();
            this.tenTG = row["TenTG"].ToString();
            this.lienLac = row["LienLac"].ToString();
        }
    }
}
