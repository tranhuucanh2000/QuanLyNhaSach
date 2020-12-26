--Tạo csdl QuanLyNhaSach và sử dụng nó
CREATE DATABASE QuanLyNhaSach
GO
USE QuanLyNhaSach
GO

--tạo bảng nhà xuất bản
CREATE TABLE NhaXuatBan
(
	MaNXB CHAR(6) NOT NULL,
	TenNXB NVARCHAR(100)NOT NULL,
	DiaChiNXB NVARCHAR(100) NOT NULL,
	DienThoai VARCHAR(20) NOT NULL,
	CONSTRAINT pk_NXB PRIMARY KEY (MaNXB)
)
GO
--tạo bảng phiếu nhập
CREATE TABLE PhieuNhap
(
	SoPN CHAR(5) NOT NULL,
	NgayNhap SMALLDATETIME NOT NULL,
	MaNXB CHAR(6) NOT NULL,
	CONSTRAINT pk_PN PRIMARY KEY (SoPN),
	CONSTRAINT fk_PN FOREIGN KEY (MaNXB) REFERENCES dbo.NhaXuatBan(MaNXB)
)
GO
--tạo bảng hóa đơn
CREATE TABLE HoaDon
(
	SoHD CHAR(5) NOT NULL,
	NgayBan SMALLDATETIME NOT NULL,
	CONSTRAINT pk_HD PRIMARY KEY (SoHD)
)
GO
--tạo bảng tác giả
CREATE TABLE TacGia
(
	MaTG CHAR(5) NOT NULL,
	TenTG NVARCHAR(40) NOT NULL,
	LienLac NVARCHAR(40),
	CONSTRAINT pk_TG PRIMARY KEY (MaTG)
)
GO
--tạo bảng thể loại
CREATE TABLE TheLoai
(
	MaTL CHAR(5) NOT NULL,
	TenTL NVARCHAR(50) NOT NULL,
	CONSTRAINT pk_TL PRIMARY KEY (MaTL)
)
GO
--tạo bảng sách
CREATE TABLE Sach
(
	MaSach CHAR(4) NOT NULL,
	TenSach NVARCHAR(40) NOT NULL,
	SoLuongTon INT NOT NULL,
	MaTL CHAR(5) NOT NULL,
	MaTG CHAR(5) NOT NULL,
	MaNXB CHAR(6) NOT NULL,
	GiaTien INT NOT NULL,
	KinhDoanh NVARCHAR(15) NOT NULL DEFAULT N'Còn',
	CONSTRAINT pk_S PRIMARY KEY (MaSach),
	CONSTRAINT fk_S_MaTL FOREIGN KEY (MaTL) REFERENCES dbo.TheLoai(MaTL),
	CONSTRAINT fk_S_MaTG FOREIGN KEY (MaTG) REFERENCES dbo.TacGia(MaTG),
	CONSTRAINT fk_S_MaNXB FOREIGN KEY (MaNXB) REFERENCES dbo.NhaXuatBan(MaNXB),
)
GO
--tạo bảng chi tiết phiếu nhập
CREATE TABLE ChiTietPhieuNhap
(
	MaSach CHAR(4) NOT NULL,
	SoPN CHAR(5) NOT NULL,
	SoLuongNhap INT NOT NULL,
	GiaNhap MONEY NOT NULL,
	CONSTRAINT pk_CTPN PRIMARY KEY(MaSach,SoPN),
	CONSTRAINT fk_CTPN_MaSach FOREIGN KEY (MaSach) REFERENCES dbo.Sach(MaSach),
	CONSTRAINT fk_CTPN_SoPN FOREIGN KEY (SoPN) REFERENCES dbo.PhieuNhap(SoPN),
)
GO
--tạo bảng chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon
(
	MaSach CHAR(4) NOT NULL,
	SoHD CHAR(5) NOT NULL,
	SoLuongBan INT NOT NULL,
	GiaBan MONEY NOT NULL,
	CONSTRAINT pk_CTHD PRIMARY KEY(MaSach,SoHD),
	CONSTRAINT fk_CTHD_MaSach FOREIGN KEY (MaSach) REFERENCES dbo.Sach(MaSach),
	CONSTRAINT fk_CTHD_SoHD FOREIGN KEY (SoHD) REFERENCES dbo.HoaDon(SoHD),
)
GO
--tạo bảng tài khoản
CREATE TABLE TaiKhoan
(
	TenDN NVARCHAR(50) PRIMARY KEY NOT NULL,
	HoTen NVARCHAR(50) NOT NULL,
	Loai INT DEFAULT 0 NOT NULL,
	MatKhau NVARCHAR(1000) NOT NULL,
	NhapSach INT NOT NULL,
	ThongKe INT NOT NULL,
	KeSach INT NOT NULL,
	ThemDuLieu INT NOT NULL,
	BanSach INT NOT NULL,
	TTTaiKhoan INT NOT NULL,
	CaiDat INT DEFAULT 0 NOT NULL,
	Ma NVARCHAR(10) NOT NULL,
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
--set ngày-tháng năm
SET DATEFORMAT DMY
GO
--Hiển thị sách
CREATE PROC USP_HienThiSach
AS
BEGIN
	SELECT DISTINCT s.MaSach, s.TenSach, tg.TenTG,tl.TenTL, nxb.TenNXB,s.SoLuongTon,s.GiaTien
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
	WHERE s.KinhDoanh = N'Còn'
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
	WHERE s.MaSach=ct.MaSach AND s.MaTG=tg.MaTG AND s.MaTL=tl.MaTL AND s.MaNXB=nxb.MaNXB AND s.KinhDoanh = N'Còn'
END
GO
-- Tìm kiếm sách qua tên tác giả
CREATE PROC USP_TimSach_TacGia
@tacGia NVARCHAR(50)
AS
BEGIN
	SELECT DISTINCT s.MaSach, s.TenSach, tg.TenTG,tl.TenTL, nxb.TenNXB,s.SoLuongTon,s.GiaTien
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
	WHERE tg.TenTG LIKE CONCAT(@tacGia,'%') AND s.KinhDoanh = N'Còn'
END
GO
--Tìm kiếm sách qua tên sách

CREATE PROC USP_TimSach_TenSach
@tenSach NVARCHAR(50)
AS
BEGIN
	SELECT DISTINCT s.MaSach, s.TenSach, tg.TenTG,tl.TenTL, nxb.TenNXB,s.SoLuongTon,s.GiaTien
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
	WHERE s.TenSach LIKE CONCAT(@tenSach,'%') AND s.KinhDoanh = N'Còn'
END
GO

--Tìm kiếm sách qua thể loại
CREATE PROC USP_TimSach_TheLoai
@theLoai NVARCHAR(50)
AS
BEGIN
	SELECT DISTINCT s.MaSach, s.TenSach, tg.TenTG,tl.TenTL, nxb.TenNXB,s.SoLuongTon,s.GiaTien
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
	WHERE tl.TenTL LIKE CONCAT(@theLoai,'%') AND s.KinhDoanh = N'Còn'
END
GO


--Tìm kiếm sách qua tên sách và thể loại
CREATE PROC USP_TimSach_TenSach_TheLoai
@tenSach NVARCHAR(50), @theLoai NVARCHAR(50)
AS
BEGIN
	SELECT DISTINCT s.MaSach, s.TenSach, tg.TenTG,tl.TenTL, nxb.TenNXB,s.SoLuongTon,s.GiaTien
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
	WHERE tl.TenTL LIKE CONCAT(@theLoai,'%') AND s.TenSach LIKE CONCAT(@tenSach,'%') AND s.KinhDoanh = N'Còn'
END
GO

--Tìm kiếm sách qua tên sách và tác giả
CREATE PROC USP_TimSach_TenSach_TacGia
@tenSach NVARCHAR(50), @tacGia NVARCHAR(50)
AS
BEGIN
	SELECT DISTINCT s.MaSach, s.TenSach, tg.TenTG,tl.TenTL, nxb.TenNXB,s.SoLuongTon,s.GiaTien
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
	WHERE s.TenSach LIKE CONCAT(@tenSach,'%') AND tg.TenTG LIKE CONCAT(@tacGia,'%') AND s.KinhDoanh = N'Còn'
END
GO

--Tìm sách qua tác giả và thể loại
CREATE PROC USP_TimSach_TacGia_TheLoai
@tacGia NVARCHAR(50) , @theLoai NVARCHAR(50)
AS
BEGIN
	SELECT DISTINCT s.MaSach, s.TenSach, tg.TenTG,tl.TenTL, nxb.TenNXB,s.SoLuongTon,s.GiaTien
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
	WHERE tg.TenTG LIKE CONCAT(@tacGia,'%') AND tl.TenTL LIKE CONCAT(@theLoai,'%') AND s.KinhDoanh = N'Còn'
END
GO

--Tìm sách qua tên sách, tác giả, thể loại
CREATE PROC USP_TimSach_TenSach_TacGia_TheLoai
@tenSach NVARCHAR(50) , @tacGia NVARCHAR(50) , @theLoai NVARCHAR(50)
AS
BEGIN
	SELECT DISTINCT s.MaSach, s.TenSach, tg.TenTG,tl.TenTL, nxb.TenNXB,s.SoLuongTon,s.GiaTien
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
	WHERE s.TenSach LIKE CONCAT(@tenSach,'%') AND tg.TenTG LIKE CONCAT(@tacGia,'%') AND tl.TenTL LIKE CONCAT(@theLoai,'%') AND s.KinhDoanh = N'Còn'
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
GO

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
GO
--Cập nhật tài khoản
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
GO

--Cập nhật tài khoản admin
CREATE PROC USP_CapNhatTenDNAdmin
@tendncu NVARCHAR(50), @tendnmoi NVARCHAR(50), @mk NVARCHAR(50)
AS
BEGIN
	UPDATE TaiKhoan
	SET
		TenDN = @tendnmoi
	WHERE
		TenDN = @tendncu AND MatKhau = @mk
END
GO

--Xóa tài khoản	
CREATE PROC USP_XoaTaiKhoan
@tenDN NVARCHAR(50)
AS
BEGIN
	DELETE FROM TaiKhoan WHERE TenDN = @tenDN
END
GO
--Thêm mã thể loại
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
GO
ALTER TABLE TheLoai
ADD CONSTRAINT df_ID_TL DEFAULT DBO.AUTO_MATL() FOR MaTL
GO
--Thêm Mã Tác Giả
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
GO
ALTER TABLE TacGia
ADD CONSTRAINT df_ID_TG DEFAULT DBO.AUTO_MATG() FOR MaTG
GO
--Thêm Mã Nhà Xuất Bản
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
GO
ALTER TABLE NhaXuatBan
ADD CONSTRAINT df_ID_NXB DEFAULT DBO.AUTO_MANXB() FOR MaNXB
GO
-- Thêm Thể Loại
CREATE PROC USP_ThemTheLoai
@tentl NVARCHAR(50)
AS
BEGIN
	INSERT INTO TheLoai
		(
			TenTL
		)
	VALUES
		(
			@tentl
		)
END
GO
--Thêm tác giả
CREATE PROC USP_ThemTacGia
@tentg NVARCHAR(50), @sdt NVARCHAR(40)
AS
BEGIN
	INSERT INTO TacGia
		(
			TenTG,
			LienLac
		)
	VALUES 
		(
			@tentg,
			@sdt
		)
END
GO
--Thêm nhà xuất bản
CREATE PROC USP_ThemNhaXuatBan
@tennxb NVARCHAR(50), @diachi NVARCHAR(100), @sdt NVARCHAR(50)
AS
BEGIN
	INSERT INTO NhaXuatBan
		(
			TenNXB,
			DiaChiNXB,
			DienThoai
		)
	VALUES
		(
			@tennxb,
			@diachi,
			@sdt
		)
END
GO
--Thêm tài khoản
CREATE PROC USP_ThemTaiKhoan
@tendn NVARCHAR(50),@matkhau NVARCHAR(50), @tenht NVARCHAR(50), @loai INT, @nhapsach INT, @thongke INT, @kesach INT, @themdl INT, @bansach INT, @tttaikhoan INT, @ma NVARCHAR(50)
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
		TTTaiKhoan,
		Ma
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
		@tttaikhoan,
		@ma
	)
END
GO
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
GO
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
GO
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
Go
--Thêm số lượng cho sách

CREATE PROC [dbo].[USP_ThemSLChoSach]
@soPn CHAR(5),@maSach CHAR(4), @soluong INT, @giatien INT, @ngaynhap SMALLDATETIME, @manxb CHAR(6)
AS
BEGIN
	INSERT INTO PhieuNhap
	(
		SoPN,
		NgayNhap,
		MaNXB
	)
	VALUES
	(
		@soPn,
		@ngaynhap,
		@manxb
	)
	INSERT INTO ChiTietPhieuNhap
	(
		MaSach,
		SoPN,
		SoLuongNhap,
		GiaNhap
	)
	VALUES
	(
		@maSach,
		@soPn,
		@soluong,
		@giatien
	)
	UPDATE Sach
	SET
		SoLuongTon = SoLuongTon + @soluong
	WHERE
		MaSach = @maSach
END
GO

--Thêm Mã PN-Trong Bảng PhieuNhap
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
GO
ALTER TABLE PhieuNhap
ADD CONSTRAINT df_ID_PN DEFAULT DBO.AUTO_MAPN() FOR SoPN
GO
--Thêm Mã PN--Trong Bảng ChiTietPhieuNhap
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
GO
ALTER TABLE ChiTietPhieuNhap
ADD CONSTRAINT df_ID_PN_CTPN DEFAULT DBO.AUTO_MAPN() FOR SoPN
GO
--Thêm Mã Sách-Trong Bảng Sách
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
GO
ALTER TABLE Sach
ADD CONSTRAINT df_ID_SACH DEFAULT DBO.AUTO_MASACH() FOR MaSach
GO
--Thêm Mã Sách-- Trong Bảng ChiTietPhieuNhap
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
GO
ALTER TABLE ChiTietPhieuNhap
ADD CONSTRAINT df_ID_SACH_CTPN DEFAULT DBO.AUTO_MASACH_CTPN() FOR MaSach
GO
--Thêm sách
CREATE PROC USP_ThemSach
@soPn CHAR(5),@maSach CHAR(4),@tenSach NVARCHAR(100), @soluong INT, @giatien INT, @matl CHAR(5), @matg CHAR(5), @manxb CHAR(6), @ngaynhap smalldatetime
AS
BEGIN
	SET DATEFORMAT DMY

	INSERT INTO Sach
(
	MaSach,
	TenSach,
	SoLuongTon,
	GiaTien,
	MaTL,
	MaTG,
	MaNXB
)
VALUES
(
	@maSach,
	@tenSach,
	@soluong,
	@giatien,
	@matl,
	@matg,
	@manxb
)
END
	INSERT INTO PhieuNhap
	(
		SoPN,
		NgayNhap,
		MaNXB
	)
	VALUES
	(
		@soPn,
		@ngaynhap,
		@manxb
	)

	INSERT INTO ChiTietPhieuNhap
	(
		MaSach,
		SoPN,
		SoLuongNhap,
		GiaNhap
	)
	VALUES
	(
		@maSach,
		@soPn,
		@soluong,
		@giatien
	)
GO
--Xóa Sách
CREATE PROC USP_XoaSach
@masach CHAR(5)
AS
BEGIN
	DELETE FROM ChiTietPhieuNhap
	WHERE 
	MaSach= @masach
	DELETE FROM Sach
	WHERE
	MaSach = @masach
END
GO
--Xác nhận tài khoản qua mã
CREATE PROC USP_XacNhanTaiKhoanQuaMa
@tendn NVARCHAR(50), @ma NVARCHAR(50)
AS
BEGIN
	SELECT * FROM TaiKhoan WHERE TenDN = @tendn AND Ma = @ma
END
GO
--Quên Mật Khẩu
CREATE PROC USP_QuenMatKhau
@tendn NVARCHAR(50), @matkhaumoi NVARCHAR(50)
AS
BEGIN
    UPDATE QuanLyNhaSach.dbo.TaiKhoan
	SET
	MatKhau = @matkhaumoi
	WHERE
	TenDN = @tendn
END
GO
--Sửa mã tài khoản
CREATE PROC USP_SuaMaTaiKhoan
@tenDN NVARCHAR(50), @ma NVARCHAR(50), @maMoi NVARCHAR(50)
AS
BEGIN
	DECLARE @isMaDung INT = 0
	
	SELECT @isMaDung = COUNT(*) FROM TaiKhoan WHERE @tenDN = TenDN AND @ma = Ma
	
	IF (@isMaDung = 1)
	BEGIN

		UPDATE TaiKhoan 
		SET
		Ma = @maMoi WHERE TenDN = @tenDN
	END
END
GO
--Thêm hóa đơn
CREATE PROC USP_ThemHoaDon
@soHD CHAR(5), @ngay SMALLDATETIME
AS
BEGIN
    INSERT INTO HoaDon
	(
		SoHD,
		NgayBan
	)
	VALUES
	(
		@soHD,
		@ngay
	)
END
GO
--Thêm chi tiết hóa đơn 
CREATE PROC USP_USP_ThemChiTietHoaDon 
@maSach CHAR(4), @soHD CHAR(5), @soLuongBan INT, @giaBan INT
AS
BEGIN
    INSERT INTO ChiTietHoaDon
	(
		MaSach,
		SoHD,
		SoLuongBan,
		GiaBan
	)
	VALUES
	(
		@maSach,
		@soHD,
		@soLuongBan,
		@giaBan
	)
END
GO
--Lấy tất cả sách
CREATE PROC USP_LayTatCaSach
AS
BEGIN
	SELECT DISTINCT s.MaSach AS [ID], s.TenSach AS [Tên Sách], tg.TenTG AS [Tác Giả],tl.TenTL AS [Thể Loại], nxb.TenNXB AS [Nhà Sản Xuất] ,s.SoLuongTon AS [Số Lượng Tồn],s.GiaTien AS [Giá Tiền], s.KinhDoanh AS [Kinh Doanh]
	FROM Sach s 
	INNER JOIN ChiTietPhieuNhap ct on s.MaSach=ct.MaSach
	INNER JOIN TacGia tg on s.MaTG=tg.MaTG
	INNER JOIN TheLoai tl on s.MaTL=tl.MaTL
	INNER JOIN NhaXuatBan nxb on s.MaNXB=nxb.MaNXB
END
GO
--Trạng thái sách còn kinh doanh
CREATE PROC USP_TTKinhDoanhSach
@maSach CHAR(4)
AS
BEGIN
    UPDATE Sach
	SET KinhDoanh = N'Còn'
	WHERE MaSach = @maSach
END
GO
--Trạng thái sách ngừng kinh doanh
CREATE PROC USP_NgungKinhDoanhSach
@maSach CHAR(4)
AS
BEGIN
    UPDATE Sach
	SET KinhDoanh = N'Ngừng'
	WHERE MaSach = @maSach
END
GO
--Sửa tác giả
CREATE PROC USP_SuaTacGia
@tentg NVARCHAR(50), @sdt NVARCHAR(20), @matg CHAR(5)
AS
BEGIN
	UPDATE TacGia
	SET
		TenTG = @tentg,
		LienLac =@sdt
		WHERE
		MaTG = @matg
END
GO
--Sửa thể loại
CREATE PROC USP_SuaTheLoai
@tentl NVARCHAR(50), @matl CHAR(5)
AS
BEGIN
	UPDATE TheLoai
	SET
		TenTL = @tentl
		WHERE
		MaTL = @matl
END
GO
--Sửa nhà xuất bản
CREATE PROC USP_SuaNhaXuatBan
@tennxb NVARCHAR(100), @sdt VARCHAR(20), @diachi NVARCHAR(100), @manxb CHAR(6)
AS
BEGIN
	UPDATE NhaXuatBan
	SET
	TenNXB = @tennxb,
	DienThoai = @sdt,
	DiaChiNXB = @diachi
	WHERE
	MaNXB = @manxb
END
GO
--Cập nhật mật khẩu
CREATE PROC USP_CapNhatMatKhau
@mkmoi NVARCHAR(50), @matk VARCHAR(5)
AS
BEGIN
	UPDATE TaiKhoan
	SET
	
		MatKhau = @mkmoi
		
	WHERE
		Ma = @matk
END
GO
--Sửa Sách
CREATE PROC USP_SuaSach
@tensach NVARCHAR(50), @soluong INT, @giatien INT, @masach CHAR(4) 
AS
BEGIN
	UPDATE Sach
	SET
	TenSach = @tensach,
	SoLuongTon = @soluong,
	GiaTien = @giatien
	WHERE 
	MaSach = @masach
END
GO

--Thêm tài khoản mặc định

INSERT INTO TaiKhoan VALUES (N'admin', N'Quản lý', 1,N'admin',1,1,1,1,1,1,1,N'KVC2020')

