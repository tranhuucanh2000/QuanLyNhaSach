using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    public class DangNhap_DTO
    {
        private int id;
        private string TenDangNhap;
        private string MatKhau;

        public int Id1
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string TenDangNhap1
        {
            get
            {
                return TenDangNhap;
            }
            set
            {
                TenDangNhap = value;
            }
        }

        public string MatKhau1
        {
            get
            {
                return MatKhau;
            }
            set
            {
                MatKhau = value;
            }
        }
    }

}
