﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO();return instance; }
            private set => instance = value; 
        }

        public bool isAccount(string usn, string psw)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("DangNhap @userName , @passWord", new object[] { usn, psw });
            return data.Rows.Count > 0;
        }
        public bool isAdmin(string usn, string psw)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("DangNhap @userName , @passWord", new object[] { usn, psw });
            DataRow dataRow = data.Rows[0];
            object[] array = dataRow.ItemArray;
            string loai = array[2].ToString();
            if (loai == "admin") return true;
            return false;
        }
    }
}
