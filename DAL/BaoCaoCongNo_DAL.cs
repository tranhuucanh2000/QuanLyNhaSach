using System.Data.SqlClient;
using DTO;
using Utility;
using System.Data;
using System;



namespace DAL
{
    
    public class BaoCaoCongNo_DAL
    {
        public Result insert(BaoCaoCongNo_DTO x)
        {
            string query = "INSERT INTO [BAOCAOCONGNO] ([Thang], [NgayLap]) VALUES (@Thang, @NgayLap)";
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
                        return new Result(false, null, "Thêm báo cáo công nợ thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null, "Thêm báo cáo công nợ thành công!");
                }
            }
            return new Result(true);
        }


        public Result GetNextIncrement()
        {
            string query = "SELECT IDENT_CURRENT('BAOCAOCONGNO') num";
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
                        return new Result(false, null, "Lấy mã báo cáo công nợ dự định tạo thất bại!", ex.Message);
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
