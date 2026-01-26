-- Script thêm dữ liệu mẫu để kiểm tra chức năng Cảnh báo Hàng tồn kho
-- Chạy script này sau khi đã chạy CreateDatabase.sql

USE QLCHLinhKienDienTu;
GO

-- 1. Thêm các danh mục (nếu chưa có)
IF NOT EXISTS (SELECT * FROM DanhMuc WHERE TenDanhMuc = N'Linh kiện cơ bản')
BEGIN
    INSERT INTO DanhMuc (TenDanhMuc, MoTa) VALUES
    (N'Linh kiện cơ bản', N'Các linh kiện điện tử cơ bản'),
    (N'Vi mạch IC', N'Các loại IC, vi mạch tích hợp'),
    (N'Cảm biến', N'Cảm biến nhiệt, ánh sáng, độ ẩm'),
    (N'Module/Bo mạch', N'Module Arduino, Raspberry Pi, PLC'),
    (N'Phụ kiện', N'Dây cắm, công tắc, nút bấm');
END
GO

-- 2. Thêm nhà cung cấp (nếu chưa có)
IF NOT EXISTS (SELECT * FROM NhaCungCap WHERE TenNCC = N'Công ty ABC')
BEGIN
    INSERT INTO NhaCungCap (TenNCC, SoDienThoai, Email, DiaChi, MaSoThue) VALUES
    (N'Công ty ABC', '0901234567', 'abc@example.com', N'123 Nguyễn Văn A, TP.HCM', '1234567890'),
    (N'Công ty XYZ', '0912345678', 'xyz@example.com', N'456 Lê Văn B, Hà Nội', '0987654321'),
    (N'Cửa hàng Linh Kiện 123', '0918765432', 'store@example.com', N'789 Trần Văn C, Đà Nẵng', '5555555555');
END
GO

-- 3. Thêm sản phẩm CÓ HÀNG TỒN THẤP (để kiểm tra chức năng cảnh báo)
-- Mục tiêu: Một số sản phẩm có SoLuongTon <= TonToiThieu

IF NOT EXISTS (SELECT * FROM SanPham WHERE TenSanPham = N'Điện trở 1K ohm')
BEGIN
    -- HẾT HÀNG (SoLuongTon = 0)
    INSERT INTO SanPham (MaSoSanPham, TenSanPham, MaDanhMuc, MaNCC, GiaBan, GiaNhap, SoLuongTon, TonToiThieu, TonToiDa, MoTa, TrangThai)
    VALUES 
    (N'SP20250126001', N'Điện trở 1K ohm', 1, 1, 5000, 3000, 0, 50, 200, N'Điện trở 1/4W 1K ohm', 1),
    (N'SP20250126002', N'Tụ điện 10µF', 1, 1, 2000, 1000, 0, 30, 150, N'Tụ điện hóa 10µF 50V', 1),
    
    -- SẮP HẾT (0 < SoLuongTon <= TonToiThieu)
    (N'SP20250126003', N'LED đỏ 5mm', 1, 1, 3000, 1500, 5, 50, 200, N'LED đỏ 5mm sáng 20mcd', 1),
    (N'SP20250126004', N'Vi mạch 555 Timer', 2, 2, 15000, 8000, 3, 30, 100, N'IC NE555 Timer', 1),
    (N'SP20250126005', N'Cảm biến DHT11', 3, 2, 45000, 25000, 8, 50, 200, N'Cảm biến nhiệt độ độ ẩm DHT11', 1),
    (N'SP20250126006', N'Arduino Nano', 4, 1, 120000, 60000, 12, 100, 300, N'Board Arduino Nano v3', 1),
    (N'SP20250126007', N'Relay 5V 1 channel', 4, 3, 25000, 12000, 2, 20, 80, N'Module Relay 5V 1 kênh', 1),
    (N'SP20250126008', N'Dây cắm breadboard', 5, 1, 8000, 4000, 15, 40, 150, N'Bộ dây cắm breadboard 65 sợi', 1),
    
    -- BÌNH THƯỜNG (SoLuongTon > TonToiThieu)
    (N'SP20250126009', N'Nút bấm 6x6x5mm', 5, 1, 1500, 800, 100, 50, 300, N'Nút bấm 4 chân 6x6mm', 1),
    (N'SP20250126010', N'Công tắc gạt', 5, 1, 3000, 1500, 80, 40, 200, N'Công tắc gạt 2 chiều', 1),
    (N'SP20250126011', N'Dây USB Micro', 5, 2, 25000, 12000, 150, 50, 300, N'Cáp USB Micro 1m', 1),
    (N'SP20250126012', N'Còi buzzer 12V', 1, 3, 12000, 6000, 60, 30, 150, N'Còi cảnh báo buzzer 12V', 1);
END
GO

-- 4. Hiển thị kết quả kiểm tra
SELECT N'--- KIỂM TRA DỮ LIỆU HÀNG TỒN ---' AS Info;
GO

SELECT 
    MaSanPham,
    MaSoSanPham,
    TenSanPham,
    dm.TenDanhMuc,
    SoLuongTon,
    TonToiThieu,
    TonToiDa,
    CASE 
        WHEN SoLuongTon = 0 THEN N'❌ HẾT HÀNG'
        WHEN SoLuongTon <= TonToiThieu THEN N'⚠️  SẮP HẾT'
        ELSE N'✅ BÌNH THƯỜNG'
    END AS TrangThaiHang
FROM SanPham sp
LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
WHERE sp.TrangThai = 1
ORDER BY SoLuongTon ASC;
GO

PRINT N'✅ Đã thêm dữ liệu mẫu thành công!';
PRINT N'';
PRINT N'📊 TÓNG KẾT DỮ LIỆU:';
PRINT N'- Hết hàng: 2 sản phẩm (Điện trở, Tụ điện)';
PRINT N'- Sắp hết: 6 sản phẩm (LED, IC 555, DHT11, Arduino Nano, Relay, Dây cắm)';
PRINT N'- Bình thường: 4 sản phẩm (Nút bấm, Công tắc, Dây USB, Còi buzzer)';
PRINT N'';
PRINT N'🔍 Mở form "Cảnh báo Hàng tồn" để kiểm tra chức năng!';
GO
