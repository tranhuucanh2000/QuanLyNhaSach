CREATE DATABASE QuanLyNhaSach
GO

USE QuanLyNhaSach
GO

--TaiKhoan
--Sach
--HoaDon

CREATE TABLE TaiKhoan
(
	TenDangNhap NVARCHAR(100) PRIMARY KEY,
	Ten NVARCHAR(100) NOT NULL,
	MatKhau NVARCHAR(1000) NOT NULL,
)
GO

CREATE TABLE TheLoai
(
	id INT IDENTITY PRIMARY KEY,
	TenTheLoai NVARCHAR(100) NOT NULL,
)
GO

CREATE TABLE Sach
(
	id INT IDENTITY PRIMARY KEY,
	TenSach NVARCHAR(100) NOT NULL,
	TacGia NVARCHAR(100) NOT NULL,
	NhaXuatBan NVARCHAR(100) NOT NULL,
	TheLoai INT NOT NULL,
	SoLuong INT NOT NULL,
	GiaTien INT NOT NULL DEFAULT 0,
)
GO

CREATE TABLE Khach
(
	id INT IDENTITY PRIMARY KEY,
	TenKhach NVARCHAR(100) NOT NULL DEFAULT N'Chưa có tên',
)
GO

CREATE TABLE HoaDon
(
	id INT IDENTITY PRIMARY KEY,
	Ngay DATE NOT NULL DEFAULT GETDATE(),
	idKhach INT NOT NULL,
	TrangThai INT NOT NULL, --1:Đã thanh toán || 0: Chưa thanh toán
	FOREIGN KEY (idKhach) REFERENCES dbo.Khach(id) 
)
GO

CREATE TABLE ThongTinHoaDon
(
	id INT IDENTITY PRIMARY KEY,
	idHoaDon INT NOT NULL,
	idSach INT NOT NULL,
	SoLuongSach int NOT NULL DEFAULT 0,

	FOREIGN KEY (idSach) REFERENCES dbo.Sach(id),
	FOREIGN KEY (idHoaDon) REFERENCES dbo.HoaDon(id)
)
GO

INSERT INTO dbo.TaiKhoan
(
	TenDangNhap,
	Ten,
	MatKhau
)
VALUES
(
	N'admin',
	N'Chủ Tịch',
	N'admin'
)
INSERT INTO dbo.TaiKhoan
(
	TenDangNhap,
	Ten,
	MatKhau
)
VALUES
(
	N'HuuCanh',
	N'Trần Hữu Cảnh',
	N'huucanh'
)
SELECT TenDangNhap as [Tên Đăng Nhập], Ten as [Tên], MatKhau as [Mật Khẩu] FROM dbo.TaiKhoan