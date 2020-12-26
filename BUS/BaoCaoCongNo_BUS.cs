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
    public class BaoCaoCongNo_BUS
    {
        private BaoCaoCongNo_DAL baoCaoCongNoDAL = new BaoCaoCongNo_DAL();

        public Result insert(BaoCaoCongNo_DTO x)
        {
            return baoCaoCongNoDAL.insert(x);
        }

        public Result GetNextIncrement()
        {
            return baoCaoCongNoDAL.GetNextIncrement();
        }
    }
}
