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
  

    public class ChiTietBaoCaoTon_BUS
    {
        private ChiTietBaoCaoTon_DAL chiTietBaoCaoTonDAL = new ChiTietBaoCaoTon_DAL();


        /// <summary>
        ///     ''' Lấy dữ liệu tính toán được từ DB
        ///     ''' </summary>
        ///     ''' <param name="x"></param>
        ///     ''' <returns></returns>
        public Result ThongKeBaoCaoTon(int Thang, int Nam)
        {
            return chiTietBaoCaoTonDAL.ThongKeBaoCaoTon(Thang, Nam);
        }

        public Result insert(ChiTietBaoCaoTon_DTO x)
        {
            return chiTietBaoCaoTonDAL.insert(x);
        }
    }

}
