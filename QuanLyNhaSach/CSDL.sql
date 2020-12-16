CREATE DATABASE QuanLyNhaSach
GO
USE QuanLyNhaSach
GO

CREATE TABLE NhaXuatBan
(
	MaNXB VARCHAR(10) not NULL,
	TenNXB NVARCHAR(100),
	DiaChiNXB NVARCHAR(100),
	DienThoai VARCHAR(20),
	CONSTRAINT pk_NXB PRIMARY KEY (MaNXB)
)
GO

CREATE TABLE PhieuNhap
(
	SoPN CHAR(4) NOT NULL,
	NgayNhap SMALLDATETIME,
	MaNXB VARCHAR(10),
	CONSTRAINT pk_PN PRIMARY KEY (SoPN),
	CONSTRAINT fk_PN FOREIGN KEY (MaNXB) REFERENCES dbo.NhaXuatBan(MaNXB)
)
GO

CREATE TABLE HoaDon
(
	SoHD CHAR(10) NOT NULL,
	NgayBan SMALLDATETIME,
	CONSTRAINT pk_HD PRIMARY KEY (SoHD)
)
GO

CREATE TABLE TacGia
(
	MaTG VARCHAR(10) NOT NULL,
	TenTG NVARCHAR(40),
	LienLac NVARCHAR(40),
	CONSTRAINT pk_TG PRIMARY KEY (MaTG)
)
GO

CREATE TABLE TheLoai
(
	MaTL VARCHAR(10) NOT NULL,
	TenTL NVARCHAR(10),
	CONSTRAINT pk_TL PRIMARY KEY (MaTL)
)
GO

CREATE TABLE Sach
(
	MaSach CHAR(10) NOT NULL,
	TenSach NVARCHAR(40),
	SoLuongTon INT,
	MaTL VARCHAR(10),
	MaTG VARCHAR(10),
	MaNXB VARCHAR(10),
	CONSTRAINT pk_S PRIMARY KEY (MaSach),
	CONSTRAINT fk_S_MaTL FOREIGN KEY (MaTL) REFERENCES dbo.TheLoai(MaTL),
	CONSTRAINT fk_S_MaTG FOREIGN KEY (MaTG) REFERENCES dbo.TacGia(MaTG),
	CONSTRAINT fk_S_MaNXB FOREIGN KEY (MaNXB) REFERENCES dbo.NhaXuatBan(MaNXB),
)
GO

CREATE TABLE ChiTietPhieuNhap
(
	MaSach CHAR(10) NOT NULL,
	SoPN CHAR(4) NOT NULL,
	SoLuongNhap INT,
	GiaNhap MONEY,
	CONSTRAINT pk_CTPN PRIMARY KEY(MaSach,SoPN),
	CONSTRAINT fk_CTPN_MaSach FOREIGN KEY (MaSach) REFERENCES dbo.Sach(MaSach),
	CONSTRAINT fk_CTPN_SoPN FOREIGN KEY (SoPN) REFERENCES dbo.PhieuNhap(SoPN),
)
GO

CREATE TABLE ChiTietHoaDon
(
	MaSach CHAR(10) NOT NULL,
	SoHD CHAR(10) NOT NULL,
	SoLuongBan INT,
	GiaBan MONEY,
	CONSTRAINT pk_CTHD PRIMARY KEY(MaSach,SoHD),
	CONSTRAINT fk_CTHD_MaSach FOREIGN KEY (MaSach) REFERENCES dbo.Sach(MaSach),
	CONSTRAINT fk_CTHD_SoHD FOREIGN KEY (SoHD) REFERENCES dbo.HoaDon(SoHD),
)
GO

CREATE TABLE TaiKhoan
(
	TenDN NVARCHAR(50) PRIMARY KEY NOT NULL,
	HoTen NVARCHAR(50) NOT NULL,
	Loai INT DEFAULT 0,
	MatKhau NVARCHAR(1000) NOT NULL
)
GO

--Đăng nhập
CREATE PROC USP_DangNhap
@tenDN NVARCHAR(50), @matKhau NVARCHAR(50)
AS
BEGIN
	SELECT * FROM TaiKhoan WHERE TenDN = @tenDN AND MatKhau = @matKhau
END
GO



SET DATEFORMAT DMY

ALTER TABLE Sach
ADD GiaTien INT

--Hiển thị sách
CREATE PROC USP_HienThiSach
AS
BEGIN
	Select s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền]
from Sach s 
inner join ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
inner join TacGia tg on s.MaTG=tg.MaTG
inner join TheLoai tl on s.MaTL=tl.MaTL
inner join NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
END
GO
	
--Hiển thị sách tìm kiếm
CREATE PROC USP_HienThiSachTimKiem
AS
BEGIN
	SELECT
	s.MaSach AS [ID],
	s.TenSach AS [Tên Sách],
	s.SoLuongTon AS [Số Lượng],
	s.GiaTien AS [Giá Tiền]
	FROM Sach s , ChiTietPhieuNhap ct, TacGia tg, TheLoai tl, NhaXuatBan nxb
	WHERE s.MaSach=ct.MaSach AND s.MaTG=tg.MaTG AND s.MaTL=tl.MaTL AND s.MaNXB=nxb.MaNXB
END

-- Tìm kiếm sách qua tên tác giả
CREATE PROC USP_TimSach_TacGia
@tacGia NVARCHAR(50)
AS
BEGIN
	SELECT s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền]
FROM Sach AS s 
inner join ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
inner join TacGia tg on s.MaTG=tg.MaTG
inner join TheLoai tl on s.MaTL=tl.MaTL
inner join NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
WHERE tg.TenTG LIKE CONCAT(@tacGia,'%')
END
GO
--Tìm kiếm sách qua tên sách

CREATE PROC USP_TimSach_TenSach
@tenSach NVARCHAR(50)
AS
BEGIN
	SELECT s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền]
FROM Sach AS s 
inner join ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
inner join TacGia tg on s.MaTG=tg.MaTG
inner join TheLoai tl on s.MaTL=tl.MaTL
inner join NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
WHERE s.TenSach LIKE CONCAT(@tenSach,'%')
END
GO

--Tìm kiếm sách qua thể loại
CREATE PROC USP_TimSach_TheLoai
@theLoai NVARCHAR(50)
AS
BEGIN
	SELECT s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền]
FROM Sach AS s 
inner join ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
inner join TacGia tg on s.MaTG=tg.MaTG
inner join TheLoai tl on s.MaTL=tl.MaTL
inner join NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
WHERE tl.TenTL LIKE CONCAT(@theLoai,'%')
END
GO


--Tìm kiếm sách qua tên sách và thể loại
CREATE PROC USP_TimSach_TenSach_TheLoai
@tenSach NVARCHAR(50), @theLoai NVARCHAR(50)
AS
BEGIN
	SELECT s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền]
FROM Sach AS s 
inner join ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
inner join TacGia tg on s.MaTG=tg.MaTG
inner join TheLoai tl on s.MaTL=tl.MaTL
inner join NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
WHERE tl.TenTL LIKE CONCAT(@theLoai,'%') AND s.TenSach LIKE CONCAT(@tenSach,'%')
END
GO

--Tìm kiếm sách qua tên sách và tác giả
CREATE PROC USP_TimSach_TenSach_TacGia
@tenSach NVARCHAR(50), @tacGia NVARCHAR(50)
AS
BEGIN
	SELECT s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền]
FROM Sach AS s 
inner join ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
inner join TacGia tg on s.MaTG=tg.MaTG
inner join TheLoai tl on s.MaTL=tl.MaTL
inner join NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
WHERE s.TenSach LIKE CONCAT(@tenSach,'%') AND tg.TenTG LIKE CONCAT(@tacGia,'%')
END
GO

--Tìm sách qua tác giả và thể loại
CREATE PROC USP_TimSach_TacGia_TheLoai
@tacGia NVARCHAR(50) , @theLoai NVARCHAR(50)
AS
BEGIN
	SELECT s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền]
FROM Sach AS s 
inner join ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
inner join TacGia tg on s.MaTG=tg.MaTG
inner join TheLoai tl on s.MaTL=tl.MaTL
inner join NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
WHERE tg.TenTG LIKE CONCAT(@tacGia,'%') AND tl.TenTL LIKE CONCAT(@theLoai,'%')
END
GO

--Tìm sách qua tên sách, tác giả, thể loại
CREATE PROC USP_TimSach_TenSach_TacGia_TheLoai
@tenSach NVARCHAR(50) , @tacGia NVARCHAR(50) , @theLoai NVARCHAR(50)
AS
BEGIN
	SELECT s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền]
FROM Sach AS s 
inner join ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
inner join TacGia tg on s.MaTG=tg.MaTG
inner join TheLoai tl on s.MaTL=tl.MaTL
inner join NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
WHERE s.TenSach LIKE CONCAT(@tenSach,'%') AND tg.TenTG LIKE CONCAT(@tacGia,'%') AND tl.TenTL LIKE CONCAT(@theLoai,'%')
END
GO

--Thanh toán sách

CREATE PROC USP_ThanhToanSach
@maSach NVARCHAR(50) , @soLuong INT
AS
BEGIN
	UPDATE Sach
	SET
		SoLuongTon = SoLuongTon - @soLuong
	WHERE MaSach = @maSach
END

-- Thêm dữ liệu

ALTER TABLE NhaXuatBan
ALTER COLUMN MaNXB NVARCHAR(50)
	
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB001', N'Bách khoa Hà Nội', N'Số 1 Đường Đại Cồ Việt, Hai Bà Trưng , Hà Nội.', '8823451' )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB002', N'Chính trị Quốc gia Sự thật', N'6/86 Duy Tân, Cầu Giấy, Hà Nội', '908256478'  )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB003', N'Công Thương', N'Tầng 4, Tòa nhà Bộ Công Thương, số 655 Phạm Văn Đồng, quận Bắc Từ Liêm, Hà Nội', '938776266'  )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB004', N'Công an nhân dân', N'92 Nguyễn Du, quận Hai Bà Trưng, TP. Hà Nội', '917325476'  )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB005', N'Dân trí', N'Số 9, ngõ 26, phố Hoàng Cầu, quận Đống Đa, thành phố Hà Nội', '8246108'  )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB006', N'Giao thông vận tải', N'80B Trần Hưng Đạo, Quận Hoàn Kiếm, Thành phố Hà Nội', '8631738'  )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB007', N'Giáo dục Việt Nam', N'81 Trần Hưng Đạo - Q. Hoàn KIếm - Hà Nội', '916783565'  )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB008', N'Hàng hải', N'484 Lạch Tray, Ngô Quyền, Hải Phòng', '938435756'  )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB009', N'Học viện Nông nghiệp', N'Trường Đại học Nông nghiệp Hà Nội - Thị trấn Trâu Quỳ, huyện Gia Lâm, Hà Nội', '8654763'  )
INSERT INTO dbo.NhaXuatBan VALUES  ( 'NXB010', N'Hồng Đức', N'65 Tràng Thi, Hà Nội', '8768904'  )

--DELETE FROM dbo.NhaXuatBan WHERE MaNXB='NXB0010'


INSERT INTO dbo.PhieuNhap VALUES  ( 'PN001','12/7/2020','NXB002' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN002','1/8/2020','NXB007' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN003','30/12/2019','NXB008' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN004','24/12/2019','NXB004' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN005','12/8/2020','NXB006' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN006','3/3/2020','NXB009' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN007','2/5/2020','NXB003' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN008','15/8/2020','NXB001' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN009','16/12/2019','NXB010' )
INSERT INTO dbo.PhieuNhap VALUES  ( 'PN010','31/7/2020','NXB007' )


INSERT INTO dbo.HoaDon VALUES  ( 'HD001', '21/2/2020')
INSERT INTO dbo.HoaDon VALUES  ( 'HD002', '13/8/2020')
INSERT INTO dbo.HoaDon VALUES  ( 'HD003', '27/7/2020')
INSERT INTO dbo.HoaDon VALUES  ( 'HD004', '12/4/2020')
INSERT INTO dbo.HoaDon VALUES  ( 'HD005', '31/1/2020')
INSERT INTO dbo.HoaDon VALUES  ( 'HD006', '26/2/2020')
INSERT INTO dbo.HoaDon VALUES  ( 'HD007', '21/9/2020')
INSERT INTO dbo.HoaDon VALUES  ( 'HD008', '19/1/2020')
INSERT INTO dbo.HoaDon VALUES  ( 'HD009', '25/12/2020')


INSERT INTO dbo.TacGia VALUES  ('TG001',N'Nguyễn Như Nhựt',N'927345678')
INSERT INTO dbo.TacGia VALUES  ('TG002',N'Lê Thị Phi Yến',N'987567390')
INSERT INTO dbo.TacGia VALUES  ('TG003',N'Nguyễn Văn B',N'997047382')
INSERT INTO dbo.TacGia VALUES  ('TG004',N'Ngô Thành Tuân',N'913758498')
INSERT INTO dbo.TacGia VALUES  ('TG005',N'Nguyễn Thị Trúc Thành',N'918590387')
INSERT INTO dbo.TacGia VALUES  ('TG006',N'Hà Duy Lập',N'87689042')
INSERT INTO dbo.TacGia VALUES  ('TG007',N'Lê Hà Vinh',N'865476323')
INSERT INTO dbo.TacGia VALUES  ('TG008',N'Nguyễn Văn Bình',N'824610823')
INSERT INTO dbo.TacGia VALUES  ('TG009',N'Lâm Thái Sơn',N'956412135')



INSERT INTO dbo.TheLoai VALUES  ( 'TL001',N'Chính trị' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL002',N'Pháp luật' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL003',N'Khoa học công nghệ' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL004',N'Kinh tế' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL005',N'Văn hóa xã hội' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL006',N'Lịch sử' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL007',N'Văn học nghệ thuật' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL008',N'Tiểu thuyết' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL009',N'Tâm lý' )
INSERT INTO dbo.TheLoai VALUES  ( 'TL010',N'Tôn giáo' )




INSERT INTO dbo.Sach  
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S001' ,N'Tôi tài giỏi, bạn cũng thế' , 100 , 80000 ,'TL002','TG003','NXB009')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S002' ,N'Đắc nhân tâm' ,120,72000,'TL003','TG002','NXB008')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S003' ,N'Tội ác và trừng phạt' ,90,59000,'TL004','TG004','NXB007')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S004' ,N'Nhà giả kim' ,60,70000,'TL002','TG005','NXB006')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S005' ,N'Bắt trẻ đồng xanh' ,200,95000,'TL001','TG006','NXB005')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S006' ,N'Xách ba lô lên và đi' ,150,56000,'TL006','TG007','NXB004')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S007' ,N'Cứ đi rồi sẽ đến' ,50,63000,'TL005','TG009','NXB003')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S008' ,N'7 thói quen để thành đạt' ,100,190000,'TL008','TG008','NXB002')
INSERT INTO Sach
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S009' ,N'Thép đã tôi thế đấy' ,200,160000,'TL009','TG001','NXB001')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S010' ,N'Đọc vị bất kì ai' ,100,34000,'TL010','TG002','NXB010')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S011' ,N'Cuộc đời của Pi' ,100,34000,'TL010','TG003','NXB009')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S012' ,N'Những Người Đàn Ông Không Có Đàn Bà' ,100,90000,'TL002','TG004','NXB008')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S013' ,N'Trà hoa nữ' ,200,67000,'TL001','TG005','NXB007')

INSERT INTO Sach
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S014' ,N'Đàn ông đến từ sao Hỏa – Đàn bà đến từ sao Kim' ,100,50000,'TL003','TG006','NXB006')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S015' ,N'Thần chú mê đắm' ,300,95000,'TL004','TG007','NXB005')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S016' ,N'Bạn Đắt Giá Bao Nhiêu?' ,150,66000,'TL005','TG009','NXB004')
INSERT INTO Sach
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S017' ,N'Đời ngắn đừng ngủ dài' ,200,36000,'TL006','TG008','NXB003')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S018' ,N'Tuổi trẻ đáng giá bao nhiêu' ,150,94000,'TL007','TG003','NXB002')
INSERT INTO Sach
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S019' ,N'Khéo ăn nói sẽ có được thiên hạ' ,200,39000,'TL009','TG001','NXB001')
INSERT INTO Sach 
(
	s.MaSach,
	s.TenSach,
	s.SoLuongTon,
	s.GiaTien,
	s.MaTL,
	s.MaTG,
	s.MaNXB
)
VALUES  ( 'S020' ,N'Cafe cùng Tony' ,400,64000,'TL008','TG002','NXB010')


INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S001','PN010', 20, 60000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S002','PN009', 20, 50000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S003','PN008', 20, 30000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S004','PN007', 20, 60000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S005','PN006', 20, 60000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S006','PN005', 20, 40000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S007','PN004', 20, 60000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S008','PN003', 20, 60000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S009','PN002', 20, 60000)
INSERT INTO dbo.ChiTietPhieuNhap VALUES  ( 'S010','PN001', 20, 20000)



INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S001', 'HD009',  1, 80000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S002', 'HD008',  1, 72000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S003', 'HD007',  1, 59000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S004', 'HD006',  1, 70000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S005', 'HD005',  1, 95000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S006', 'HD004',  1, 56000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S007', 'HD003',  1, 63000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S008', 'HD002',  1, 190000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S009', 'HD001',  1, 160000)
INSERT INTO dbo.ChiTietHoaDon VALUES  ( 'S010', 'HD009',  1, 34000)

-- Sửa tài khoản
CREATE PROC USP_SuaTaiKhoan
@tenDN NVARCHAR(50), @tenHT NVARCHAR(50), @matKhau NVARCHAR(50), @matKhauMoi NVARCHAR(50)
AS
BEGIN
	DECLARE @isMKDung INT = 0
	
	SELECT @isMKDung = COUNT(*) FROM TaiKhoan WHERE @tenDN = TenDN AND @matKhau = MatKhau
	
	IF (@isMKDung = 1)
	BEGIN
		IF (@matKhauMoi = NULL OR @matKhauMoi = '')
		UPDATE TaiKhoan SET HoTen = @tenHT WHERE TenDN = @tenDN
		ELSE
		UPDATE TaiKhoan SET HoTen = @tenHT, MatKhau = @matKhauMoi WHERE TenDN = @tenDN
	END
END

--Cập nhật tài khoản
ALTER Table TaiKhoan
add ThemDuLieu INT
CREATE PROC USP_CapNhatTaiKhoan
@tendn NVARCHAR(50), @tenht NVARCHAR(50), @nhapsach INT, @thongke INT, @kesach INT, @themdl INT, @bansach INT, @tttaikhoan INT, @mkmoi NVARCHAR(50)
AS
BEGIN
	UPDATE TaiKhoan
	SET
		HoTen = @tenht,
		MatKhau = @mkmoi,
		NhapSach = @nhapsach,
		ThongKe = @thongke,
		KeSach = @kesach,
		ThemDuLieu = @themdl,
		BanSach = @bansach,
		TTTaiKhoan = @tttaikhoan
	WHERE
		TenDN = @tenDN
END

--Xóa tài khoản	
CREATE PROC USP_XoaTaiKhoan
@tenDN NVARCHAR(50)
AS
BEGIN
	DELETE FROM TaiKhoan WHERE TenDN = @tenDN
END
--Thêm mã thể loại

ALTER TABLE TheLoai
ADD CONSTRAINT df_ID_TL DEFAULT DBO.AUTO_MATL() FOR MaTL
DROP FUNCTION AUTO_MATL
CREATE FUNCTION AUTO_MATL()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ma VARCHAR(5)
	IF (SELECT COUNT(MaTL) FROM TheLoai) = 0
		SET @ma = '0'
	ELSE
		SELECT @ma = MAX(RIGHT(MaTL, 3)) FROM TheLoai
		SELECT @ma = CASE
			WHEN @ma >= 0 and @ma < 9 THEN 'TL00' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
			WHEN @ma >= 9 THEN 'TL0' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
		END
	RETURN @ma
END
--Thêm Mã Tác Giả
ALTER TABLE TacGia
ADD CONSTRAINT df_ID_TG DEFAULT DBO.AUTO_MATG() FOR MaTG
CREATE FUNCTION AUTO_MATG()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ma VARCHAR(5)
	IF (SELECT COUNT(MaTG) FROM TacGia) = 0
		SET @ma = '0'
	ELSE
		SELECT @ma = MAX(RIGHT(MaTG, 3)) FROM TacGia
		SELECT @ma = CASE
			WHEN @ma >= 0 and @ma < 9 THEN 'TG00' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
			WHEN @ma >= 9 THEN 'TG0' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
		END
	RETURN @ma
END
--Thêm Mã Nhà Xuất Bản
ALTER TABLE NhaXuatBan
ADD CONSTRAINT df_ID_NXB DEFAULT DBO.AUTO_MANXB() FOR MaNXB
ALTER TABLE NhaXuatBan
DROP CONSTRAINT df_ID_NXB
DROP FUNCTION AUTO_MANXB

CREATE FUNCTION AUTO_MANXB()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ma VARCHAR(6)
	IF (SELECT COUNT(MaNXB) FROM NhaXuatBan) = 0
		SET @ma = '0'
	ELSE
		SELECT @ma = MAX(RIGHT(MaNXB, 3)) FROM NhaXuatBan
		SELECT @ma = CASE
			WHEN @ma >= 0 and @ma < 9 THEN 'NXB00' + CONVERT(VARCHAR, CONVERT(INT, @ma) + 1)
			WHEN @ma >= 9 THEN 'NXB0' + CONVERT(VARCHAR, CONVERT(INT, @ma) + 1)
		END
	RETURN @ma
END
-- Thêm Thể Loại
CReate proc USP_ThemTheLoai
@tentl NVARCHAR(50)
AS
Begin
	insert into TheLoai
		(
			TenTL
		)
	values 
		(
			@tentl
		)
END
--Thêm tác giả
CReate proc USP_ThemTacGia
@tentg NVARCHAR(50), @sdt NVARCHAR(40)
AS
Begin
	insert into TacGia
		(
			TenTG,
			LienLac
		)
	values 
		(
			@tentg,
			@sdt
		)
END
--Thêm nhà xuất bản
CReate proc USP_ThemNhaXuatBan
@tennxb NVARCHAR(50), @diachi NVARCHAR(100), @sdt NVARCHAR(50)
AS
Begin
	insert into NhaXuatBan
		(
			TenNXB,
			DiaChiNXB,
			DienThoai
		)
	values 
		(
			@tennxb,
			@diachi,
			@sdt
		)
END
--Thêm tài khoản
alter table TaiKhoan
add CaiDat INT
CREATE PROC USP_ThemTaiKhoan
@tendn NVARCHAR(50),@matkhau NVARCHAR(50), @tenht NVARCHAR(50), @loai INT, @nhapsach INT, @thongke INT, @kesach INT, @themdl INT, @bansach INT, @tttaikhoan INT
AS
BEGIN
	INSERT INTO TaiKhoan
	(
		TenDN,
		HoTen,
		Loai,
		MatKhau,
		NhapSach,
		ThongKe,
		KeSach,
		ThemDuLieu,
		BanSach,
		TTTaiKhoan
	)
	VALUES
	(
		@tenDN,
		@tenHT,
		@loai,
		@matKhau,
		@nhapsach,
		@thongke,
		@kesach,
		@themdl,
		@bansach,
		@tttaikhoan
	)
END

--Hiển thị tác giả
CREATE PROC USP_HienThiTacGia
AS
BEGIN
	SELECT
		tg.MaTG AS [Mã Tác Giả],
		tg.TenTG AS [Tên Tác Giả],
		tg.LienLac AS [Số Điện Thoại]
	FROM
		TacGia AS tg
END

--Hiển thị thể loại
CREATE PROC USP_HienThiTheLoai
AS
BEGIN
	SELECT
		tl.MaTL AS [Mã Thể Loại],
		tl.TenTL AS [Tên Thể Loại]
	FROM
		TheLoai AS tl
END

-- Hiển thị nhà sản xuất

CREATE PROC USP_HienThiNhaXuatBan
AS
BEGIN
	SELECT
		nxb.MaNXB AS [Mã NXB],
		nxb.TenNXB AS [Tên NXB],
		nxb.DiaChiNXB AS [Địa chỉ NXB],
		nxb.DienThoai AS [Số Điện Thoại]
	FROM
		NhaXuatBan AS nxb
END

--Thêm số lượng cho sách

CREATE PROC USP_ThemSLChoSach
@soluong INT, @maSach NVARCHAR(50)
AS
BEGIN
	UPDATE Sach
	SET
		SoLuongTon = SoLuongTon + @soluong
	WHERE
		MaSach = @maSach
END
--Thêm Mã PN-Trong Bảng PhieuNhap
ALTER TABLE PhieuNhap
ADD CONSTRAINT df_ID_PN DEFAULT DBO.AUTO_MAPN() FOR SoPN


CREATE FUNCTION AUTO_MAPN()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ma VARCHAR(5)
	IF (SELECT COUNT(SoPN) FROM PhieuNhap) = 0
		SET @ma = '0'
	ELSE
		SELECT @ma = MAX(RIGHT(SoPN, 3)) FROM PhieuNhap
		SELECT @ma = CASE
			WHEN @ma >= 0 and @ma < 9 THEN 'PN00' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
			WHEN @ma >= 9 THEN 'PN0' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
		END
	RETURN @ma
END
--Thêm Mã PN--Trong Bảng ChiTietPhieuNhap
ALTER TABLE ChiTietPhieuNhap
ADD CONSTRAINT df_ID_PN_CTPN DEFAULT DBO.AUTO_MAPN() FOR SoPN
Alter table ChiTietPhieuNhap
drop constraint df_ID_PN_CTPN

CREATE FUNCTION AUTO_MAPN_CTPN()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ma VARCHAR(5)
	IF (SELECT COUNT(SoPN) FROM ChiTietPhieuNhap) = 0
		SET @ma = '0'
	ELSE
		SELECT @ma = MAX(RIGHT(SoPN, 3)) FROM ChiTietPhieuNhap
		SELECT @ma = CASE
			WHEN @ma >= 0 and @ma < 9 THEN 'PN00' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
			WHEN @ma >= 9 THEN 'PN0' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
		END
	RETURN @ma
END
--Thêm Mã Sách-Trong Bảng Sách
ALTER TABLE Sach
ADD CONSTRAINT df_ID_SACH DEFAULT DBO.AUTO_MASACH() FOR MaSach
alter table Sach
drop constraint df_ID_SACH
DROP FUNCTION AUTO_MASACH;

CREATE FUNCTION AUTO_MASACH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ma VARCHAR(5)
	IF (SELECT COUNT(MaSach) FROM Sach) = 0
		SET @ma = '0'
	ELSE
		SELECT @ma = MAX(RIGHT(MaSach, 3)) FROM dbo.Sach
		SELECT @ma = CASE
			WHEN @ma >= 0 and @ma < 9 THEN 'S00' + CONVERT(VARCHAR, CONVERT(INT, @ma) + 1)
			WHEN @ma >= 9 THEN 'S0' + CONVERT(VARCHAR, CONVERT(INT, @ma) + 1)
		END
	RETURN @ma
END
--Thêm Mã Sách-- Trong Bảng ChiTietPhieuNhap
ALTER TABLE ChiTietPhieuNhap
ADD CONSTRAINT df_ID_SACH_CTPN DEFAULT DBO.AUTO_MASACH_CTPN() FOR MaSach

CREATE FUNCTION AUTO_MASACH_CTPN()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ma VARCHAR(5)
	IF (SELECT COUNT(MaSach) FROM ChiTietPhieuNhap) = 0
		SET @ma = '0'
	ELSE
		SELECT @ma = MAX(RIGHT(MaSach, 3)) FROM ChiTietPhieuNhap
		SELECT @ma = CASE
			WHEN @ma >= 0 and @ma < 9 THEN 'S00' + CONVERT(VARCHAR, CONVERT(INT, @ma) + 1)
			WHEN @ma >= 9 THEN 'S0' + CONVERT(VARCHAR, CONVERT(INT, @ma) + 1)
		END
	RETURN @ma
END
--Thêm sách
Drop proc USP_ThemSach
CREATE PROC USP_ThemSach
@tenSach NVARCHAR(100), @soluong INT, @giatien INT, @matl CHAR(5), @matg CHAR(5), @manxb CHAR(6), @ngaynhap smalldatetime
AS
BEGIN
	SET DATEFORMAT DMY

	INSERT INTO Sach
(
	TenSach,
	SoLuongTon,
	GiaTien,
	MaTL,
	MaTG,
	MaNXB
)
VALUES
(
	@tenSach,
	@soluong,
	@giatien,
	@matl,
	@matg,
	@manxb
)
	INSERT INTO PhieuNhap
	(
		NgayNhap,
		MaNXB
	)
	VALUES
	(
		@ngaynhap,
		@manxb
	)
	
	

	INSERT INTO ChiTietPhieuNhap
	(
		MaSach,
		SoLuongNhap,
		GiaNhap
	)
	VALUES
	(

		@soluong,
		@giatien

	)
END





