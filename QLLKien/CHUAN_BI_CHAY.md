# 🚀 CHUẨN BỊ CHẠY ỨNG DỤNG

## ✅ DANH SÁCH KIỂM TRA

### 1. **Yêu Cầu Hệ Thống**
- [ ] Windows 7 trở lên
- [ ] .NET Framework 4.7.2 trở lên
- [ ] SQL Server Express hoặc cao hơn
- [ ] Microsoft Excel (để xuất file)
- [ ] Visual Studio 2022 hoặc Build Tools (tuỳ chọn)

### 2. **Cài Đặt Các Thành Phần**

#### A. SQL Server & Database
```bash
# Chạy script tạo database
sqlcmd -S localhost\SQLEXPRESS -i Database\database.sql
```

#### B. NuGet Packages
```bash
# Nếu dùng Visual Studio
# Visual Studio sẽ tự động restore packages
# Hoặc chạy trong Package Manager Console:
Update-Package
```

### 3. **Cấu Hình Ứng Dụng**

#### Connection String
- Sửa file: `App.config`
- Tìm: `connectionString`
- Đảm bảo server name đúng: `DESKTOP-EBPD2D3\SQLEXPRESS`
- User ID: `sa`
- Password: `123456`

#### Ví dụ:
```xml
<connectionStrings>
    <add name="QuanLyBanHang.Properties.Settings.QuanLyBanHangConnectionString"
        connectionString="Data Source=DESKTOP-EBPD2D3\SQLEXPRESS;Initial Catalog=QLCHLinhKienDienTu;User ID=sa;Password=123456"
        providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. **Biên Dịch Project**

#### Cách 1: Visual Studio
```
1. Mở Visual Studio
2. Mở file: QLLKien\QLLKien.sln
3. Chuột phải → Solution → Rebuild Solution
4. Chờ đến khi thấy "Build succeeded"
```

#### Cách 2: Script Build.bat
```batch
1. Chạy: Build.bat
2. Chờ kết quả Build
```

#### Cách 3: Command Line
```cmd
# Tìm MSBuild
"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" ^
QuanLyBanHang.csproj ^
/p:Configuration=Debug ^
/p:Platform=AnyCPU
```

### 5. **Chạy Ứng Dụng**

#### Cách 1: Visual Studio
```
1. Press F5 hoặc Ctrl+F5
2. Login với tài khoản admin/123456
```

#### Cách 2: Chạy trực tiếp
```
1. Vào: bin\Debug\
2. Double-click: QuanLyBanHang.exe
```

---

## 📋 TÀI KHOẢN MẶC ĐỊNH

| Tài Khoản | Mật Khẩu | Vai Trò |
|-----------|---------|--------|
| admin | 123456 | Quản Trị |
| quanly1 | 123456 | Quản Lý |
| nhanvien1 | 123456 | Nhân Viên |
| nhanvien2 | 123456 | Nhân Viên |
| kho | 123456 | Nhân Viên |

---

## 🔧 TROUBLESHOOTING

### ❌ Lỗi: "Cannot connect to database"
**Giải pháp:**
1. Kiểm tra SQL Server đang chạy
2. Kiểm tra connection string trong App.config
3. Kiểm tra tên server: `DESKTOP-EBPD2D3\SQLEXPRESS`
4. Kiểm tra user/password

### ❌ Lỗi: "Missing assembly"
**Giải pháp:**
1. Mở Visual Studio
2. Tools → NuGet Package Manager → Package Manager Console
3. Chạy: `Update-Package`
4. Rebuild solution

### ❌ Lỗi: "File not found: .rdlc"
**Giải pháp:**
1. Kiểm tra file báo cáo trong project
2. Đảm bảo file .rdlc có trong thư mục project
3. Build lại project

### ❌ Lỗi: "Excel not installed"
**Giải pháp:**
1. Cài đặt Microsoft Excel hoặc LibreOffice
2. Chạy Windows Installer repair nếu cần
3. Khởi động lại ứng dụng

---

## 📌 CẤU TRÚC THƯ MỤC

```
QLLKDienTu/
├── Database/
│   └── database.sql           # Script tạo database
├── docs/
│   └── phancong.txt          # Phân công công việc
├── QLLKien/
│   ├── QuanLyBanHang/        # Project chính
│   │   ├── bin/
│   │   │   ├── Debug/        # Build output (Debug)
│   │   │   └── Release/      # Build output (Release)
│   │   ├── obj/              # Intermediate objects
│   │   ├── Class/
│   │   │   └── Functions.cs
│   │   ├── App.config        # Configuration
│   │   ├── Build.bat         # Build script
│   │   ├── QuanLyBanHang.exe # Executable
│   │   └── *.cs              # Source files
│   ├── packages/             # NuGet packages
│   └── QLLKien.sln          # Solution file
└── README.md                 # Documentation
```

---

## 🎯 BƯỚC ĐẦU TIÊN (Quick Start)

### 1. Chuẩn Bị Database
```sql
-- Chạy script này trong SQL Server Management Studio
sqlcmd -S DESKTOP-EBPD2D3\SQLEXPRESS -i "c:\QLLKDienTu\Database\database.sql"
```

### 2. Biên Dịch
```batch
cd c:\QLLKDienTu\QLLKien\QuanLyBanHang
Build.bat
```

### 3. Chạy
```bash
bin\Debug\QuanLyBanHang.exe
```

### 4. Đăng Nhập
- **Tài khoản**: admin
- **Mật khẩu**: 123456

---

## 📞 CẦN GIÚP?

Nếu gặp vấn đề:
1. Kiểm tra log output của ứng dụng
2. Mở file `bin\Debug` để xem lỗi biên dịch
3. Kiểm tra Windows Event Viewer
4. Liên hệ IT support

---

**Cập nhật**: 26/01/2026
**Trạng thái**: ✅ CHUẨN BỊ HOÀN TẤT
