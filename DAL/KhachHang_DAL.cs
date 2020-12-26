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
    

    public class KhachHang_DAL
    {
        public Result selectTenKH_ByMaKH(int iMaKH)
        {
            string kh = "";
            string query = string.Empty;
            query += " SELECT [HoTenKhachHang]";
            query += " FROM [KHACHHANG]";
            query += " WHERE ";
            query += " @MaKH=[MaKhachHang] ";

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaKH", iMaKH);
                    }
                    try
                    {
                        conn.Open();
                       
                        SqlDataReader reader;
                        reader = comm.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                                kh = reader["HoTenKhachHang"].ToString();
                        }
                        else
                            throw new Exception("Không tìm thấy kh!");
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy thông tin kh thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, kh);
                }
            }
            return new Result(true); // thanh cong
        }

        public Result SelectALL_ListKhachHang()
        {
            string query = "SELECT * FROM [KHACHHANG]";

            List<KhachHang_DTO> listKhachHang = new List<KhachHang_DTO>();
            listKhachHang.Clear();

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
                                listKhachHang.Add(new KhachHang_DTO(int.Parse(reader["MaKhachHang"].ToString()), reader["HoTenKhachHang"].ToString(),reader["DiaChi"].ToString(), reader["DienThoai"].ToString(), reader["Email"].ToString(), double.Parse(reader["TienNo"].ToString())));
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy danh sách khách hàng thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, listKhachHang);
                }
            }
        }

        public Result deleteByKhachHang(KhachHang_DTO khachHangDTO)
        {
            string query = "DELETE FROM [DBSACH].[dbo].[CHITIETHOADON] WHERE [DBSACH].[dbo].[CHITIETHOADON].MaChiTietHoaDon IN (SELECT [DBSACH].[dbo].[CHITIETHOADON].MaChiTietHoaDon From [DBSACH].[dbo].[CHITIETHOADON],[DBSACH].[dbo].[HOADON] where [DBSACH].[dbo].[CHITIETHOADON].MaHoaDon = [DBSACH].[dbo].[HOADON].MaHoaDon and [DBSACH].[dbo].[HOADON].MaKhachHang = @MaKhachHang)" +
                "DELETE [HOADON] WHERE MaKhachHang = @MaKhachHang;" +
                "DELETE [PHIEUTHUTIEN] WHERE MaKhachHang = @MaKhachHang;" +
                "DELETE [CHITIETBAOCAOCONGNO] WHERE MaKhachHang = @MaKhachHang;" +
                "DELETE [KHACHHANG] WHERE MaKhachHang = @MaKhachHang;";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;

                        withBlock.Parameters.AddWithValue("@MaKhachHang", khachHangDTO.MaKH1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Xóa khách hàng thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Xóa khách hàng thành công!");
                }
            }
            return new Result(true);
        }

        public Result selectKhachHang_ByMaKH(int maKhachHang1)
        {
            KhachHang_DTO khachHangDTO = new KhachHang_DTO() ;
            string query = string.Empty;
            query += " SELECT *";
            query += " FROM [KHACHHANG]";
            query += " WHERE ";
            query += " ( @MaKhachHang=[MaKhachHang] )";

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaKhachHang", maKhachHang1);
                    }
                    try
                    {
                        conn.Open();

                        SqlDataReader reader;
                        reader = comm.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                                
                               khachHangDTO = new KhachHang_DTO(int.Parse(reader["MaKhachHang"].ToString()), reader["HoTenKhachHang"].ToString(), reader["DiaChi"].ToString(), reader["DienThoai"].ToString(), reader["Email"].ToString(), double.Parse(reader["TienNo"].ToString()));
                        }
                        else
                            throw new Exception("Không tìm thấy khách hàng!");
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy thông tin khách hàng thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, khachHangDTO);
                }
            }
            return new Result(true); // thanh cong
        }

        public Result SelectTienNo_KhachHang(int iMaKH)
        {
            float tienno = 0;
            string query = string.Empty;
            query += " SELECT [TienNo]";
            query += " FROM [KHACHHANG]";
            query += " WHERE ";
            query += " @MaKH=[MaKhachHang] ";

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaKH", iMaKH);
                    }
                    try
                    {
                        conn.Open();
                        SqlDataReader reader;
                        reader = comm.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                                tienno = int.Parse(reader["TienNo"].ToString());
                        }
                        else
                            throw new Exception("Không tìm thấy khách hàng!");
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy thông tin tiền nợ thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    //return new Result(true, tienno);
                }
            }
            return new Result(true); // thanh cong
        }


        public Result SelectALL_ListKhachHangByStringMaKHHoTenSDT(string text)
        {
            List<KhachHang_DTO> listKhachHang = new List<KhachHang_DTO>();
            listKhachHang.Clear();

            string textMaKhachHang = text;

            while ((textMaKhachHang.IndexOf(" ") != -1))
                textMaKhachHang = textMaKhachHang.Replace(" ", "");
            text = " " + text + " ";
            while ((text.IndexOf("  ") != -1))
                text = text.Replace("  ", " ");

            while ((text.IndexOf(" ") != -1))
                text = text.Replace(" ", "%");


            int maKH;
            if ((int.TryParse(textMaKhachHang, out maKH) == true))
            {
                Result res = selectKhachHang_ByMaKhachHang(maKH);
                if ((res.FlagResult == true))
                {
                    listKhachHang.Add((KhachHang_DTO)res.Obj1);

                    return new Result(true, listKhachHang);
                }
            }

            string query = "SELECT * FROM [KHACHHANG] WHERE ([DienThoai] like @text) OR ( [HoTenKhachHang] like @text)   ";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@text", text);
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
                                listKhachHang.Add(new KhachHang_DTO(int.Parse(reader["MaKhachHang"].ToString()), reader["HoTenKhachHang"].ToString(), reader["DiaChi"].ToString(), reader["DienThoai"].ToString(), reader["Email"].ToString(), double.Parse(reader["TienNo"].ToString())));
                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Tìm kiếm thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, listKhachHang);
                }
            }
        }


        public Result update(KhachHang_DTO x)
        {
            string query = "UPDATE [KHACHHANG] SET [HoTenKhachHang] = @HoTenKhachHang, [DiaChi] = @DiaChi, [DienThoai] = @DienThoai, [Email] = @Email, [TienNo] = @TienNo WHERE MaKhachHang = @MaKhachHang";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaKhachHang", x.MaKH1);
                        withBlock.Parameters.AddWithValue("@HoTenKhachHang", x.HoTenKhachHang1);
                        withBlock.Parameters.AddWithValue("@DiaChi", x.DiaChi1);
                        withBlock.Parameters.AddWithValue("@DienThoai", x.DienThoai1);
                        withBlock.Parameters.AddWithValue("@Email", x.Email1);
                        withBlock.Parameters.AddWithValue("@TienNo", x.TienNo1);
                    }
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Cập nhật thông tin khách hàng thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Cập nhật thông tin khách hàng thành công!");
                }
            }
            return new Result(true);
        }

        private Result selectKhachHang_ByMaKhachHang(int maKH)
        {
            KhachHang_DTO khachHangDTO = new KhachHang_DTO();
            string query = string.Empty;
            query += " SELECT *";
            query += " FROM [KHACHHANG]";
            query += " WHERE ";
            query += " @MaKhachHang=[MaKhachHang] ";

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaKhachHang", maKH);
                    }
                    try
                    {
                        conn.Open();

                        SqlDataReader reader;
                        reader = comm.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())

                                khachHangDTO = new KhachHang_DTO(int.Parse(reader["MaKhachHang"].ToString()), reader["HoTenKhachHang"].ToString(), reader["DiaChi"].ToString(), reader["DienThoai"].ToString(), reader["Email"].ToString(), double.Parse(reader["TienNo"].ToString()));
                        }
                        else
                            throw new Exception("Không tìm thấy KH!");
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy thông tin KH thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, khachHangDTO);
                }
            }
            return new Result(true); // thanh cong
            
        }

        public Result insert(KhachHang_DTO x)
        {
            string query = "INSERT INTO [KHACHHANG] ([HoTenKhachHang], [TienNo], [DiaChi], [DienThoai], [Email]) VALUES (@HoTenKhachHang, @TienNo, @DiaChi, @DienThoai, @Email)";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;


                        withBlock.Parameters.AddWithValue("@HoTenKhachHang", x.HoTenKhachHang1);
                        withBlock.Parameters.AddWithValue("@TienNo", x.TienNo1);
                        withBlock.Parameters.AddWithValue("@DiaChi", x.DiaChi1);
                        withBlock.Parameters.AddWithValue("@DienThoai", x.DienThoai1);
                        withBlock.Parameters.AddWithValue("@Email", x.Email1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm KH mới thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm KH mới thành công!");
                }
            }
            return new Result(true);
        }

        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('KHACHHANG') num";
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
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy mã KH dự định tạo thất bại!", ex.Message);
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
