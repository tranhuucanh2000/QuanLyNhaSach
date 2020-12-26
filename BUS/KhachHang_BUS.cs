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
  

    public class KhachHang_BUS
    {
        private KhachHang_DAL khDAL;
        private Result res;
        public KhachHang_BUS()
        {
            khDAL = new KhachHang_DAL();
        }

        public Result  selectTienNo_KhachHang(int x)
        {
            return khDAL.SelectTienNo_KhachHang(x);
        }

        public Result selectTenKH_ByMaKH(int x)
        {
            return khDAL.selectTenKH_ByMaKH(x);
        }

        public Result GetNextIncrement()
        {
            return khDAL.GetNextIncrement();
        }

        public Result insert(KhachHang_DTO x)
        {
            return khDAL.insert(x);
        }

        public Result isValidHoTen(string text)
        {
            if ((text.Length < 1))
                return new Result(false, null, "Vui lòng nhập tên khách hàng!");
            return new Result(true);
        }

        public Result SelectALL_ListKhachHang()
        {
            return khDAL.SelectALL_ListKhachHang();
        }

        public Result isValidDienThoai(string text)
        {
            if ((text.Length < 1))
                return new Result(true);

            if ((Regex.IsMatch(text, "^[0-9]*$") == false))
                return new Result(false, null, "Số điện thoại sai định dạng!" + Environment.NewLine + "Vui lòng chỉ nhập số.");
            return new Result(true);
        }

        public Result isValidEmail(string text)
        {
            if ((text.Length < 1))
                return new Result(true);

            if ((Regex.IsMatch(text, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") == false))
                return new Result(false, null, "Địa chỉ email sai định dạng!");

            return new Result(true);
        }

        public Result SelectALL_ListKhachHangByStringMaKHHoTenSDT(string text)
        {
            return khDAL.SelectALL_ListKhachHangByStringMaKHHoTenSDT(text);
        }

        public Result deleteByKhachHang(KhachHang_DTO khachHangDTO)
        {
            return khDAL.deleteByKhachHang(khachHangDTO);
        }

        public Result update(KhachHang_DTO x)
        {
            return khDAL.update(x);
        }

        public Result KiemTraNo(double v)
        {
            ThamSo_BUS thamsoBUS = new ThamSo_BUS();
            res = thamsoBUS.SelectAll_ThamSo();
            if ((res.FlagResult == true))
            {
                ThamSo_DTO thamsoDTO = (ThamSo_DTO)res.Obj1;
                if (v <= thamsoDTO.SoTienNoToiDa1)
                    return new Result(true);
                else
                    return new Result(false, null, "Khách hàng này đang nợ hơn " + Math.Round(thamsoDTO.SoTienNoToiDa1, 3).ToString());
            }
            else
                return new Result(false, null, "Get số tiền nợ tối đa thất bại");
        }

        public Result selectKhachHang_ByMaKH(int maKhachHang1)
        {
            return khDAL.selectKhachHang_ByMaKH(maKhachHang1);
        }
    }

}
