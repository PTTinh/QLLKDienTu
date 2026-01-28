# HƯỚNG DẪN XUẤT FILE EXCEL

## 📊 Tính Năng Xuất Excel Được Hỗ Trợ

### 1. **Xuất Hóa Đơn Riêng Lẻ**

#### Từ Form In Hóa Đơn (frmInHoaDon):
- Nhấp nút **"Xuất Excel"** để xuất hóa đơn đã thanh toán
- File sẽ chứa đầy đủ thông tin hóa đơn theo định dạng chuyên nghiệp

#### Nội dung file Excel:
```
┌─────────────────────────────────────────┐
│    CỬA HÀNG LINH KIỆN ĐIỆN TỬ          │  <- Tiêu đề
│  Điện thoại | Email                     │  <- Thông tin liên hệ
├─────────────────────────────────────────┤
│ HÓA ĐƠN BÁN HÀNG                       │
│ Số HĐ: HD202601260001                  │  <- Thông tin cơ bản
│ Ngày: 26/01/2026 14:30                 │
├─────────────────────────────────────────┤
│ THÔNG TIN KHÁCH HÀNG                   │
│ Tên KH: Nguyễn Văn An    SĐT: 090X...  │
│ Địa Chỉ: 123 Nguyễn Trãi, Q1, TP.HCM  │
│ Nhân Viên: Lê Văn Nhân Viên            │
├─────────────────────────────────────────┤
│ STT │ Mã SP │ Tên SP │ SL │ Giá │ Tiền │  <- Bảng chi tiết
│  1  │CPU-I5│I5-12400│ 1  │4.8M │4.8M  │
│  2  │RAM-16│RAM 16G │ 2  │1.2M │2.4M  │
├─────────────────────────────────────────┤
│ Tổng Tiền:        7.200.000            │  <- Tính toán
│ Chiết Khấu:         500.000            │
│ Thuế VAT (10%):     670.000            │
│ THÀNH TIỀN:       7.370.000            │  <- Kết quả cuối
├─────────────────────────────────────────┤
│ Phương Thức TT: Tiền mặt                │
│ Cảm ơn bạn đã mua hàng!                │
│ Lưu ý: Hàng bán không hoàn lại...      │
└─────────────────────────────────────────┘
```

### 2. **Xuất Giỏ Hàng (Trước Khi Thanh Toán)**

#### Từ Form Bán Hàng POS (frmPOS):
- Nhấp nút **"Xuất Excel"** để xuất giỏ hàng hiện tại
- Useful để backup trước khi thanh toán hoặc gửi cho khách

### 3. **Xuất Danh Sách Hóa Đơn**

#### Từ Form Lịch Sử Giao Dịch (frmLichSuGiaoDich):
- Chọn các hóa đơn muốn xuất
- Nhấp nút **"Xuất Excel"** để xuất danh sách tất cả các hóa đơn

#### Nội dung:
```
┌─────────────────────────────────────────────────────────┐
│         DANH SÁCH HÓA ĐƠN                              │
├────────────┬──────────────┬──────────┬──────────┬──────┤
│ Số HĐ      │ Ngày Bán     │ Tên KH   │ Tổng TT  │ Trạng│
├────────────┼──────────────┼──────────┼──────────┼──────┤
│HD20260126 1│26/01/2026 9:3│ Nguyễn An│7.200.000 │ Hoàn │
│HD20260126 2│26/01/2026 14:│ Trần Bích│9.500.000 │ Hoàn │
└────────────┴──────────────┴──────────┴──────────┴──────┘
```

## 🎨 Định Dạng Excel Đẹp Mắt

### Tiêu đề và Header
- **Font**: Times New Roman, kích thước 11-16pt
- **Màu nền**: 
  - Header bảng: Xám nhạt (Light Gray)
  - Tổng tiền: Vàng (Yellow) - nổi bật
- **Căn chỉnh**: Tiêu đề center, số tiền right-align

### Bảng Chi Tiết
| Yếu Tố | Định Dạng |
|--------|-----------|
| STT | Định dạng số |
| Tên SP | Text |
| Số Lượng | Center align |
| Giá Tiền | Format: #,##0 (có dấu phẩy phân cách) |
| Giảm Giá | Format: #,##0 |
| Thành Tiền | Format: #,##0, **Bold** |

### Độ Rộng Cột
- STT: 6
- Mã SP / Mã số: 12-15
- Tên Sản Phẩm: 25-30
- Số Lượng: 12
- Đơn Giá / Giá Tiền: 15
- Thành Tiền: 18

## 📝 Cách Sử Dụng

### Bước 1: Tạo Hóa Đơn
```
1. Mở Form Bán Hàng (POS)
2. Chọn khách hàng
3. Thêm sản phẩm vào giỏ
4. Tính toán chiết khấu, VAT
5. Nhấp "Thanh Toán"
```

### Bước 2: Xuất Excel
```
Cách 1 - Từ Form In Hóa Đơn:
  1. Nhấp "Xuất Excel"
  2. Chọn nơi lưu file
  3. File sẽ được tạo (tự động mở nếu chọn Yes)

Cách 2 - Từ Form POS (Giỏ Hàng):
  1. Nhấp "Xuất Excel" ở form POS
  2. Chọn nơi lưu file
  3. File được tạo với dữ liệu giỏ hàng hiện tại
```

### Bước 3: Mở và Sử Dụng File
```
1. File được mở tự động nếu chọn "Yes"
2. Hoặc mở thủ công bằng Excel
3. Có thể in trực tiếp hoặc chỉnh sửa thêm
```

## 🔒 Lưu Ý Quan Trọng

### 1. **Định Dạng Số Tiền**
- Tất cả số tiền đều có định dạng: **#,##0**
- Ví dụ: 1.234.567 (không có ký tự tiền tệ)

### 2. **Tên File**
- **Hóa đơn riêng**: `HoaDon_HD20260126001.xlsx`
- **Giỏ hàng**: `GioHang_HD20260126001.xlsx`
- **Danh sách**: `DanhSachHoaDon_20260126_143000.xlsx`

### 3. **Yêu Cầu Hệ Thống**
- Cần cài đặt Microsoft Excel hoặc Office
- Hoặc cài đặt Microsoft.Office.Interop.Excel library
- Hệ điều hành: Windows XP trở lên

### 4. **Vấn Đề Thường Gặp**
| Vấn Đề | Giải Pháp |
|--------|----------|
| File không mở | Cài đặt Excel hoặc chọn "No" khi hỏi mở file |
| Lỗi định dạng | Đảm bảo Excel được cập nhật phiên bản mới |
| File bị khóa | Đóng file trước khi tạo file mới |

## 💡 Thủ Thuật

### 1. **Chỉnh Sửa Thêm Sau Khi Xuất**
- Mở file Excel
- Chỉnh sửa thông tin khách hàng, chiết khấu, v.v.
- Thêm chữ ký, logo công ty
- In hoặc gửi cho khách

### 2. **Tạo Template**
- Xuất file mẫu
- Lưu lại làm template
- Sử dụng lại cho các hóa đơn sau

### 3. **In Trực Tiếp**
```
Cách 1: Từ Excel
  File -> In -> Chọn máy in

Cách 2: Từ Form
  Nhấp "In" (in trực tiếp từ form in hóa đơn)
```

## 📞 Hỗ Trợ

Nếu gặp lỗi khi xuất Excel:
1. Kiểm tra kết nối database
2. Đảm bảo Excel được cài đặt đúng
3. Thử lại hoặc liên hệ IT support

---
**Cập nhật lần cuối**: 26/01/2026
