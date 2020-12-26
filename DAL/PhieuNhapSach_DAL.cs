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
 

    public class PhieuNhapSach_DAL
    {
        public Result insertPhieuNhap(PhieuNhapSach_DTO x)
        {
            string query = "INSERT INTO [PHIEUNHAP] ([NgayNhap]) VALUES (@NgayNhap)";

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;

                        withBlock.Parameters.AddWithValue("@NgayNhap", x.NgayNhap1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm vào phiếu nhập thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm vào phiếu nhập thành công!");
                }
            }
            return new Result(true);
        }


        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('PHIEUNHAP') num";
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
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy mã phiếu nhập dự định thất bại!", ex.Message);
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
