using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DTO
{
    class Account
    {
        private string tenDN;
        private string ten;
        private string passWord;
        private string type;
        public string TenDN { get => tenDN; set => tenDN = value; }
        public string Ten { get => ten; set => ten = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string Type { get => type; set => type = value; }
        public Account(string tendn,string ten, string pass, string type)
        {
            this.TenDN = tendn;
            this.Ten = ten;
            this.PassWord = pass;
            this.Type = type;
        }
    }
}
