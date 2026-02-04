-- Database schema for QLCHLinhKienDienTu
-- Created: 2026-01-07
USE MASTER;
IF DB_ID(N'QLCHLinhKienDienTu') IS NULL
BEGIN
    CREATE DATABASE QLCHLinhKienDienTu;
END
GO
USE QLCHLinhKienDienTu;
GO
-- Table definitions
CREATE TABLE NguoiDung (
    MaNguoiDung INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap VARCHAR(100) UNIQUE NOT NULL,
    MatKhau VARCHAR(255) NOT NULL,
    HoTen NVARCHAR(200) NOT NULL,
    Email VARCHAR(100),
    SoDienThoai VARCHAR(20),
    VaiTro NVARCHAR(50) DEFAULT N'Nhân viên', -- Quản trị, Quản lý, Nhân viên
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1 -- 1: Hoạt động, 0: Khóa
);
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
    DuongDanAnh TEXT, 
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
    LoaiKhachHang NVARCHAR(50) DEFAULT N'Thường', -- Thường, VIP, Sỉ
    TongChiTieu DECIMAL(18,2) DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE()
);

CREATE TABLE HoaDon (
    MaHoaDon INT PRIMARY KEY IDENTITY(1,1),
    SoHoaDon VARCHAR(50) UNIQUE NOT NULL,
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    MaNhanVien INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung), -- Bổ sung ở đây
    NgayBan DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) NOT NULL,
    GiamGia DECIMAL(18,2) DEFAULT 0,
    ThueVAT DECIMAL(18,2) DEFAULT 0,
    ThanhTien DECIMAL(18,2) NOT NULL,
    PhuongThucThanhToan NVARCHAR(50),
    TrangThai NVARCHAR(50) DEFAULT N'Hoàn thành'
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
-- Thêm người dùng (mật khẩu đã mã hóa - mật khẩu gốc là "123456")
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro, TrangThai) VALUES
('admin', 'admin', N'Nguyễn Văn Quản Trị', 'admin@linhkien.com', '0909111222', N'Quản trị', 1),
('quanly1', 'quanly1', N'Trần Thị Quản Lý', 'quanly@linhkien.com', '0918333444', N'Quản lý', 1),
('nhanvien1', 'nhanvien1', N'Lê Văn Nhân Viên', 'nhanvien1@linhkien.com', '0928555666', N'Nhân viên', 1);
-- Thêm danh mục
INSERT INTO DanhMuc (TenDanhMuc, MoTa, NgayTao) VALUES
(N'CPU - Bộ vi xử lý', N'Các loại CPU Intel, AMD cho desktop và laptop', '2024-01-01'),
(N'RAM - Bộ nhớ trong', N'RAM DDR4, DDR5 các loại: 4GB, 8GB, 16GB, 32GB', '2024-01-01'),
(N'Ổ cứng - Lưu trữ', N'SSD, HDD, NVMe các dung lượng từ 128GB đến 4TB', '2024-01-01'),
(N'Mainboard - Bo mạch chủ', N'Mainboard các chuẩn: ATX, Micro-ATX, Mini-ITX', '2024-01-01'),
(N'VGA - Card màn hình', N'Card đồ họa NVIDIA, AMD các dòng từ cơ bản đến cao cấp', '2024-01-01'),
(N'PSU - Nguồn máy tính', N'Nguồn máy tính các công suất: 450W, 550W, 650W, 750W, 850W', '2024-01-01'),
(N'Tản nhiệt', N'Tản nhiệt khí, tản nhiệt nước AIO', '2024-01-01'),
(N'Case - Thùng máy', N'Thùng máy ATX, Micro-ATX, Mini-ITX', '2024-01-02'),
(N'Màn hình', N'Màn hình máy tính từ 19 inch đến 34 inch', '2024-01-02'),
(N'Bàn phím - Chuột', N'Bàn phím cơ, bàn phím thường, chuột gaming', '2024-01-02');
-- Thêm nhà cung cấp
INSERT INTO NhaCungCap (TenNCC, SoDienThoai, Email, DiaChi, MaSoThue) VALUES
(N'Công ty TNHH Intel Việt Nam', '02838233456', 'contact@intel.com.vn', N'Số 1 Đường 1A, Khu Công Nghệ Cao, Quận 9, TP.HCM', '0301234567'),
(N'Công ty TNHH AMD Việt Nam', '02838237890', 'info@amd.com.vn', N'Tầng 10, Tòa nhà AMD, Quận 1, TP.HCM', '0301234568'),
(N'Công ty TNHH Kingston Việt Nam', '02838231234', 'sales@kingston.com.vn', N'123 Lê Văn Lương, Quận 7, TP.HCM', '0301234569'),
(N'Công ty TNHH Samsung Electronics Vina', '02838234567', 'contact@samsung.com.vn', N'364 Cộng Hòa, Tân Bình, TP.HCM', '0301234570'),
(N'Công ty TNHH ASUS Việt Nam', '02838237891', 'support@asus.com.vn', N'117-119-121 Nguyễn Du, Quận 1, TP.HCM', '0301234571'),
(N'Công ty TNHH Gigabyte Việt Nam', '02838231235', 'info@gigabyte.com.vn', N'72-74 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', '0301234572'),
(N'Công ty TNHH Corsair Việt Nam', '02838234568', 'vn_sales@corsair.com', N'45 Võ Thị Sáu, Quận 1, TP.HCM', '0301234573'),
(N'Công ty TNHH Logitech Việt Nam', '02838237892', 'contact@logitech.com.vn', N'215 Nam Kỳ Khởi Nghĩa, Quận 3, TP.HCM', '0301234574'),
(N'Công ty TNHH Cooler Master Việt Nam', '02838231236', 'sales@coolermaster.com.vn', N'89 Lý Chính Thắng, Quận 3, TP.HCM', '0301234575'),
(N'Nhà phân phối Phong Vũ', '19006767', 'info@phongvu.vn', N'384-386 Hoàng Diệu, Quận 4, TP.HCM', '0301234576');
-- Thêm sản phẩm
INSERT INTO SanPham (MaSoSanPham, TenSanPham, MaDanhMuc, MaNCC, GiaNhap, GiaBan, SoLuongTon, TonToiThieu, TonToiDa, MoTa, TrangThai) VALUES
-- CPU
('CPU-INTEL-I5-12400', N'Intel Core i5-12400 6C/12T 2.5GHz', 1, 1, 4200000, 4890000, 25, 5, 50, N'CPU Intel Gen 12, socket LGA1700', 1),
('CPU-INTEL-I7-12700', N'Intel Core i7-12700 12C/20T 2.1GHz', 1, 1, 7500000, 8790000, 15, 3, 30, N'CPU Intel Core i7 Gen 12', 1),
('CPU-AMD-R5-5600X', N'AMD Ryzen 5 5600X 6C/12T 3.7GHz', 1, 2, 3900000, 4590000, 30, 5, 50, N'CPU AMD Ryzen 5, socket AM4', 1),
('CPU-AMD-R7-5800X', N'AMD Ryzen 7 5800X 8C/16T 3.8GHz', 1, 2, 6500000, 7490000, 18, 3, 30, N'CPU AMD Ryzen 7 cao cấp', 1),

-- RAM
('RAM-KING-8GB-D4', N'RAM Kingston Fury 8GB DDR4 3200MHz', 2, 3, 550000, 649000, 45, 10, 100, N'RAM DDR4 8GB, hỗ trợ RGB', 1),
('RAM-KING-16GB-D4', N'RAM Kingston Fury 16GB DDR4 3200MHz', 2, 3, 1050000, 1249000, 35, 8, 80, N'RAM DDR4 16GB, hiệu năng cao', 1),
('RAM-COR-32GB-D5', N'RAM Corsair Vengeance 32GB DDR5 5200MHz', 2, 7, 2300000, 2790000, 20, 5, 50, N'RAM DDR5 32GB cho gaming', 1),

-- SSD
('SSD-SAM-500GB', N'SSD Samsung 970 EVO Plus 500GB NVMe', 3, 4, 1450000, 1699000, 40, 10, 100, N'SSD NVMe PCIe Gen3 tốc độ cao', 1),
('SSD-SAM-1TB', N'SSD Samsung 980 PRO 1TB NVMe', 3, 4, 2500000, 2999000, 25, 5, 50, N'SSD PCIe 4.0 tốc độ 7000MB/s', 1),
('SSD-KING-1TB', N'SSD Kingston KC3000 1TB NVMe', 3, 3, 2300000, 2699000, 30, 5, 60, N'SSD Kingston hiệu năng cao', 1),

-- Mainboard
('MB-ASUS-B660', N'Mainboard ASUS TUF Gaming B660-PLUS', 4, 5, 3200000, 3890000, 22, 5, 40, N'Mainboard Intel B660, socket LGA1700', 1),
('MB-GIG-B550', N'Mainboard Gigabyte B550 AORUS ELITE', 4, 6, 2800000, 3390000, 28, 5, 50, N'Mainboard AMD B550, socket AM4', 1),
('MB-ASUS-Z790', N'Mainboard ASUS ROG STRIX Z790-E', 4, 5, 8500000, 9990000, 12, 3, 25, N'Mainboard cao cấp Z790', 1),

-- VGA
('VGA-ASUS-RTX3060', N'VGA ASUS TUF Gaming RTX 3060 12GB', 5, 5, 8500000, 9990000, 18, 3, 30, N'Card màn hình NVIDIA RTX 3060', 1),
('VGA-GIG-RTX4070', N'VGA Gigabyte Gaming OC RTX 4070 12GB', 5, 6, 15500000, 17990000, 10, 2, 20, N'Card màn hình NVIDIA RTX 4070', 1),
('VGA-ASUS-RX6700', N'VGA ASUS DUAL RX 6700 XT 12GB', 5, 5, 9500000, 11490000, 15, 3, 25, N'Card màn hình AMD Radeon RX 6700 XT', 1),

-- Nguồn
('PSU-COR-750W', N'Nguồn Corsair RM750 750W 80 Plus Gold', 6, 7, 2200000, 2690000, 30, 5, 50, N'Nguồn 750W Full Modular', 1),
('PSU-COOL-850W', N'Nguồn Cooler Master MWE 850 Gold V2', 6, 9, 2500000, 2990000, 25, 5, 40, N'Nguồn 850W 80 Plus Gold', 1),

-- Tản nhiệt
('FAN-COOL-MASTER', N'Tản nhiệt khí Cooler Master Hyper 212', 7, 9, 550000, 699000, 50, 10, 100, N'Tản nhiệt khí cho CPU', 1),

-- Case
('CASE-COOL-TD500', N'Thùng máy Cooler Master TD500 Mesh', 8, 9, 1800000, 2190000, 20, 5, 40, N'Thùng máy ATX với tản nhiệt tốt', 1),

-- Màn hình
('MON-SAM-27', N'Màn hình Samsung Odyssey G5 27" 144Hz', 9, 4, 6500000, 7890000, 15, 3, 30, N'Màn hình gaming 27 inch 144Hz', 1),

-- Bàn phím chuột
('KB-LOG-G413', N'Bàn phím Logitech G413 Mechanical', 10, 8, 1200000, 1499000, 35, 8, 80, N'Bàn phím cơ Logitech', 1),
('MOUSE-LOG-G502', N'Chuột Logitech G502 Hero', 10, 8, 850000, 1099000, 40, 10, 100, N'Chuột gaming Logitech G502', 1);
-- Thêm khách hàng
INSERT INTO KhachHang (MaSoKhachHang, HoTen, SoDienThoai, Email, DiaChi, LoaiKhachHang, TongChiTieu, NgayTao) VALUES
('KH001', N'Nguyễn Văn An', '0903123456', 'nguyenvanan@gmail.com', N'123 Nguyễn Trãi, Quận 1, TP.HCM', N'VIP', 25890000, '2024-01-15'),
('KH002', N'Trần Thị Bích', '0918234567', 'tranthibich@yahoo.com', N'45 Lê Lợi, Quận 3, TP.HCM', N'Thường', 12450000, '2024-02-10'),
('KH003', N'Lê Hoàng Nam', '0987654321', 'hoangnamle@gmail.com', N'78 Nguyễn Văn Linh, Quận 7, TP.HCM', N'VIP', 35670000, '2024-01-20'),
('KH004', N'Phạm Minh Tuấn', '0934567890', 'minhtuan.pham@gmail.com', N'22 Cách Mạng Tháng 8, Quận 10, TP.HCM', N'Sỉ', 125000000, '2024-01-05'),
('KH005', N'Hoàng Thị Hương', '0978123456', 'huonghoang@gmail.com', N'56 Võ Văn Tần, Quận 3, TP.HCM', N'Thường', 8900000, '2024-02-15'),
('KH006', N'Vũ Đức Mạnh', '0945678901', 'ducmanh.vu@outlook.com', N'89 Lý Thường Kiệt, Quận 11, TP.HCM', N'VIP', 42150000, '2024-01-25'),
('KH007', N'Đỗ Quang Huy', '0923456789', 'quanghuy.do@gmail.com', N'34 Nguyễn Thị Minh Khai, Quận 1, TP.HCM', N'Sỉ', 98700000, '2024-01-08'),
('KH008', N'Bùi Thanh Hà', '0967890123', 'thanhha.bui@gmail.com', N'12 Trần Hưng Đạo, Quận 5, TP.HCM', N'Thường', 15600000, '2024-02-20'),
('KH009', N'Nguyễn Trung Kiên', '0956789012', 'trungkien.nguyen@yahoo.com', N'67 Phạm Ngọc Thạch, Quận 3, TP.HCM', N'VIP', 31200000, '2024-01-30'),
('KH010', N'Lý Thị Mai', '0912345678', 'thimai.ly@gmail.com', N'99 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', N'Thường', 7200000, '2024-02-25');
-- Thêm hóa đơn
INSERT INTO HoaDon (SoHoaDon, MaKhachHang, MaNhanVien, NgayBan, TongTien, GiamGia, ThueVAT, ThanhTien, PhuongThucThanhToan, TrangThai) VALUES
('HD2401001', 1, 1, '2024-01-10 09:30:00', 14280000, 500000, 1378000, 15158000, N'Tiền mặt', N'Hoàn thành'),
('HD2401002', 4, 1, '2024-01-12 14:15:00', 35690000, 1000000, 3469000, 38159000, N'Chuyển khoản', N'Hoàn thành'),
('HD2401003', 3, 1, '2024-01-15 10:45:00', 21450000, 0, 2145000, 23595000, N'Thẻ', N'Hoàn thành'),
('HD2401004', 6, 1, '2024-01-18 16:20:00', 18900000, 300000, 1860000, 20460000, N'Tiền mặt', N'Hoàn thành'),
('HD2401005', 2, 1, '2024-01-20 11:10:00', 12450000, 200000, 1225000, 13475000, N'Tiền mặt', N'Hoàn thành'),
('HD2401006', 7, 1, '2024-01-22 13:45:00', 45200000, 1500000, 4370000, 48070000, N'Chuyển khoản', N'Hoàn thành'),
('HD2401007', 9, 1, '2024-01-25 09:15:00', 31200000, 800000, 3040000, 33440000, N'Thẻ', N'Hoàn thành'),
('HD2401008', 8, 1, '2024-01-28 15:30:00', 15600000, 100000, 1550000, 16150000, N'Tiền mặt', N'Hoàn thành'),
('HD2402001', 5, 1, '2024-02-02 10:20:00', 8900000, 0, 890000, 9790000, N'Tiền mặt', N'Hoàn thành'),
('HD2402002', 10, 1, '2024-02-05 14:40:00', 7200000, 100000, 710000, 7810000, N'Tiền mặt', N'Hoàn thành'),
('HD2402003', 1, 1, '2024-02-08 11:30:00', 11600000, 400000, 1120000, 12320000, N'Thẻ', N'Hoàn thành'),
('HD2402004', 3, 1, '2024-02-10 16:15:00', 14220000, 300000, 1392000, 15212000, N'Tiền mặt', N'Hoàn thành'),
('HD2402005', 4, 1, '2024-02-12 09:45:00', 26750000, 1200000, 2555000, 28105000, N'Chuyển khoản', N'Hoàn thành'),
('HD2402006', 6, 1, '2024-02-15 13:20:00', 23250000, 700000, 2255000, 24805000, N'Thẻ', N'Hoàn thành'),
('HD2402007', 2, 1, '2024-02-18 10:50:00', 15200000, 500000, 1470000, 16170000, N'Tiền mặt', N'Đã hủy'),
('HD2402008', 9, 1, '2024-02-20 15:10:00', 18700000, 300000, 1840000, 20240000, N'Tiền mặt', N'Hoàn thành');
Go
-- Thêm chi tiết hóa đơn
-- HD2401001
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(1, 3, 1, 4590000, 0, 4590000), -- CPU AMD Ryzen 5
(1, 6, 2, 1249000, 50000, 2398000), -- RAM 16GB
(1, 9, 1, 2999000, 0, 2999000), -- SSD 1TB
(1, 12, 1, 3390000, 0, 3390000); -- Mainboard B550
Go
-- HD2401002
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(2, 2, 2, 8790000, 200000, 17180000), -- CPU i7
(2, 15, 1, 17990000, 500000, 17490000); -- VGA RTX 4070
Go
-- HD2401003
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(3, 1, 1, 4890000, 0, 4890000), -- CPU i5
(3, 5, 2, 649000, 0, 1298000), -- RAM 8GB
(3, 8, 1, 1699000, 0, 1699000), -- SSD 500GB
(3, 14, 1, 9990000, 0, 9990000), -- VGA RTX 3060
(3, 17, 1, 2690000, 0, 2690000); -- Nguồn 750W
Go
-- HD2401004
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(4, 4, 1, 7490000, 100000, 7390000), -- CPU R7
(4, 7, 1, 2790000, 0, 2790000), -- RAM 32GB
(4, 10, 1, 2699000, 0, 2699000), -- SSD Kingston
(4, 13, 1, 9990000, 200000, 9790000); -- Mainboard Z790
Go
-- HD2401005
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(5, 3, 1, 4590000, 0, 4590000), -- CPU R5
(5, 6, 1, 1249000, 0, 1249000), -- RAM 16GB
(5, 9, 1, 2999000, 0, 2999000), -- SSD 1TB
(5, 12, 1, 3390000, 0, 3390000); -- Mainboard B550
Go
-- HD2401006
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(6, 1, 3, 4890000, 300000, 14370000), -- CPU i5 (3 cái)
(6, 15, 2, 17990000, 1000000, 34980000); -- VGA RTX 4070 (2 cái)
Go
-- HD2401007
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(7, 2, 1, 8790000, 0, 8790000), -- CPU i7
(7, 7, 1, 2790000, 0, 2790000), -- RAM 32GB
(7, 9, 2, 2999000, 200000, 5798000), -- SSD 1TB (2 cái)
(7, 14, 1, 9990000, 0, 9990000), -- VGA RTX 3060
(7, 18, 1, 2990000, 0, 2990000), -- Nguồn 850W
(7, 22, 1, 1499000, 0, 1499000); -- Bàn phím
Go
-- HD2401008
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(8, 3, 1, 4590000, 0, 4590000), -- CPU R5
(8, 6, 1, 1249000, 0, 1249000), -- RAM 16GB
(8, 12, 1, 3390000, 0, 3390000), -- Mainboard B550
(8, 20, 1, 7890000, 100000, 7790000), -- Màn hình
(8, 23, 1, 1099000, 0, 1099000); -- Chuột
Go
-- HD2402001
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(9, 1, 1, 4890000, 0, 4890000), -- CPU i5
(9, 5, 1, 649000, 0, 649000), -- RAM 8GB
(9, 8, 1, 1699000, 0, 1699000), -- SSD 500GB
(9, 19, 1, 2190000, 0, 2190000); -- Case
Go
-- HD2402002
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(10, 5, 2, 649000, 50000, 1248000), -- RAM 8GB (2 cái)
(10, 8, 1, 1699000, 0, 1699000), -- SSD 500GB
(10, 21, 1, 699000, 0, 699000), -- Tản nhiệt
(10, 22, 1, 1499000, 0, 1499000), -- Bàn phím
(10, 23, 1, 1099000, 50000, 1049000); -- Chuột
Go
-- HD2402003
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(11, 16, 1, 11490000, 400000, 11090000); -- VGA RX 6700
Go
-- HD2402004
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(12, 4, 1, 7490000, 0, 7490000), -- CPU R7
(12, 10, 1, 2699000, 0, 2699000), -- SSD Kingston
(12, 22, 1, 1499000, 0, 1499000), -- Bàn phím
(12, 23, 2, 1099000, 100000, 2098000); -- Chuột (2 cái)
Go
-- HD2402005
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(13, 2, 2, 8790000, 800000, 16780000), -- CPU i7 (2 cái)
(13, 7, 2, 2790000, 400000, 5180000); -- RAM 32GB (2 cái)
Go
-- HD2402006
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(14, 13, 1, 9990000, 500000, 9490000), -- Mainboard Z790
(14, 15, 1, 17990000, 200000, 17790000); -- VGA RTX 4070
Go
-- HD2402007 (Hóa đơn đã hủy)
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(15, 3, 1, 4590000, 0, 4590000),
(15, 9, 1, 2999000, 0, 2999000),
(15, 20, 1, 7890000, 0, 7890000);
Go
-- HD2402008
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(16, 1, 1, 4890000, 0, 4890000),
(16, 6, 2, 1249000, 100000, 2398000),
(16, 9, 1, 2999000, 0, 2999000),
(16, 14, 1, 9990000, 200000, 9790000);

