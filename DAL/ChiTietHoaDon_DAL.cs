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


    public class ChiTietHoaDon_DAL
    {
        public Result insertChiTietHoaDon(ChiTietHoaDon_DTO x)
        {
            string query = "INSERT INTO [CHITIETHOADON] ([MaHoaDon], [MaSach], [SoLuongban], [DonGiaBan]) VALUES (@MaHoaDon, @MaSach, @SoLuongBan, @DonGiaBan)";

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;

                        withBlock.Parameters.AddWithValue("@MaHoaDon", x.MaHoaDon1);
                        withBlock.Parameters.AddWithValue("@MaSach", x.MaSach1);
                        withBlock.Parameters.AddWithValue("@SoLuongban", x.SoLuongban1);
                        withBlock.Parameters.AddWithValue("@DonGiaBan", x.DonGiaBan1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm vào chi tiết hóa đơn thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm vào chi tiết hóa đơn thành công!");
                }
            }
            return new Result(true);
        }



        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('CHITIETHOADON') num";
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
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy mã chi tiết hóa đơn dự định thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, Increment + 1);
                }
            }
        }
    }

}
