-- Script tạo database Quản lý Bán hàng
-- Chạy script này để tạo database và các bảng

USE master;
GO

-- Tạo database nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QLCHLinhKienDienTu')
BEGIN
    CREATE DATABASE QLCHLinhKienDienTu;
END
GO

USE QLCHLinhKienDienTu;
GO

-- Tạo bảng Danh mục
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

-- Tạo bảng Nhà cung cấp
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

-- Tạo bảng Sản phẩm
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
        TrangThai BIT DEFAULT 1 -- 1: Đang kinh doanh, 0: Ngừng kinh doanh
    );
END
GO

-- Tạo bảng Khách hàng
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KhachHang')
BEGIN
    CREATE TABLE KhachHang (
        MaKhachHang INT PRIMARY KEY IDENTITY(1,1),
        MaSoKhachHang VARCHAR(50) UNIQUE,
        HoTen NVARCHAR(200) NOT NULL,
        SoDienThoai VARCHAR(20),
        Email VARCHAR(100),
        DiaChi NVARCHAR(500),
        LoaiKhachHang VARCHAR(50) DEFAULT 'Thường', -- Thường, VIP, Sỉ
        TongChiTieu DECIMAL(18,2) DEFAULT 0,
        NgayTao DATETIME DEFAULT GETDATE()
    );
END
GO

-- Tạo bảng Hóa đơn
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
        PhuongThucThanhToan VARCHAR(50), -- Tiền mặt, Chuyển khoản, Thẻ
        TrangThai VARCHAR(50) DEFAULT 'Hoàn thành' -- Chờ xử lý, Hoàn thành, Đã hủy
    );
END
GO

-- Tạo bảng Chi tiết hóa đơn
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

-- Tạo bảng Người dùng
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NguoiDung')
BEGIN
    CREATE TABLE NguoiDung (
        MaNguoiDung INT PRIMARY KEY IDENTITY(1,1),
        TenDangNhap VARCHAR(100) UNIQUE NOT NULL,
        MatKhau VARCHAR(255) NOT NULL,
        HoTen NVARCHAR(200) NOT NULL,
        Email VARCHAR(100),
        SoDienThoai VARCHAR(20),
        VaiTro VARCHAR(50) DEFAULT N'Nhân viên', -- Quản trị, Quản lý, Nhân viên
        NgayTao DATETIME DEFAULT GETDATE(),
        TrangThai BIT DEFAULT 1 -- 1: Hoạt động, 0: Khóa
    );
END
GO

-- Thêm dữ liệu mẫu
-- Người dùng mặc định (admin/admin)
IF NOT EXISTS (SELECT * FROM NguoiDung WHERE TenDangNhap = 'admin')
BEGIN
    INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai)
    VALUES ('admin', 'admin', N'Quản trị viên', N'Quản trị', 1);
END
GO

-- Danh mục mẫu
IF NOT EXISTS (SELECT * FROM DanhMuc)
BEGIN
    INSERT INTO DanhMuc (TenDanhMuc, MoTa) VALUES
    (N'Linh kiện điện tử', N'Các loại linh kiện điện tử cơ bản'),
    (N'IC - Vi mạch', N'Các loại IC, vi mạch tích hợp'),
    (N'Cảm biến', N'Các loại cảm biến'),
    (N'Module', N'Các module chức năng'),
    (N'Phụ kiện', N'Phụ kiện điện tử');
END
GO

-- Nhà cung cấp mẫu
IF NOT EXISTS (SELECT * FROM NhaCungCap)
BEGIN
    INSERT INTO NhaCungCap (TenNCC, SoDienThoai, Email, DiaChi) VALUES
    (N'Công ty TNHH Điện tử ABC', '0901234567', 'abc@example.com', N'123 Nguyễn Văn A, TP.HCM'),
    (N'Công ty CP Linh kiện XYZ', '0912345678', 'xyz@example.com', N'456 Lê Văn B, Hà Nội');
END
GO

-- Khách hàng mẫu
IF NOT EXISTS (SELECT * FROM KhachHang)
BEGIN
    INSERT INTO KhachHang (MaSoKhachHang, HoTen, SoDienThoai, LoaiKhachHang) VALUES
    ('KH001', N'Nguyễn Văn A', '0909123456', N'Thường'),
    ('KH002', N'Trần Thị B', '0918234567', N'VIP');
END
GO

PRINT N'Đã tạo database và dữ liệu mẫu thành công!';
GO
