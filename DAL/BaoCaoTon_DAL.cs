using System.Data.SqlClient;
using DTO;
using Utility;
using System.Data;
using System;

namespace DAL
{
   
    public class BaoCaoTon_DAL
    {
        public Result insert(BaoCaoTon_DTO x)
        {
            string query = "INSERT INTO [BAOCAOTON] ([Thang], [NgayLap]) VALUES (@Thang, @NgayLap)";
            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@Thang", x.Thang1);
                        withBlock.Parameters.AddWithValue("@NgayLap", x.NgayLap1);
                    }
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Thêm báo cáo tồn thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Thêm báo cáo tồn thành công!");
                }
            }
            return new Result(true);
        }

        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('BAOCAOTON') num";
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
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy mã báo cáo tồn dự định tạo thất bại!", ex.Message);
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
