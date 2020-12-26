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
   
    public class ChiTietHoaDon_BUS
    {
        private ChiTietHoaDon_DAL chiTietHoaDonDAL;
        private Result res;
        private ThamSo_BUS thamSoBUS = new ThamSo_BUS();
        private ThamSo_DTO ts;


        public ChiTietHoaDon_BUS()
        {
            chiTietHoaDonDAL = new ChiTietHoaDon_DAL();
        }

        public Result insertChiTietHoaDon(ChiTietHoaDon_DTO x)
        {
            return chiTietHoaDonDAL.insertChiTietHoaDon(x);
        }

        public Result GetNextIncrement()
        {
            return chiTietHoaDonDAL.GetNextIncrement();
        }



        /// <summary>
        ///     '''  trả về false, và object là "số lượng tồn tối thiểu", nếu vi phạm quy định
        ///     ''' </summary>
        ///     ''' <param name="SLSauTon"></param>
        ///     ''' <returns></returns>
        public Result isValidSoLuongSachTon(int SLSauTon)
        {
            res = thamSoBUS.SelectAll_ThamSo();
            ts = (ThamSo_DTO)res.Obj1;
            if ((System.Convert.ToInt32(SLSauTon) < ts.SoLuongTonToiThieu1))
                return new Result(false, ts.SoLuongTonToiThieu1, "Sách có lượng tồn sau khi bán phải ít nhất là " + ts.SoLuongTonToiThieu1.ToString());
            return new Result(true);
        }

        public Result isValidSoLuongBan(string v)
        {
            if ((v == string.Empty))
                return new Result(false, null, "Số lượng tồn không được bỏ trống!");
            if ((v.Length < 1))
                return new Result(false, null, "Số lượng tồn không được bỏ trống!");
            if ((Regex.IsMatch(v, "^[0-9]*$") == false))
                return new Result(false, null, "Lượng tồn phải là số nguyên lớn hơn 0!");

            return new Result(true);
        }
    }

}
