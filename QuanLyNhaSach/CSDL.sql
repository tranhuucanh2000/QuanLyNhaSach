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
	TheLoai NVARCHAR(100) NOT NULL,
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
DROP TABLE dbo.Sach

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



INSERT INTO dbo.Sach
(
	TheLoai,
	TenSach,
	TacGia,
	NhaXuatBan,
	SoLuong,
	GiaTien
)
VALUES
(
	N'Tâm Lý',
	N'Khéo Ăn Nói Sẽ Có Được Thiên Hạ',
	N'Trác Nhã',
	N'NXB Văn Học',
	N'10',
	N'72000'
)
GO

INSERT INTO dbo.Sach
(
	TheLoai,
	TenSach,
	TacGia,
	NhaXuatBan,
	SoLuong,
	GiaTien
)
VALUES
(
	N'Tâm Lý',
	N'Vì Con Cần Có Mẹ',
	N'ATY biên soạn',
	N'NXB Đại Học Sư Phạm',
	N'15',
	N'50000'
)
GO

INSERT INTO dbo.Sach
(
	TheLoai,
	TenSach,
	TacGia,
	NhaXuatBan,
	SoLuong,
	GiaTien
)
VALUES
(
	N'Tiểu Thuyết',	N'Nhà Giả Kim',N'Paulo Coelho',N'NXB Hội Nhà Văn',N'12',N'67000'
)
GO

SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach 


INSERT INTO dbo.Sach(TheLoai, TenSach, TacGia, NhaXuatBan, SoLuong, GiaTien) VALUES (N'cc', N'aa', N'bb', N'đd', N'5', N'100000')

SELECT * FROM Sach AS s WHERE s.TenSach = N'nHà giả kim'

CREATE PROC USP_TimSachQuaTenSach
@tenSach NVARCHAR(50)
AS
BEGIN
	SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach WHERE TenSach = @tenSach
END
GO

EXEC USP_TimSachQuaTenSach @tenSach = N'nhà giả kim'

CREATE PROC USP_TimSachQuaTheLoai
@theLoai NVARCHAR(50)
AS
BEGIN
	SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach WHERE TheLoai = @theLoai
END
GO

EXEC USP_TimSachQuaTheLoai @theLoai = N'Tiểu Thuyết'

CREATE PROC USP_TimSachQuaTacGia
@tacGia NVARCHAR(50)
AS
BEGIN
	SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach WHERE TacGia = @tacGia
END
GO
EXEC USP_TimSachQuaTacGia @tacGia= N'Nguyên Phong'

CREATE PROC USP_TimSachQuaTenVaTacGia
@tenSach NVARCHAR(50) , @tacGia NVARCHAR(50)
AS
BEGIN
	SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach WHERE TacGia = @tacGia AND TenSach = @tenSach
END
GO
EXEC USP_TimSachQuaTenVaTacGia @tacGia= N'Nguyên Phong', @tenSach = N'Dấu Chân Trên Cát'

CREATE PROC USP_TimSachQuaTenVaTheLoai
@tenSach NVARCHAR(50) , @theLoai NVARCHAR(50)
AS
BEGIN
	SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach WHERE TheLoai = @theLoai AND TenSach = @tenSach
END
GO
EXEC USP_TimSachQuaTenVaTheloai @tenSach= N'Dấu Chân Trên Cát', @theLoai = N'Tiểu thuyết'

CREATE PROC USP_TimSachQuaTheLoaiVaTacGia
@tacGia NVARCHAR(50) , @theLoai NVARCHAR(50)
AS
BEGIN
	SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach WHERE TheLoai = @theLoai AND TacGia = @tacGia
END
GO
EXEC USP_TimSachQuaTheLoaiVaTacGia @tacGia= N'Nguyên Phong', @theLoai = N'Tiểu thuyết'

CREATE PROC USP_TimSachQuaTenVaTheLoaiVaTacGia
@tacGia NVARCHAR(50) , @theLoai NVARCHAR(50) , @tenSach NVARCHAR(50)
AS
BEGIN
	SELECT TenSach as [Tên Sách], TacGia as[Tác Giả], NhaXuatBan as [Nhà Xuất Bản], TheLoai as [Thể Loại], SoLuong as [Số Lượng], GiaTien as [Giá Tiền] FROM dbo.Sach WHERE TheLoai = @theLoai AND TacGia = @tacGia AND TenSach = @tenSach
END
GO
EXEC USP_TimSachQuaTenVaTheLoaiVaTacGia @tacGia= N'Nguyên Phong', @theLoai = N'Tiểu thuyết', @tenSach = N'Dấu Chân Trên Cát'
EXEC USP_TimSachQuaTenVaTacGia @tenSach = N'Dấu Chân Trên Cát', @tacGia = N'Nguyên Phong'
SELECT * FROM Sach AS s
SELECT * FROM TaiKhoan

CREATE PROC USN_ThanhToanSach
@tenSach NVARCHAR(50) , @soLuong INT
AS
BEGIN
	UPDATE Sach
	SET SoLuong = SoLuong - @soLuong
	WHERE TenSach = @tenSach
END

EXEC USN_ThanhToanSach @tenSach = N'Dấu Chân Trên Cát' , @soLuong = 3

SELECT * FROM Sach