using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    public class BaoCaoCongNo_DTO
    {
        private int MaBaoCaoCongNo;
        private DateTime Thang;
        private DateTime NgayLap;

        public BaoCaoCongNo_DTO(DateTime thang1, DateTime ngayLap1)
        {
            this.Thang1 = thang1;
            this.NgayLap1 = ngayLap1;
        }

        public int MaBaoCaoCongNo1
        {
            get
            {
                return MaBaoCaoCongNo;
            }
            set
            {
                MaBaoCaoCongNo = value;
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
