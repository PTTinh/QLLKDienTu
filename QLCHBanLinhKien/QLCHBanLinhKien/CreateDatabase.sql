-- Script tao database Quan ly cua hang linh kien
-- Chay script nay trong SQL Server Management Studio
-- hoac sqlcmd de tao database va cac bang

USE master;
GO

-- Tao database neu chua ton tai
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QLCHLinhKienDienTu')
BEGIN
    CREATE DATABASE QLCHLinhKienDienTu;
END
GO

USE QLCHLinhKienDienTu;
GO

-- Tao bang Danh muc
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DanhMuc')
BEGIN
    CREATE TABLE DanhMuc (
        MaDanhMuc INT PRIMARY KEY IDENTITY(1,1),
        TenDanhMuc NVARCHAR(100) NOT NULL,
        MoTa NVARCHAR(500),
        NgayTao DATETIME DEFAULT GETDATE()
    );
END
GO

-- Tao bang Nha cung cap
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NhaCungCap')
BEGIN
    CREATE TABLE NhaCungCap (
        MaNCC INT PRIMARY KEY IDENTITY(1,1),
        TenNCC NVARCHAR(200) NOT NULL,
        SoDienThoai VARCHAR(20),
        Email VARCHAR(100),
        DiaChi NVARCHAR(500),
        MaSoThue VARCHAR(50)
    );
END
GO

-- Tao bang San pham
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SanPham')
BEGIN
    CREATE TABLE SanPham (
        MaSanPham INT PRIMARY KEY IDENTITY(1,1),
        MaSoSanPham VARCHAR(50) UNIQUE NOT NULL,
        TenSanPham NVARCHAR(200) NOT NULL,
        MaDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc),
        MaNCC INT FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
        GiaBan DECIMAL(18,2) NOT NULL,
        GiaNhap DECIMAL(18,2),
        SoLuongTon INT DEFAULT 0,
        TonToiThieu INT DEFAULT 10,
        TonToiDa INT DEFAULT 100,
        MoTa NVARCHAR(1000),
        DuongDanAnh VARCHAR(500),
        NgayTao DATETIME DEFAULT GETDATE(),
        TrangThai BIT DEFAULT 1 -- 1: Dang kinh doanh, 0: Ngung kinh doanh
    );
END
GO

-- Tao bang Khach hang
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KhachHang')
BEGIN
    CREATE TABLE KhachHang (
        MaKhachHang INT PRIMARY KEY IDENTITY(1,1),
        MaSoKhachHang VARCHAR(50) UNIQUE,
        HoTen NVARCHAR(200) NOT NULL,
        SoDienThoai VARCHAR(20),
        Email VARCHAR(100),
        DiaChi NVARCHAR(500),
        LoaiKhachHang VARCHAR(50) DEFAULT 'Thuong', -- Thuong, VIP, Si
        TongChiTieu DECIMAL(18,2) DEFAULT 0,
        NgayTao DATETIME DEFAULT GETDATE()
    );
END
GO

-- Tao bang Hoa don
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HoaDon')
BEGIN
    CREATE TABLE HoaDon (
        MaHoaDon INT PRIMARY KEY IDENTITY(1,1),
        SoHoaDon VARCHAR(50) UNIQUE NOT NULL,
        MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
        MaNhanVien INT,
        NgayBan DATETIME DEFAULT GETDATE(),
        TongTien DECIMAL(18,2) NOT NULL,
        GiamGia DECIMAL(18,2) DEFAULT 0,
        ThueVAT DECIMAL(18,2) DEFAULT 0,
        ThanhTien DECIMAL(18,2) NOT NULL,
        PhuongThucThanhToan VARCHAR(50), -- Tien mat, Chuyen khoan, The
        TrangThai VARCHAR(50) DEFAULT 'Hoan thanh' -- Cho xu ly, Hoan thanh, Da huy
    );
END
GO

-- Tao bang Chi tiet hoa don
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ChiTietHoaDon')
BEGIN
    CREATE TABLE ChiTietHoaDon (
        MaChiTiet INT PRIMARY KEY IDENTITY(1,1),
        MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
        MaSanPham INT FOREIGN KEY REFERENCES SanPham(MaSanPham),
        SoLuong INT NOT NULL,
        DonGia DECIMAL(18,2) NOT NULL,
        GiamGia DECIMAL(18,2) DEFAULT 0,
        ThanhTien DECIMAL(18,2) NOT NULL
    );
END
GO

-- Tao bang Nguoi dung
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NguoiDung')
BEGIN
    CREATE TABLE NguoiDung (
        MaNguoiDung INT PRIMARY KEY IDENTITY(1,1),
        TenDangNhap VARCHAR(100) UNIQUE NOT NULL,
        MatKhau VARCHAR(255) NOT NULL,
        HoTen NVARCHAR(200) NOT NULL,
        Email VARCHAR(100),
        SoDienThoai VARCHAR(20),
        VaiTro VARCHAR(50) DEFAULT N'Nhan vien', -- Quan tri, Quan ly, Nhan vien
        NgayTao DATETIME DEFAULT GETDATE(),
        TrangThai BIT DEFAULT 1 -- 1: Hoat dong, 0: Khoa
    );
END
GO

-- Them du lieu mau
-- Nguoi dung mac dinh (admin/admin)
IF NOT EXISTS (SELECT * FROM NguoiDung WHERE TenDangNhap = 'admin')
BEGIN
    INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai)
    VALUES ('admin', 'admin', N'Quan tri vien', N'Quan tri', 1);
END
GO

-- Danh muc mau
IF NOT EXISTS (SELECT * FROM DanhMuc)
BEGIN
    INSERT INTO DanhMuc (TenDanhMuc, MoTa) VALUES
    (N'Linh kien dien tu', N'Cac loai linh kien dien tu co ban'),
    (N'IC - Vi mach', N'Cac loai IC, vi mach tich hop'),
    (N'Cam bien', N'Cac loai cam bien'),
    (N'Module', N'Cac module chuc nang'),
    (N'Phu kien', N'Phu kien dien tu');
END
GO

-- Nha cung cap mau
IF NOT EXISTS (SELECT * FROM NhaCungCap)
BEGIN
    INSERT INTO NhaCungCap (TenNCC, SoDienThoai, Email, DiaChi) VALUES
    (N'Cong ty TNHH Dien tu ABC', '0901234567', 'abc@example.com', N'123 Nguyen Van A, TP.HCM'),
    (N'Cong ty CP Linh kien XYZ', '0912345678', 'xyz@example.com', N'456 Le Van B, Ha Noi');
END
GO

-- Khach hang mau
IF NOT EXISTS (SELECT * FROM KhachHang)
BEGIN
    INSERT INTO KhachHang (MaSoKhachHang, HoTen, SoDienThoai, LoaiKhachHang) VALUES
    ('KH001', N'Nguyen Van A', '0909123456', N'Thuong'),
    ('KH002', N'Tran Thi B', '0918234567', N'VIP');
END
GO

-- San pham mau
IF NOT EXISTS (SELECT * FROM SanPham)
BEGIN
    INSERT INTO SanPham (MaSoSanPham, TenSanPham, MaDanhMuc, MaNCC, GiaBan, GiaNhap, SoLuongTon) VALUES
    ('SP001', N'Dien tro 10K', 1, 1, 500, 200, 1000),
    ('SP002', N'Tu dien 100uF', 1, 1, 1000, 500, 500),
    ('SP003', N'IC 555', 2, 2, 5000, 3000, 200),
    ('SP004', N'Arduino Uno R3', 4, 2, 150000, 100000, 50),
    ('SP005', N'Cam bien nhiet do DS18B20', 3, 1, 25000, 15000, 100);
END
GO

PRINT N'Da tao database va du lieu mau thanh cong!';
GO
