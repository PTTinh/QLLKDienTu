-- Database schema for QLCHLinhKienDienTu
-- Created: 2026-01-07

CREATE TABLE DanhMuc (
    MaDanhMuc INT PRIMARY KEY IDENTITY(1,1),
    TenDanhMuc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(500),
    NgayTao DATETIME DEFAULT GETDATE()
);

CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY IDENTITY(1,1),
    TenNCC NVARCHAR(200) NOT NULL,
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100),
    DiaChi NVARCHAR(500),
    MaSoThue VARCHAR(50)
);

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

CREATE TABLE ChiTietHoaDon (
    MaChiTiet INT PRIMARY KEY IDENTITY(1,1),
    MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaSanPham INT FOREIGN KEY REFERENCES SanPham(MaSanPham),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    GiamGia DECIMAL(18,2) DEFAULT 0,
    ThanhTien DECIMAL(18,2) NOT NULL
);

CREATE TABLE NguoiDung (
    MaNguoiDung INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap VARCHAR(100) UNIQUE NOT NULL,
    MatKhau VARCHAR(255) NOT NULL,
    HoTen NVARCHAR(200) NOT NULL,
    Email VARCHAR(100),
    SoDienThoai VARCHAR(20),
    VaiTro VARCHAR(50) DEFAULT 'Nhân viên', -- Quản trị, Quản lý, Nhân viên
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1 -- 1: Hoạt động, 0: Khóa
);
