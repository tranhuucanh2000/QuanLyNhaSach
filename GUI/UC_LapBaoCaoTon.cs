using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using BUS;
using DTO;
using Utility;


namespace GUI
{
    public partial class UC_LapBaoCaoTon : UserControl
    {
        public UC_LapBaoCaoTon()
        {
            InitializeComponent();
        }
        private Result res;
        private ChiTietBaoCaoTon_BUS chiTietBaoCaoTonBUS = new ChiTietBaoCaoTon_BUS();
        private List<object> listChiTietBaoCao;
        private BaoCaoTon_BUS baoCaoTonBUS = new BaoCaoTon_BUS();



        private void UC_LapBaoCaoTon_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            InitDataGridViewBaoCaoTon();
            btn_LuuBaoCao.Enabled = false;
            btn_LuuBaoCao.BackColor = Color.LightGray;
        }


        public void InitDataGridViewBaoCaoTon()
        {
            dgv_listBaoCaoTon.Columns.Clear();

            dgv_listBaoCaoTon.AutoGenerateColumns = false;

            dgv_listBaoCaoTon.DataSource = listChiTietBaoCao;

            var clSTT = new DataGridViewTextBoxColumn();
            {
                var withBlock = clSTT;
                withBlock.Name = "STT";
                withBlock.DataPropertyName = "STT";
                withBlock.HeaderText = "STT";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoTon.Columns.Add(clSTT);

            var clMaSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = clMaSach;
                withBlock.Name = "MaSach";
                withBlock.DataPropertyName = "MaSach";
                withBlock.HeaderText = "Mã sách";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoTon.Columns.Add(clMaSach);

            var clTenSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTenSach;
                withBlock.Name = "TenSach";
                withBlock.DataPropertyName = "TenSach";
                withBlock.HeaderText = "Tên sách";
            }
            dgv_listBaoCaoTon.Columns.Add(clTenSach);

            var clTonDau = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTonDau;
                withBlock.Name = "TonDau";
                withBlock.DataPropertyName = "TonDau";
                withBlock.HeaderText = "Tồn đầu";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoTon.Columns.Add(clTonDau);

            var clPhatSinh = new DataGridViewTextBoxColumn();
            {
                var withBlock = clPhatSinh;
                withBlock.Name = "PhatSinh";
                withBlock.DataPropertyName = "PhatSinh";
                withBlock.HeaderText = "Phát sinh";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoTon.Columns.Add(clPhatSinh);



            var clTonCuoi = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTonCuoi;
                withBlock.Name = "TonCuoi";
                withBlock.DataPropertyName = "TonCuoi";
                withBlock.HeaderText = "Tồn cuối";
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung
            }
            dgv_listBaoCaoTon.Columns.Add(clTonCuoi);


            double rong = dgv_listBaoCaoTon.Width;

            dgv_listBaoCaoTon.Columns["STT"].Width = (int)(rong * 0.1);
            dgv_listBaoCaoTon.Columns["MaSach"].Width = (int)(rong * 0.15);
            dgv_listBaoCaoTon.Columns["TenSach"].Width = (int)(rong * 0.3 - 20);
            dgv_listBaoCaoTon.Columns["TonDau"].Width = (int)(rong * 0.15);
            dgv_listBaoCaoTon.Columns["PhatSinh"].Width = (int)(rong * 0.15);
            dgv_listBaoCaoTon.Columns["TonCuoi"].Width = (int)(rong * 0.15);




            dgv_listBaoCaoTon.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv_listBaoCaoTon.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_listBaoCaoTon.RowHeadersVisible = false;
        }



        private void btn_XemBaoCao_Click(object sender, EventArgs e)
        {
            res = chiTietBaoCaoTonBUS.ThongKeBaoCaoTon(dtp_ThangBaoCao.Value.Month, dtp_ThangBaoCao.Value.Year);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listChiTietBaoCao = (List<object>)res.Obj1;

            InitDataGridViewBaoCaoTon();

            if (dgv_listBaoCaoTon.RowCount == 0)
                MessageBox.Show("Tháng này không có sự thay đổi về tồn sách!");
            else
                btn_LuuBaoCao.Enabled = true;// xem xong mới cho lưu
                btn_LuuBaoCao.BackColor = Color.Teal;
        }



        private void DateTimePicker_ThangBaoCao_ValueChanged(object sender, EventArgs e)
        {
            btn_LuuBaoCao.Enabled = false;
            btn_LuuBaoCao.BackColor = Color.LightGray;
        }

        private void btn_LuuBaoCao_Click(object sender, EventArgs e)
        {
            res = baoCaoTonBUS.GetNextIncrement();
            int MaBaoCaoTon = System.Convert.ToInt32(res.Obj1);

            res = baoCaoTonBUS.insert(new BaoCaoTon_DTO(dtp_ThangBaoCao.Value, dtp_NgayLap.Value));
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            foreach (object chitiet in listChiTietBaoCao)
            {
                res = chiTietBaoCaoTonBUS.insert(new ChiTietBaoCaoTon_DTO(MaBaoCaoTon, (int)chitiet.GetType().GetProperty("MaSach").GetValue(chitiet, null), (int)chitiet.GetType().GetProperty("TonDau").GetValue(chitiet, null), (int)chitiet.GetType().GetProperty("PhatSinh").GetValue(chitiet, null), (int)chitiet.GetType().GetProperty("TonCuoi").GetValue(chitiet, null)));
                if ((res.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            btn_LuuBaoCao.Enabled = false;
            btn_LuuBaoCao.BackColor = Color.LightGray;
            MessageBox.Show("Lưu báo cáo tồn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
