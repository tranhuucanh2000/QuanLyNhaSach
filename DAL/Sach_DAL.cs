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
    
    public class Sach_DAL
    {
        public Result insertSach(Sach_DTO x)
        {
            string query = "INSERT INTO [SACH] ([TenSach], [TheLoai], [TacGia], [SoLuongTon], [DonGia]) VALUES (@TenSach, @TheLoai, @TacGia, @SoLuongTon, @DonGia)";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;

                        withBlock.Parameters.AddWithValue("@TenSach", x.TenSach1);
                        withBlock.Parameters.AddWithValue("@TheLoai", x.TheLoai1);
                        withBlock.Parameters.AddWithValue("@TacGia", x.TacGia1);
                        withBlock.Parameters.AddWithValue("@SoLuongTon", x.SoLuongTon1);
                        withBlock.Parameters.AddWithValue("@DonGia", x.DonGia1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm sách mới thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm sách mới thành công!");
                }
            }
            return new Result(true);
        }


        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('SACH') num";
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
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy mã sách dự định tạo thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, Increment + 1);
                }
            }
        }


        public Result deleteSach(Sach_DTO sachDTO)
        {
            string query = "DELETE [CHITIETHOADON] WHERE MaSach = @MaSach;" +
                "DELETE [CHITIETBAOCAOTON] WHERE MaSach = @MaSach;" +
                "DELETE [CHITIETPHIEUNHAP] WHERE MaSach = @MaSach;" +
                "DELETE [SACH] WHERE MaSach = @MaSach";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaSach", sachDTO.MaSach1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Xóa sách thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Xóa sách thành công!");
                }
            }
            return new Result(true);
        }


        public Result SelectALL_ListSachByStringMaSachTenSach_Advanced(string text, string Advanced)
        {
            List<Sach_DTO> listSach = new List<Sach_DTO>();
            listSach.Clear();

            string textMaSach = text;

            while ((textMaSach.IndexOf(" ") != -1))
                textMaSach = textMaSach.Replace(" ", "");
            text = " " + text + " ";
            while ((text.IndexOf("  ") != -1))
                text = text.Replace("  ", " ");

            while ((text.IndexOf(" ") != -1))
                text = text.Replace(" ", "%");


            int masach;
            if ((int.TryParse(textMaSach, out masach) == true))
            {
                Result res = selectSach_ByMaSach_Advanced(masach, Advanced);
                if ((res.FlagResult == true))
                {
                    listSach.Add((Sach_DTO)res.Obj1);
                    return new Result(true, listSach);
                }
            }

            string query = "SELECT * FROM [SACH] WHERE ( ([MaSach] like @textGoc) OR ( [TenSach] like @text) )  " + Advanced;
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@textGoc", textMaSach);
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
                                listSach.Add(new Sach_DTO(int.Parse(reader["MaSach"].ToString()), reader["TenSach"].ToString(), reader["TheLoai"].ToString(), reader["TacGia"].ToString(), int.Parse(reader["SoLuongTon"].ToString()), float.Parse(reader["DonGia"].ToString())));
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Tìm kiếm thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, listSach);
                }
            }
        }

        public Result SelectALL_ListSachByStringMaSachTenSach(string text)
        {
            List<Sach_DTO> listSach = new List<Sach_DTO>();
            listSach.Clear();

            string textMaSach = text;

            while ((textMaSach.IndexOf(" ") != -1))
                textMaSach = textMaSach.Replace(" ", "");
            text = " " + text + " ";
            while ((text.IndexOf("  ") != -1))
                text = text.Replace("  ", " ");

            while ((text.IndexOf(" ") != -1))
                text = text.Replace(" ", "%");


            int masach;
            if ((int.TryParse(textMaSach, out masach) == true))
            {
                Result res = selectSach_ByMaSach(masach);
                if ((res.FlagResult == true))
                {
                    listSach.Add((Sach_DTO)res.Obj1);
                    return new Result(true, listSach);
                }
            }



            string query = "SELECT * FROM [SACH] WHERE ([MaSach] like @textGoc) OR ( [TenSach] like @text)   ";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@textGoc", textMaSach);
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
                                listSach.Add(new Sach_DTO(int.Parse(reader["MaSach"].ToString()), reader["TenSach"].ToString(), reader["TheLoai"].ToString(), reader["TacGia"].ToString(), int.Parse(reader["SoLuongTon"].ToString()), float.Parse(reader["DonGia"].ToString())));
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
                    return new Result(true, listSach);
                }
            }
        }

        public Result selectSach_ByMaSach_Advanced(int iMaSach, string Advanced)
        {
            Sach_DTO sach = new Sach_DTO();
            string query = string.Empty;
            query += " SELECT *";
            query += " FROM [SACH]";
            query += " WHERE ";
            query += " ( @MaSach=[MaSach] )  " + Advanced;

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaSach", iMaSach);
                    }
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        SqlDataReader reader;
                        reader = comm.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                                sach = new Sach_DTO(int.Parse(reader["MaSach"].ToString()), reader["TenSach"].ToString(), reader["TheLoai"].ToString(), reader["TacGia"].ToString(), int.Parse(reader["SoLuongTon"].ToString()), float.Parse(reader["DonGia"].ToString()));
                        }
                       else
                            throw new Exception("Không tìm thấy sách!");
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy thông tin sách thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, sach);
                }
                
            }
            return new Result(true); // thanh cong
        }

        public Result selectSach_ByMaSach(int iMaSach)
        {
            return selectSach_ByMaSach_Advanced(iMaSach, "");
        }


        public Result updateSach(Sach_DTO x)
        {
            string query = "UPDATE [SACH] SET [TenSach] = @TenSach, [TheLoai] = @TheLoai, [TacGia] = @TacGia, [SoLuongTon] = @SoLuongTon, [DonGia] = @DonGia WHERE MaSach = @MaSach";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaSach", x.MaSach1);
                        withBlock.Parameters.AddWithValue("@TenSach", x.TenSach1);
                        withBlock.Parameters.AddWithValue("@TheLoai", x.TheLoai1);
                        withBlock.Parameters.AddWithValue("@TacGia", x.TacGia1);
                        withBlock.Parameters.AddWithValue("@SoLuongTon", x.SoLuongTon1);
                        withBlock.Parameters.AddWithValue("@DonGia", x.DonGia1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Cập nhật thông tin sách thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Cập nhật thông tin sách thành công!");
                }
            }
            return new Result(true);
        }

        public Result SelectALL_ListSach()
        {
            return SelectALL_ListSach_Advanced("");
        }

        public Result SelectALL_ListSach_Advanced(string Advanced)
        {
            string query = "SELECT * FROM [SACH] Where (1=1) " + Advanced;

            List<Sach_DTO> listSach = new List<Sach_DTO>();
            listSach.Clear();

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
                                listSach.Add(new Sach_DTO(int.Parse(reader["MaSach"].ToString()), reader["TenSach"].ToString(), reader["TheLoai"].ToString(),reader["TacGia"].ToString(), int.Parse(reader["SoLuongTon"].ToString()), float.Parse(reader["DonGia"].ToString())));
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
                    return new Result(true, listSach);
                }
            }
        }

        public Result SelectALL_ListTheLoai()
        {
            string query = "SELECT DISTINCT [TheLoai] FROM [SACH] ORDER BY [TheLoai] ASC";

            List<string> listTheLoai = new List<string>();
            listTheLoai.Clear();

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
                                listTheLoai.Add(reader["TheLoai"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy danh sách thể loại thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, listTheLoai);
                }
            }
        }
    }

}
