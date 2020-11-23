using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DTO
{
    public class Account
    {
        private string tenDN;
        private string ten;
        private string passWord;
        private int type;
        public string TenDN { get => tenDN; set => tenDN = value; }
        public string Ten { get => ten; set => ten = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
        public Account () { }
        public Account(string tendn,string ten, int type , string pass = null)
        {
            this.TenDN = tendn;
            this.Ten = ten;
            this.PassWord = pass;
            this.Type = type;
        }
        public Account(DataRow row)
        {
            this.TenDN = row["TenDN"].ToString();
            this.Ten = row["HoTen"].ToString();
            this.PassWord = row["MatKhau"].ToString();
            this.Type = int.Parse(row["Loai"].ToString());
        }
    }
}
