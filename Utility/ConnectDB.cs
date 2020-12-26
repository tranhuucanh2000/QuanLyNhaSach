using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using Microsoft.VisualBasic;

namespace Utility
{

    public class ConnectDB
    {
        public static string ConnectionStringConnectDB = "Data Source =.\\sqlexpress; Initial Catalog = DBSACH; Integrated Security = True";

        public ConnectDB()
        {
        }

        public static SqlConnection GetConnectionDB()
        {
            return new SqlConnection(ConnectionStringConnectDB); // ConfigurationManager.AppSettings("ConnectionString"))
        }


        public static bool CheckConnectionDB()
        {
            try
            {
                using (SqlConnection conn = GetConnectionDB())
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
