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
using DAL;
using Utility;
using DTO;
using System.Text.RegularExpressions;


namespace BUS
{

    public class PhieuNhapSach_BUS
    {
        private PhieuNhapSach_DAL phieuNhapDAL;

        public PhieuNhapSach_BUS()
        {
            phieuNhapDAL = new PhieuNhapSach_DAL();
        }

        public Result insertPhieuNhap(PhieuNhapSach_DTO x)
        {
            return phieuNhapDAL.insertPhieuNhap(x);
        }

        public Result GetNextIncrement()
        {
            return phieuNhapDAL.GetNextIncrement();
        }
    }

}
