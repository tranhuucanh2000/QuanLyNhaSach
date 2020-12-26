using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace DTO
{
    using System;

    public class PhieuNhapSach_DTO
    {
        private int MaPhieuNhap;
        private DateTime NgayNhap;

        public PhieuNhapSach_DTO()
        {
        }

        public int MaPhieuNhap1
        {
            get
            {
                return MaPhieuNhap;
            }
            set
            {
                MaPhieuNhap = value;
            }
        }

        public DateTime NgayNhap1
        {
            get
            {
                return NgayNhap;
            }
            set
            {
                NgayNhap = value;
            }
        }
    }

}
