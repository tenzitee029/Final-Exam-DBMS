# 📚 Database Management Systems (DBMS) - Final Project

Dự án bài tập lớn kết thúc học phần môn **Hệ quản trị Cơ sở dữ liệu**.

Dự án tập trung vào việc thiết kế, xây dựng và tối ưu hóa các đối tượng nâng cao trong **Microsoft SQL Server** (bao gồm *Stored Procedures*, *Scalar Functions*, *Inline / Multi-statement Table-Valued Functions*, và *Triggers*) kết hợp với giao diện tương tác trực quan qua **C# Windows Forms (.NET Framework)**.

---

## 📌 Thông tin đồ án
* **Môn học**: Hệ quản trị Cơ sở dữ liệu (DBMS)
* **Sinh viên thực hiện**: Nguyễn Nhật Tiến - 2411****

---

## 🛠️ Công nghệ sử dụng
* **Ngôn ngữ lập trình**: T-SQL, C#
* **Framework / Giao diện**: .NET Framework (Windows Forms)
* **Giao thức kết nối CSDL**: `System.Data.SqlClient` (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `SqlParameter`)

---

## 🏗️ Kiến trúc Cơ sở dữ liệu
Hệ thống đồ án được phân chia thành **các Cơ sở dữ liệu (CSDL) độc lập** trên SQL Server nhằm mô hình hóa các bài toán quản lý thực tế:

| Tên CSDL | Mô tả chức năng | Bài tập áp dụng |
| :--- | :--- | :--- |
| **`TinhToan`** | Thực hiện các giải thuật số học, giải phương trình và tính toán đại số vô hướng | Bài 1, 2, 4 |
| **`QuanLyThuVien`** | Quản lý độc giả (người lớn, trẻ em), đầu sách, ấn bản và lịch sử mượn/trả; kích hoạt Trigger đồng bộ trạng thái sách tự động | Bài 3, 5, 6 |
| **`DeAn`** | Quản lý cơ cấu phòng ban, nhân sự, dự án, thời gian phân công, quan hệ thân nhân và tính lương/thưởng | Bài 7, 8 |
| **`QuanLyGara`** | Quản lý tổ đội thợ sửa chữa, phân loại dịch vụ/công việc, hợp đồng dịch vụ và công nợ qua phiếu thu | Bài 9 |
| **`QLThi`** | Quản lý danh mục môn học, giáo viên phụ trách, phòng thi, ca thi và ràng buộc phân công giám thị coi thi | Bài 10 |

---

## 📋 Danh mục chức năng & Bài tập chi tiết

### 🧮 1. Tính toán đại số & Thời gian
* **Bài 1**: `sp_GiaiPTB1` - Thủ tục Stored Procedure giải phương trình bậc nhất $ax + b = 0$.
* **Bài 2**: `fn_GiaiPTB2` - Hàm vô hướng (Scalar Function) giải phương trình bậc hai $ax^2 + bx + c = 0$ biện luận đầy đủ các trường hợp nghiệm.
* **Bài 4**: `fn_TinhTuoi` - Hàm vô hướng tính tuổi dựa trên năm sinh và năm hiện hành của hệ thống (`GETDATE()`).

### 📖 2. Quản lý Thư viện (Library Management)
* **Bài 3 & Bài 5b**: `sp_ThongtinDausach` - Tra cứu thông tin chi tiết đầu sách (ISBN) và đếm số lượng bản sao chưa được mượn.
* **Bài 5a**: `sp_ThongtinDocGia` - Phân loại và truy xuất thông tin độc giả (người lớn kèm thông tin liên lạc / trẻ em kèm mã người bảo lãnh).
* **Bài 5c - 5e**: Thống kê danh sách độc giả người lớn đang mượn sách, độc giả mượn quá hạn 14 ngày và các trường hợp người lớn cùng trẻ em bảo lãnh đều đang mượn sách.
* **Bài 6 (Triggers)**:
  * `tg_delMuon` (`AFTER DELETE`): Tự động chuyển tình trạng cuốn sách thành `yes` khi xóa lượt mượn (trả sách).
  * `tg_insMuon` (`AFTER INSERT`): Tự động chuyển tình trạng cuốn sách thành `no` khi tạo lượt mượn mới.
  * `tg_updCuonSach` (`AFTER UPDATE`): Đồng bộ trạng thái còn/hết của đầu sách (`Dausach.trangthai`) khi có sự thay đổi ở từng cuốn sách vật lý.
  * `tg_InfThongbao`: Ghi nhận thông báo tiếng Việt khi thêm mới hoặc sửa đổi dữ liệu tựa sách.

### 🏢 3. Quản lý Nhân sự & Đề án (Project Management)
* **Bài 7**:
  * `fn_LuongTrungBinh_PhongBan`: Tính lương trung bình của phòng ban (kết hợp lương cơ bản và thưởng tính theo giờ).
  * `fn_TongLuongNV_TheoDuAn`: Tính lương thực nhận của nhân sự theo từng dự án cụ thể.
  * `fn_TinhTienThuong`: Tính thưởng lũy tiến theo các mốc giờ làm việc.
  * `fn_ThongTinNhanVien_Inline` & `fn_ThongTinNhanVien_MultiStatement`: So sánh và cài đặt hàm trả về bảng (Inline TVF vs Multi-statement TVF).
* **Bài 8**: Các hàm thống kê điều kiện phức tạp (đề án > 2 người tham gia, phòng có lương TB > 30.000, đếm nhân viên theo điều kiện lương/giới tính dùng kỹ thuật `COUNT(CASE WHEN...)`).

### 🚗 4. Quản lý Gara Sửa chữa xe
* **Bài 9**:
  * `fn_DanhSachTho_KhongThamGiaHD`: Tìm danh sách thợ rảnh rỗi (chưa nhận hợp đồng nào) bằng `NOT EXISTS`.
  * `fn_HopDong_ThanhLyChuaTraDu`: Thống kê hợp đồng đã nghiệm thu nhưng số tiền thu qua phiếu chưa đủ thanh toán.
  * `fn_Tho_LamViecNhieuNhat` & `fn_Tho_TongTriGiaCaoNhat`: Xếp hạng thợ đảm nhận nhiều công việc nhất và có tổng trị giá công việc lớn nhất sử dụng `TOP 1 WITH TIES`.

### 🎓 5. Quản lý Lịch thi & Phân công giám thị
* **Bài 10.1 (Trigger kiểm tra nghiệp vụ)**:
  * `tg_KiemTra_PC_CoiThi`: Ràng buộc giáo viên không được phân công gác thi môn học mình chủ nhiệm.
  * `tg_KiemTra_TGThi_30Tiet` / `tg_KiemTra_TGThi_Tren45Tiet`: Tự động kiểm tra tính khớp giữa số tiết học môn thi và thời lượng thi (120 phút / 150 phút).
* **Bài 10.2 (Function)**: Lọc danh sách giáo viên gác thi/không gác thi học kỳ 1, lịch thi môn Văn và các ca gác thi của giáo viên chủ nhiệm môn Văn.

---

## ⚡ Tính năng nổi bật trên WinForms
1. **Kiểm soát kết nối an toàn (State Management)**: Toàn bộ các thẻ Tab chức năng đều được ẩn tự động khi ứng dụng khởi chạy và chỉ mở ra sau khi cổng kết nối `SqlConnection` được xác thực thành công.
2. **Kỹ thuật kiểm thử không làm bẩn CSDL (Safe Testing with Transactions)**:
   - Các thao tác kiểm thử Trigger (`INSERT`, `UPDATE`, `DELETE`) được bọc trong khối giao dịch `BEGIN TRAN ... ROLLBACK TRAN`.
   - Giúp kiểm tra được toàn diện phản ứng của Trigger (thành công hoặc ném lỗi vi phạm) mà dữ liệu mẫu không bị biến dạng sau mỗi lần chạy.
3. **Phòng chống SQL Injection**: 100% các câu lệnh gửi đến SQL Server đều được tham số hóa thông qua `SqlParameter` và `AddWithValue(...)`.

---

## 🚀 Hướng dẫn cài đặt & Khởi chạy

### 1. Yêu cầu hệ thống
* Visual Studio 2019/2022 (đã cài gói phát triển *.NET desktop development*).
* Microsoft SQL Server (2019/2022) hoặc SQL Server Express.
* SQL Server Management Studio (SSMS).

### 2. Thiết lập Cơ sở dữ liệu
1. Mở SSMS và kết nối đến SQL Server Instance của bạn.
2. Chạy các đoạn script tạo bảng và dữ liệu mẫu tương ứng cho 5 CSDL: `TinhToan`, `QuanLyThuVien`, `DeAn`, `QuanLyGara`, và `QLThi`.
3. Tạo đầy đủ các Stored Procedures, Functions, và Triggers theo mã nguồn đã cung cấp.

### 3. Cấu hình ứng dụng WinForms
1. Mở Solution `.sln` bằng Visual Studio.
2. Mở các Form tương ứng, cập nhật lại chuỗi kết nối `strCon` cho phù hợp với Server Name máy của bạn:
   ```csharp
   string strCon = @"Data Source=YOUR_SERVER_NAME;Initial Catalog=<Tên_CSDL>;Integrated Security=True";
