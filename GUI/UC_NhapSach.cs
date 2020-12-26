using System;
using System.Drawing;
using System.Windows.Forms;
using DTO;
using BUS;
using Utility;
namespace GUI
{

    public partial class UC_NhapSach : UserControl
    {

        private Sach_DTO sachDTO;
        private Sach_DTO sach;
        private Sach_BUS sachBUS = new Sach_BUS();

        private PhieuNhapSach_BUS phieuNhapBUS;
        private PhieuNhapSach_DTO phieuNhapDTO;

        private ChiTIetPhieuNhap_BUS chiTietPhieuNhapBUS;
        private ChiTIetPhieuNhap_DTO chiTietPhieuNhapDTO;

        private ThamSo_DTO thamSoDTO;
        private ThamSo_BUS thamSoBUS;
        private ThamSo_DTO ts;

        private Result res;
        private Result res1;
        private int count;
        private int rowTrungTen;
        private int STT;


        public UC_NhapSach()
        {
            InitializeComponent();

            phieuNhapDTO = new PhieuNhapSach_DTO();
            phieuNhapBUS = new PhieuNhapSach_BUS();
            chiTietPhieuNhapDTO = new ChiTIetPhieuNhap_DTO();
            chiTietPhieuNhapBUS = new ChiTIetPhieuNhap_BUS();
            thamSoBUS = new ThamSo_BUS();
            res = thamSoBUS.SelectAll_ThamSo();
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage, "Lỗi xẩy ra!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                thamSoDTO = new ThamSo_DTO();
            }
            else
                thamSoDTO = (ThamSo_DTO)res.Obj1;
        }
        

        public void reload_GUI()
        {
            this.Width = this.Parent.Size.Width;
            this.Height = this.Parent.Size.Height;
        }

        public void reloadMaPhieuNhap()
        {
            res = phieuNhapBUS.GetNextIncrement();
            if ((res.FlagResult == false))
            {
                MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txt_MaPhieuNhap.Text = System.Convert.ToInt32(res.Obj1).ToString();
        }

        private void ChangeColor_SaiQuyDinh(int rowIndex)
        {
            dgv_listSachNhap.Rows[rowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
        }
        private void ChangeColor_SaiCuPhap(int rowIndex)
        {
            dgv_listSachNhap.Rows[rowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
        }
        private void Original_Color(int rowIndex)
        {
            //dgv_listSachNhap.Rows[rowIndex].DefaultCellStyle.BackColor = null;
        }

        private void UC_NhapSach_Load(object sender, EventArgs e)
        {
            res = thamSoBUS.SelectAll_ThamSo();
            ts = (ThamSo_DTO)res.Obj1;
            txt_SLnhapToiThieu.Text = ts.SoLuongNhapToiThieu1.ToString();
            txt_SLtonToiDa.Text = ts.SoLuongTonToiDa1.ToString();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            InitColumnsDataGridViewListSach();

            // chỉnh màu cho các ô cho phép ng dùng nhập
            dgv_listSachNhap.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSachNhap.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSachNhap.Columns[3].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSachNhap.Columns[4].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSachNhap.Columns[5].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv_listSachNhap.Columns[7].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            reloadMaPhieuNhap();

            dgv_listSachNhap["STT", 0].Value = 1;
            STT = 1;
        }

        private void InitColumnsDataGridViewListSach()
        {
            var txtSTT = new DataGridViewTextBoxColumn();
            {
                var withBlock = txtSTT;
                withBlock.Name = "STT";
                withBlock.HeaderText = "STT";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                withBlock.ReadOnly = true;
            }
            dgv_listSachNhap.Columns.Add(txtSTT);



            var txtMaSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = txtMaSach;
                withBlock.Name = "MaSach";
                withBlock.HeaderText = "Mã sách";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_listSachNhap.Columns.Add(txtMaSach);


            var clTenSach = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTenSach;
                withBlock.Name = "TenSach";
                withBlock.HeaderText = "Tên sách";
                withBlock.ReadOnly = true;
                withBlock.DataPropertyName = "TenSach1";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_listSachNhap.Columns.Add(clTenSach);


            var clTheLoai = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTheLoai;
                withBlock.Name = "TheLoai";
                withBlock.HeaderText = "Thể loại";
                withBlock.ReadOnly = true;
                withBlock.DataPropertyName = "TheLoai1";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_listSachNhap.Columns.Add(clTheLoai);


            var clTacGia = new DataGridViewTextBoxColumn();
            {
                var withBlock = clTacGia;
                withBlock.Name = "TacGia";
                withBlock.HeaderText = "Tác giả";
                withBlock.ReadOnly = true;
                withBlock.DataPropertyName = "TacGia1";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_listSachNhap.Columns.Add(clTacGia);


            var clSoLuongTon = new DataGridViewTextBoxColumn();
            {
                var withBlock = clSoLuongTon;
                withBlock.Name = "SoLuongTon";
                withBlock.HeaderText = "Lượng tồn";
                withBlock.ReadOnly = true;
                withBlock.DataPropertyName = "SoLuongTon1";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_listSachNhap.Columns.Add(clSoLuongTon);


            var clSoLuongNhap = new DataGridViewTextBoxColumn();
            {
                var withBlock = clSoLuongNhap;
                withBlock.Name = "SoLuongNhap";
                withBlock.HeaderText = "Lượng nhập";
                withBlock.SortMode = DataGridViewColumnSortMode.NotSortable;
                withBlock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_listSachNhap.Columns.Add(clSoLuongNhap);


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
            dgv_listSachNhap.Columns.Add(clDonGia);


            double rong = dgv_listSachNhap.Width;

            dgv_listSachNhap.Columns["STT"].Width = (int)(rong * 0.08);

            dgv_listSachNhap.Columns["MaSach"].Width = (int)(rong * 0.1);

            dgv_listSachNhap.Columns["TenSach"].Width = (int)(rong * 0.22 - 55);

            dgv_listSachNhap.Columns["TheLoai"].Width = (int)(rong * 0.1 - 3);

            dgv_listSachNhap.Columns["TacGia"].Width = (int)(rong * 0.14);

            dgv_listSachNhap.Columns["SoLuongTon"].Width = (int)(rong * 0.12);

            dgv_listSachNhap.Columns["SoLuongNhap"].Width = (int)(rong * 0.14);


            dgv_listSachNhap.Columns["DonGia"].Width = (int)(rong * 0.1);

            dgv_listSachNhap.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv_listSachNhap.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }


        private void dgv_listSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex != 1 & e.ColumnIndex != 6))
                return;


            // Load tự động stt 
            if ((dgv_listSachNhap["STT", e.RowIndex + 1].Value == null))
            {
                STT = STT + 1;
                dgv_listSachNhap["STT", e.RowIndex + 1].Value = STT;
            }

            try
            {
                if ((e.ColumnIndex == 1))
                {
                    dgv_listSachNhap.Rows[e.RowIndex].Cells[2].Value = "";
                    dgv_listSachNhap.Rows[e.RowIndex].Cells[3].Value = "";
                    dgv_listSachNhap.Rows[e.RowIndex].Cells[4].Value = "";
                    dgv_listSachNhap.Rows[e.RowIndex].Cells[5].Value = "";
                    dgv_listSachNhap.Rows[e.RowIndex].Cells[6].Value = "";
                    dgv_listSachNhap.Rows[e.RowIndex].Cells[7].Value = "";




                    if ((dgv_listSachNhap.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == string.Empty))
                    {
                        dgv_listSachNhap.Rows.RemoveAt(e.RowIndex); // clear dòng
                        CapNhatLaiSTT(e.RowIndex); // Cập nhật STT
                        return;
                    }

                    // kt mã sách có đc nhập trước đó ko
                    for (int i = 0; i <= dgv_listSachNhap.Rows.Count - 1; i++)
                    {
                        if (dgv_listSachNhap.Rows[i].Cells[1].Value == dgv_listSachNhap.Rows[e.RowIndex].Cells[1].Value & i != e.RowIndex)
                        {
                            MessageBox.Show("Mã sách vừa nhập đã tồn tại!");
                            dgv_listSachNhap.Rows.Remove(dgv_listSachNhap.Rows[e.RowIndex]); // clear dòng
                                                                                             // Cập nhật lại STT khi 1 dòng bị xóa
                            CapNhatLaiSTT(e.RowIndex);
                            // Cập nhật lại STT khi 1 dòng bị xóa                        
                            return;
                        }
                    }
                    // kt mã sách có đc nhập trước đó ko



                    res = sachBUS.isValidMaSach(dgv_listSachNhap.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()); // kiểm tra mã sách nhập hợp lệ ko?
                    if ((res.FlagResult == false))
                    {
                        ChangeColor_SaiCuPhap(e.RowIndex);
                        return;
                    }

                    res = sachBUS.selectSach_ByMaSach(int.Parse(dgv_listSachNhap.Rows[e.RowIndex].Cells[1].Value.ToString())); // lấy thông tin từ mã sách
                    if ((res.FlagResult == false))
                        ChangeColor_SaiCuPhap(e.RowIndex);
                    sach = (Sach_DTO)res.Obj1;

                    dgv_listSachNhap["TenSach", e.RowIndex].Value = sach.TenSach1;
                    dgv_listSachNhap["TheLoai", e.RowIndex].Value = sach.TheLoai1;
                    dgv_listSachNhap["TacGia", e.RowIndex].Value = sach.TacGia1;
                    dgv_listSachNhap["SoLuongTon", e.RowIndex].Value = sach.SoLuongTon1;
                    dgv_listSachNhap["DonGia", e.RowIndex].Value = Math.Round(sach.DonGia1, 3);

                    res1 = chiTietPhieuNhapBUS.isValidSoLuongTonToiDa(sach.SoLuongTon1.ToString());
                    if ((res1.FlagResult == false))
                        ChangeColor_SaiQuyDinh(e.RowIndex);
                    return;
                }


                if ((e.ColumnIndex == 6))
                {
                    if (dgv_listSachNhap.Rows[e.RowIndex].Cells[6].Value.ToString() != "")
                    {
                        if ((dgv_listSachNhap.Rows[e.RowIndex].Cells[1].Value.ToString() == string.Empty))
                        {
                            dgv_listSachNhap.Rows[e.RowIndex].Cells[6].Value = "";
                            MessageBox.Show("Bạn chưa nhập mã sách", "Lỗi nhập liệu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        ChangeColor_SaiCuPhap(e.RowIndex);
                        return;
                    }


                    res = sachBUS.selectSach_ByMaSach(int.Parse(dgv_listSachNhap.Rows[e.RowIndex].Cells[1].Value.ToString())); // lấy thông tin sách
                    if ((res.FlagResult == false))
                    {
                        dgv_listSachNhap.Focus();
                        ChangeColor_SaiCuPhap(e.RowIndex);
                        return;
                    }

                    sach = (Sach_DTO)res.Obj1;
                    res1 = chiTietPhieuNhapBUS.isValidSoLuongTonToiDa(sach.SoLuongTon1.ToString()); // Kiểm tra QĐ về số lượng tồn
                    if ((res1.FlagResult == false))
                    {
                        ChangeColor_SaiQuyDinh(e.RowIndex);
                        return;
                    }

                    res = chiTietPhieuNhapBUS.isValidSoLuongNhap(dgv_listSachNhap.Rows[e.RowIndex].Cells[6].Value.ToString()); // kiểm tra số lượng nhập đúng cú pháp ko?
                    if ((res.FlagResult == false))
                    {
                        ChangeColor_SaiCuPhap(e.RowIndex);
                        return;
                    }

                    res = chiTietPhieuNhapBUS.isValidSoLuongNhapToiThieu(dgv_listSachNhap.Rows[e.RowIndex].Cells[6].Value.ToString()); // Kiểm tra QĐ về số lượng nhập tối thiểu
                    if ((res.FlagResult == false))
                    {
                        ChangeColor_SaiQuyDinh(e.RowIndex);
                        return;
                    }
                    Original_Color(e.RowIndex); // ĐÚng hết thì set màu bình thường
                }
            }
            catch (Exception ex)
            {
            }
        }



        private void btn_NhapSach_Click(object sender, EventArgs e)
        {
            if (dgv_listSachNhap.Rows[0].Cells[1].Value == null)
            {
                MessageBox.Show("Vui lòng nhập thông tin của phiếu nhập!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int j = 0; j <= dgv_listSachNhap.Rows.Count - 1; j++)
            {
                if (dgv_listSachNhap.Rows[j].Cells[1].Value == null/* TODO Change to default(_) if this is not a reference type */ & dgv_listSachNhap.Rows[j].Cells[6].Value == null/* TODO Change to default(_) if this is not a reference type */ )
                    continue;
                else
                {
                    if (dgv_listSachNhap.Rows[j].DefaultCellStyle.BackColor == Color.OrangeRed)
                        continue;
                    if (dgv_listSachNhap.Rows[j].Cells[1].Value == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        ChangeColor_SaiCuPhap(j);
                        continue;
                    }
                    if (dgv_listSachNhap.Rows[j].Cells[6].Value == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        ChangeColor_SaiCuPhap(j);
                        continue;
                    }
                }
            }

            //for (int j = 0; j <= dgv_listSachNhap.Rows.Count - 1; j++)
            //{
                //if (dgv_listSachNhap.Rows[j].DefaultCellStyle.BackColor == Color.OrangeRed | dgv_listSachNhap.Rows[j].DefaultCellStyle.BackColor == Color.GreenYellow)
                //{
                   // MessageBox.Show("Một số dòng nhập liệu sai quy định. Vui lòng kiểm tra lại!");
                   // return;
                //}
            //}


            {
                var withBlock = phieuNhapDTO;
                phieuNhapDTO.NgayNhap1 = dtp_NgayNhap.Value;
            }

            res = phieuNhapBUS.insertPhieuNhap(phieuNhapDTO);
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
                    var withBlock = chiTietPhieuNhapDTO;
                    withBlock.MaPhieuNhap1 = int.Parse(txt_MaPhieuNhap.Text);
                    withBlock.MaSach1 = int.Parse(dgv_listSachNhap.Rows[i].Cells[1].Value.ToString());
                    withBlock.SoLuongNhap1 = int.Parse(dgv_listSachNhap.Rows[i].Cells[6].Value.ToString());
                }

                res = chiTietPhieuNhapBUS.insertChiTietPhieuNhap(chiTietPhieuNhapDTO);
                if ((res.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Result ResSach = sachBUS.selectSach_ByMaSach(chiTietPhieuNhapDTO.MaSach1);
                if ((ResSach.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Lỗi cập nhật lượng tồn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sachDTO = (Sach_DTO)ResSach.Obj1;
                sachDTO.SoLuongTon1 += chiTietPhieuNhapDTO.SoLuongNhap1;
                ResSach = sachBUS.updateSach(sachDTO);
                if ((ResSach.FlagResult == false))
                {
                    MessageBox.Show(res.ApplicationMessage + Environment.NewLine + res.SystemMessage, "Lỗi cập nhật lượng tồn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                i = i + 1;
                if ((dgv_listSachNhap.Rows[i].Cells[1].Value == null))
                    break;
            }
            while (!(false))// Cập nhật lại lượng tồn
            ; // ko còn mã phiếu nhập 

            MessageBox.Show("Lập phiếu nhập sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reloadMaPhieuNhap();
            dgv_listSachNhap.Rows.Clear();


            dgv_listSachNhap["STT", 0].Value = 1;
            STT = 1;
        }


        private void dgv_listSachNhap_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
        }



        private void btn_XoaDongLoi_Click(object sender, EventArgs e)
        {
            int i = 0;
            while ((true))
            {
                if ((i > dgv_listSachNhap.Rows.Count - 1))
                    break;
                if (dgv_listSachNhap.Rows[i].DefaultCellStyle.BackColor == Color.OrangeRed | dgv_listSachNhap.Rows[i].DefaultCellStyle.BackColor == Color.GreenYellow)
                {
                    dgv_listSachNhap.Rows.RemoveAt(i);
                    i = i - 1;
                }
                i = i + 1;
            }

            CapNhatLaiSTT(0);
        }


        private void CapNhatLaiSTT(int x)
        {
            for (int i = x; i <= dgv_listSachNhap.Rows.Count - 1; i++)
            {
                if ((i - 1 == -1))
                    dgv_listSachNhap.Rows[i].Cells[0].Value = 1;
                else
                    dgv_listSachNhap.Rows[i].Cells[0].Value = int.Parse(dgv_listSachNhap.Rows[i - 1].Cells[0].Value.ToString()) + 1;
                STT = int.Parse(dgv_listSachNhap.Rows[i].Cells[0].Value.ToString());
            }
        }

        private void dgv_listSachNhap_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CapNhatLaiSTT(0); // cập nhật lại STT tất cả
        }
    }
}
