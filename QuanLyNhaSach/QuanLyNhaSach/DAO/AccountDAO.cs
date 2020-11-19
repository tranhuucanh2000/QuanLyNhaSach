﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO();return instance; }
            private set => instance = value; 
        }

        public static bool Type { get => type; set => type = value; }

        private static bool type;
        public bool isAccount(string usn, string psw)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_DangNhap @userName , @passWord", new object[] { usn, psw });
            if(data.Rows.Count>0)
            {
                DataRow row = data.Rows[0];
                if (row["Loai"].ToString() == "1") Type = true;
                else Type = false;
                return true;
            }
            return false;
        }
    }
}
