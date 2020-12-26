using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using Microsoft.VisualBasic;
using DTO;
using DAL;
using Utility;

namespace BUS
{


    public class BaoCaoTon_BUS
    {
        private BaoCaoTon_DAL baoCaoTonDAL = new BaoCaoTon_DAL();

        public Result insert(BaoCaoTon_DTO x)
        {
            return baoCaoTonDAL.insert(x);
        }

        public Result GetNextIncrement()
        {
            return baoCaoTonDAL.GetNextIncrement();
        }
    }

}
