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
using System.Data.SqlClient;


namespace BUS
{


    public class PhieuThuTien_BUS
    {
        private PhieuThuTien_DAL phieuThuTienDAL;
        private ThamSo_BUS thamSoBUS = new ThamSo_BUS();
        private ThamSo_DTO thamSoDTO;
        private Result Res;


        public PhieuThuTien_BUS()
        {
            phieuThuTienDAL = new PhieuThuTien_DAL();
        }

        
        public Result GetNextIncrement()
        {
            return phieuThuTienDAL.GetNextIncrement();
        }

        public Result IsValidSoTienThu(string text, double tienno)
        {
            if ((text.Length < 1))
                return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Vui lòng nhập số tiền thu!");

            if ((Regex.IsMatch(text, @"^[0-9]*\.?[0-9]+$") == false))
                return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Số tiền không hợp lệ." + Environment.NewLine + "Chỉ có thể chứa số 0-9 và dấu chấm!");


            if ((double.Parse(text) <= 0))
                return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Số tiền thu phải lớn hơn 0!");



            Res = thamSoBUS.SelectAll_ThamSo();
            if ((Res.FlagResult == false))
                return Res;
            thamSoDTO = (ThamSo_DTO)Res.Obj1;


            if (thamSoDTO.SuDungQD41 == true)
            {
                if (double.Parse(text) > tienno)
                    return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Số tiền được phép thu không được lớn hơn số tiền KH đang nợ!");
            }

            return new Result(true);
        }

        public Result IsValidMaPhieuThu(string text)
        {
            if ((text.Length < 1))
                return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Chưa nhập mã phiếu thu!");
            if ((Regex.IsMatch(text, @"^[0-9]*\.?[0-9]+$") == false))
                return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Mã phiếu không hợp lệ." + Environment.NewLine + "Chỉ có thể chứa số 0-9!");
            return new Result(true);
        }

        public Result SelectAll_ListPhieuThuTienByMaPhieu(int v)
        {
            return phieuThuTienDAL.SelectAll_ListPhieuThuTienByMaPhieu(v);
        }

        public Result SelectAll_ListPhieuThuTien()
        {
            return phieuThuTienDAL.SelectAll_ListPhieuThuTien();
        }

        public Result insert(PhieuThuTien_DTO phieuThuTienDTO)
        {
            return phieuThuTienDAL.insert(phieuThuTienDTO);
        }
    }

}
