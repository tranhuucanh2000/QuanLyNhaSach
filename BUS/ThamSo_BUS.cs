using System;
using Utility;
using DAL;
using System.Text.RegularExpressions;
using DTO;


namespace BUS
{
   

    public class ThamSo_BUS
    {
        private ThamSo_DAL thamSoDAL;

        public ThamSo_BUS()
        {
            thamSoDAL = new ThamSo_DAL();
        }

        public Result isValidSoLuongNhapToiThieu(string text)
        {
            if ((text.Length < 1))
                return new Result(false, null, "Số lượng nhập tối thiểu không được bỏ trống!");
            if ((Regex.IsMatch(text, "^[0-9]*$") == false))
                return new Result(false, null, "Số lượng nhập tối thiểu phải là số nguyên không âm!");

            return new Result(true);
        }


        public Result isValidSoLuongTonToiDa(string text)
        {
            if ((text.Length < 1))
                return new Result(false, null, "\"Số lượng tồn tối đa cho phép nhập\" không được bỏ trống!");
            if ((Regex.IsMatch(text, "^[0-9]*$") == false))
                return new Result(false, null, "\"Số lượng tồn tối đa cho phép nhập\" phải là số nguyên không âm!");

            return new Result(true);
        }

        public Result isValidSoLuongTonToiThieu(string text)
        {
            if ((text.Length < 1))
                return new Result(false, null, "\"Số lượng tồn tối thiểu sau khi bán\" không được bỏ trống!");
            if ((Regex.IsMatch(text, "^[0-9]*$") == false))
                return new Result(false, null, "\"Số lượng tồn tối thiểu sau khi bán\" phải là số nguyên không âm!");

            return new Result(true);
        }

        public Result isValidSoTienNoToiDa(string text)
        {
            if ((text.Length < 1))
                return new Result(false, null, "Số tiền nợ tối đa được bỏ trống!");
            if ((Regex.IsMatch(text, @"^[0-9]*\.?[0-9]+$") == false))
                return new Result(false, null, "Số tiền nợ tối đa không hợp lệ." + Environment.NewLine + "Chỉ có thể chứa số 0-9 và dấu chấm!");
            return new Result(true);
        }

        public Result Update(ThamSo_DTO thamsoDTO)
        {
            return thamSoDAL.Update(thamsoDTO);
        }

        public Result SelectAll_ThamSo()
        {
            return thamSoDAL.SelectAll_ThamSo();
        }
    }

}
