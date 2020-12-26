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
using DAL;
using Utility;

namespace BUS
{


    public class ChiTietBaoCaoCongNo_BUS
    {
        private ChiTietBaoCaoCongNo_DAL chiTietBaoCaoCongNoDAL = new ChiTietBaoCaoCongNo_DAL();

        public Result ThongKeBaoCaoCongNo(int Thang, int Nam)
        {
            return chiTietBaoCaoCongNoDAL.ThongKeBaoCaoCongNo(Thang, Nam);
        }

        public Result insert(ChiTietBaoCaoCongNo_DTO x)
        {
            return chiTietBaoCaoCongNoDAL.insert(x);
        }
    }

}
