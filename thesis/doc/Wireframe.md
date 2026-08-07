# Wireframe Design

## 1. Navigation Flow

- `Login.aspx`
  - Nếu đăng nhập thành công -> `Dashboard.aspx`
  - Nếu thất bại -> giữ trên `Login.aspx` với thông báo lỗi
- `Dashboard.aspx`
  - Liên kết đến `Category.aspx`, `Transaction.aspx`, `Budget.aspx`, `Report.aspx`, `Profile.aspx`
- `Category.aspx`
  - Quay lại `Dashboard.aspx`
  - Điều hướng giữa danh mục thu và danh mục chi
- `Transaction.aspx`
  - Quay lại `Dashboard.aspx`
  - Chuyển đến các hành động thêm, sửa, xóa giao dịch
- `Budget.aspx`
  - Quay lại `Dashboard.aspx`
  - Điều hướng thêm / chỉnh sửa ngân sách
- `Report.aspx`
  - Quay lại `Dashboard.aspx`
  - Chuyển đổi giữa thống kê tháng / năm và xuất XML
- `Profile.aspx`
  - Quay lại `Dashboard.aspx`

## 2. Mô tả bố cục chung

### Header
- Logo ứng dụng ở góc trái.
- Tiêu đề trang hoặc tên module.
- Liên kết nhanh đến Profile và Đăng xuất.

### Sidebar
- Thanh điều hướng chính ở bên trái.
- Các liên kết: Dashboard, Category, Transaction, Budget, Report, Profile.
- Trạng thái người dùng và vai trò hiển thị ở đầu sidebar.

### Main Content
- Hiển thị nội dung chính của từng trang.
- Sắp xếp thành các khu vực, bảng, biểu đồ và biểu mẫu theo mục tiêu chức năng.

### Footer
- Thông tin bản quyền và liên hệ ngắn.
- Ghi chú về phiên bản ứng dụng.

## 3. Thiết kế từng màn hình

### Login
- Logo
- Username
- Password
- Nút Đăng nhập
- Thông báo lỗi đăng nhập

### Dashboard
- Tổng thu (hiển thị chỉ số)
- Tổng chi (hiển thị chỉ số)
- Số dư (hiển thị chỉ số)
- Biểu đồ thu chi (biểu đồ thanh hoặc đường)
- Giao dịch gần đây (bảng liệt kê giao dịch mới nhất)

### Danh mục
- Danh mục thu (bảng danh sách danh mục thu)
- Danh mục chi (bảng danh sách danh mục chi)
- Nút thêm danh mục mới
- Hành động sửa / xóa cho mỗi danh mục
- Bộ lọc trạng thái danh mục (đang hoạt động / không hoạt động)

### Giao dịch
- Danh sách giao dịch (bảng)
- Nút Thêm giao dịch
- Hành động Sửa giao dịch
- Hành động Xóa giao dịch
- Tìm kiếm giao dịch (theo mô tả, danh mục, khoảng thời gian)
- Bộ lọc theo loại (thu/chi), danh mục, ngày

### Ngân sách
- Danh sách ngân sách (bảng danh sách)
- Nút Thêm ngân sách
- Nút Chỉnh sửa ngân sách
- Trạng thái ngân sách (đã duyệt, đang áp dụng, hết hạn)

### Báo cáo
- Thống kê tháng (bảng hoặc biểu đồ tháng)
- Thống kê năm (bảng hoặc biểu đồ năm)
- Nút Xuất XML
- Các bộ lọc khoảng thời gian và danh mục
