using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using DTO;
using BUS;
using Utility;

namespace GUI
{
    public partial class UC_LapHoaDon : UserControl
    {
        private Sach_DTO sachDTO;
        private Sach_BUS sachBUS;
        private Sach_DTO sach;
        private HoaDon_BUS hoaDonBUS;
        private HoaDon_DTO hoaDonDTO;
        private HoaDon_DTO hoadon;
        private ThamSo_DTO thamSoDTO;
        private ThamSo_BUS thamSoBUS;
        private KhachHang_BUS khachHangBUS;
        private KhachHang_DTO khachHangDTO;
        private KhachHang_DTO kh;

        private ChiTietHoaDon_BUS chiTietHoaDonBUS;
        private ChiTietHoaDon_DTO chiTietHoaDonDTO;

        private Result res, res1;
        private int stt;
        private int count;
        private int rowTrungTen;
        private string ThongBaoTienNoVuotQuyDinh = "";
        public UC_LapHoaDon()
        {
            InitializeComponent();
            sachDTO = new Sach_DTO();
            sachBUS = new Sach_BUS();
            hoaDonDTO = new HoaDon_DTO();
            hoaDonBUS = new HoaDon_BUS();
            chiTietHoaDonBUS = new ChiTietHoaDon_BUS();
            chiTietHoaDonDTO = new ChiTietHoaDon_DTO();
            thamSoDTO = new ThamSo_DTO();
            thamSoBUS = new ThamSo_BUS();
            khachHangBUS = new KhachHang_BUS();
            khachHangDTO = new KhachHang_DTO();
        }

        public void ReloadMaHoaDon()
        {
            // Lấy mã hóa đơn
            res = hoaDonBUS.GetNextIncrement();
            if ((res.FlagResult == false))
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_MaHoaDon.Text = System.Convert.ToInt32(res.Obj1).ToString();
        }



        private void CapNhatTongTien()
        {
            int i = 0;
            double tongTien = 0;
            double temp;
            while ((i < dgv_listSach.Rows.Count - 1))
            {
                if ((double.TryParse(dgv_listSach.Rows[i].Cells[7].Value.ToString(), out temp)))
                    tongTien = tongTien + temp;
                i = i + 1;
            }
            txt_TongTien.Text = Math.Round(tongTien, 3).ToString();
        }


        private void ChangeColor_SaiQuyDinh(int rowIndex)
        {
            dgv_listSach.Rows[rowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
        }
        private void ChangeColor_SaiCuPhap(int rowIndex)
        {
            dgv_listSach.Rows[rowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
        }
        private void Original_Color(int rowIndex)
        {
            //dgv_listSach.Rows[rowIndex].DefaultCellStyle.BackColor = null;
        }

        private void UC_LapHoaDon_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            InitColumnsDataGridViewListSach();

            // chỉnh màu cho các ô cho phép ng dùng nhập
            dgv_listSach.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSach.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSach.Columns[3].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSach.Columns[5].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSach.Columns[6].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSach.Columns[7].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // init
            dgv_listSach["STT", 0].Value = 1;
            stt = 1;

            ReloadMaHoaDon();

            txt_TongTien.Text = "0";
        }


        private void InitColumnsDataGridViewListSach()
        {
            var stt = new DataGridViewTextBoxColumn();
            {
                var withBlock = stt;
                withBlock.Name = "STT";
                withBlock.HeaderText = "STT";
                withBlock.ReadOnly = true;
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_listSach.Columns.Add(stt);

            var txtMaSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = txtMaSach;
                withBlock.Name = "MaSach";
                withBlock.HeaderText = "Mã sách";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_listSach.Columns.Add(txtMaSach);

            var clTenSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTenSach;
                withBlock.Name = "TenSach";
                withBlock.HeaderText = "Tên sách";
                withBlock.ReadOnly = true;
                withBlock.DataPropertyName = "TenSach1";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_listSach.Columns.Add(clTenSach);


            var clTheLoai = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTheLoai;
                withBlock.Name = "TheLoai";
                withBlock.HeaderText = "Thể loại";
                withBlock.ReadOnly = true;
                withBlock.DataPropertyName = "TheLoai1";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv_listSach.Columns.Add(clTheLoai);


            var clSoLuongNhap = new DataGridViewTextBoxColumn();
            {
                var withBlock = clSoLuongNhap;
                withBlock.Name = "SoLuongNhap";
                withBlock.HeaderText = "Số lượng bán";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_listSach.Columns.Add(clSoLuongNhap);

            var clTacGia = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTacGia;
                withBlock.Name = "TacGia";
                withBlock.HeaderText = "Tác giả";
                withBlock.ReadOnly = true;
                withBlock.DataPropertyName = "TacGia1";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_listSach.Columns.Add(clTacGia);

            var clDonGia = new DataGridViewTextBoxColumn();
            {
                var withBlock = clDonGia;
                withBlock.Name = "DonGia";
                withBlock.HeaderText = "Đơn giá";
                withBlock.ReadOnly = true;
                withBlock.DataPropertyName = "DonGia1";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgv_listSach.Columns.Add(clDonGia);

            var clThanhTien = new DataGridViewTextBoxColumn();
            {
                var withBlock = clThanhTien;
                withBlock.Name = "ThanhTien";
                withBlock.HeaderText = "Thành tiền";
                withBlock.ReadOnly = true;
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgv_listSach.Columns.Add(clThanhTien);

            double rong = dgv_listSach.Width;
            dgv_listSach.Columns["STT"].Width = (int)(rong * 0.06);
            dgv_listSach.Columns["MaSach"].Width = (int)(rong * 0.11);
            dgv_listSach.Columns["TenSach"].Width = (int)(rong * 0.25 - 55);
            dgv_listSach.Columns["TheLoai"].Width = (int)(rong * 0.1);

            dgv_listSach.Columns["TacGia"].Width = (int)(rong * 0.1);
            dgv_listSach.Columns["SoLuongNhap"].Width = (int)(rong * 0.14 - 5);

            dgv_listSach.Columns["DonGia"].Width = (int)(rong * 0.11);

            dgv_listSach.Columns["ThanhTien"].Width = (int)(rong * 0.13);



            dgv_listSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv_listSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }


        private void txt_MaKH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên kh theo mã kh
                if ((txt_MaKH.Text == ""))
                {
                    txt_MaKH.Focus();
                    txt_HoTenKH.Text = "";
                    txt_SoTienNo.Text = "";
                    txt_SoTienNo.BackColor = Color.FromArgb(240, 240, 240);
                    return;
                }

                if ((sachBUS.isValidMaSach(txt_MaKH.Text).FlagResult == false))
                {
                    txt_HoTenKH.Text = "";
                    txt_SoTienNo.Text = "";
                    return;
                }


                res = khachHangBUS.selectTenKH_ByMaKH(System.Convert.ToInt32(txt_MaKH.Text));
                if ((res.FlagResult == false))
                {
                    txt_HoTenKH.Text = "";
                    txt_SoTienNo.Text = "";
                    txt_SoTienNo.BackColor = Color.FromArgb(240, 240, 240);
                    return;
                }
                txt_HoTenKH.Text = System.Convert.ToString(res.Obj1);
                // Lấy tên kh theo mã kh


                // lấy thông tin tiền kh đang nợ
                res = khachHangBUS.selectTienNo_KhachHang(System.Convert.ToInt32(txt_MaKH.Text));
                if ((res.FlagResult == false))
                    return;
                else
                    txt_SoTienNo.Text = Math.Round(System.Convert.ToDouble(res.Obj1), 3).ToString();

                // kiểm tra nợ so với QĐ
                Result res2 = khachHangBUS.KiemTraNo(System.Convert.ToDouble(txt_SoTienNo.Text));
                if ((res2.FlagResult == false))
                {
                    txt_SoTienNo.BackColor = Color.OrangeRed;
                    ThongBaoTienNoVuotQuyDinh = res2.ApplicationMessage;
                    return;
                }

                txt_SoTienNo.BackColor = Color.FromArgb(240, 240, 240); // gán lại màu bình thường
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        private void dgv_listSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex != 1 & e.ColumnIndex != 4 & e.ColumnIndex != 7))
                return;

            try
            {

                // Load tự động stt 
                if ((dgv_listSach["STT", e.RowIndex + 1].Value == null))
                {
                    stt = stt + 1;
                    dgv_listSach["STT", e.RowIndex + 1].Value = stt;
                }


                if ((e.ColumnIndex == 1))
                {
                    dgv_listSach.Rows[e.RowIndex].Cells[2].Value = string.Empty;
                    dgv_listSach.Rows[e.RowIndex].Cells[3].Value = string.Empty;
                    dgv_listSach.Rows[e.RowIndex].Cells[4].Value = string.Empty;
                    dgv_listSach.Rows[e.RowIndex].Cells[5].Value = string.Empty;
                    dgv_listSach.Rows[e.RowIndex].Cells[6].Value = string.Empty;
                    dgv_listSach.Rows[e.RowIndex].Cells[7].Value = string.Empty;

                    if ((dgv_listSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == string.Empty))
                    {
                        // KHi ô mã sách bị xóa rỗng
                        dgv_listSach.Rows.RemoveAt(e.RowIndex); // nếu mã trống thì clear dòng

                        CapNhatTongTien();
                        // Cập nhật lại STT khi 1 dòng bị xóa
                        CapNhatLaiSTT(e.RowIndex);
                        // Cập nhật lại STT khi 1 dòng bị xóa
                        return;
                    }

                    // kt mã sách có đc nhập trước đó ko
                    for (int i = 0; i <= dgv_listSach.Rows.Count - 1; i++)
                    {
                        if (dgv_listSach.Rows[i].Cells[1].Value == dgv_listSach.Rows[e.RowIndex].Cells[1].Value & i != e.RowIndex)
                        {
                            MessageBox.Show("Mã sách vừa nhập đã tồn tại!");
                            dgv_listSach.Rows.Remove(dgv_listSach.Rows[e.RowIndex]);
                            // Cập nhật lại STT khi 1 dòng bị xóa
                            CapNhatLaiSTT(e.RowIndex);
                            // Cập nhật lại STT khi 1 dòng bị xóa
                            return;
                        }
                    }

                    // Kiểm tra nhập đúng định dạng không?
                    res = sachBUS.isValidMaSach(dgv_listSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    if ((res.FlagResult == false))
                    {
                        ChangeColor_SaiCuPhap(e.RowIndex);
                        return;
                    }


                    // lấy thông tin sách theo mã đã nhập
                    res = sachBUS.selectSach_ByMaSach(int.Parse(dgv_listSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                    if ((res.FlagResult == false))
                    {
                        ChangeColor_SaiCuPhap(e.RowIndex);
                        return;
                    }
                    sach = (Sach_DTO)res.Obj1;
                    dgv_listSach["TenSach", e.RowIndex].Value = sach.TenSach1;
                    dgv_listSach["TheLoai", e.RowIndex].Value = sach.TheLoai1;
                    dgv_listSach["TacGia", e.RowIndex].Value = sach.TacGia1;
                    dgv_listSach["DonGia", e.RowIndex].Value = Math.Round(sach.DonGia1, 3);
                }

                // Khi nhập/thay đổi số lượng bán
                if ((e.ColumnIndex == 4))
                {
                    dgv_listSach["ThanhTien", e.RowIndex].Value = string.Empty;
                    // CapNhatTongTien()

                    // Khi xóa sl - ô sl trống
                    if (dgv_listSach.Rows[e.RowIndex].Cells[4].Value == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        ChangeColor_SaiCuPhap(e.RowIndex); // ĐỔi màu báo hiệu chưa hoàn thành
                        dgv_listSach.Rows[e.RowIndex].Cells[7].Value = ""; // xóa ô thành tiền
                                                                           // CapNhatTongTien()
                        return;
                    }

                    // khi chưa nhập mã sách mà lại nhập số lượng
                    if ((dgv_listSach.Rows[e.RowIndex].Cells[1].Value.ToString() == string.Empty))
                    {
                        dgv_listSach.Rows[e.RowIndex].Cells[4].Value = string.Empty;
                        MessageBox.Show("Bạn chưa nhập mã sách", "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    // kiểm tra nhập đúng cú pháp không?
                    res = chiTietHoaDonBUS.isValidSoLuongBan(dgv_listSach.Rows[e.RowIndex].Cells[4].Value.ToString());
                    if ((res.FlagResult == false))
                    {
                        ChangeColor_SaiCuPhap(e.RowIndex);
                        return;
                    }

                    res = sachBUS.selectSach_ByMaSach(int.Parse(dgv_listSach.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    if ((res.FlagResult == false))
                    {
                        ChangeColor_SaiQuyDinh(e.RowIndex);
                        return;
                    }
                    else
                        sach = (Sach_DTO)res.Obj1;

                    int slton = sach.SoLuongTon1 - int.Parse(dgv_listSach.Rows[e.RowIndex].Cells[4].Value.ToString());
                    Result res2 = chiTietHoaDonBUS.isValidSoLuongSachTon(slton);
                    if ((res2.FlagResult == false))
                    {
                        ChangeColor_SaiQuyDinh(e.RowIndex);
                        return;
                    }
                    Original_Color(e.RowIndex); // Set màu xác nhận đúng
                    dgv_listSach["ThanhTien", e.RowIndex].Value = double.Parse(dgv_listSach["DonGia", e.RowIndex].Value.ToString()) * int.Parse(dgv_listSach["SoLuongNhap", e.RowIndex].Value.ToString());
                }

                if ((e.ColumnIndex == 7))
                    CapNhatTongTien();
            }


            catch (Exception ex)
            {
            }
        }


        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (txt_SoTienNo.BackColor == Color.OrangeRed)
            {
                MessageBox.Show(ThongBaoTienNoVuotQuyDinh, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txt_HoTenKH.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập thông tin khách hàng!" + Environment.NewLine + "Hoặc thông tin khách hàng không chính xác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgv_listSach.Rows[0].Cells[1].Value == null)
            {
                MessageBox.Show("Vui lòng nhập thông tin các chi tiết hóa đơn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }




            for (int j = 0; j <= dgv_listSach.Rows.Count - 1; j++)
            {
                if (dgv_listSach.Rows[j].Cells[1].Value == null & dgv_listSach.Rows[j].Cells[4].Value == null)
                    continue;
                else if (dgv_listSach.Rows[j].Cells[1].Value.ToString() != "")
                {
                    if (dgv_listSach.Rows[j].Cells[4].Value == null)
                        ChangeColor_SaiCuPhap(j);
                    else if (dgv_listSach.Rows[j].Cells[6].Value == null)
                        ChangeColor_SaiCuPhap(j);
                }
            }

            //for (int j = 0; j <= dgv_listSach.Rows.Count - 1; j++)
            //{
                //if (dgv_listSach.Rows[j].DefaultCellStyle.BackColor == Color.OrangeRed | dgv_listSach.Rows[j].DefaultCellStyle.BackColor == Color.GreenYellow)
                //{
                    //MessageBox.Show("Một số dòng nhập liệu sai quy định. Vui lòng kiểm tra lại!");
                    //return;
                //}
           // }


            // insert vào hóa đơn
            {
                var withBlock = hoaDonDTO;
                withBlock.NgayLapHoaDon1 = dtp_NgayLap.Value;
                withBlock.MaKhachHang1 = System.Convert.ToInt32(txt_MaKH.Text);
            }

            res = hoaDonBUS.insertHoaDon(hoaDonDTO);
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int i;
            i = 0;
            do
            {
                {
                    var withBlock = chiTietHoaDonDTO;
                    withBlock.MaHoaDon1 = System.Convert.ToInt32(txt_MaHoaDon.Text);
                    withBlock.MaSach1 = System.Convert.ToInt32(dgv_listSach.Rows[i].Cells[1].Value);
                    withBlock.SoLuongban1 = System.Convert.ToInt32(dgv_listSach.Rows[i].Cells[4].Value);
                    withBlock.DonGiaBan1 = System.Convert.ToDouble(dgv_listSach.Rows[i].Cells[6].Value);
                }

                res = chiTietHoaDonBUS.insertChiTietHoaDon(chiTietHoaDonDTO);
                if ((res.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Result ResKhachHang = khachHangBUS.selectKhachHang_ByMaKH(hoaDonDTO.MaKhachHang1);
                if ((ResKhachHang.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Lỗi cập nhật lượng tồn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                khachHangDTO = (KhachHang_DTO)ResKhachHang.Obj1;
                Result res3 = sachBUS.selectSach_ByMaSach(chiTietHoaDonDTO.MaSach1);
                if ((res3.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                khachHangDTO.TienNo1 += System.Convert.ToDouble(((Sach_DTO)res3.Obj1).DonGia1) * chiTietHoaDonDTO.SoLuongban1;
                ResKhachHang = khachHangBUS.update(khachHangDTO);
                if ((ResKhachHang.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Lỗi cập nhật tiền nợ KH!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Result ResSach = sachBUS.selectSach_ByMaSach(chiTietHoaDonDTO.MaSach1);
                if ((ResSach.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Lỗi cập nhật lượng tồn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sachDTO = (Sach_DTO)ResSach.Obj1;
                sachDTO.SoLuongTon1 -= chiTietHoaDonDTO.SoLuongban1;
                ResSach = sachBUS.updateSach(sachDTO);
                if ((ResSach.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Lỗi cập nhật lượng tồn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                i = i + 1;
                if ((dgv_listSach.Rows[i].Cells[1].Value == null))
                    break;
            }
            while (!(false))// Cập nhật lại lượng tồn// Cập nhật lại lượng tồn sau khi bán
    ;


            MessageBox.Show("Lập hóa đơn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReloadMaHoaDon();

            dgv_listSach.Rows.Clear();
            dgv_listSach["STT", 0].Value = 1;
            stt = 1;
            txt_TongTien.Text = "0";
        }


        private void dgv_listSach_Enter(object sender, EventArgs e)
        {
            if (txt_SoTienNo.BackColor == Color.OrangeRed)
                MessageBox.Show(ThongBaoTienNoVuotQuyDinh, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dgv_listSach_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
        }

        /// <summary>
        ///     ''' Cập nhật lại STT của bảng bắt đầu tại vị trí X
        ///     ''' </summary>
        ///     ''' <param name="x">vị trí dong bắt đầu cập nhật</param>
        private void CapNhatLaiSTT(int x)
        {
            for (int i = x; i <= dgv_listSach.Rows.Count - 1; i++)
            {
                if ((i - 1 == -1))
                    dgv_listSach.Rows[i].Cells[0].Value = 1;
                else
                    dgv_listSach.Rows[i].Cells[0].Value = int.Parse(dgv_listSach.Rows[i - 1].Cells[0].Value.ToString()) + 1;
                stt = int.Parse(dgv_listSach.Rows[i].Cells[0].Value.ToString());
            }
        }

        private void dgv_listSach_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CapNhatLaiSTT(0); // cập nhật lại STT tất cả
            CapNhatTongTien();
        }


        private void btn_XoaDongLoi_Click(object sender, EventArgs e)
        {
            int i = 0;
            while ((true))
            {
                if ((i > dgv_listSach.Rows.Count - 1))
                    break;
                if (dgv_listSach.Rows[i].DefaultCellStyle.BackColor == Color.OrangeRed | dgv_listSach.Rows[i].DefaultCellStyle.BackColor == Color.GreenYellow)
                {
                    dgv_listSach.Rows.RemoveAt(i);
                    i = i - 1;
                }
                i = i + 1;
            }

            CapNhatLaiSTT(0);
            CapNhatTongTien();
        }
    }
}
