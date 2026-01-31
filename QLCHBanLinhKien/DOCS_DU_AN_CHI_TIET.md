# TAI LIEU DU AN QUAN LY CUA HANG LINH KIEN DIEN TU

## MUC LUC
1. [Tong quan du an](#1-tong-quan-du-an)
2. [Cau truc database](#2-cau-truc-database)
3. [Giai thich Class Functions](#3-giai-thich-class-functions)
4. [Phan cong kiem tra - 5 nguoi](#4-phan-cong-kiem-tra---5-nguoi)
5. [Chi tiet tung Form](#5-chi-tiet-tung-form)

---

## 1. TONG QUAN DU AN

### 1.1. Mo ta
- **Ten du an**: Quan ly cua hang linh kien dien tu (QLCHBanLinhKien)
- **Ngon ngu**: C# .NET Framework
- **Giao dien**: Windows Forms
- **Database**: SQL Server (QLCHLinhKienDienTu)
- **IDE**: Visual Studio 2022

### 1.2. Cac tinh nang chinh
| STT | Chuc nang | Mo ta |
|-----|-----------|-------|
| 1 | Dang nhap | Xac thuc nguoi dung, phan quyen |
| 2 | Dashboard | Tong quan doanh thu, thong ke nhanh |
| 3 | Ban hang (POS) | Tao hoa don, gio hang, thanh toan |
| 4 | Quan ly san pham | CRUD san pham, gia, ton kho |
| 5 | Quan ly khach hang | CRUD khach hang, phan loai |
| 6 | Quan ly nha cung cap | CRUD nha cung cap |
| 7 | Quan ly nguoi dung | CRUD tai khoan, phan quyen |
| 8 | Quan ly danh muc | CRUD danh muc san pham |
| 9 | Nhap hang | Cap nhat ton kho tu NCC |
| 10 | Bao cao doanh thu | Thong ke theo thoi gian |
| 11 | Top san pham | San pham ban chay nhat |
| 12 | Top khach hang | Khach hang mua nhieu nhat |
| 13 | Canh bao hang ton | San pham sap het hang |
| 14 | Tim kiem | Tim san pham, khach hang, hoa don |

### 1.3. Danh sach 25 Forms
```
1.  frmLogin           - Dang nhap
2.  frmMains           - Form chinh (MDI Container)
3.  frmDashboard       - Trang tong quan
4.  frmPOS             - Ban hang (Point of Sale)
5.  frmQuanLySanPham   - Quan ly san pham
6.  frmQuanLyKhachHang - Quan ly khach hang
7.  frmQuanLyNhaCungCap- Quan ly nha cung cap
8.  frmQuanLyNguoiDung - Quan ly nguoi dung
9.  frmQuanLyDanhMuc   - Quan ly danh muc
10. frmNhapHang        - Nhap hang
11. frmCapNhatSanPham  - Cap nhat nhanh san pham
12. frmThongKeDoanhThu - Thong ke doanh thu
13. frmThongKeNhanVien - Thong ke nhan vien
14. frmTopSanPham      - Top san pham ban chay
15. frmTopKhachHang    - Top khach hang
16. frmCanhBaoHangTon  - Canh bao hang ton kho
17. frmTimSanPham      - Tim kiem san pham
18. frmTimKhachHang    - Tim kiem khach hang
19. frmTimHoaDon       - Tim kiem hoa don
20. frmChiTietHoaDon   - Chi tiet hoa don
21. frmInHoaDon        - In hoa don
22. frmLichSuMuaHang   - Lich su mua hang khach hang
23. frmThongTinCaNhan  - Thong tin ca nhan
24. frmDoiMatKhau      - Doi mat khau
25. frmCauHinh         - Cau hinh he thong
```

---

## 2. CAU TRUC DATABASE

### 2.1. So do bang (7 bang chinh)

```
+-------------+       +-------------+       +-------------+
|  DanhMuc    |       |  NhaCungCap |       |  NguoiDung  |
+-------------+       +-------------+       +-------------+
| MaDanhMuc   |       | MaNCC       |       | MaNguoiDung |
| TenDanhMuc  |       | TenNCC      |       | TenDangNhap |
| MoTa        |       | SoDienThoai |       | MatKhau     |
| NgayTao     |       | Email       |       | HoTen       |
+------+------+       | DiaChi      |       | VaiTro      |
       |              | MaSoThue    |       | TrangThai   |
       |              +------+------+       +------+------+
       |                     |                     |
       v                     v                     v
+------+------+------+-------+---------------------+
|             SanPham              |
+---------------------------------+
| MaSanPham (PK, Identity)        |
| MaSoSanPham (Unique)            |
| TenSanPham                      |
| MaDanhMuc (FK -> DanhMuc)       |
| MaNCC (FK -> NhaCungCap)        |
| GiaBan                          |
| GiaNhap                         |
| SoLuongTon                      |
| TonToiThieu                     |
| TrangThai                       |
+----------------+----------------+
                 |
                 v
+----------------+----------------+       +----------------+
|          HoaDon                 |       |   KhachHang    |
+---------------------------------+       +----------------+
| MaHoaDon (PK, Identity)         |       | MaKhachHang    |
| SoHoaDon (Unique)               |       | MaSoKhachHang  |
| MaKhachHang (FK -> KhachHang)   +<------+ HoTen          |
| MaNhanVien (FK -> NguoiDung)    |       | SoDienThoai    |
| NgayBan                         |       | LoaiKhachHang  |
| TongTien                        |       | TongChiTieu    |
| GiamGia                         |       +----------------+
| ThanhTien                       |
+----------------+----------------+
                 |
                 v
+----------------+----------------+
|       ChiTietHoaDon             |
+---------------------------------+
| MaChiTiet (PK, Identity)        |
| MaHoaDon (FK -> HoaDon)         |
| MaSanPham (FK -> SanPham)       |
| SoLuong                         |
| DonGia                          |
| ThanhTien                       |
+---------------------------------+
```

### 2.2. Chi tiet cac bang

#### Bang DanhMuc
```sql
CREATE TABLE DanhMuc (
    MaDanhMuc INT PRIMARY KEY IDENTITY(1,1),  -- Tu dong tang
    TenDanhMuc NVARCHAR(100) NOT NULL,        -- Ten danh muc
    MoTa NVARCHAR(500),                       -- Mo ta
    NgayTao DATETIME DEFAULT GETDATE()        -- Mac dinh ngay hien tai
);
```
**Giai thich**:
- `IDENTITY(1,1)`: Tu dong tang tu 1, moi lan tang 1
- `NVARCHAR`: Ho tro Unicode (tieng Viet)
- `DEFAULT GETDATE()`: Tu dong lay ngay gio hien tai

#### Bang SanPham
```sql
CREATE TABLE SanPham (
    MaSanPham INT PRIMARY KEY IDENTITY(1,1),
    MaSoSanPham VARCHAR(50) UNIQUE NOT NULL,  -- Ma rieng, khong trung
    TenSanPham NVARCHAR(200) NOT NULL,
    MaDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc),
    MaNCC INT FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
    GiaBan DECIMAL(18,2) NOT NULL,            -- 18 chu so, 2 so le
    GiaNhap DECIMAL(18,2),
    SoLuongTon INT DEFAULT 0,
    TrangThai BIT DEFAULT 1                    -- 1=Hoat dong, 0=Ngung
);
```
**Giai thich**:
- `FOREIGN KEY REFERENCES`: Khoa ngoai lien ket bang khac
- `DECIMAL(18,2)`: Kieu so thuc, 18 chu so tong, 2 chu so thap phan
- `BIT`: Kieu boolean (0 hoac 1)

#### Bang HoaDon
```sql
CREATE TABLE HoaDon (
    MaHoaDon INT PRIMARY KEY IDENTITY(1,1),
    SoHoaDon VARCHAR(50) UNIQUE NOT NULL,     -- VD: HD20260130123456
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    MaNhanVien INT,                           -- Nguoi tao hoa don
    NgayBan DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) NOT NULL,          -- Tong tien truoc giam
    GiamGia DECIMAL(18,2) DEFAULT 0,          -- So tien giam
    ThanhTien DECIMAL(18,2) NOT NULL          -- Tien phai tra
);
```

#### Bang ChiTietHoaDon
```sql
CREATE TABLE ChiTietHoaDon (
    MaChiTiet INT PRIMARY KEY IDENTITY(1,1),
    MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaSanPham INT FOREIGN KEY REFERENCES SanPham(MaSanPham),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien DECIMAL(18,2) NOT NULL          -- = SoLuong * DonGia
);
```

---

## 3. GIAI THICH CLASS FUNCTIONS

### 3.1. Tong quan
File: `Class/Functions.cs`
Day la class tien ich chua cac phuong thuc ket noi va thao tac database.

### 3.2. Bien static
```csharp
public static SqlConnection conn;           // Doi tuong ket noi SQL
public static string currentUser = "";      // Ten nguoi dang nhap
public static int currentUserId = 0;        // ID nguoi dang nhap
public static string currentUserRole = "";  // Vai tro (Admin, NhanVien)
```
**Giai thich**: Bien `static` duoc dung chung cho toan bo ung dung, khong can tao doi tuong.

### 3.3. Phuong thuc ket noi

#### Connect() - Ket noi database
```csharp
public static void Connect()
{
    try
    {
        conn = new SqlConnection();
        conn.ConnectionString = Properties.Settings.Default.QuanLyBanHangConnectionString;
        conn.Open();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Loi ket noi: " + ex.Message);
    }
}
```
**Giai thich**:
- Tao doi tuong `SqlConnection`
- Lay chuoi ket noi tu Settings
- `conn.Open()`: Mo ket noi
- Xu ly loi bang `try-catch`

#### ConnectSilent() - Ket noi im lang
```csharp
public static void ConnectSilent()
{
    try
    {
        if (conn == null || conn.State != ConnectionState.Open)
        {
            conn = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.QuanLyBanHangConnectionString;
            conn.Open();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Loi ket noi: " + ex.Message);
    }
}
```
**Giai thich**: Chi ket noi khi chua co hoac da dong. Tranh tao nhieu ket noi khong can thiet.

#### Disconnect() - Dong ket noi
```csharp
public static void Disconnect()
{
    if (conn.State == ConnectionState.Open)
    {
        conn.Close();     // Dong ket noi
        conn.Dispose();   // Giai phong bo nho
        conn = null;      // Gan null de garbage collector don dep
    }
}
```

### 3.4. Phuong thuc truy van

#### GetDataToTable() - Lay du lieu vao DataTable
```csharp
public static DataTable GetDataToTable(string sql)
{
    DataTable table = new DataTable();
    ConnectSilent();                              // Dam bao da ket noi
    SqlDataAdapter MyData = new SqlDataAdapter(); // Cau noi giua DB va DataTable
    MyData.SelectCommand = new SqlCommand();
    MyData.SelectCommand.Connection = Functions.conn;
    MyData.SelectCommand.CommandText = sql;
    MyData.Fill(table);                           // Do du lieu vao table
    return table;
}
```
**Giai thich**:
- `SqlDataAdapter`: Lop trung gian de chuyen du lieu
- `Fill(table)`: Thuc hien truy van va do vao DataTable

#### GetDataTable() voi Parameters - Chong SQL Injection
```csharp
public static DataTable GetDataTable(string sql, SqlParameter[] parameters)
{
    DataTable table = new DataTable();
    ConnectSilent();
    SqlDataAdapter MyData = new SqlDataAdapter();
    MyData.SelectCommand = new SqlCommand();
    MyData.SelectCommand.Connection = Functions.conn;
    MyData.SelectCommand.CommandText = sql;
    if (parameters != null)
    {
        MyData.SelectCommand.Parameters.AddRange(parameters);
    }
    MyData.Fill(table);
    return table;
}
```
**Giai thich**: Su dung `SqlParameter` de truyen gia tri an toan, tranh SQL Injection.

**Vi du su dung**:
```csharp
string sql = "SELECT * FROM SanPham WHERE TenSanPham LIKE @Keyword";
SqlParameter[] parameters = { 
    new SqlParameter("@Keyword", "%" + txtTimKiem.Text + "%") 
};
DataTable dt = Functions.GetDataTable(sql, parameters);
```

### 3.5. Phuong thuc thuc thi

#### RunSQL() - Thuc thi INSERT, UPDATE, DELETE
```csharp
public static bool RunSQL(string sql)
{
    ConnectSilent();
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;
    cmd.CommandText = sql;
    try
    {
        cmd.ExecuteNonQuery();    // Thuc thi, khong tra ve du lieu
        cmd.Dispose();
        return true;              // Thanh cong
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
        cmd.Dispose();
        return false;             // That bai
    }
}
```
**Giai thich**:
- `ExecuteNonQuery()`: Dung cho cau lenh khong tra ve du lieu (INSERT, UPDATE, DELETE)
- Tra ve `true/false` de kiem tra thanh cong

#### GetFieldValues() - Lay 1 gia tri duy nhat
```csharp
public static string GetFieldValues(string sql)
{
    string ma = "";
    ConnectSilent();
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlDataReader reader;
    reader = cmd.ExecuteReader();     // Doc du lieu
    while (reader.Read())
        ma = reader.GetValue(0).ToString();  // Lay gia tri cot dau tien
    reader.Close();
    return ma;
}
```
**Giai thich**:
- `SqlDataReader`: Doc du lieu tung dong
- `GetValue(0)`: Lay gia tri cot dau tien (index 0)

**Vi du su dung**:
```csharp
string sql = "SELECT COUNT(*) FROM SanPham";
string soSanPham = Functions.GetFieldValues(sql);  // Tra ve "100"
```

### 3.6. Phuong thuc tien ich

#### CheckKey() - Kiem tra khoa trung
```csharp
public static bool CheckKey(string sql)
{
    ConnectSilent();
    SqlDataAdapter MyData = new SqlDataAdapter(sql, conn);
    DataTable table = new DataTable();
    MyData.Fill(table);
    if (table.Rows.Count > 0)
        return true;    // Co du lieu -> trung
    else
        return false;   // Khong co -> chua trung
}
```

#### FillCombo() - Do du lieu vao ComboBox
```csharp
public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
{
    ConnectSilent();
    SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
    DataTable table = new DataTable();
    dap.Fill(table);
    cbo.DataSource = table;
    cbo.ValueMember = ma;       // Truong gia tri (an)
    cbo.DisplayMember = ten;    // Truong hien thi
}
```
**Vi du**:
```csharp
// SQL: SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc
Functions.FillCombo(sql, cboDanhMuc, "MaDanhMuc", "TenDanhMuc");
// ComboBox se hien thi TenDanhMuc nhung gia tri la MaDanhMuc
```

#### CreateKey() - Tao ma tu dong
```csharp
public static string CreateKey(string tiento)
{
    string key = tiento;
    // Them ngay thang: 01302026
    string[] partsDay = DateTime.Now.ToShortDateString().Split('/');
    string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
    key = key + d;
    
    // Them gio phut giay: _143025
    string[] partsTime = DateTime.Now.ToLongTimeString().Split(':');
    // Xu ly AM/PM...
    string t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
    key = key + t;
    
    return key;  // VD: HD01302026_143025
}
```

#### ChuyenSoSangChuoi() - Doc so thanh chu
```csharp
public static string ChuyenSoSangChuoi(double so)
{
    // 123000 -> "mot tram hai muoi ba nghin dong"
    // Su dung de in hoa don bang chu
}
```
**Cach hoat dong**:
1. Tach so theo hang: Ty, Trieu, Nghin, Tram, Chuc, Don vi
2. Doc tung phan roi ghep lai
3. Xu ly cac truong hop dac biet: "muoi mot" -> "muoi mot", "muoi nam" -> "muoi lam"

---

## 4. PHAN CONG KIEM TRA - 5 NGUOI

### NGUOI 1: DANG NHAP & HE THONG (5 Forms)

| STT | Form | Chuc nang | Muc do |
|-----|------|-----------|--------|
| 1 | frmLogin | Dang nhap he thong | Quan trong |
| 2 | frmMains | Form chinh, menu | Quan trong |
| 3 | frmThongTinCaNhan | Xem/sua thong tin ca nhan | Trung binh |
| 4 | frmDoiMatKhau | Doi mat khau | Trung binh |
| 5 | frmCauHinh | Cau hinh ket noi database | Kho |

**Checklist kiem tra**:
- [ ] Dang nhap dung/sai mat khau
- [ ] Phan quyen Admin/NhanVien
- [ ] Menu hoat dong dung
- [ ] Doi mat khau thanh cong
- [ ] Cau hinh ket noi database

---

### NGUOI 2: BAN HANG & HOA DON (5 Forms)(KHANH)

| STT | Form | Chuc nang | Muc do |
|-----|------|-----------|--------|
| 1 | frmPOS | Man hinh ban hang | **Rat kho** |
| 2 | frmTimHoaDon | Tim kiem hoa don | Trung binh |
| 3 | frmChiTietHoaDon | Xem chi tiet hoa don | Trung binh |
| 4 | frmInHoaDon | In hoa don | Kho |
| 5 | frmDashboard | Trang tong quan | Trung binh |

**Checklist kiem tra**:
- [ ] Them san pham vao gio hang
- [ ] Tinh tong tien chinh xac
- [ ] Chon khach hang
- [ ] Thanh toan tao hoa don
- [ ] Tim hoa don theo ngay/ma
- [ ] In hoa don ra file

---

### NGUOI 3: QUAN LY DANH MUC (5 Forms)

| STT | Form | Chuc nang | Muc do |
|-----|------|-----------|--------|
| 1 | frmQuanLySanPham | CRUD san pham | Kho |
| 2 | frmQuanLyDanhMuc | CRUD danh muc | De |
| 3 | frmQuanLyNhaCungCap | CRUD nha cung cap | Trung binh |
| 4 | frmCapNhatSanPham | Cap nhat nhanh san pham | Trung binh |
| 5 | frmTimSanPham | Tim kiem san pham | De |

**Checklist kiem tra**:
- [ ] Them moi san pham
- [ ] Sua thong tin san pham
- [ ] Xoa san pham (kiem tra rang buoc)
- [ ] Tim kiem theo ten/ma
- [ ] Loc theo danh muc

---

### NGUOI 4: KHACH HANG & NGUOI DUNG (5 Forms)

| STT | Form | Chuc nang | Muc do |
|-----|------|-----------|--------|
| 1 | frmQuanLyKhachHang | CRUD khach hang | Trung binh |
| 2 | frmQuanLyNguoiDung | CRUD nguoi dung | Kho |
| 3 | frmTimKhachHang | Tim kiem khach hang | De |
| 4 | frmLichSuMuaHang | Xem lich su mua cua KH | Trung binh |
| 5 | frmTopKhachHang | Top khach hang | Trung binh |

**Checklist kiem tra**:
- [ ] Them khach hang moi
- [ ] Phan loai khach hang (Thuong/VIP)
- [ ] Them nguoi dung moi
- [ ] Phan quyen nguoi dung
- [ ] Xem lich su mua hang
- [ ] Top khach hang mua nhieu

---

### NGUOI 5: BAO CAO & KHO HANG (5 Forms)

| STT | Form | Chuc nang | Muc do |
|-----|------|-----------|--------|
| 1 | frmThongKeDoanhThu | Bao cao doanh thu | Kho |
| 2 | frmThongKeNhanVien | Thong ke theo nhan vien | Trung binh |
| 3 | frmTopSanPham | Top san pham ban chay | Trung binh |
| 4 | frmCanhBaoHangTon | Canh bao het hang | Trung binh |
| 5 | frmNhapHang | Nhap hang tu NCC | Kho |

**Checklist kiem tra**:
- [ ] Loc doanh thu theo ngay/thang/nam
- [ ] Xuat Excel bao cao
- [ ] Top san pham ban chay
- [ ] Canh bao san pham < 10
- [ ] Nhap hang cap nhat ton kho

---

## 5. CHI TIET TUNG FORM

### 5.1. frmLogin - Dang nhap

#### Giao dien
```
+------------------------------------------+
|           DANG NHAP HE THONG             |
+------------------------------------------+
|  Ten dang nhap: [________________]       |
|  Mat khau:      [________________]       |
|                                          |
|  [  Dang nhap  ]    [  Thoat  ]         |
+------------------------------------------+
```

#### Cac thanh phan
| Control | Ten | Chuc nang |
|---------|-----|-----------|
| TextBox | txtTenDangNhap | Nhap ten dang nhap |
| TextBox | txtMatKhau | Nhap mat khau (PasswordChar = '*') |
| Button | btnDangNhap | Xu ly dang nhap |
| Button | btnThoat | Thoat ung dung |

#### Logic xu ly
```csharp
private void btnDangNhap_Click(object sender, EventArgs e)
{
    // 1. Kiem tra rong
    if (string.IsNullOrEmpty(txtTenDangNhap.Text))
    {
        MessageBox.Show("Vui long nhap ten dang nhap!");
        return;
    }

    // 2. Truy van database (chong SQL Injection)
    string sql = "SELECT MaNguoiDung, HoTen, VaiTro FROM NguoiDung " +
                 "WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau AND TrangThai = 1";
    SqlParameter[] parameters = {
        new SqlParameter("@TenDangNhap", txtTenDangNhap.Text),
        new SqlParameter("@MatKhau", txtMatKhau.Text)
    };

    DataTable dt = Functions.GetDataTable(sql, parameters);

    // 3. Kiem tra ket qua
    if (dt.Rows.Count > 0)
    {
        // Luu thong tin nguoi dung
        Functions.currentUserId = Convert.ToInt32(dt.Rows[0]["MaNguoiDung"]);
        Functions.currentUser = dt.Rows[0]["HoTen"].ToString();
        Functions.currentUserRole = dt.Rows[0]["VaiTro"].ToString();
        
        // Mo form chinh
        this.Hide();
        frmMains frmMain = new frmMains();
        frmMain.ShowDialog();
        this.Close();
    }
    else
    {
        MessageBox.Show("Ten dang nhap hoac mat khau khong dung!");
    }
}
```

#### Giai thich SQL
```sql
SELECT MaNguoiDung, HoTen, VaiTro 
FROM NguoiDung 
WHERE TenDangNhap = @TenDangNhap    -- Ten dang nhap phai khop
  AND MatKhau = @MatKhau           -- Mat khau phai khop
  AND TrangThai = 1                -- Tai khoan phai dang hoat dong
```

---

### 5.2. frmPOS - Ban hang (PHUC TAP NHAT)

#### Giao dien
```
+------------------------------------------------------------------+
|                        BAN HANG (POS)                            |
+------------------------------------------------------------------+
| [Tim kiem SP: ___________] [Danh muc: v] [Tim]                  |
+----------------------------------+-------------------------------+
|      DANH SACH SAN PHAM          |        GIO HANG               |
+----------------------------------+-------------------------------+
| Ma SP | Ten SP | Gia | Ton kho   | Ma SP | Ten SP | SL | Thanh tien|
|-------|--------|-----|-----------|-------|--------|----|-----------| 
| SP001 | Dien...|  500| 1000      | SP001 | Dien...|  2 | 1,000     |
| SP002 | Tu d...|1,000| 500       | SP003 | IC 555 |  1 | 5,000     |
|       |        |     |           |       |        |    |           |
+----------------------------------+-------------------------------+
| Khach hang: [-- Khach le -- v]   | Tong tien:        6,000 VND   |
| Giam gia:   [    0    ]          | Giam gia:             0 VND   |
| Ghi chu:    [_______________]    | THANH TOAN:       6,000 VND   |
|                                  |                               |
| [Xoa khoi gio] [Xoa het]         | [      THANH TOAN      ]      |
+------------------------------------------------------------------+
```

#### Cau truc gio hang (DataTable)
```csharp
private DataTable dtGioHang;

private void KhoiTaoGioHang()
{
    dtGioHang = new DataTable();
    dtGioHang.Columns.Add("MaSanPham", typeof(int));      // Khoa chinh
    dtGioHang.Columns.Add("MaSoSanPham", typeof(string)); // Ma hien thi
    dtGioHang.Columns.Add("TenSanPham", typeof(string));  // Ten san pham
    dtGioHang.Columns.Add("DonGia", typeof(decimal));     // Gia ban
    dtGioHang.Columns.Add("SoLuong", typeof(int));        // So luong mua
    dtGioHang.Columns.Add("ThanhTien", typeof(decimal));  // = DonGia * SoLuong
    
    dgvGioHang.DataSource = dtGioHang;
}
```

#### Them san pham vao gio
```csharp
private void ThemVaoGioHang()
{
    if (dgvSanPham.CurrentRow == null) return;
    
    // Lay thong tin san pham duoc chon
    int maSP = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
    string tenSP = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
    decimal giaBan = Convert.ToDecimal(dgvSanPham.CurrentRow.Cells["GiaBan"].Value);
    int tonKho = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["SoLuongTon"].Value);
    
    // Kiem tra da co trong gio chua
    foreach (DataRow row in dtGioHang.Rows)
    {
        if (Convert.ToInt32(row["MaSanPham"]) == maSP)
        {
            // Da co -> tang so luong
            int slHienTai = Convert.ToInt32(row["SoLuong"]);
            if (slHienTai + 1 > tonKho)
            {
                MessageBox.Show("So luong trong kho khong du!");
                return;
            }
            row["SoLuong"] = slHienTai + 1;
            row["ThanhTien"] = Convert.ToDecimal(row["DonGia"]) * (slHienTai + 1);
            TinhTongTien();
            return;
        }
    }
    
    // Chua co -> them moi
    DataRow newRow = dtGioHang.NewRow();
    newRow["MaSanPham"] = maSP;
    newRow["TenSanPham"] = tenSP;
    newRow["DonGia"] = giaBan;
    newRow["SoLuong"] = 1;
    newRow["ThanhTien"] = giaBan;
    dtGioHang.Rows.Add(newRow);
    
    TinhTongTien();
}
```

#### Tinh tong tien
```csharp
private void TinhTongTien()
{
    decimal tongTien = 0;
    
    // Cong tong cac dong trong gio hang
    foreach (DataRow row in dtGioHang.Rows)
    {
        tongTien += Convert.ToDecimal(row["ThanhTien"]);
    }
    
    decimal giamGia = numGiamGia.Value;  // Lay tu NumericUpDown
    decimal thanhToan = tongTien - giamGia;
    if (thanhToan < 0) thanhToan = 0;    // Khong am
    
    lblTongTien.Text = tongTien.ToString("N0") + " VND";    // 6,000 VND
    lblThanhToan.Text = thanhToan.ToString("N0") + " VND";  // 6,000 VND
}
```

#### Thanh toan - Tao hoa don
```csharp
private void btnThanhToan_Click(object sender, EventArgs e)
{
    if (dtGioHang.Rows.Count == 0)
    {
        MessageBox.Show("Gio hang trong!");
        return;
    }
    
    // BUOC 1: Tao hoa don
    string maHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");  // HD20260130143025
    
    string sqlHoaDon = @"INSERT INTO HoaDon 
                        (SoHoaDon, NgayBan, MaKhachHang, TongTien, GiamGia, ThanhTien, MaNhanVien)
                        VALUES (@MaHD, GETDATE(), @MaKH, @TongTien, @GiamGia, @ThanhTien, @MaNV);
                        SELECT SCOPE_IDENTITY();";  // Tra ve ID vua tao
    
    SqlParameter[] paramsHD = {
        new SqlParameter("@MaHD", maHD),
        new SqlParameter("@MaKH", selectedKhachHangId > 0 ? (object)selectedKhachHangId : DBNull.Value),
        new SqlParameter("@TongTien", tongTien),
        new SqlParameter("@GiamGia", giamGia),
        new SqlParameter("@ThanhTien", thanhToan),
        new SqlParameter("@MaNV", frmLogin.MaNguoiDung)
    };
    
    object result = Functions.GetFieldValues(sqlHoaDon, paramsHD);
    int maHoaDon = Convert.ToInt32(result);  // ID hoa don vua tao
    
    // BUOC 2: Them chi tiet hoa don + Cap nhat ton kho
    foreach (DataRow row in dtGioHang.Rows)
    {
        int maSP = Convert.ToInt32(row["MaSanPham"]);
        int soLuong = Convert.ToInt32(row["SoLuong"]);
        decimal donGia = Convert.ToDecimal(row["DonGia"]);
        decimal thanhTienItem = Convert.ToDecimal(row["ThanhTien"]);
        
        // Them chi tiet
        string sqlCT = @"INSERT INTO ChiTietHoaDon 
                        (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien)
                        VALUES (@MaHD, @MaSP, @SL, @DonGia, @ThanhTien)";
        SqlParameter[] paramsCT = {
            new SqlParameter("@MaHD", maHoaDon),
            new SqlParameter("@MaSP", maSP),
            new SqlParameter("@SL", soLuong),
            new SqlParameter("@DonGia", donGia),
            new SqlParameter("@ThanhTien", thanhTienItem)
        };
        Functions.RunSQL(sqlCT, paramsCT);
        
        // Cap nhat ton kho (tru di so luong da ban)
        string sqlCapNhat = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSanPham = @MaSP";
        SqlParameter[] paramsCapNhat = {
            new SqlParameter("@SL", soLuong),
            new SqlParameter("@MaSP", maSP)
        };
        Functions.RunSQL(sqlCapNhat, paramsCapNhat);
    }
    
    MessageBox.Show("Thanh toan thanh cong! Ma hoa don: " + maHD);
    ResetForm();  // Xoa gio hang
}
```

#### Giai thich SQL quan trong

**1. Tao hoa don va lay ID**
```sql
INSERT INTO HoaDon (SoHoaDon, NgayBan, MaKhachHang, TongTien, GiamGia, ThanhTien, MaNhanVien)
VALUES (@MaHD, GETDATE(), @MaKH, @TongTien, @GiamGia, @ThanhTien, @MaNV);
SELECT SCOPE_IDENTITY();
```
- `GETDATE()`: Lay ngay gio hien tai cua SQL Server
- `SCOPE_IDENTITY()`: Lay ID tu dong tang vua duoc tao (MaHoaDon)

**2. Cap nhat ton kho**
```sql
UPDATE SanPham 
SET SoLuongTon = SoLuongTon - @SL 
WHERE MaSanPham = @MaSP
```
- Tru truc tiep tren database, dam bao chinh xac

---

### 5.3. frmDashboard - Trang tong quan

#### Cac chi so hien thi
| Chi so | SQL | Giai thich |
|--------|-----|------------|
| Tong san pham | `SELECT COUNT(*) FROM SanPham` | Dem so dong |
| Tong khach hang | `SELECT COUNT(*) FROM KhachHang` | Dem so dong |
| Hoa don hom nay | `SELECT COUNT(*) FROM HoaDon WHERE CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)` | Chi ngay hom nay |
| Doanh thu hom nay | `SELECT ISNULL(SUM(ThanhTien), 0) FROM HoaDon WHERE CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)` | Tong tien hom nay |
| San pham sap het | `SELECT COUNT(*) FROM SanPham WHERE SoLuongTon < 10` | Ton < 10 |

#### Giai thich SQL
```sql
-- Doanh thu thang nay
SELECT ISNULL(SUM(ThanhTien), 0) 
FROM HoaDon 
WHERE MONTH(NgayBan) = MONTH(GETDATE())    -- Thang hien tai
  AND YEAR(NgayBan) = YEAR(GETDATE())      -- Nam hien tai
```
- `MONTH()`: Lay thang tu ngay
- `YEAR()`: Lay nam tu ngay
- `ISNULL(x, 0)`: Neu x la NULL thi tra ve 0

```sql
-- Top 10 san pham ban chay
SELECT TOP 10 
    sp.TenSanPham AS 'San pham', 
    SUM(ct.SoLuong) AS 'SL ban',
    SUM(ct.ThanhTien) AS 'Doanh thu'
FROM ChiTietHoaDon ct
INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
GROUP BY sp.TenSanPham
ORDER BY SUM(ct.SoLuong) DESC
```
- `TOP 10`: Lay 10 dong dau tien
- `SUM()`: Tinh tong
- `GROUP BY`: Nhom theo ten san pham
- `ORDER BY ... DESC`: Sap xep giam dan

---

### 5.4. frmQuanLySanPham - Quan ly san pham

#### Cac thao tac CRUD

**1. Load du lieu (READ)**
```csharp
private void LoadData()
{
    string sql = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, 
                  dm.TenDanhMuc, ncc.TenNCC, sp.GiaBan, sp.GiaNhap, 
                  sp.SoLuongTon, sp.TrangThai
                  FROM SanPham sp
                  LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                  LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
                  ORDER BY sp.TenSanPham";
    
    DataTable dt = Functions.GetDataToTable(sql);
    dgvSanPham.DataSource = dt;
}
```
**Giai thich**: `LEFT JOIN` de lay ca san pham chua co danh muc/NCC.

**2. Them san pham (CREATE)**
```csharp
private void btnThem_Click(object sender, EventArgs e)
{
    // Kiem tra ma trung
    string checkSql = "SELECT COUNT(*) FROM SanPham WHERE MaSoSanPham = @MaSP";
    SqlParameter[] checkParams = { new SqlParameter("@MaSP", txtMaSP.Text.Trim()) };
    object result = Functions.GetFieldValues(checkSql, checkParams);
    
    if (result != null && Convert.ToInt32(result) > 0)
    {
        MessageBox.Show("Ma san pham da ton tai!");
        return;
    }
    
    // Them moi
    string sql = @"INSERT INTO SanPham 
                  (MaSoSanPham, TenSanPham, MaDanhMuc, MaNCC, GiaBan, GiaNhap, SoLuongTon, TrangThai)
                  VALUES (@MaSP, @TenSP, @MaDM, @MaNCC, @GiaBan, @GiaNhap, @SoLuong, @TrangThai)";
    
    SqlParameter[] parameters = {
        new SqlParameter("@MaSP", txtMaSP.Text.Trim()),
        new SqlParameter("@TenSP", txtTenSP.Text.Trim()),
        // Xu ly truong hop chua chon danh muc
        new SqlParameter("@MaDM", cboDanhMuc.SelectedValue.ToString() == "0" 
                                  ? DBNull.Value 
                                  : (object)cboDanhMuc.SelectedValue),
        new SqlParameter("@MaNCC", cboNhaCungCap.SelectedValue.ToString() == "0" 
                                   ? DBNull.Value 
                                   : (object)cboNhaCungCap.SelectedValue),
        new SqlParameter("@GiaBan", decimal.Parse(txtGiaBan.Text)),
        new SqlParameter("@GiaNhap", decimal.Parse(txtGiaNhap.Text)),
        new SqlParameter("@SoLuong", int.Parse(txtSoLuong.Text)),
        new SqlParameter("@TrangThai", chkTrangThai.Checked ? 1 : 0)
    };
    
    if (Functions.RunSQL(sql, parameters))
    {
        MessageBox.Show("Them san pham thanh cong!");
        LoadData();
        ResetForm();
    }
}
```

**3. Sua san pham (UPDATE)**
```csharp
string sql = @"UPDATE SanPham 
              SET TenSanPham = @TenSP, 
                  MaDanhMuc = @MaDM, 
                  MaNCC = @MaNCC,
                  GiaBan = @GiaBan, 
                  GiaNhap = @GiaNhap, 
                  SoLuongTon = @SoLuong, 
                  TrangThai = @TrangThai
              WHERE MaSanPham = @MaSanPham";
```

**4. Xoa san pham (DELETE)**
```csharp
string sql = "DELETE FROM SanPham WHERE MaSanPham = @MaSanPham";
```
**Luu y**: Can kiem tra rang buoc khoa ngoai truoc khi xoa.

**5. Tim kiem**
```csharp
private void txtTimKiem_TextChanged(object sender, EventArgs e)
{
    string keyword = txtTimKiem.Text.Trim();
    
    string sql = @"SELECT ... FROM SanPham sp
                  WHERE sp.MaSoSanPham LIKE @Keyword 
                     OR sp.TenSanPham LIKE @Keyword";
    
    SqlParameter[] parameters = { 
        new SqlParameter("@Keyword", "%" + keyword + "%")  // Tim chua tu khoa
    };
    
    DataTable dt = Functions.GetDataTable(sql, parameters);
    dgvSanPham.DataSource = dt;
}
```
**Giai thich**: `LIKE '%abc%'` tim tat ca chuoi chua "abc".

---

### 5.5. frmThongKeDoanhThu - Bao cao doanh thu

#### SQL thong ke
```sql
SELECT hd.MaHoaDon, hd.NgayBan, kh.HoTen AS TenKH, 
       hd.TongTien, hd.GiamGia, hd.ThanhTien
FROM HoaDon hd
LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
WHERE hd.NgayBan >= @TuNgay 
  AND hd.NgayBan <= @DenNgay
ORDER BY hd.NgayBan DESC
```

#### Xu ly ngay
```csharp
// Ngay ket thuc phai den 23:59:59
cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));
```
**Giai thich**: 
- `dtpTuNgay.Value.Date`: Lay ngay, gio la 00:00:00
- `.AddDays(1).AddSeconds(-1)`: Them 1 ngay roi tru 1 giay = 23:59:59

---

### 5.6. frmNhapHang - Nhap hang

#### Logic nhap hang
```csharp
private void btnNhapHang_Click(object sender, EventArgs e)
{
    foreach (DataGridViewRow row in dgvChiTiet.Rows)
    {
        int maSP = Convert.ToInt32(row.Cells["MaSanPham"].Value);
        int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
        decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

        // Cap nhat ton kho va gia nhap
        string updateQuery = @"UPDATE SanPham 
                              SET SoLuongTon = SoLuongTon + @SoLuong,
                                  GiaNhap = @GiaNhap
                              WHERE MaSanPham = @MaSanPham";
        
        SqlParameter[] parameters = {
            new SqlParameter("@SoLuong", soLuong),
            new SqlParameter("@GiaNhap", donGia),
            new SqlParameter("@MaSanPham", maSP)
        };

        Functions.RunSQL(updateQuery, parameters);
    }
    
    MessageBox.Show("Nhap hang thanh cong!");
}
```
**Giai thich**: `SoLuongTon = SoLuongTon + @SoLuong` - Cong them vao ton kho hien tai.

---

## 6. CAC HAM KHO CAN CHU Y

### 6.1. Xu ly null trong SQL
```csharp
// Truong hop khach le (khong chon khach hang)
new SqlParameter("@MaKH", selectedKhachHangId > 0 
                          ? (object)selectedKhachHangId 
                          : DBNull.Value)
```
**Giai thich**: Neu khong chon khach hang, truyen `DBNull.Value` de luu NULL vao database.

### 6.2. ComboBox voi gia tri tuy chinh
```csharp
// Tao class de luu ca ID va Ten
public class ComboBoxItem
{
    public int Value { get; set; }
    public string Text { get; set; }
    
    public ComboBoxItem(int value, string text)
    {
        Value = value;
        Text = text;
    }
    
    public override string ToString()
    {
        return Text;  // Hien thi Text trong ComboBox
    }
}

// Su dung
cboKhachHang.Items.Add(new ComboBoxItem(1, "Nguyen Van A - 0909123456"));

// Lay gia tri
int maKH = ((ComboBoxItem)cboKhachHang.SelectedItem).Value;
```

### 6.3. DataRowView - Lay du lieu tu DataGridView
```csharp
private void ChonSanPham()
{
    if (dgvSanPham.CurrentRow == null) return;
    
    // Cach 1: Truy cap truc tiep cell
    string tenSP = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
    
    // Cach 2: Su dung DataRowView (tot hon)
    DataRowView row = dgvSanPham.CurrentRow.DataBoundItem as DataRowView;
    if (row != null)
    {
        string maSP = row["MaSanPham"].ToString();
        decimal giaBan = Convert.ToDecimal(row["GiaBan"]);
    }
}
```

### 6.4. Format so tien
```csharp
decimal soTien = 1234567.89m;

// Dinh dang 1,234,567 (khong co so le)
string formatted = soTien.ToString("N0");

// Dinh dang 1,234,567.89 (2 so le)
string formatted2 = soTien.ToString("N2");

// Ap dung cho DataGridView
dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
```

### 6.5. Doc so thanh chu (ChuyenSoSangChuoi)
```csharp
// 1,234,000 -> "Mot trieu hai tram ba muoi tu nghin dong"
string chuoiSo = Functions.ChuyenSoSangChuoi(1234000);
```

---

## 7. CAC LOI THUONG GAP

### 7.1. Loi ket noi database
**Nguyen nhan**: Connection string sai, SQL Server chua chay
**Cach sua**: Kiem tra Settings, kiem tra SQL Server Service

### 7.2. Loi SQL Injection
**Nguyen nhan**: Noi chuoi truc tiep trong SQL
```csharp
// SAI - de bi tan cong
string sql = "SELECT * FROM NguoiDung WHERE TenDangNhap = '" + txtUser.Text + "'";

// DUNG - su dung parameter
string sql = "SELECT * FROM NguoiDung WHERE TenDangNhap = @User";
SqlParameter[] parameters = { new SqlParameter("@User", txtUser.Text) };
```

### 7.3. Loi Convert kieu du lieu
**Nguyen nhan**: Gia tri null hoac kieu khong phu hop
```csharp
// SAI - co the null
decimal giaBan = Convert.ToDecimal(row["GiaBan"]);

// DUNG - kiem tra null
decimal giaBan = row["GiaBan"] != DBNull.Value 
                 ? Convert.ToDecimal(row["GiaBan"]) 
                 : 0;
```

### 7.4. Loi khoa ngoai khi xoa
**Nguyen nhan**: San pham da co trong hoa don
**Cach sua**: Kiem tra truoc khi xoa hoac dat TrangThai = 0 thay vi xoa

---

## 8. HUONG DAN CHAY DU AN

### Buoc 1: Tao database
```
1. Mo SQL Server Management Studio
2. Chay file CreateDatabase.sql
3. Kiem tra database QLCHLinhKienDienTu da duoc tao
```

### Buoc 2: Cau hinh connection string
```
1. Mo file App.config
2. Sua connectionString cho phu hop:
   - Server: Ten may\Instance (VD: DESKTOP-ABC\SQLEXPRESS)
   - Database: QLCHLinhKienDienTu
```

### Buoc 3: Chay ung dung
```
1. Mo Visual Studio
2. Nhan F5 hoac Ctrl+F5
3. Dang nhap: admin / admin
```

---

## 9. TON TAT

### Ky thuat su dung
- ADO.NET (SqlConnection, SqlCommand, SqlDataAdapter)
- Windows Forms (DataGridView, ComboBox, DateTimePicker)
- Parameterized Queries (chong SQL Injection)
- MDI Container (form chinh chua cac form con)

### Nguyen tac thiet ke
- Tach biet UI va Logic (Functions class)
- Su dung try-catch xu ly loi
- Validation input truoc khi xu ly
- Dung parameterized queries

### Cai tien tuong lai
- Ma hoa mat khau (hash)
- Phan quyen chi tiet hon
- Them bao cao RDLC
- Xuat PDF hoa don
- Backup/Restore database

---

**Tac gia**: Team DEV  
**Phien ban**: 1.0  
**Ngay tao**: 30/01/2026
