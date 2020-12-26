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
    

    public class DangNhap_DAL
    {
        public Result update(DangNhap_DTO x)
        {
            string query = "UPDATE [DANGNHAP] SET [TenDangNhap] = @TenDangNhap, [MatKhau] = @MatKhau WHERE id = @id";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@TenDangNhap", x.TenDangNhap1);
                        withBlock.Parameters.AddWithValue("@MatKhau", x.MatKhau1);
                        withBlock.Parameters.AddWithValue("@id", x.Id1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Cập nhật thông tin đăng nhập thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Cập nhật thông tin đăng nhập thành công!");
                }
            }
            return new Result(true);
        }

        public Result KiemTraDangNhap(DangNhap_DTO x)
        {
            string query = "SELECT id FROM DANGNHAP WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.Parameters.AddWithValue("@TenDangNhap", x.TenDangNhap1);
                        withBlock.Parameters.AddWithValue("@MatKhau", x.MatKhau1);

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
                            reader.Read(); // đọc thông tin user vào reader
                            return new Result(true, System.Convert.ToInt32(reader["id"]), "Đăng nhập thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Đăng nhập thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Tên đăng nhập hoặc mật khẩu chưa chính xác!" + Environment.NewLine + "Vui lòng thử lại!");
                }
            }
        }
    }

}
