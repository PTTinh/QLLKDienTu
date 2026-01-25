# HỆ THỐNG QUẢN LÝ BÁN HÀNG - LINH KIỆN ĐIỆN TỬ

## ✅ ĐÃ KIỂM TRA VÀ DỌNG DẸP CODE

### 📋 CÁC FORM HỢP LỆ (Đã kiểm tra với Database mới)

#### ✅ NGƯỜI 1: QUẢN TRỊ HỆ THỐNG (4/4 Forms - HOÀN THÀNH)
**Chịu trách nhiệm bảng: NguoiDung**

1. ✅ **frmLogin.cs** - Form Đăng nhập
   - ✓ Đúng với bảng NguoiDung
   - ✓ Lưu thông tin user hiện tại
   - ✓ Phân quyền theo vai trò

2. ✅ **frmDoiMatKhau.cs** - Form Đổi mật khẩu
   - ✓ Cập nhật bảng NguoiDung
   - ✓ Validation đầy đủ

3. ✅ **frmQuanLyNguoiDung.cs** - Form Quản lý Người dùng (CRUD)
   - ✓ CRUD hoàn chỉnh
   - ✓ Phân quyền: Quản trị, Quản lý, Nhân viên
   - ✓ Khóa/mở khóa tài khoản

4. ✅ **frmCauHinh.cs** - Form Cấu hình kết nối Database
   - ✓ Lưu connection string
   - ✓ Test connection
   - ✓ Windows/SQL Authentication

---

#### ✅ NGƯỜI 2: QUẢN LÝ KHO HÀNG (2/5 Forms)
**Chịu trách nhiệm bảng: SanPham, DanhMuc, NhaCungCap**

5. ✅ **frmDanhSachSanPham.cs** - Form Danh sách Sản phẩm
   - ✓ Đúng bảng SanPham, DanhMuc, NhaCungCap
   - ✓ Tìm kiếm, lọc theo danh mục
   - ✓ Double click để sửa

6. ✅ **frmCapNhatSanPham.cs** - Form Cập nhật Sản phẩm
   - ✓ Thêm/sửa sản phẩm
   - ✓ Quản lý tồn kho
   - ✓ Validation đầy đủ

**CẦN TẠO THÊM:**
7. ⏳ **frmQuanLyDanhMuc.cs** - Quản lý Danh mục
8. ⏳ **frmQuanLyNhaCungCap.cs** - Quản lý Nhà cung cấp
9. ⏳ **frmCanhBaoHangTon.cs** - Cảnh báo hàng tồn

---

#### ✅ NGƯỜI 3: BÁN HÀNG (0/4 Forms - CẦN TẠO MỚI)
**Chịu trách nhiệm bảng: HoaDon, ChiTietHoaDon**

⏳ **CẦN TẠO:**
10. **frmPOS.cs** - Form Bán hàng POS (QUAN TRỌNG)
11. **frmTimSanPhamNhanh.cs** - Tìm sản phẩm nhanh
12. **frmInHoaDon.cs** - In hóa đơn

---

#### ✅ NGƯỜI 4: KHÁCH HÀNG & LỊCH SỬ (3/4 Forms)
**Chịu trách nhiệm bảng: KhachHang, HoaDon**

13. ✅ **frmTimKhachHang.cs** - Tìm kiếm Khách hàng
    - ✓ Đã sửa đúng bảng KhachHang
    - ✓ Tìm theo mã, tên, địa chỉ, SĐT

14. ✅ **frmTimHDBan.cs** - Tìm lịch sử Hóa đơn
    - ✓ Đã sửa đúng bảng HoaDon
    - ✓ Lọc theo tháng, năm, khách hàng

15. ✅ **frmTimHang.cs** - Tìm sản phẩm
    - ✓ Đã sửa đúng bảng SanPham
    - ✓ Tìm theo tên, giá, số lượng

**CẦN TẠO THÊM:**
16. ⏳ **frmQuanLyKhachHang.cs** - Quản lý Khách hàng (CRUD)
17. ⏳ **frmCongNo.cs** - Công nợ khách hàng

---

#### ⏳ NGƯỜI 5: THỐNG KÊ (0/4 Forms - CẦN TẠO MỚI)
**Chịu trách nhiệm: Báo cáo & Thống kê**

18. ⏳ **frmDashboard.cs** - Dashboard (QUAN TRỌNG)
19. ⏳ **frmThongKeDoanhThu.cs** - Thống kê doanh thu
20. ⏳ **frmTopSanPham.cs** - Top sản phẩm bán chạy
21. ⏳ **frmThongKeNhanVien.cs** - Thống kê nhân viên

---

## 🗑️ ĐÃ XÓA CÁC FORM KHÔNG HỢP LỆ

❌ **Đã xóa các form sử dụng bảng cũ:**
- ~~frmDMChatLieu~~ - Bảng tblChatLieu không tồn tại
- ~~frmDanhmucnhanvien~~ - Đã có frmQuanLyNguoiDung thay thế
- ~~frmDMHang~~ - Dùng bảng tblHang (cũ), đã có frmDanhSachSanPham
- ~~frmDMKhachhang~~ - Dùng bảng tblKhach (cũ), sẽ tạo form mới
- ~~frmHDBanHang~~ - Dùng bảng tblHDBan (cũ), cần tạo frmPOS mới
- ~~frmBaoCao, frmBaoCaoDoanhThu, frmBaoCaoHangTon~~ - Dùng schema cũ
- ~~frmVainet, frmHientrogiup~~ - Không liên quan

---

## 📁 CẤU TRÚC PROJECT HIỆN TẠI

```
QuanLyBanHang/
│
├── Class/
│   └── Functions.cs                 ✅ Database Helper (đã cập nhật)
│
├── ✅ NGƯỜI 1 - QUẢN TRỊ (4/4)/
│   ├── frmLogin.cs                  ✅
│   ├── frmDoiMatKhau.cs             ✅
│   ├── frmQuanLyNguoiDung.cs        ✅
│   └── frmCauHinh.cs                ✅
│
├── ✅ NGƯỜI 2 - KHO HÀNG (2/5)/
│   ├── frmDanhSachSanPham.cs        ✅
│   ├── frmCapNhatSanPham.cs         ✅
│   ├── frmQuanLyDanhMuc.cs          ⏳ CẦN TẠO
│   ├── frmQuanLyNhaCungCap.cs       ⏳ CẦN TẠO
│   └── frmCanhBaoHangTon.cs         ⏳ CẦN TẠO
│
├── ⏳ NGƯỜI 3 - BÁN HÀNG (0/4)/
│   ├── frmPOS.cs                    ⏳ CẦN TẠO (QUAN TRỌNG)
│   ├── frmTimSanPhamNhanh.cs        ⏳ CẦN TẠO
│   └── frmInHoaDon.cs               ⏳ CẦN TẠO
│
├── ✅ NGƯỜI 4 - KHÁCH HÀNG (3/4)/
│   ├── frmTimKhachHang.cs           ✅ (đã sửa)
│   ├── frmTimHDBan.cs               ✅ (đã sửa)
│   ├── frmTimHang.cs                ✅ (đã sửa)
│   ├── frmQuanLyKhachHang.cs        ⏳ CẦN TẠO
│   └── frmCongNo.cs                 ⏳ CẦN TẠO
│
├── ⏳ NGƯỜI 5 - THỐNG KÊ (0/4)/
│   ├── frmDashboard.cs              ⏳ CẦN TẠO (QUAN TRỌNG)
│   ├── frmThongKeDoanhThu.cs        ⏳ CẦN TẠO
│   ├── frmTopSanPham.cs             ⏳ CẦN TẠO
│   └── frmThongKeNhanVien.cs        ⏳ CẦN TẠO
│
├── frmMains.cs                      ⏳ CẦN CẬP NHẬT MENU
├── Program.cs                       ✅ (start = frmLogin)
├── App.config                       ✅
└── CreateDatabase.sql               ✅
```

---

## 🗄️ DATABASE (Đã xác nhận đúng)

### Bảng dữ liệu:
1. ✅ **DanhMuc** - Danh mục sản phẩm
2. ✅ **NhaCungCap** - Nhà cung cấp
3. ✅ **SanPham** - Sản phẩm (có khóa ngoại DanhMuc, NhaCungCap)
4. ✅ **KhachHang** - Khách hàng
5. ✅ **HoaDon** - Hóa đơn bán (có khóa ngoại KhachHang)
6. ✅ **ChiTietHoaDon** - Chi tiết hóa đơn (có khóa ngoại HoaDon, SanPham)
7. ✅ **NguoiDung** - Tài khoản người dùng

---

## 📊 TIẾN ĐỘ HOÀN THÀNH

| Người | Forms hoàn thành | Tổng | % |
|-------|------------------|------|---|
| **Người 1** | 4 | 4 | 100% ✅ |
| **Người 2** | 2 | 5 | 40% |
| **Người 3** | 0 | 4 | 0% ⏳ |
| **Người 4** | 3 | 4 | 75% |
| **Người 5** | 0 | 4 | 0% ⏳ |
| **TỔNG** | **9** | **21** | **43%** |

---

## 🚀 HƯỚNG DẪN CHẠY PROJECT

### 1. Tạo Database
```sql
-- Chạy file CreateDatabase.sql trong SQL Server
-- Database: QLCHLinhKienDienTu
-- Tài khoản: admin/admin
```

### 2. Cấu hình Connection
- Chạy ứng dụng
- Đăng nhập: admin/admin  
- Vào Form Cấu hình để set connection string

### 3. Build Project
- Mở Visual Studio
- Build project
- Chạy và test các chức năng

---

## ✨ TÍNH NĂNG ĐÃ KIỂM TRA & HỢP LỆ

✅ Đăng nhập với phân quyền
✅ Quản lý người dùng (CRUD)
✅ Đổi mật khẩu
✅ Cấu hình database động
✅ Danh sách sản phẩm (tìm kiếm, lọc)
✅ Cập nhật sản phẩm (CRUD)
✅ Tìm kiếm khách hàng
✅ Tìm kiếm hóa đơn
✅ Tìm kiếm sản phẩm
✅ Database schema chuẩn

---

## 📝 CÔNG VIỆC CẦN HOÀN THÀNH (ƯU TIÊN)

### ⭐⭐⭐⭐⭐ Ưu tiên CỰC CAO:
1. **frmPOS.cs** - Form bán hàng POS (Người 3)
2. **frmDashboard.cs** - Dashboard thống kê (Người 5)

### ⭐⭐⭐⭐ Ưu tiên cao:
3. **frmQuanLyKhachHang.cs** - CRUD khách hàng (Người 4)
4. **frmQuanLyDanhMuc.cs** - Quản lý danh mục (Người 2)
5. **frmQuanLyNhaCungCap.cs** - Quản lý NCC (Người 2)

### ⭐⭐⭐ Ưu tiên trung bình:
6. **frmCanhBaoHangTon.cs** - Cảnh báo tồn (Người 2)
7. **frmInHoaDon.cs** - In hóa đơn (Người 3)
8. **frmThongKeDoanhThu.cs** - Thống kê doanh thu (Người 5)
9. **frmTopSanPham.cs** - Top sản phẩm (Người 5)

### ⭐⭐ Ưu tiên thấp:
10. Cập nhật frmMains với menu mới
11. Form công nợ
12. Thống kê nhân viên

---

## 🔧 CÔNG NGHỆ

- .NET Framework 4.7.2
- C# Windows Forms
- SQL Server (ADO.NET)
- Microsoft ReportViewer

---

_Đã kiểm tra và dọn dẹp: 2026-01-25_
_Forms hợp lệ: 9/21 (43%)_
_Database: 100% đúng schema_

### 📋 NGƯỜI 1: QUẢN TRỊ HỆ THỐNG & NHÂN VIÊN (4 Forms)
**Chịu trách nhiệm bảng: NguoiDung**

1. ✅ **frmLogin.cs** - Form Đăng nhập
   - Kiểm tra tài khoản/mật khẩu
   - Lưu thông tin người dùng hiện tại
   - Phân quyền theo vai trò

2. ✅ **frmDoiMatKhau.cs** - Form Đổi mật khẩu
   - Người dùng tự đổi mật khẩu
   - Xác thực mật khẩu cũ
   - Validation mật khẩu mới

3. ✅ **frmQuanLyNguoiDung.cs** - Form Quản lý Nhân viên (CRUD)
   - Danh sách nhân viên
   - Thêm, sửa, xóa tài khoản
   - Khóa/mở khóa tài khoản
   - Phân quyền vai trò

4. ✅ **frmCauHinh.cs** - Form Cấu hình kết nối Database
   - Cài đặt chuỗi kết nối
   - Test connection
   - Lưu vào App.config
   - Hỗ trợ Windows Authentication và SQL Authentication

---

### 📦 NGƯỜI 2: QUẢN LÝ KHO HÀNG HÓA (4-5 Forms)
**Chịu trách nhiệm bảng: SanPham, DanhMuc, NhaCungCap**

5. ✅ **frmDanhSachSanPham.cs** - Form Danh sách Sản phẩm
   - Hiển thị lưới sản phẩm
   - Tìm kiếm theo tên, mã
   - Lọc theo danh mục
   - Double click để sửa

6. ✅ **frmCapNhatSanPham.cs** - Form Cập nhật Sản phẩm
   - Thêm mới sản phẩm
   - Sửa thông tin sản phẩm
   - Quản lý tồn kho
   - Upload hình ảnh

7. **frmQuanLyDanhMuc.cs** - Form Quản lý Danh mục
   - CRUD danh mục sản phẩm
   - Mô tả danh mục

8. **frmQuanLyNhaCungCap.cs** - Form Quản lý Nhà cung cấp
   - CRUD nhà cung cấp
   - Thông tin liên hệ
   - Mã số thuế

9. **frmCanhBaoHangTon.cs** - Form Cảnh báo hàng tồn
   - Hiển thị sản phẩm SoLuongTon <= TonToiThieu
   - Gợi ý nhập hàng
   - Xuất báo cáo tồn kho thấp

---

### 💰 NGƯỜI 3: NGHIỆP VỤ BÁN HÀNG - POS (3-4 Forms)
**Chịu trách nhiệm bảng: HoaDon, ChiTietHoaDon**

10. **frmPOS.cs** - Form Bán hàng chính (Point of Sale)
    - Chọn khách hàng
    - Quét/tìm sản phẩm
    - Thêm vào giỏ hàng
    - Tính tổng tiền, chiết khấu, thuế VAT
    - Chọn phương thức thanh toán
    - Lưu hóa đơn + chi tiết
    - Cập nhật tồn kho tự động

11. **frmTimSanPhamNhanh.cs** - Form Tìm kiếm Sản phẩm nhanh
    - Popup tra cứu giá
    - Tìm theo mã/tên
    - Hiển thị tồn kho
    - Chọn để thêm vào POS

12. **frmInHoaDon.cs** - Form In Hóa đơn
    - Thiết kế template hóa đơn
    - Sử dụng ReportViewer
    - In/xuất PDF
    - Gửi email hóa đơn

13. **frmChiTietHoaDon.cs** (Optional) - Form Chi tiết hóa đơn
    - Xem chi tiết từng hóa đơn đã bán
    - Danh sách sản phẩm trong hóa đơn

---

### 👥 NGƯỜI 4: QUẢN LÝ KHÁCH HÀNG & LỊCH SỬ (4 Forms)
**Chịu trách nhiệm bảng: KhachHang, HoaDon (phần xem)**

14. **frmQuanLyKhachHang.cs** - Form Quản lý Khách hàng
    - CRUD khách hàng
    - Phân loại: Thường, VIP, Sỉ
    - Thông tin liên hệ
    - Lịch sử mua hàng

15. **frmLichSuGiaoDich.cs** - Form Lịch sử Giao dịch
    - Danh sách tất cả hóa đơn
    - Sắp xếp theo ngày mới nhất
    - Tìm kiếm theo số hóa đơn
    - Lọc theo ngày, khách hàng

16. **frmChiTietGiaoDich.cs** - Form Chi tiết Giao dịch
    - Click vào hóa đơn → xem chi tiết
    - Sản phẩm đã mua
    - Giá, số lượng, thành tiền

17. **frmCongNo.cs** - Form Tra cứu Công nợ/Chi tiêu
    - Tổng tiền khách hàng đã mua
    - Top khách hàng VIP
    - Công nợ (nếu có)

---

### 📊 NGƯỜI 5: THỐNG KÊ & BÁO CÁO (4-5 Forms)
**Chịu trách nhiệm: Tổng hợp dữ liệu (Chỉ Select)**

18. **frmDashboard.cs** - Dashboard Trang chủ
    - Tổng số khách hàng
    - Tổng số sản phẩm
    - Doanh thu hôm nay
    - Doanh thu tháng
    - Số đơn hàng
    - Biểu đồ doanh thu

19. **frmThongKeDoanhThu.cs** - Form Thống kê Doanh thu
    - Chọn từ ngày - đến ngày
    - Hiển thị tổng tiền bán được
    - Biểu đồ theo ngày/tháng/năm
    - Xuất Excel

20. **frmTopSanPham.cs** - Form Top Sản phẩm bán chạy
    - Sản phẩm bán nhiều nhất
    - Biểu đồ cột/tròn
    - Lọc theo khoảng thời gian

21. **frmThongKeNhanVien.cs** (Optional) - Form Thống kê theo Nhân viên
    - Nhân viên bán được bao nhiêu đơn
    - Doanh số theo nhân viên
    - Xếp hạng nhân viên

22. **frmBaoCaoTonKho.cs** (Optional) - Form Báo cáo Tồn kho
    - Báo cáo hàng tồn kho
    - Sản phẩm cần nhập
    - Sản phẩm tồn nhiều

---

## 📁 CẤU TRÚC PROJECT

```
QuanLyBanHang/
│
├── Class/
│   └── Functions.cs                 ✅ Database Helper (đã cập nhật)
│
├── NGƯỜI 1 - QUẢN TRỊ/
│   ├── frmLogin.cs                  ✅
│   ├── frmDoiMatKhau.cs             ✅
│   ├── frmQuanLyNguoiDung.cs        ✅
│   └── frmCauHinh.cs                ✅
│
├── NGƯỜI 2 - KHO HÀNG/
│   ├── frmDanhSachSanPham.cs        ✅
│   ├── frmCapNhatSanPham.cs         ✅
│   ├── frmQuanLyDanhMuc.cs          TODO
│   ├── frmQuanLyNhaCungCap.cs       TODO
│   └── frmCanhBaoHangTon.cs         TODO
│
├── NGƯỜI 3 - BÁN HÀNG/
│   ├── frmPOS.cs                    TODO (QUAN TRỌNG)
│   ├── frmTimSanPhamNhanh.cs        TODO
│   └── frmInHoaDon.cs               TODO
│
├── NGƯỜI 4 - KHÁCH HÀNG/
│   ├── frmQuanLyKhachHang.cs        TODO (có thể dùng frmDMKhachhang hiện tại)
│   ├── frmLichSuGiaoDich.cs         TODO
│   ├── frmChiTietGiaoDich.cs        TODO
│   └── frmCongNo.cs                 TODO
│
├── NGƯỜI 5 - THỐNG KÊ/
│   ├── frmDashboard.cs              TODO (QUAN TRỌNG)
│   ├── frmThongKeDoanhThu.cs        TODO
│   ├── frmTopSanPham.cs             TODO
│   └── frmThongKeNhanVien.cs        TODO
│
├── frmMains.cs                      TODO (cập nhật menu)
├── Program.cs                       ✅ (đã đổi start form thành Login)
├── App.config                       ✅ (có connection string)
└── CreateDatabase.sql               ✅ (script tạo database)
```

---

## 🗄️ DATABASE

### Bảng dữ liệu:
1. **DanhMuc** - Danh mục sản phẩm
2. **NhaCungCap** - Nhà cung cấp
3. **SanPham** - Sản phẩm
4. **KhachHang** - Khách hàng
5. **HoaDon** - Hóa đơn bán
6. **ChiTietHoaDon** - Chi tiết hóa đơn
7. **NguoiDung** - Tài khoản người dùng

### Tạo Database:
1. Mở SQL Server Management Studio
2. Chạy file `CreateDatabase.sql`
3. Database: **QLCHLinhKienDienTu**
4. Tài khoản mặc định: **admin/admin**

---

## 🚀 HƯỚNG DẪN CHẠY PROJECT

### 1. Cấu hình Database
```
- Chạy CreateDatabase.sql trong SQL Server
- Hoặc sử dụng frmCauHinh để cấu hình connection string
```

### 2. Cấu hình Connection String
Sửa file `App.config`:
```xml
<connectionStrings>
    <add name="QuanLyBanHang.Properties.Settings.QuanLyBanHangConnectionString"
         connectionString="Data Source=YOUR_SERVER\SQLEXPRESS;Initial Catalog=QLCHLinhKienDienTu;Integrated Security=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 3. Build và Run
- Build project trong Visual Studio
- Chạy ứng dụng
- Đăng nhập: admin/admin
- Đổi mật khẩu sau lần đăng nhập đầu tiên

---

## ✨ TÍNH NĂNG ĐÃ HOÀN THÀNH

✅ Hệ thống đăng nhập với phân quyền
✅ Quản lý người dùng (CRUD)
✅ Đổi mật khẩu
✅ Cấu hình kết nối database động
✅ Danh sách và cập nhật sản phẩm
✅ Database helper với các function tiện ích
✅ Script tạo database và dữ liệu mẫu

---

## 📝 CÔNG VIỆC CẦN HOÀN THÀNH

### Ưu tiên cao (Core features):
1. **frmPOS.cs** - Form bán hàng chính (Người 3)
2. **frmDashboard.cs** - Trang chủ thống kê (Người 5)
3. **frmQuanLyDanhMuc.cs** - Quản lý danh mục (Người 2)
4. **frmQuanLyNhaCungCap.cs** - Quản lý NCC (Người 2)
5. **frmLichSuGiaoDich.cs** - Lịch sử hóa đơn (Người 4)

### Ưu tiên trung bình:
6. **frmCanhBaoHangTon.cs** - Cảnh báo tồn kho (Người 2)
7. **frmTimSanPhamNhanh.cs** - Tìm kiếm nhanh (Người 3)
8. **frmInHoaDon.cs** - In hóa đơn (Người 3)
9. **frmThongKeDoanhThu.cs** - Thống kê doanh thu (Người 5)
10. **frmTopSanPham.cs** - Top sản phẩm (Người 5)

### Ưu tiên thấp (Nice to have):
11. Cập nhật frmMains với menu mới
12. Form công nợ khách hàng
13. Form thống kê nhân viên
14. Báo cáo tồn kho chi tiết

---

## 👥 PHÂN CHIA CÔNG VIỆC

| Người | Forms đã có | Forms cần làm | Độ khó |
|-------|-------------|---------------|--------|
| **Người 1** | 4/4 ✅ | 0 | ⭐⭐ |
| **Người 2** | 2/5 | 3 | ⭐⭐⭐ |
| **Người 3** | 0/4 | 4 | ⭐⭐⭐⭐⭐ (Khó nhất) |
| **Người 4** | 0/4 | 4 | ⭐⭐⭐ |
| **Người 5** | 0/4 | 4 | ⭐⭐⭐⭐ |

---

## 🔧 CÔNG NGHỆ SỬ DỤNG

- **Framework:** .NET Framework 4.7.2
- **Language:** C#
- **Database:** SQL Server
- **UI:** Windows Forms
- **Report:** Microsoft ReportViewer
- **ORM:** ADO.NET (SqlConnection, SqlCommand)

---

## 📞 LIÊN HỆ & HỖ TRỢ

- Khi gặp lỗi kết nối: Sử dụng **frmCauHinh** để cấu hình lại
- Khi quên mật khẩu admin: Chạy lại script CreateDatabase.sql
- Khi cần thêm form mới: Copy template từ form đã có

---

## 🎯 MỤC TIÊU PROJECT

Xây dựng hệ thống quản lý bán hàng linh kiện điện tử hoàn chỉnh với:
- ✅ Quản lý kho hàng
- ✅ Bán hàng (POS)
- ✅ Quản lý khách hàng
- ✅ Thống kê báo cáo
- ✅ Phân quyền người dùng

**Tổng cộng: 18-22 Forms**

---

_Cập nhật lần cuối: 2026-01-25_
