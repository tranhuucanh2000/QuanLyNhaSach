USE [master]
GO
/****** Object:  Database [QuanLyNhaSach]    Script Date: 12/16/2020 9:18:14 PM ******/
CREATE DATABASE [QuanLyNhaSach]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyNhaSach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyNhaSach.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyNhaSach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyNhaSach_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyNhaSach] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyNhaSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyNhaSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyNhaSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyNhaSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyNhaSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyNhaSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyNhaSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyNhaSach] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyNhaSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyNhaSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyNhaSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyNhaSach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyNhaSach] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyNhaSach] SET QUERY_STORE = OFF
GO
USE [QuanLyNhaSach]
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_MANXB]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_MANXB]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ma VARCHAR(5)
	IF (SELECT COUNT(MaNXB) FROM NhaXuatBan) = 0
		SET @ma = '0'
	ELSE
		SELECT @ma = MAX(RIGHT(MaNXB, 3)) FROM NhaXuatBan
		SELECT @ma = CASE
			WHEN @ma >= 0 and @ma < 9 THEN 'NXB00' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
			WHEN @ma >= 9 THEN 'NXB0' + CONVERT(CHAR, CONVERT(INT, @ma) + 1)
		END
	RETURN @ma
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_MAPN]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_MAPN]()
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
/****** Object:  UserDefinedFunction [dbo].[AUTO_MATG]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_MATG]()
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
/****** Object:  UserDefinedFunction [dbo].[AUTO_MATL]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_MATL]()
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
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaSach] [char](4) NOT NULL,
	[SoHD] [char](5) NOT NULL,
	[SoLuongBan] [int] NULL,
	[GiaBan] [money] NULL,
 CONSTRAINT [pk_CTHD] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC,
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaSach] [char](4) NOT NULL,
	[SoPN] [char](5) NOT NULL,
	[SoLuongNhap] [int] NULL,
	[GiaNhap] [money] NULL,
 CONSTRAINT [pk_CTPN] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC,
	[SoPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[SoHD] [char](5) NOT NULL,
	[NgayBan] [smalldatetime] NULL,
 CONSTRAINT [pk_HD] PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[MaNXB] [char](6) NOT NULL,
	[TenNXB] [nvarchar](100) NULL,
	[DiaChiNXB] [nvarchar](100) NULL,
	[DienThoai] [varchar](20) NULL,
 CONSTRAINT [pk_NXB] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[SoPN] [char](5) NOT NULL,
	[NgayNhap] [smalldatetime] NULL,
	[MaNXB] [char](6)  NULL,
 CONSTRAINT [pk_PN] PRIMARY KEY CLUSTERED 
(
	[SoPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [char](4) NOT NULL,
	[TenSach] [nvarchar](50) NULL,
	[SoLuongTon] [int] NULL,
	[MaTL] [char](5) NULL,
	[MaTG] [char](5) NULL,
	[MaNXB] [char](6)  NULL,
	[GiaTien] [int] NULL,
 CONSTRAINT [pk_S] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTG] [char](5) NOT NULL,
	[TenTG] [nvarchar](40) NULL,
	[LienLac] [nvarchar](40) NULL,
 CONSTRAINT [pk_TG] PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDN] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[Loai] [int] NULL,
	[MatKhau] [nvarchar](1000) NOT NULL,
	[NhapSach] [int] NULL,
	[ThongKe] [int] NULL,
	[KeSach] [int] NULL,
	[BanSach] [int] NULL,
	[TTTaiKhoan] [int] NULL,
	[ThemDuLieu] [int] NULL,
	[CaiDat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTL] [char](5) NOT NULL,
	[TenTL] [nvarchar](50) NULL,
 CONSTRAINT [pk_TL] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NhaXuatBan] ADD  CONSTRAINT [df_ID_NXB]  DEFAULT ([DBO].[AUTO_MANXB]()) FOR [MaNXB]
GO
ALTER TABLE [dbo].[PhieuNhap] ADD  CONSTRAINT [df_ID_PN]  DEFAULT ([DBO].[AUTO_MAPN]()) FOR [SoPN]
GO
ALTER TABLE [dbo].[TacGia] ADD  CONSTRAINT [df_ID_TG]  DEFAULT ([DBO].[AUTO_MATG]()) FOR [MaTG]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ((0)) FOR [Loai]
GO
ALTER TABLE [dbo].[TheLoai] ADD  CONSTRAINT [df_ID_TL]  DEFAULT ([DBO].[AUTO_MATL]()) FOR [MaTL]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [fk_CTHD_MaSach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [fk_CTHD_MaSach]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [fk_CTHD_SoHD] FOREIGN KEY([SoHD])
REFERENCES [dbo].[HoaDon] ([SoHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [fk_CTHD_SoHD]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [fk_CTPN_MaSach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [fk_CTPN_MaSach]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [fk_CTPN_SoPN] FOREIGN KEY([SoPN])
REFERENCES [dbo].[PhieuNhap] ([SoPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [fk_CTPN_SoPN]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [fk_PN] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NhaXuatBan] ([MaNXB])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [fk_PN]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [fk_S_MaNXB] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NhaXuatBan] ([MaNXB])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [fk_S_MaNXB]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [fk_S_MaTG] FOREIGN KEY([MaTG])
REFERENCES [dbo].[TacGia] ([MaTG])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [fk_S_MaTG]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [fk_S_MaTL] FOREIGN KEY([MaTL])
REFERENCES [dbo].[TheLoai] ([MaTL])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [fk_S_MaTL]
GO
/****** Object:  StoredProcedure [dbo].[USP_CapNhatTaiKhoan]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_CapNhatTaiKhoan]
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
/****** Object:  StoredProcedure [dbo].[USP_DangNhap]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DangNhap]
@tenDN NVARCHAR(50), @matKhau NVARCHAR(50)
AS
BEGIN
	SELECT * FROM TaiKhoan WHERE TenDN = @tenDN AND MatKhau = @matKhau
END
GO
/****** Object:  StoredProcedure [dbo].[USP_HienThiNhaXuatBan]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_HienThiNhaXuatBan]
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
GO
/****** Object:  StoredProcedure [dbo].[USP_HienThiSach]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_HienThiSach]
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
/****** Object:  StoredProcedure [dbo].[USP_HienThiSachTimKiem]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_HienThiSachTimKiem]
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
GO
/****** Object:  StoredProcedure [dbo].[USP_HienThiTacGia]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_HienThiTacGia]
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
/****** Object:  StoredProcedure [dbo].[USP_HienThiTheLoai]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_HienThiTheLoai]
AS
BEGIN
	SELECT
		tl.MaTL AS [Mã Thể Loại],
		tl.TenTL AS [Tên Thể Loại]
	FROM
		TheLoai AS tl
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SuaTaiKhoan]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SuaTaiKhoan]
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
/****** Object:  StoredProcedure [dbo].[USP_ThanhToanSach]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_ThanhToanSach]
@maSach NVARCHAR(50) , @soLuong INT
AS
BEGIN
	UPDATE Sach
	SET
		SoLuongTon = SoLuongTon - @soLuong
	WHERE MaSach = @maSach
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ThemNhaXuatBan]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CReate proc [dbo].[USP_ThemNhaXuatBan]
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
GO
/****** Object:  StoredProcedure [dbo].[USP_ThemSach]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_ThemSach]
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
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ThemSLChoSach]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_ThemSLChoSach]
@soluong INT, @maSach NVARCHAR(50)
AS
BEGIN
	UPDATE Sach
	SET
		SoLuongTon = SoLuongTon + @soluong
	WHERE
		MaSach = @maSach
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ThemTacGia]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CReate proc [dbo].[USP_ThemTacGia]
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
GO
/****** Object:  StoredProcedure [dbo].[USP_ThemTaiKhoan]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_ThemTaiKhoan]
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
GO
/****** Object:  StoredProcedure [dbo].[USP_ThemTheLoai]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CReate proc [dbo].[USP_ThemTheLoai]
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
GO
/****** Object:  StoredProcedure [dbo].[USP_TimSach_TacGia]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_TimSach_TacGia]
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
/****** Object:  StoredProcedure [dbo].[USP_TimSach_TacGia_TheLoai]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_TimSach_TacGia_TheLoai]
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
/****** Object:  StoredProcedure [dbo].[USP_TimSach_TenSach]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_TimSach_TenSach]
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
/****** Object:  StoredProcedure [dbo].[USP_TimSach_TenSach_TacGia]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_TimSach_TenSach_TacGia]
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
/****** Object:  StoredProcedure [dbo].[USP_TimSach_TenSach_TacGia_TheLoai]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_TimSach_TenSach_TacGia_TheLoai]
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
/****** Object:  StoredProcedure [dbo].[USP_TimSach_TenSach_TheLoai]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_TimSach_TenSach_TheLoai]
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
/****** Object:  StoredProcedure [dbo].[USP_TimSach_TheLoai]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_TimSach_TheLoai]
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
/****** Object:  StoredProcedure [dbo].[USP_XoaTaiKhoan]    Script Date: 12/16/2020 9:18:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_XoaTaiKhoan]
@tenDN NVARCHAR(50)
AS
BEGIN
	DELETE FROM TaiKhoan WHERE TenDN = @tenDN
END
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhaSach] SET  READ_WRITE 
GO
ALTER TABLE TaiKhoan
ADD CONSTRAINT df_TaiKhoan
DEFAULT 0 FOR CaiDat




