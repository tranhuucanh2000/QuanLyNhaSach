using QuanLyNhaSach.DTO;
using QuanLyNhaSach.Properties;
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
    public partial class FHoaDonTT : Form
    {
        private Account loginAcc;
        public FHoaDonTT(DataTable data, Account acc)
        {
            InitializeComponent();
            dtgHoaDon.DataSource = data;
            loginAcc = acc;
        }

        private void ptClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.logo;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("NHÀ SÁCH KVC", new Font("Segoe UI", 40, FontStyle.Bold), Brushes.Black, new Point(195, 30));
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString(), new Font("Segoe UI", 22, FontStyle.Bold),Brushes.Black, new Point(0, image.Height + 40));
            e.Graphics.DrawString("Tên khách hàng: " + txbTen.Text, new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 80));
            e.Graphics.DrawString("Tên nhân viên: " + loginAcc.Ten, new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 120));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + 180));
            e.Graphics.DrawString("Tên Sách", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(0, image.Height + 200));
            e.Graphics.DrawString("SL", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(440, image.Height + 200));
            e.Graphics.DrawString("Giá", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(550, image.Height + 200));
            e.Graphics.DrawString("T.Tiền", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(680, image.Height + 200));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + 230));
            int yPoint = 250;
            int tongtien = 0;
            for(int i = 0; i < dtgHoaDon.Rows.Count - 1; i++)
            {
                string tensach = dtgHoaDon.Rows[i].Cells[1].Value.ToString();
                string tenht = tensach;
                if(tensach.Length>26)
                {
                    tenht = tenht.Substring(0, 26);
                    tenht = tenht + "...";
                }
                e.Graphics.DrawString(tenht , new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint));
                e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[2].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(440, image.Height + yPoint));
                e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[3].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(550, image.Height + yPoint));
                e.Graphics.DrawString(dtgHoaDon.Rows[i].Cells[4].Value.ToString(), new Font("Segoe UI", 21, FontStyle.Regular), Brushes.Black, new Point(680, image.Height + yPoint));
                int ttien = int.Parse(dtgHoaDon.Rows[i].Cells[4].Value.ToString());
                tongtien += ttien;
                yPoint += 30;
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(0, image.Height + yPoint));
            e.Graphics.DrawString("Tổng tiền: ", new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(450, image.Height + yPoint + 30));
            e.Graphics.DrawString(tongtien.ToString(), new Font("Segoe UI", 22, FontStyle.Bold), Brushes.Black, new Point(680, image.Height + yPoint + 30));
            e.Graphics.DrawString("----------------------------------Nhà Sách KVC--------------------------------------", new Font("Segoe UI", 18, FontStyle.Regular), Brushes.Black, new Point(0, 970));
            e.Graphics.DrawString("Địa chỉ: 28/11 đường số 1, Tăng Nhơn Phú B, Quận 9, Hồ Chí Minh", new Font("Segoe UI", 19, FontStyle.Italic), Brushes.Black, new Point(45, 1000));
            e.Graphics.DrawString("Số điện thoại: 0989777999", new Font("Segoe UI", 19, FontStyle.Italic), Brushes.Black, new Point(290, 1040));

        }

        private void label4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
