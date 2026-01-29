# Quan ly cua hang linh kien dien tu

Du an WinForms C# .NET Framework 4.8 quan ly cua hang ban linh kien dien tu.

## Cau truc project

```
QLCHBanLinhKien/
    QLCHBanLinhKien.sln           # Solution file
    QLCHBanLinhKien/
        Program.cs                 # Entry point
        App.config                 # Connection string config
        frmLogin.cs               # Form dang nhap
        frmMains.cs               # Form chinh (MDI container)
        Class/
            Functions.cs          # Database utilities
        CreateDatabase.sql        # Script tao database
        Properties/
            Settings.settings     # Application settings
```

## Yeu cau he thong

- .NET Framework 4.8
- SQL Server Express (hoac SQL Server)
- Visual Studio 2019/2022

## Huong dan cai dat

### 1. Tao Database

Chay file `CreateDatabase.sql` trong SQL Server Management Studio hoac dung sqlcmd:

```powershell
sqlcmd -S TINH\SQLEXPRESS -i "CreateDatabase.sql"
```

### 2. Cau hinh Connection String

Sua connection string trong `App.config` cho phu hop voi may cua ban:

```xml
<connectionStrings>
    <add name="QLCHBanLinhKien.Properties.Settings.QuanLyBanHangConnectionString" 
         connectionString="Data Source=TEN_MAY\SQLEXPRESS;Initial Catalog=QLCHLinhKienDienTu;Integrated Security=True;Connect Timeout=30" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Thay `TEN_MAY\SQLEXPRESS` bang ten SQL Server instance cua ban.

### 3. Build va chay

```powershell
# Build solution
cd "c:\Users\phamt\OneDrive\May tinh\DUAN\QLCHBanLinhKien"
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" QLCHBanLinhKien.sln /p:Configuration=Debug

# Chay ung dung
Start-Process ".\QLCHBanLinhKien\bin\Debug\QLCHBanLinhKien.exe"
```

## Tai khoan mac dinh

- **Username**: admin
- **Password**: admin

## Chuc nang

1. **Dang nhap**: Xac thuc nguoi dung
2. **Menu He thong**: Dang xuat, Thoat
3. **Menu Danh muc**: San pham, Danh muc, Khach hang, Nha cung cap, Nguoi dung
4. **Menu Hoa don**: Ban hang (POS), Tim hoa don
5. **Menu Bao cao**: Bao cao doanh thu, Bao cao hang ton
6. **Menu Tro giup**: Gioi thieu, Huong dan

## Lenh git de xuat (KHONG TU DONG THUC HIEN)

```powershell
# Tao branch moi
git checkout -b feature/qlch-base-structure

# Add cac file moi
git add .

# Commit
git commit -m "feat: add base structure for QLCHBanLinhKien project"

# Push (sau khi duoc xac nhan)
git push origin feature/qlch-base-structure
```

## Ghi chu

- Du an nay duoc tao lai dua theo cau truc cua QuanLyBanHang
- Cac form chuc nang (frmPOS, frmSanPham...) se duoc them sau
- Unicode tieng Viet khong dau de tranh loi encoding
