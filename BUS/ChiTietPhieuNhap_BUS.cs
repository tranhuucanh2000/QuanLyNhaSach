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
   
    public class ChiTIetPhieuNhap_BUS
    {
        private ChiTietPhieuNhap_DAL chiTietPhieuNhapDAL = new ChiTietPhieuNhap_DAL();
        private Result res;
        private ThamSo_BUS thamSoBUS = new ThamSo_BUS();
        private ThamSo_DTO ts;


        public ChiTIetPhieuNhap_BUS()
        {
            res = thamSoBUS.SelectAll_ThamSo();
            ts = (ThamSo_DTO)res.Obj1;
        }

        public Result insertChiTietPhieuNhap(ChiTIetPhieuNhap_DTO x)
        {
            return chiTietPhieuNhapDAL.insertChiTietPhieuNhap(x);
        }

        public Result GetNextIncrement()
        {
            return chiTietPhieuNhapDAL.GetNextIncrement();
        }

        public Result select_MaPhieuNhap()
        {
            return chiTietPhieuNhapDAL.select_MaPhieuNhap();
        }

        public Result isValidSoLuongNhap(string text)
        {
            if ((text == string.Empty))
                return new Result(false, null, "Số lượng nhập tối thiểu không được bỏ trống!");

            if ((text == ""))
                return new Result(false, null, "Số lượng nhập tối thiểu không được bỏ trống!");

            if ((text.Length < 1))
                return new Result(false, null, "Số lượng nhập tối thiểu không được bỏ trống!");

            if ((Regex.IsMatch(text, "^[0-9]*$") == false))
                return new Result(false, null, "Số lượng nhập tối thiểu phải là số nguyên không âm!");

            return new Result(true);
        }


        public Result isValidSoLuongNhapToiThieu(string text)
        {
            if ((System.Convert.ToInt32(text) < ts.SoLuongNhapToiThieu1))
                return new Result(false, null, "Số lượng nhập ít nhất là " + ts.SoLuongNhapToiThieu1.ToString());

            return new Result(true);
        }


        public Result isValidSoLuongTonToiDa(string text)
        {
            if ((System.Convert.ToInt32(text) >= ts.SoLuongTonToiDa1))
                return new Result(false, null, "Chỉ được nhập vào sách có lượng tồn < " + ts.SoLuongTonToiDa1.ToString());

            return new Result(true);
        }
    }

}
