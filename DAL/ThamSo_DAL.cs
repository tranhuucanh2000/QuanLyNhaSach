using System.Data.SqlClient;
using DTO;
using Utility;
using System;
using System.Data;
namespace DAL
{
  

    public class ThamSo_DAL
    {
        public Result Update(ThamSo_DTO thamsoDTO)
        {
            string query = "Update [THAMSO] SET SoLuongNhapToiThieu = @SoLuongNhapToiThieu, SoLuongTonToiDa = @SoLuongTonToiDa, SoLuongTonToiThieu=@SoLuongTonToiThieu, SoTienNoToiDa=@SoTienNoToiDa, SuDungQD4=@SuDungQD4";

            using (SqlConnection conn = ConnectDB.GetConnectionDB())
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    {
                        var withBlock = comm;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = query;
                        withBlock.Parameters.AddWithValue("@SoLuongNhapToiThieu", thamsoDTO.SoLuongNhapToiThieu1);
                        withBlock.Parameters.AddWithValue("@SoLuongTonToiDa", thamsoDTO.SoLuongTonToiDa1);
                        withBlock.Parameters.AddWithValue("@SoLuongTonToiThieu", thamsoDTO.SoLuongTonToiThieu1);
                        withBlock.Parameters.AddWithValue("@SoTienNoToiDa", thamsoDTO.SoTienNoToiDa1);
                        withBlock.Parameters.AddWithValue("@SuDungQD4", thamsoDTO.SuDungQD41);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Cập nhật tham số thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, null/* TODO Change to default(_) if this is not a reference type */, "Cập nhật tham số thành công!");
                }
            }
        }

        public Result SelectAll_ThamSo()
        {
            string query = "SELECT * FROM [THAMSO]";

            ThamSo_DTO thamSoDTO = new ThamSo_DTO();

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
                                    var withBlock = thamSoDTO;
                                    withBlock.SoLuongNhapToiThieu1 = int.Parse(reader["SoLuongNhapToiThieu"].ToString());
                                    withBlock.SoLuongTonToiDa1 = int.Parse(reader["SoLuongTonToiDa"].ToString());
                                    withBlock.SoLuongTonToiThieu1 = int.Parse(reader["SoLuongTonToiThieu"].ToString());
                                    withBlock.SoTienNoToiDa1 = double.Parse(reader["SoTienNoToiDa"].ToString());
                                    withBlock.SuDungQD41 = (bool)reader["SuDungQD4"];
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return new Result(false, null/* TODO Change to default(_) if this is not a reference type */, "Lấy tham số từ hệ thống thất bại!", ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return new Result(true, thamSoDTO);
                }
            }
        }
    }

}
