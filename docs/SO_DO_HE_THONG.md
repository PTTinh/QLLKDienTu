# SƠ ĐỒ HỆ THỐNG QUẢN LÝ CỬA HÀNG LINH KIỆN ĐIỆN TỬ

## 1. SƠ ĐỒ ERD (Entity Relationship Diagram)

```mermaid
erDiagram
    DanhMuc {
        INT MaDanhMuc PK
        NVARCHAR TenDanhMuc
        NVARCHAR MoTa
        DATETIME NgayTao
    }
    
    NhaCungCap {
        INT MaNCC PK
        NVARCHAR TenNCC
        VARCHAR SoDienThoai
        VARCHAR Email
        NVARCHAR DiaChi
        VARCHAR MaSoThue
    }
    
    SanPham {
        INT MaSanPham PK
        VARCHAR MaSoSanPham UK
        NVARCHAR TenSanPham
        INT MaDanhMuc FK
        INT MaNCC FK
        DECIMAL GiaBan
        DECIMAL GiaNhap
        INT SoLuongTon
        INT TonToiThieu
        INT TonToiDa
        NVARCHAR MoTa
        VARCHAR DuongDanAnh
        DATETIME NgayTao
        BIT TrangThai
    }
    
    KhachHang {
        INT MaKhachHang PK
        VARCHAR MaSoKhachHang UK
        NVARCHAR HoTen
        VARCHAR SoDienThoai
        VARCHAR Email
        NVARCHAR DiaChi
        VARCHAR LoaiKhachHang
        DECIMAL TongChiTieu
        DATETIME NgayTao
    }
    
    HoaDon {
        INT MaHoaDon PK
        VARCHAR SoHoaDon UK
        INT MaKhachHang FK
        INT MaNhanVien FK
        DATETIME NgayBan
        DECIMAL TongTien
        DECIMAL GiamGia
        DECIMAL ThueVAT
        DECIMAL ThanhTien
        VARCHAR PhuongThucThanhToan
        VARCHAR TrangThai
    }
    
    ChiTietHoaDon {
        INT MaChiTiet PK
        INT MaHoaDon FK
        INT MaSanPham FK
        INT SoLuong
        DECIMAL DonGia
        DECIMAL GiamGia
        DECIMAL ThanhTien
    }
    
    NguoiDung {
        INT MaNguoiDung PK
        VARCHAR TenDangNhap UK
        VARCHAR MatKhau
        NVARCHAR HoTen
        VARCHAR Email
        VARCHAR SoDienThoai
        VARCHAR VaiTro
        DATETIME NgayTao
        BIT TrangThai
    }
    
    DanhMuc ||--o{ SanPham : "chứa"
    NhaCungCap ||--o{ SanPham : "cung cấp"
    KhachHang ||--o{ HoaDon : "mua hàng"
    NguoiDung ||--o{ HoaDon : "tạo"
    HoaDon ||--|{ ChiTietHoaDon : "có"
    SanPham ||--o{ ChiTietHoaDon : "được bán"
```

---

## 2. SƠ ĐỒ USE CASE

### 2.1 Use Case Tổng Quan Hệ Thống

```mermaid
flowchart TB
    subgraph Actors
        Admin[("👤 Quản trị viên")]
        Manager[("👤 Quản lý")]
        Staff[("👤 Nhân viên")]
        Customer[("👤 Khách hàng")]
    end
    
    subgraph "Hệ thống QL Cửa hàng Linh kiện"
        UC1[Đăng nhập/Đăng xuất]
        UC2[Quản lý người dùng]
        UC3[Quản lý sản phẩm]
        UC4[Quản lý danh mục]
        UC5[Quản lý nhà cung cấp]
        UC6[Quản lý khách hàng]
        UC7[Bán hàng POS]
        UC8[Quản lý hóa đơn]
        UC9[Nhập hàng]
        UC10[Báo cáo thống kê]
        UC11[Cảnh báo hàng tồn]
        UC12[Đổi mật khẩu]
    end
    
    Admin --> UC1
    Admin --> UC2
    Admin --> UC3
    Admin --> UC4
    Admin --> UC5
    Admin --> UC6
    Admin --> UC7
    Admin --> UC8
    Admin --> UC9
    Admin --> UC10
    Admin --> UC11
    Admin --> UC12
    
    Manager --> UC1
    Manager --> UC3
    Manager --> UC4
    Manager --> UC5
    Manager --> UC6
    Manager --> UC7
    Manager --> UC8
    Manager --> UC9
    Manager --> UC10
    Manager --> UC11
    Manager --> UC12
    
    Staff --> UC1
    Staff --> UC6
    Staff --> UC7
    Staff --> UC8
    Staff --> UC12
    
    Customer -.-> UC7
```

### 2.2 Use Case Chi Tiết - Quản Lý Sản Phẩm

```mermaid
flowchart LR
    subgraph Actors
        Admin[("👤 Quản trị")]
        Manager[("👤 Quản lý")]
    end
    
    subgraph "UC: Quản lý Sản phẩm"
        UC1[Xem danh sách sản phẩm]
        UC2[Thêm sản phẩm mới]
        UC3[Sửa thông tin sản phẩm]
        UC4[Xóa sản phẩm]
        UC5[Tìm kiếm sản phẩm]
        UC6[Lọc theo danh mục]
        UC7[Cập nhật số lượng tồn]
        UC8[Cập nhật giá bán]
    end
    
    Admin --> UC1
    Admin --> UC2
    Admin --> UC3
    Admin --> UC4
    Admin --> UC5
    Admin --> UC6
    Admin --> UC7
    Admin --> UC8
    
    Manager --> UC1
    Manager --> UC2
    Manager --> UC3
    Manager --> UC5
    Manager --> UC6
    Manager --> UC7
    Manager --> UC8
```

### 2.3 Use Case Chi Tiết - Bán Hàng (POS)

```mermaid
flowchart LR
    subgraph Actors
        Staff[("👤 Nhân viên")]
        Customer[("👤 Khách hàng")]
    end
    
    subgraph "UC: Bán hàng POS"
        UC1[Tìm kiếm sản phẩm]
        UC2[Thêm sản phẩm vào giỏ]
        UC3[Xóa sản phẩm khỏi giỏ]
        UC4[Cập nhật số lượng]
        UC5[Áp dụng giảm giá]
        UC6[Chọn khách hàng]
        UC7[Thêm khách hàng mới]
        UC8[Chọn phương thức thanh toán]
        UC9[Thanh toán]
        UC10[In hóa đơn]
        UC11[Hủy đơn hàng]
    end
    
    Staff --> UC1
    Staff --> UC2
    Staff --> UC3
    Staff --> UC4
    Staff --> UC5
    Staff --> UC6
    Staff --> UC7
    Staff --> UC8
    Staff --> UC9
    Staff --> UC10
    Staff --> UC11
    
    Customer -.-> UC6
```

### 2.4 Use Case Chi Tiết - Báo Cáo Thống Kê

```mermaid
flowchart LR
    subgraph Actors
        Admin[("👤 Quản trị")]
        Manager[("👤 Quản lý")]
    end
    
    subgraph "UC: Báo cáo Thống kê"
        UC1[Thống kê doanh thu theo ngày]
        UC2[Thống kê doanh thu theo tháng]
        UC3[Thống kê doanh thu theo năm]
        UC4[Thống kê sản phẩm bán chạy]
        UC5[Thống kê khách hàng VIP]
        UC6[Thống kê nhân viên]
        UC7[Xuất báo cáo Excel]
        UC8[In báo cáo]
        UC9[Xem Dashboard]
    end
    
    Admin --> UC1
    Admin --> UC2
    Admin --> UC3
    Admin --> UC4
    Admin --> UC5
    Admin --> UC6
    Admin --> UC7
    Admin --> UC8
    Admin --> UC9
    
    Manager --> UC1
    Manager --> UC2
    Manager --> UC3
    Manager --> UC4
    Manager --> UC5
    Manager --> UC7
    Manager --> UC8
    Manager --> UC9
```

---

## 3. SƠ ĐỒ DFD (Data Flow Diagram)

### 3.1 DFD Level 0 - Context Diagram

```mermaid
flowchart TB
    Customer((Khách hàng))
    Staff((Nhân viên))
    Manager((Quản lý))
    Supplier((Nhà cung cấp))
    
    System[["0. Hệ thống Quản lý<br/>Cửa hàng Linh kiện"]]
    
    Customer -->|Thông tin đặt hàng| System
    System -->|Hóa đơn, Sản phẩm| Customer
    
    Staff -->|Thông tin bán hàng| System
    System -->|Báo cáo, Danh sách SP| Staff
    
    Manager -->|Yêu cầu báo cáo| System
    System -->|Báo cáo thống kê| Manager
    
    Supplier -->|Thông tin sản phẩm| System
    System -->|Đơn đặt hàng| Supplier
```

### 3.2 DFD Level 1

```mermaid
flowchart TB
    %% External Entities
    KH((Khách hàng))
    NV((Nhân viên))
    QL((Quản lý))
    NCC((Nhà cung cấp))
    
    %% Processes
    P1[["1.0<br/>Quản lý<br/>Người dùng"]]
    P2[["2.0<br/>Quản lý<br/>Sản phẩm"]]
    P3[["3.0<br/>Quản lý<br/>Khách hàng"]]
    P4[["4.0<br/>Bán hàng<br/>POS"]]
    P5[["5.0<br/>Nhập hàng"]]
    P6[["6.0<br/>Báo cáo<br/>Thống kê"]]
    
    %% Data Stores
    D1[(D1: NguoiDung)]
    D2[(D2: SanPham)]
    D3[(D3: DanhMuc)]
    D4[(D4: KhachHang)]
    D5[(D5: HoaDon)]
    D6[(D6: ChiTietHoaDon)]
    D7[(D7: NhaCungCap)]
    
    %% Flows
    NV -->|Đăng nhập| P1
    P1 -->|Xác thực| D1
    D1 -->|Thông tin user| P1
    
    QL -->|CRUD Sản phẩm| P2
    P2 <-->|Thông tin SP| D2
    P2 <-->|Danh mục| D3
    
    NV -->|CRUD Khách hàng| P3
    P3 <-->|Thông tin KH| D4
    
    NV -->|Tạo đơn hàng| P4
    KH -.->|Mua hàng| P4
    P4 -->|Lưu hóa đơn| D5
    P4 -->|Lưu chi tiết| D6
    P4 -->|Cập nhật tồn| D2
    P4 -->|Hóa đơn| KH
    
    NCC -->|Thông tin nhập| P5
    P5 <-->|Cập nhật NCC| D7
    P5 -->|Cập nhật tồn kho| D2
    
    QL -->|Yêu cầu báo cáo| P6
    P6 -->|Đọc dữ liệu| D5
    P6 -->|Đọc chi tiết| D6
    P6 -->|Đọc SP| D2
    P6 -->|Báo cáo| QL
```

### 3.3 DFD Level 2 - Quy trình Bán hàng POS

```mermaid
flowchart TB
    %% External Entities
    NV((Nhân viên))
    KH((Khách hàng))
    
    %% Processes
    P4_1[["4.1<br/>Tìm kiếm<br/>Sản phẩm"]]
    P4_2[["4.2<br/>Quản lý<br/>Giỏ hàng"]]
    P4_3[["4.3<br/>Chọn<br/>Khách hàng"]]
    P4_4[["4.4<br/>Tính toán<br/>Hóa đơn"]]
    P4_5[["4.5<br/>Thanh toán"]]
    P4_6[["4.6<br/>In<br/>Hóa đơn"]]
    
    %% Data Stores
    D2[(D2: SanPham)]
    D4[(D4: KhachHang)]
    D5[(D5: HoaDon)]
    D6[(D6: ChiTietHoaDon)]
    
    %% Flows
    NV -->|Từ khóa| P4_1
    P4_1 -->|Tìm kiếm| D2
    D2 -->|DS Sản phẩm| P4_1
    P4_1 -->|SP được chọn| P4_2
    
    NV -->|Thao tác giỏ| P4_2
    P4_2 -->|Giỏ hàng| P4_4
    
    NV -->|Chọn KH| P4_3
    P4_3 <-->|Thông tin KH| D4
    P4_3 -->|KH được chọn| P4_4
    
    P4_4 -->|Tính tổng, VAT, giảm giá| P4_5
    
    NV -->|Xác nhận thanh toán| P4_5
    P4_5 -->|Lưu hóa đơn| D5
    P4_5 -->|Lưu chi tiết| D6
    P4_5 -->|Cập nhật tồn| D2
    P4_5 -->|Cập nhật chi tiêu| D4
    
    P4_5 -->|Thông tin HD| P4_6
    P4_6 -->|Hóa đơn in| KH
```

---

## 4. SƠ ĐỒ BFD (Business Flow Diagram)

### 4.1 Quy trình Bán hàng

```mermaid
flowchart TD
    Start([Bắt đầu])
    
    A[Khách hàng vào cửa hàng]
    B[Nhân viên tiếp đón]
    C{Khách hàng<br/>đã có tài khoản?}
    D[Tạo tài khoản khách hàng mới]
    E[Chọn khách hàng có sẵn]
    F[Tìm kiếm sản phẩm]
    G{Sản phẩm<br/>còn hàng?}
    H[Thông báo hết hàng]
    I[Thêm vào giỏ hàng]
    J{Tiếp tục<br/>mua hàng?}
    K[Tính tổng tiền]
    L[Áp dụng giảm giá nếu có]
    M[Tính thuế VAT]
    N{Chọn phương thức<br/>thanh toán}
    O[Thanh toán tiền mặt]
    P[Thanh toán chuyển khoản]
    Q[Thanh toán thẻ]
    R[Xác nhận thanh toán]
    S[Cập nhật số lượng tồn kho]
    T[Cập nhật tổng chi tiêu KH]
    U[In hóa đơn]
    V[Giao hàng cho khách]
    
    End([Kết thúc])
    
    Start --> A --> B --> C
    C -->|Không| D --> F
    C -->|Có| E --> F
    F --> G
    G -->|Không| H --> F
    G -->|Có| I --> J
    J -->|Có| F
    J -->|Không| K --> L --> M --> N
    N -->|Tiền mặt| O --> R
    N -->|Chuyển khoản| P --> R
    N -->|Thẻ| Q --> R
    R --> S --> T --> U --> V --> End
```

### 4.2 Quy trình Nhập hàng

```mermaid
flowchart TD
    Start([Bắt đầu])
    
    A[Kiểm tra hàng tồn kho]
    B{Hàng cần<br/>nhập thêm?}
    C[Chọn nhà cung cấp]
    D{NCC mới?}
    E[Tạo NCC mới]
    F[Chọn NCC có sẵn]
    G[Tạo phiếu nhập hàng]
    H[Chọn sản phẩm cần nhập]
    I[Nhập số lượng & giá nhập]
    J{Thêm SP<br/>khác?}
    K[Xác nhận phiếu nhập]
    L[Cập nhật số lượng tồn]
    M[Cập nhật giá nhập nếu thay đổi]
    N[Lưu lịch sử nhập hàng]
    
    End([Kết thúc])
    
    Start --> A --> B
    B -->|Không| End
    B -->|Có| C --> D
    D -->|Có| E --> G
    D -->|Không| F --> G
    G --> H --> I --> J
    J -->|Có| H
    J -->|Không| K --> L --> M --> N --> End
```

### 4.3 Quy trình Quản lý Sản phẩm

```mermaid
flowchart TD
    Start([Bắt đầu])
    
    A{Chọn thao tác}
    
    %% Thêm sản phẩm
    B1[Nhập mã sản phẩm]
    B2[Nhập tên sản phẩm]
    B3[Chọn danh mục]
    B4[Chọn nhà cung cấp]
    B5[Nhập giá nhập/giá bán]
    B6[Nhập mô tả, ảnh]
    B7[Lưu sản phẩm]
    
    %% Sửa sản phẩm
    C1[Tìm sản phẩm cần sửa]
    C2[Hiển thị thông tin]
    C3[Sửa thông tin]
    C4[Lưu thay đổi]
    
    %% Xóa sản phẩm
    D1[Tìm sản phẩm cần xóa]
    D2{Xác nhận xóa?}
    D3[Xóa sản phẩm]
    
    %% Tìm kiếm
    E1[Nhập từ khóa/lọc]
    E2[Hiển thị kết quả]
    
    End([Kết thúc])
    
    Start --> A
    A -->|Thêm mới| B1 --> B2 --> B3 --> B4 --> B5 --> B6 --> B7 --> End
    A -->|Sửa| C1 --> C2 --> C3 --> C4 --> End
    A -->|Xóa| D1 --> D2
    D2 -->|Có| D3 --> End
    D2 -->|Không| End
    A -->|Tìm kiếm| E1 --> E2 --> End
```

### 4.4 Quy trình Đăng nhập Hệ thống

```mermaid
flowchart TD
    Start([Bắt đầu])
    
    A[Hiển thị form đăng nhập]
    B[Nhập tên đăng nhập]
    C[Nhập mật khẩu]
    D[Bấm đăng nhập]
    E{Kiểm tra<br/>thông tin}
    F{Tài khoản<br/>bị khóa?}
    G[Thông báo tài khoản bị khóa]
    H{Vai trò<br/>người dùng?}
    I[Hiển thị menu Quản trị viên]
    J[Hiển thị menu Quản lý]
    K[Hiển thị menu Nhân viên]
    L[Ghi log đăng nhập]
    M[Thông báo sai thông tin]
    N{Quá 3 lần<br/>sai?}
    O[Khóa tài khoản tạm thời]
    
    End([Kết thúc])
    
    Start --> A --> B --> C --> D --> E
    E -->|Sai| M --> N
    N -->|Có| O --> End
    N -->|Không| A
    E -->|Đúng| F
    F -->|Có| G --> End
    F -->|Không| H
    H -->|Quản trị| I --> L --> End
    H -->|Quản lý| J --> L --> End
    H -->|Nhân viên| K --> L --> End
```

---

## 5. SƠ ĐỒ SEQUENCE

### 5.1 Sequence Diagram - Quy trình Bán hàng

```mermaid
sequenceDiagram
    actor NV as Nhân viên
    actor KH as Khách hàng
    participant POS as Form POS
    participant SP as SanPham DB
    participant HD as HoaDon DB
    participant CT as ChiTietHoaDon DB
    participant KH_DB as KhachHang DB
    
    NV->>POS: Mở form bán hàng
    POS->>SP: Lấy danh sách sản phẩm
    SP-->>POS: Trả về DS sản phẩm
    
    KH->>NV: Chọn sản phẩm
    NV->>POS: Tìm kiếm sản phẩm
    POS->>SP: Query sản phẩm
    SP-->>POS: Thông tin sản phẩm
    
    NV->>POS: Thêm vào giỏ hàng
    POS->>POS: Cập nhật giỏ hàng
    
    loop Thêm sản phẩm
        NV->>POS: Thêm SP tiếp theo
        POS->>POS: Cập nhật giỏ hàng
    end
    
    NV->>POS: Chọn khách hàng
    POS->>KH_DB: Query khách hàng
    KH_DB-->>POS: Thông tin KH
    
    NV->>POS: Thanh toán
    POS->>POS: Tính tổng tiền, VAT
    POS->>HD: Tạo hóa đơn mới
    HD-->>POS: Mã hóa đơn
    
    POS->>CT: Lưu chi tiết hóa đơn
    POS->>SP: Cập nhật số lượng tồn
    POS->>KH_DB: Cập nhật tổng chi tiêu
    
    POS-->>NV: Hiển thị hóa đơn
    NV->>POS: In hóa đơn
    POS-->>KH: Giao hóa đơn
```

### 5.2 Sequence Diagram - Đăng nhập

```mermaid
sequenceDiagram
    actor User as Người dùng
    participant Login as Form Login
    participant Auth as Xác thực
    participant DB as NguoiDung DB
    participant Main as Form Main
    
    User->>Login: Mở ứng dụng
    Login->>Login: Hiển thị form đăng nhập
    
    User->>Login: Nhập username/password
    User->>Login: Bấm đăng nhập
    
    Login->>Auth: Gửi thông tin đăng nhập
    Auth->>DB: Kiểm tra tài khoản
    
    alt Tài khoản hợp lệ
        DB-->>Auth: Trả về thông tin user
        Auth->>Auth: Kiểm tra trạng thái
        
        alt Tài khoản hoạt động
            Auth-->>Login: Xác thực thành công
            Login->>Main: Mở form chính
            Main->>Main: Load menu theo vai trò
            Main-->>User: Hiển thị giao diện
        else Tài khoản bị khóa
            Auth-->>Login: Tài khoản bị khóa
            Login-->>User: Thông báo lỗi
        end
    else Tài khoản không hợp lệ
        DB-->>Auth: Không tìm thấy
        Auth-->>Login: Sai thông tin
        Login-->>User: Thông báo lỗi
    end
```

---

## 6. SƠ ĐỒ LỚP (CLASS DIAGRAM)

```mermaid
classDiagram
    class DanhMuc {
        +int MaDanhMuc
        +string TenDanhMuc
        +string MoTa
        +DateTime NgayTao
        +GetAll()
        +GetById(id)
        +Insert()
        +Update()
        +Delete()
    }
    
    class NhaCungCap {
        +int MaNCC
        +string TenNCC
        +string SoDienThoai
        +string Email
        +string DiaChi
        +string MaSoThue
        +GetAll()
        +GetById(id)
        +Insert()
        +Update()
        +Delete()
    }
    
    class SanPham {
        +int MaSanPham
        +string MaSoSanPham
        +string TenSanPham
        +int MaDanhMuc
        +int MaNCC
        +decimal GiaBan
        +decimal GiaNhap
        +int SoLuongTon
        +int TonToiThieu
        +int TonToiDa
        +string MoTa
        +string DuongDanAnh
        +DateTime NgayTao
        +bool TrangThai
        +GetAll()
        +GetById(id)
        +Search(keyword)
        +Insert()
        +Update()
        +Delete()
        +UpdateQuantity()
        +CheckLowStock()
    }
    
    class KhachHang {
        +int MaKhachHang
        +string MaSoKhachHang
        +string HoTen
        +string SoDienThoai
        +string Email
        +string DiaChi
        +string LoaiKhachHang
        +decimal TongChiTieu
        +DateTime NgayTao
        +GetAll()
        +GetById(id)
        +Search(keyword)
        +Insert()
        +Update()
        +Delete()
        +UpdateTotalSpent()
    }
    
    class HoaDon {
        +int MaHoaDon
        +string SoHoaDon
        +int MaKhachHang
        +int MaNhanVien
        +DateTime NgayBan
        +decimal TongTien
        +decimal GiamGia
        +decimal ThueVAT
        +decimal ThanhTien
        +string PhuongThucThanhToan
        +string TrangThai
        +GetAll()
        +GetById(id)
        +GetByDateRange()
        +Insert()
        +Update()
        +Cancel()
        +GenerateInvoiceNumber()
    }
    
    class ChiTietHoaDon {
        +int MaChiTiet
        +int MaHoaDon
        +int MaSanPham
        +int SoLuong
        +decimal DonGia
        +decimal GiamGia
        +decimal ThanhTien
        +GetByInvoiceId(id)
        +Insert()
        +Delete()
        +CalculateTotal()
    }
    
    class NguoiDung {
        +int MaNguoiDung
        +string TenDangNhap
        +string MatKhau
        +string HoTen
        +string Email
        +string SoDienThoai
        +string VaiTro
        +DateTime NgayTao
        +bool TrangThai
        +Login()
        +Logout()
        +ChangePassword()
        +GetAll()
        +Insert()
        +Update()
        +Delete()
        +Lock()
        +Unlock()
    }
    
    DanhMuc "1" --o "*" SanPham : contains
    NhaCungCap "1" --o "*" SanPham : supplies
    KhachHang "1" --o "*" HoaDon : purchases
    NguoiDung "1" --o "*" HoaDon : creates
    HoaDon "1" --* "*" ChiTietHoaDon : has
    SanPham "1" --o "*" ChiTietHoaDon : included_in
```

---

## 7. SƠ ĐỒ TRẠNG THÁI (STATE DIAGRAM)

### 7.1 Trạng thái Hóa đơn

```mermaid
stateDiagram-v2
    [*] --> ChoXuLy: Tạo mới
    
    ChoXuLy --> HoanThanh: Thanh toán thành công
    ChoXuLy --> DaHuy: Hủy đơn
    
    HoanThanh --> [*]
    DaHuy --> [*]
    
    note right of ChoXuLy
        Đang chờ thanh toán
        Có thể sửa đổi
    end note
    
    note right of HoanThanh
        Đã thanh toán
        Không thể sửa đổi
    end note
    
    note right of DaHuy
        Đơn hàng bị hủy
        Hoàn lại số lượng tồn
    end note
```

### 7.2 Trạng thái Tài khoản Người dùng

```mermaid
stateDiagram-v2
    [*] --> HoatDong: Tạo mới
    
    HoatDong --> BiKhoa: Khóa tài khoản
    HoatDong --> BiKhoa: Đăng nhập sai 3 lần
    BiKhoa --> HoatDong: Mở khóa
    
    HoatDong --> [*]: Xóa tài khoản
    BiKhoa --> [*]: Xóa tài khoản
    
    note right of HoatDong
        Có thể đăng nhập
        Sử dụng hệ thống
    end note
    
    note right of BiKhoa
        Không thể đăng nhập
        Cần admin mở khóa
    end note
```

---

## 8. BẢNG PHÂN QUYỀN

| Chức năng | Quản trị | Quản lý | Nhân viên |
|-----------|:--------:|:-------:|:---------:|
| Đăng nhập/Đăng xuất | ✓ | ✓ | ✓ |
| Đổi mật khẩu | ✓ | ✓ | ✓ |
| Quản lý người dùng | ✓ | ✗ | ✗ |
| Quản lý danh mục | ✓ | ✓ | ✗ |
| Quản lý nhà cung cấp | ✓ | ✓ | ✗ |
| Quản lý sản phẩm | ✓ | ✓ | ✗ |
| Quản lý khách hàng | ✓ | ✓ | ✓ |
| Bán hàng (POS) | ✓ | ✓ | ✓ |
| Quản lý hóa đơn | ✓ | ✓ | ✓ |
| Nhập hàng | ✓ | ✓ | ✗ |
| Xem báo cáo | ✓ | ✓ | ✗ |
| Xuất báo cáo | ✓ | ✓ | ✗ |
| Cảnh báo hàng tồn | ✓ | ✓ | ✓ |
| Cấu hình hệ thống | ✓ | ✗ | ✗ |

---

## 9. GHI CHÚ

### Quy ước ký hiệu:
- **ERD**: Entity Relationship Diagram - Sơ đồ quan hệ thực thể
- **DFD**: Data Flow Diagram - Sơ đồ luồng dữ liệu
- **BFD**: Business Flow Diagram - Sơ đồ quy trình nghiệp vụ
- **Use Case**: Sơ đồ trường hợp sử dụng

### Công cụ vẽ:
- Các sơ đồ được vẽ bằng Mermaid syntax
- Có thể xem trực tiếp trên GitHub, VS Code (với extension Markdown Preview Mermaid)
- Hoặc copy vào https://mermaid.live để xem và export

### Ngày tạo: 31/01/2026
### Phiên bản: 1.0
