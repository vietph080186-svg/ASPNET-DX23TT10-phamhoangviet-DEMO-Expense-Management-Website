# UI Structure

## Danh sách tất cả trang
- Login.aspx
- Dashboard.aspx
- Category.aspx
- Transaction.aspx
- Budget.aspx
- Report.aspx
- Profile.aspx

## URL dự kiến
- Login.aspx: /Login.aspx
- Dashboard.aspx: /Dashboard.aspx
- Category.aspx: /Category.aspx
- Transaction.aspx: /Transaction.aspx
- Budget.aspx: /Budget.aspx
- Report.aspx: /Report.aspx
- Profile.aspx: /Profile.aspx

## Mục đích từng trang
- `Login.aspx`: Xác thực người dùng và cho phép truy cập hệ thống.
- `Dashboard.aspx`: Hiển thị tổng quan thu chi, số dư và giao dịch gần đây.
- `Category.aspx`: Quản lý danh mục thu và chi.
- `Transaction.aspx`: Quản lý giao dịch thu chi, bao gồm thêm, sửa, xóa và tìm kiếm.
- `Budget.aspx`: Quản lý ngân sách theo khoảng thời gian và danh mục.
- `Report.aspx`: Hiển thị báo cáo thống kê và cho phép xuất XML.
- `Profile.aspx`: Quản lý thông tin người dùng và đổi mật khẩu.

## Thành phần giao diện chính
- `Login.aspx`
  - Form đăng nhập với Logo, Username, Password và nút Đăng nhập.
- `Dashboard.aspx`
  - Thống kê tài chính chính, biểu đồ và bảng giao dịch gần đây.
- `Category.aspx`
  - Bảng danh sách danh mục thu/chi, nút hành động, bộ lọc.
- `Transaction.aspx`
  - Bảng giao dịch, biểu mẫu tìm kiếm/lọc, các nút hành động Thêm/Sửa/Xóa.
- `Budget.aspx`
  - Bảng ngân sách, nút Thêm, nút Chỉnh sửa và bộ lọc thời gian.
- `Report.aspx`
  - Biểu đồ và bảng thống kê tháng/năm, nút Xuất XML.
- `Profile.aspx`
  - Hiển thị thông tin người dùng và chức năng đổi mật khẩu.

## Quyền truy cập
- Administrator:
  - Truy cập toàn bộ các trang: Dashboard, Category, Transaction, Budget, Report, Profile.
  - Quản lý người dùng (nếu mở rộng vào tương lai) thông qua UI riêng hoặc trang quản trị.
- User:
  - Truy cập Dashboard, Category, Transaction, Budget, Report, Profile.
  - Không truy cập các chức năng quản trị người dùng.
