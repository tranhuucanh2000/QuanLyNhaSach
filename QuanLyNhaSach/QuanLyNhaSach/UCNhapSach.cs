using QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class UCNhapSach : UserControl
    {
        private static UCNhapSach instance;
        public static UCNhapSach Instance
        {
            get => instance;
            set => instance = value;
        }

        private Account loginAccount;
        public Account LoginAccount
        {
            get => loginAccount;
            set => loginAccount = value;
        }
        public UCNhapSach(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
        }
    }
}
