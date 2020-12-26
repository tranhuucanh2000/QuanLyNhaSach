using System.Data.SqlClient;
using DTO;
using Utility;
using System;
using System.Collections.Generic;
using System.Data;



namespace DAL
{
 
    public class PhieuThuTien_DAL
    {
        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('PHIEUTHUTIEN') num";
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
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy mã phiếu thu tiền dự định tạo thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, Increment + 1);
                }
            }
        }

        public Result insert(PhieuThuTien_DTO x)
        {
            string query = "INSERT INTO [PHIEUTHUTIEN] ([MaKhachHang], [NgayThuTien], [SoTienThu]) VALUES (@MaKhachHang, @NgayThuTien, @SoTienThu)";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaKhachHang", x.MaKhachHang1);
                        withBlock.Parameters.AddWithValue("@NgayThuTien", x.NgayThuTien1);
                        withBlock.Parameters.AddWithValue("@SoTienThu", x.SoTienThu1);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm phiếu thu tiền mới thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm phiếu thu tiền mới thành công!");
                }
            }
            return new Result(true);
        }

        public Result SelectAll_ListPhieuThuTienByMaPhieu(int MaPhieu)
        {
            string query = "SELECT [MaPhieuThu],[PHIEUTHUTIEN].[MaKhachHang],[HoTenKhachHang],[NgayThuTien],[SoTienThu]";
            query += "FROM [PHIEUTHUTIEN],[KHACHHANG] WHERE [PHIEUTHUTIEN].[MaKhachHang] = [KHACHHANG].[MaKhachHang]";
            query += "And ([MaPhieuThu]=@MaPhieuThu Or ([MaPhieuThu]<>@MaPhieuThu AND [MaPhieuThu] Like @MaPhieuThu_like))";

            string MaPhieuThu_like = "%" + MaPhieu.ToString() + "%";

            List<PhieuThuTien_DTO> listPhieuThuTien = new List<PhieuThuTien_DTO>();
            listPhieuThuTien.Clear();

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@MaPhieuThu", MaPhieu);
                        withBlock.Parameters.AddWithValue("@MaPhieuThu_like", MaPhieuThu_like);
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
                                listPhieuThuTien.Add( new PhieuThuTien_DTO(int.Parse(reader["MaPhieuThu"].ToString()),int.Parse(reader["MaKhachHang"].ToString()), DateTime.Parse(reader["NgayThuTien"].ToString()), double.Parse(reader["SoTienThu"].ToString()), reader["HoTenKhachHang"].ToString()));
                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy danh sách phiếu thu tiền thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, listPhieuThuTien);
                }
            }
        }

        public Result SelectAll_ListPhieuThuTien()
        {
            string query = "SELECT [MaPhieuThu],[PHIEUTHUTIEN].[MaKhachHang],[HoTenKhachHang],[NgayThuTien],[SoTienThu] FROM [PHIEUTHUTIEN],[KHACHHANG] WHERE [PHIEUTHUTIEN].[MaKhachHang] = [KHACHHANG].[MaKhachHang]";

            List<PhieuThuTien_DTO> listPhieuThuTien = new List<PhieuThuTien_DTO>();
            listPhieuThuTien.Clear();

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
                                listPhieuThuTien.Add(new PhieuThuTien_DTO(int.Parse(reader["MaPhieuThu"].ToString()), int.Parse(reader["MaKhachHang"].ToString()), DateTime.Parse(reader["NgayThuTien"].ToString()), double.Parse(reader["SoTienThu"].ToString()), reader["HoTenKhachHang"].ToString()));
                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null, "Lấy danh sách phiếu thu tiền thất bại!", ex.Message) ;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, listPhieuThuTien);
                }
            }
        }
    }

}
