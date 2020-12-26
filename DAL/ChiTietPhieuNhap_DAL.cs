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
    public class ChiTietPhieuNhap_DAL
    {
        public Result insertChiTietPhieuNhap(ChiTIetPhieuNhap_DTO x)
        {
            string query = "INSERT INTO [CHITIETPHIEUNHAP] ([MaPhieuNhap], [MaSach], [SoLuongNhap]) VALUES (@MaPhieuNhap, @MaSach, @SoLuongNhap)";

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;

                        withBlock.Parameters.AddWithValue("@MaPhieuNhap", x.MaPhieuNhap1);
                        withBlock.Parameters.AddWithValue("@MaSach", x.MaSach1);
                        withBlock.Parameters.AddWithValue("@SoLuongNhap", x.SoLuongNhap1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm chi tiết phiếu nhập thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm chi tiết phiếu nhập thành công!");
                }
            }
            return new Result(true);
        }


        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('CHITIETPHIEUNHAP') num";
            int Increment = 0;
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
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
                                Increment = int.Parse(reader["num"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy mã chi tiết phiếu nhập dự định thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, Increment + 1);
                }
            }
        }


        public Result select_MaPhieuNhap()
        {
            string query = "SELECT TOP 1 [MAPHIEUNHAP] FROM [PHIEUNHAP] ORDER BY [MAPHIEUNHAP] DESC";

            ChiTIetPhieuNhap_DTO maPhieuNhapDTO = new ChiTIetPhieuNhap_DTO();

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
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
                                {
                                    var withBlock = maPhieuNhapDTO;
                                    withBlock.MaPhieuNhap1 = int.Parse(reader["MaPhieuNhap"].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy danh sách các đầu sách thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, maPhieuNhapDTO);
                }
            }
        }
    }

}
