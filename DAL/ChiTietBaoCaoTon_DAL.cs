using System.Data.SqlClient;
using DTO;
using Utility;
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
using System.Data;

namespace DAL
{
  

    public class ChiTietBaoCaoTon_DAL
    {
        public Result ThongKeBaoCaoTon(int thang, int nam)
        {
            List<object> listChiTietBaoCao = new List<object>();
            listChiTietBaoCao.Clear();


            string query = @"
 SELECT  thongke.MaSach,sachfull.TenSach, thongke.TonDau, thongke.PhatSinh, thongke.TonCuoi
FROM
(
	SELECT TOP 100 PERCENT ISNULL(tonthang.MaSach, tontruoc.MaSach) MaSach, ISNULL(tontruoc.SLSachTon, 0) TonDau, ISNULL(tonthang.SLSachTon, 0) PhatSinh 
	,ISNULL(tonthang.SLSachTon , 0) + ISNULL(tontruoc.SLSachTon , 0) TonCuoi
	FROM 
	(
		/*Của 1 tháng*/
		 SELECT ISNULL(ctban.MaSach,ctnhap.MaSach) as MaSach,  ISNULL(ctnhap.SLSach,0)- ISNULL(ctban.SLSach,0) as SLSachTon
		FROM   
		(
		 SELECT CHITIETHOADON.MaSach, SUm(CHITIETHOADON.SoLuongBan) SLSach
		  FROM CHITIETHOADON, HOADON
		  WHERE CHITIETHOADON.MaHoaDon = HOADON.MaHoaDon AND MONTH(HOADON.NgayLapHoaDon) = @Thang AND YEAR(HOADON.NgayLapHoaDon) = @Nam
		 GROUP BY CHITIETHOADON.MaSach
		) ctban
		FULL JOIN
		(
			SELECT CHITIETPHIEUNHAP.MaSach, SUm(CHITIETPHIEUNHAP.SoLuongNhap) SLSach
			  FROM CHITIETPHIEUNHAP, PHIEUNHAP
			  WHERE CHITIETPHIEUNHAP.MaPhieuNhap = PHIEUNHAP.MaPhieuNhap AND MONTH(PHIEUNHAP.NgayNhap) = @Thang AND YEAR(PHIEUNHAP.NgayNhap) = @Nam 
			 GROUP BY CHITIETPHIEUNHAP.MaSach
		) ctnhap
		ON ctban.MaSach = ctnhap.MaSach
	) tonthang

	FULL JOIN

	(
		/*Từ đầu đến trước tháng đó*/
		 SELECT ISNULL(ctban.MaSach,ctnhap.MaSach) as MaSach,  ISNULL(ctnhap.SLSach,0)- ISNULL(ctban.SLSach,0) as SLSachTon
		FROM  
		(
		 SELECT CHITIETHOADON.MaSach, SUm(CHITIETHOADON.SoLuongBan) SLSach
		  FROM CHITIETHOADON, HOADON
		  WHERE CHITIETHOADON.MaHoaDon = HOADON.MaHoaDon AND
		 ( (YEAR(HOADON.NgayLapHoaDon) < @Nam) OR	 (	YEAR(HOADON.NgayLapHoaDon) = @Nam AND MONTH(HOADON.NgayLapHoaDon) <@Thang )  )
		 GROUP BY CHITIETHOADON.MaSach
		) ctban 
		FULL JOIN  
		(
			SELECT CHITIETPHIEUNHAP.MaSach, SUm(CHITIETPHIEUNHAP.SoLuongNhap) SLSach
			  FROM CHITIETPHIEUNHAP, PHIEUNHAP
			  WHERE  CHITIETPHIEUNHAP.MaPhieuNhap = PHIEUNHAP.MaPhieuNhap  AND
			   ( (YEAR(PHIEUNHAP.NgayNhap) < @Nam) OR (	YEAR(PHIEUNHAP.NgayNhap) = @Nam	AND	MONTH(PHIEUNHAP.NgayNhap) <@Thang) )	  
			 GROUP BY CHITIETPHIEUNHAP.MaSach
		) ctnhap
		ON ctban.MaSach = ctnhap.MaSach
	) tontruoc
	ON tonthang.MaSach = tontruoc.MaSach

 ) AS thongke, SACH as sachfull
 
WHERE thongke.MaSach = sachfull.MaSach
ORDER BY sachfull.MaSach ASC
";

            int demSTT = 0;

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@Nam", nam);
                        withBlock.Parameters.AddWithValue("@Thang", thang);
                    }
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        SqlDataReader reader;
                        reader = comm.ExecuteReader();
                        if ((reader.HasRows == true))
                        {
                            while (reader.Read())
                            {
                                demSTT += 1;

                                object x = new { STT = demSTT, MaSach = int.Parse(reader["MaSach"].ToString()), TenSach = reader["TenSach"].ToString(), TonDau = int.Parse(reader["TonDau"].ToString()), PhatSinh = int.Parse(reader["PhatSinh"].ToString()), TonCuoi = int.Parse(reader["TonCuoi"].ToString()) };

                                listChiTietBaoCao.Add(x);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thống kê sách tồn thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, listChiTietBaoCao);
                }
            }
        }



        public Result insert(ChiTietBaoCaoTon_DTO x)
        {
            string query = "INSERT INTO [CHITIETBAOCAOTON] ([MaBaoCaoTon], [MaSach], [TonDau], [PhatSinh], [TonCuoi]) VALUES (@MaBaoCaoTon, @MaSach, @TonDau, @PhatSinh, @TonCuoi)";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaBaoCaoTon", x.MaBaoCaoTon1);
                        withBlock.Parameters.AddWithValue("@MaSach", x.MaSach1);
                        withBlock.Parameters.AddWithValue("@TonDau", x.TonDau1);
                        withBlock.Parameters.AddWithValue("@PhatSinh", x.PhatSinh1);
                        withBlock.Parameters.AddWithValue("@TonCuoi", x.TonCuoi1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm chi tiết báo cáo thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm chi tiết báo cáo thành công!");
                }
            }
            return new Result(true);
        }
    }

}
