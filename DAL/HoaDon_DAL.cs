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
    

    public class HoaDon_DAL
    {
        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('HOADON') num";
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
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy mã hóa đơn dự định tạo thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, Increment + 1);
                }
            }
        }


        public Result insertHoaDon(HoaDon_DTO x)
        {
            string query = "INSERT INTO [HOADON] ([NgayLapHoaDon], [MaKhachHang]) VALUES (@NgayLapHoaDon, @MaKhachHang)";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;

                        withBlock.Parameters.AddWithValue("@NgayLapHoaDon", x.NgayLapHoaDon1);
                        withBlock.Parameters.AddWithValue("@MaKhachHang", x.MaKhachHang1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm hóa đơn mới thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm hóa đơn mới thành công!");
                }
            }
            return new Result(true);
        }
    }

}
