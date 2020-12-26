using System.Data.SqlClient;
using DTO;
using Utility;
using System.Data;
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


namespace DAL
{
   

    public class ChiTietBaoCaoCongNo_DAL
    {
        public Result ThongKeBaoCaoCongNo(int thang, int nam)
        {
            List<object> listChiTietBaoCao = new List<object>();
            listChiTietBaoCao.Clear();


            string query = @"SELECT thongke.MaKhachHang, KHACHHANG.HoTenKhachHang ,thongke.NoDau, thongke.PhatSinh, thongke.NoCuoi
FROM
(
	SELECT TOP 100 PERCENT ISNULL(thangtruoc.MaKhachHang, thanghientai.MaKhachHang) MaKhachHang, ISNULL(thangtruoc.TienPhatSinh,0) NoDau, ISNULL(thanghientai.TienPhatSinh,0) PhatSinh, ISNULL(thangtruoc.TienPhatSinh,0) + ISNULL(thanghientai.TienPhatSinh,0) NoCuoi
	 FROM 
	 (
		/*của 1 tháng*/
		 SELECT ISNULL(ctmua.MaKhachHang,ctthu.MaKhachHang) as MaKhachHang, ISNULL(ctmua.TongThanhTien,0) - ISNULL(ctthu.TongTienThu,0) as TienPhatSinh
		 FROM
		 (
			 /*Tính tổng tiền mà KH mua trong tháng*/
			SELECT HDThanhTien.MaKhachHang, SUM(HDThanhTien.ThanhTien) TongThanhTien
			FROM
			(
				/*Tính thành tiền của các hóa đơn mà khách hàng mua trong tháng*/
				SELECT MaKhachHang, SoLuongBan*DonGiaBan ThanhTien
				FROM CHITIETHOADON, HOADON
				WHERE HOADON.MaHoaDon = CHITIETHOADON.MaHoaDon AND MONTH(HOADON.NgayLapHoaDon) = @Thang AND YEAR(HOADON.NgayLapHoaDon) = @Nam
			) HDThanhTien
			GROUP BY HDThanhTien.MaKhachHang
		 ) ctmua
		 FULL JOIN
		 (
			 /*Tổng số tiền đã thu của KH trong tháng*/
			SELECT MaKhachHang, sum(SoTienThu) TongTienThu
			FROM PHIEUTHUTIEN
			WHERE MONTH(PHIEUTHUTIEN.NgayThuTien) = @Thang AND YEAR(PHIEUTHUTIEN.NgayThuTien) = @Nam
			GROUP BY MaKhachHang
		 ) ctthu 
		 ON ctmua.MaKhachHang = ctthu.MaKhachHang
	 ) thanghientai

	 FULL JOIN

	 (
		/*của các tháng trước đó*/
		 SELECT ISNULL(ctmua.MaKhachHang,ctthu.MaKhachHang) as MaKhachHang, ISNULL(ctmua.TongThanhTien,0) - ISNULL(ctthu.TongTienThu,0) as TienPhatSinh
		 FROM
		 (
			 /*Tính tổng tiền mà KH mua trong tháng*/
			SELECT HDThanhTien.MaKhachHang, SUM(HDThanhTien.ThanhTien) TongThanhTien
			FROM
			(
				/*Tính thành tiền của các hóa đơn mà khách hàng mua trong tháng*/
				SELECT MaKhachHang, SoLuongBan*DonGiaBan ThanhTien
				FROM CHITIETHOADON, HOADON
				WHERE  HOADON.MaHoaDon = CHITIETHOADON.MaHoaDon AND
				((YEAR(HOADON.NgayLapHoaDon) < @Nam) OR (YEAR(HOADON.NgayLapHoaDon) = @Nam	AND	MONTH(HOADON.NgayLapHoaDon) <@Thang))
			) HDThanhTien
			GROUP BY HDThanhTien.MaKhachHang
		 ) ctmua
		 FULL JOIN
		 (
			 /*Tổng số tiền đã thu của KH trong tháng*/
			SELECT MaKhachHang, sum(SoTienThu) TongTienThu
			FROM PHIEUTHUTIEN
			WHERE  ( (YEAR(PHIEUTHUTIEN.NgayThuTien) < @Nam) OR (YEAR(PHIEUTHUTIEN.NgayThuTien) = @Nam AND MONTH(PHIEUTHUTIEN.NgayThuTien) <@Thang))
			GROUP BY MaKhachHang
		 ) ctthu 
		 ON ctmua.MaKhachHang = ctthu.MaKhachHang
	 ) thangtruoc
	  ON thanghientai.MaKhachHang = thangtruoc.MaKhachHang

 ) thongke, KHACHHANG


WHERE KHACHHANG.MaKhachHang = thongke.MaKhachHang
ORDER BY KHACHHANG.MaKhachHang ASC";

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

                                object x = new { STT = demSTT, MaKhachHang = int.Parse(reader["MaKhachHang"].ToString()), HoTenKhachHang = reader["HoTenKhachHang"].ToString(), NoDau = double.Parse(reader["NoDau"].ToString()), PhatSinh = double.Parse(reader["PhatSinh"].ToString()), NoCuoi = double.Parse(reader["NoCuoi"].ToString()) };

                                listChiTietBaoCao.Add(x);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thống kê nợ thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, listChiTietBaoCao);
                }
            }
        }


        public Result insert(ChiTietBaoCaoCongNo_DTO x)
        {
            string query = "INSERT INTO [CHITIETBAOCAOCONGNO] ([MaBaoCaoCongNo], [MaKhachHang], [NoDau], [PhatSinh], [NoCuoi]) VALUES (@MaBaoCaoCongNo, @MaKhachHang, @NoDau, @PhatSinh, @NoCuoi)";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaBaoCaoCongNo", x.MaBaoCaoCongNo1);
                        withBlock.Parameters.AddWithValue("@MaKhachHang", x.MaKhachHang1);
                        withBlock.Parameters.AddWithValue("@NoDau", x.NoDau1);
                        withBlock.Parameters.AddWithValue("@PhatSinh", x.PhatSinh1);
                        withBlock.Parameters.AddWithValue("@NoCuoi", x.NoCuoi1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm chi tiết báo cáo công nợ thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm chi tiết báo cáo công nợ thành công!");
                }
            }
            return new Result(true);
        }
    }

}
