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
  

    public class Sach_BUS
    {
        private Sach_DAL sachDAL;

        public Sach_BUS()
        {
            sachDAL = new Sach_DAL();
        }

        public Result insertSach(Sach_DTO x)
        {
            return sachDAL.insertSach(x);
        }

        public Result isValidMaSach(string ms)
        {
            if ((ms == string.Empty))
                return new Result(false, null, "Mã sách không được bỏ trống!");
            if ((ms.Length < 1))
                return new Result(false, null, "Mã sách không được bỏ trống!");
            if ((Regex.IsMatch(ms, "^[0-9]*$") == false))
                return new Result(false, null, "Mã sách chỉ chứa số!");
            return new Result(true);
        }



        public Result isValidTenSach(string s)
        {
            if ((s == string.Empty))
                return new Result(false, null, "Tên sách không được bỏ trống!");
            if ((s.Length < 1))
                return new Result(false, null, "Tên sách không được bỏ trống!");
            return new Result(true);
        }

        public Result isValidTheLoai(string s)
        {
            if ((s == string.Empty))
                return new Result(false, null, "Bạn chưa nhập hoặc chọn thể loại sách!");
            if ((s.Length < 1))
                return new Result(false, null, "Bạn chưa nhập hoặc chọn thể loại sách!");
            return new Result(true);
        }


        public Result isValidTacGia(string text)
        {
            if (text == string.Empty)
                return new Result(false, null, "Tên tác giả không được bỏ trống!");
            if ((text.Length < 1))
                return new Result(false, null, "Tên tác giả không được bỏ trống!");
            return new Result(true);
        }


        public Result isValidLuongTon(string text)
        {
            if (text == string.Empty)
                return new Result(false, null, "Số lượng tồn không được bỏ trống!");
            if ((text.Length < 1))
                return new Result(false, null, "Số lượng tồn không được bỏ trống!");
            if ((Regex.IsMatch(text, "^[0-9]*$") == false))
                return new Result(false, null, "Lượng tồn phải là số nguyên lớn hơn 0!");

            return new Result(true);
        }

        public Result SelectALL_ListSach_Advanced(string advanced)
        {
            return sachDAL.SelectALL_ListSach_Advanced(advanced);
        }

        public Result isValidDonGia(string text)
        {
            if (text == string.Empty)
                return new Result(false, null, "Đơn giá không được bỏ trống!");
            if ((text.Length < 1))
                return new Result(false, null, "Đơn giá không được bỏ trống!");
            if ((Regex.IsMatch(text, @"^[0-9]*\.?[0-9]+$") == false))
                return new Result(false, null, "Đơn giá không hợp lệ." + Environment.NewLine + "Chỉ có thể chứa số 0-9 và dấu chấm!");
            return new Result(true);
        }




        /// <summary>
        ///     ''' Lấy mã sách tiếp theo.
        ///     ''' Giá trị trả về nằm trong Object của Result
        ///     ''' </summary>
        ///     ''' <returns></returns>
        ///     '''
        public Result GetNextIncrement()
        {
            return sachDAL.GetNextIncrement();
        }


        public Result SelectALL_ListTheLoai()
        {
            return sachDAL.SelectALL_ListTheLoai();
        }



        public Result SelectALL_ListSach()
        {
            return sachDAL.SelectALL_ListSach();
        }

        public Result updateSach(Sach_DTO x)
        {
            return sachDAL.updateSach(x);
        }

        public Result deleteSach(Sach_DTO sachDTO)
        {
            return sachDAL.deleteSach(sachDTO);
        }


        /// <summary>
        ///     ''' Lấy list SachDTO bằng Mã sách hoặc tên sách
        ///     ''' Phục vụ tìm kiếm
        ///     ''' </summary>
        ///     ''' <returns></returns>
        ///     '''
        public Result SelectALL_ListSachByStringMaSachTenSach(string text)
        {
            return sachDAL.SelectALL_ListSachByStringMaSachTenSach(text);
        }


        public Result selectSach_ByMaSach(int iMaSach)
        {
            return sachDAL.selectSach_ByMaSach(iMaSach);
        }

        public Result SelectALL_ListSachByStringMaSachTenSach_Advanced(string text, string Advanced)
        {
            return sachDAL.SelectALL_ListSachByStringMaSachTenSach_Advanced(text, Advanced);
        }
    }

}
