# Hướng Dẫn Nhanh - Xuất Excel và Form Resize

## 1. Xuất Excel trong Form Mới

### Bước 1: Thêm using
```csharp
using QuanLyBanHang.Class;
```

### Bước 2: Trong nút Xuất Excel
```csharp
private void btnXuatExcel_Click(object sender, EventArgs e)
{
    // Kiểm tra dữ liệu
    if (dgvData.Rows.Count == 0)
    {
        MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // Xuất DataGridView
    string fileName = $"TenBaoCao_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
    ExcelExport.ShowSaveDialogAndExport(dgvData, fileName);
}
```

### Hoặc xuất DataTable:
```csharp
private void btnXuatExcel_Click(object sender, EventArgs e)
{
    // Kiểm tra dữ liệu
    if (dataTable == null || dataTable.Rows.Count == 0)
    {
        MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // Xuất DataTable
    string fileName = $"TenBaoCao_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
    ExcelExport.ShowSaveDialogAndExport(dataTable, fileName);
}
```

---

## 2. Khắc Phục Form Bị Vỡ

### Trong Designer.cs:
```csharp
// 
// frmTenForm
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.ClientSize = new System.Drawing.Size(1200, 700);
this.MinimumSize = new System.Drawing.Size(800, 600);  // ← Thêm dòng này
this.Name = "frmTenForm";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Tên Form";
```

### Các giá trị MinimumSize khuyến nghị:
- Form nhỏ: `(800, 500)`
- Form trung bình: `(900, 600)`
- Form lớn: `(1000, 700)`
- Dashboard: `(1200, 800)`

---

## 3. Thiết Lập Controls Resize Đúng

### Các control cần Dock/Anchor:
```csharp
// Panel trên cùng
panel1.Dock = DockStyle.Top;

// DataGridView
dgvData.Dock = DockStyle.Fill;

// SplitContainer
splitContainer.Dock = DockStyle.Fill;

// Buttons phải trên
btnXem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
```

---

## 4. Format Dữ liệu Trong DataGridView

### Định dạng số tiền:
```csharp
dgvData.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
dgvData.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
```

### Định dạng ngày:
```csharp
dgvData.Columns["NgayBan"].DefaultCellStyle.Format = "dd/MM/yyyy";
```

---

## 5. Xử Lý Lỗi Thường Gặp

### Lỗi: DataGridView null reference
```csharp
if (dgvData.DataSource == null || dgvData.Rows.Count == 0)
{
    MessageBox.Show("Không có dữ liệu!");
    return;
}
```

### Lỗi: DataTable null
```csharp
if (dataTable == null || dataTable.Rows.Count == 0)
{
    MessageBox.Show("Không có dữ liệu!");
    return;
}
```

### Lỗi: File đang được mở
```csharp
// Excel tự động hỏi người dùng có muốn mở file không
// Nếu file đang mở, Excel sẽ báo lỗi
```

---

## 6. Tên File Chuẩn

### Format:
```csharp
$"TenBaoCao_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
```

### Ví dụ:
- `TopSanPham_20260127_143055.xlsx`
- `ThongKeDoanhThu_20260127_143055.xlsx`
- `DanhSachKhachHang_20260127_143055.xlsx`

---

## 7. Test Checklist

- [ ] Xuất với dữ liệu có tiếng Việt
- [ ] Xuất với dữ liệu số lớn (> 1 triệu)
- [ ] Xuất với dữ liệu ngày tháng
- [ ] Maximize form
- [ ] Resize form nhỏ hơn
- [ ] Resize form lớn hơn
- [ ] Test trên màn hình độ phân giải khác

---

## 8. Lưu Ý Quan Trọng

⚠️ **KHÔNG CẦN:**
- Cài đặt Microsoft Office Interop
- Thư viện EPPlus
- Thư viện ClosedXML
- Thư viện NPOI

✅ **CHỈ CẦN:**
- Class ExcelExport.cs (đã có trong project)
- System.IO (built-in .NET)
- System.Text (built-in .NET)

---

## 9. Khắc Phục Sự Cố

### Excel không mở file?
- File CSV có thể cần double-click để mở
- Hoặc chuột phải → Open With → Excel

### Tiếng Việt bị lỗi?
- File đã sử dụng UTF-8 BOM
- Nếu vẫn lỗi, thử mở bằng Google Sheets

### Form vẫn bị vỡ?
- Kiểm tra MinimumSize đã set chưa
- Kiểm tra Dock/Anchor của controls
- Rebuild solution

---

## Hỗ Trợ

Nếu gặp vấn đề, kiểm tra:
1. File `ExcelExport.cs` có trong project
2. Using `QuanLyBanHang.Class` đã thêm
3. MinimumSize đã set trong Designer
4. DataGridView/DataTable không null

---

**Cập nhật:** 27/01/2026
