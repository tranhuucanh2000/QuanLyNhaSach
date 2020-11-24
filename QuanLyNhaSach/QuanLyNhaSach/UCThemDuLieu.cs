﻿using QuanLyNhaSach.DTO;
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
    public partial class UCThemDuLieu : UserControl
    {
        private static UCThemDuLieu instance;
        public static UCThemDuLieu Instance
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
        public UCThemDuLieu(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
        }
    }
}
