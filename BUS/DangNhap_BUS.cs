using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using DTO;
using Utility;
using DAL;

namespace BUS
{
  

    public class DangNhap_BUS
    {
        private DangNhap_DAL dangNhapDAL = new DangNhap_DAL();

        public Result update(DangNhap_DTO x)
        {
            return dangNhapDAL.update(x);
        }

        public Result KiemTraDangNhap(DangNhap_DTO x)
        {
            return dangNhapDAL.KiemTraDangNhap(x);
        }
    }

}
