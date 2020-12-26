using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{

    public class BaoCaoTon_DTO
    {
        private int MaBaoCaoTon;
        private DateTime Thang;
        private DateTime NgayLap;

        public BaoCaoTon_DTO(DateTime thang, DateTime ngayLap)
        {
            this.Thang = thang;
            this.NgayLap = ngayLap;
        }

        public int MaBaoCaoTon1
        {
            get
            {
                return MaBaoCaoTon;
            }
            set
            {
                MaBaoCaoTon = value;
            }
        }

        public DateTime Thang1
        {
            get
            {
                return Thang;
            }
            set
            {
                Thang = value;
            }
        }

        public DateTime NgayLap1
        {
            get
            {
                return NgayLap;
            }
            set
            {
                NgayLap = value;
            }
        }
    }

}
