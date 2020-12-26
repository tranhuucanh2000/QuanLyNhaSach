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
   

    public class HoaDon_BUS
    {
        private HoaDon_DAL hoaDonDAL;

        public HoaDon_BUS()
        {
            hoaDonDAL = new HoaDon_DAL();
        }

        public Result insertHoaDon(HoaDon_DTO x)
        {
            return hoaDonDAL.insertHoaDon(x);
        }

        public Result GetNextIncrement()
        {
            return hoaDonDAL.GetNextIncrement();
        }
    }

}
