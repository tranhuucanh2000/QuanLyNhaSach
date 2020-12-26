using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DTO;
using Utility;
using BUS;

namespace GUI
{
    public partial class UC_ThayDoiQuyDinh : UserControl
    {
        private Result Res;
        private ThamSo_BUS thamsoBUS;
        private ThamSo_DTO thamsoDTO = new ThamSo_DTO();
        private bool DangCapNhat = false;

        public UC_ThayDoiQuyDinh()
        {
            // This call is required by the designer
            InitializeComponent();

            thamsoBUS = new ThamSo_BUS();
            thamsoDTO = new ThamSo_DTO();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

        }


        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            //if ((DangCapNhat == false))
            //{
            //    ChoPhepCapNhatThamSo(true);
            //    DangCapNhat = true;
            //    return;
            //}


            Res = thamsoBUS.isValidSoLuongNhapToiThieu(txt_SoLuongNhapToiThieu.Text);
            if ((Res.FlagResult == false))
            {
                MessageBox.Show(Res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SoLuongNhapToiThieu.Focus();
                return;
            }

            Res = thamsoBUS.isValidSoLuongTonToiDa(txt_SoLuongTonToiDa.Text);
            if ((Res.FlagResult == false))
            {
                MessageBox.Show(Res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SoLuongTonToiDa.Focus();
                return;
            }


            Res = thamsoBUS.isValidSoTienNoToiDa(txt_SoTienNoToiDa.Text);
            if ((Res.FlagResult == false))
            {
                MessageBox.Show(Res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SoTienNoToiDa.Focus();
                return;
            }


            Res = thamsoBUS.isValidSoLuongTonToiThieu(txt_SoLuongTonToiThieu.Text);
            if ((Res.FlagResult == false))
            {
                MessageBox.Show(Res.ApplicationMessage, "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SoLuongTonToiThieu.Focus();
                return;
            }

            {
                var withBlock = thamsoDTO;
                withBlock.SoLuongNhapToiThieu1 = int.Parse(txt_SoLuongNhapToiThieu.Text);
                withBlock.SoLuongTonToiDa1 = int.Parse(txt_SoLuongTonToiDa.Text);
                withBlock.SoLuongTonToiThieu1 = int.Parse(txt_SoLuongTonToiThieu.Text);
                withBlock.SoTienNoToiDa1 = double.Parse(txt_SoTienNoToiDa.Text);
                withBlock.SuDungQD41 = cb_SuDungQD4.Checked;
            }

            Res = thamsoBUS.Update(thamsoDTO);
            if ((Res.FlagResult == false))
            {
                MessageBox.Show(Res.ApplicationMessage, "Có lỗi xảy ra!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show(Res.ApplicationMessage, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //ChoPhepCapNhatThamSo(false);
                //DangCapNhat = false;
            }
        }

        private void UC_ThayDoiQuyDinh_Load(object sender, EventArgs e)
        {
            ChoPhepCapNhatThamSo(true);

            Res = thamsoBUS.SelectAll_ThamSo();
            if ((Res.FlagResult == false))
            {
                MessageBox.Show(Res.ApplicationMessage, "Có lỗi xảy ra!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                thamsoDTO = (ThamSo_DTO)Res.Obj1;
                {
                    var withBlock = thamsoDTO;
                    txt_SoLuongNhapToiThieu.Text = withBlock.SoLuongNhapToiThieu1.ToString();
                    txt_SoLuongTonToiDa.Text = withBlock.SoLuongTonToiDa1.ToString();
                    txt_SoLuongTonToiThieu.Text = withBlock.SoLuongTonToiThieu1.ToString();
                    txt_SoTienNoToiDa.Text = Math.Round(withBlock.SoTienNoToiDa1, 3).ToString();
                    cb_SuDungQD4.Checked = withBlock.SuDungQD41;
                }
            }
        }

        /// <summary>
        ///     ''' Set trạng thái chỉ đọc cho các checkbox textbox
        ///     ''' </summary>
        ///     ''' <param name="x"></param>
        private void ChoPhepCapNhatThamSo(bool x)
        {
            txt_SoLuongNhapToiThieu.ReadOnly = !x;
            txt_SoLuongTonToiDa.ReadOnly = !x;
            txt_SoLuongTonToiThieu.ReadOnly = !x;
            txt_SoTienNoToiDa.ReadOnly = !x;
            cb_SuDungQD4.Enabled = x;
        }

        private void btn_KhoiPhucMacDinh_Click(object sender, EventArgs e)
        {
            {
                var withBlock = thamsoDTO;
                withBlock.SoLuongNhapToiThieu1 = 150;
                withBlock.SoLuongTonToiDa1 = 300;
                withBlock.SoLuongTonToiThieu1 = 20;
                withBlock.SoTienNoToiDa1 = 20000;
                withBlock.SuDungQD41 = true;

                txt_SoLuongNhapToiThieu.Text = withBlock.SoLuongNhapToiThieu1.ToString();
                txt_SoLuongTonToiDa.Text = withBlock.SoLuongTonToiDa1.ToString();
                txt_SoLuongTonToiThieu.Text = withBlock.SoLuongTonToiThieu1.ToString();
                txt_SoTienNoToiDa.Text = Math.Round(withBlock.SoTienNoToiDa1, 3).ToString();
                cb_SuDungQD4.Checked = withBlock.SuDungQD41;

            }

            Res = thamsoBUS.Update(thamsoDTO);
            if ((Res.FlagResult == false))
            {
                MessageBox.Show(Res.ApplicationMessage, "Có lỗi xảy ra!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Khôi phục mặc định thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //ChoPhepCapNhatThamSo(false);
                //DangCapNhat = false;
            }
        }
    }
}
