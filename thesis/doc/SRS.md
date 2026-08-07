# Software Requirements Specification (SRS)

## 1. Giới thiệu

### Tên đề tài
Expense Management Website

### Mục tiêu
Xây dựng một hệ thống quản lý chi tiêu Web Forms nhằm hỗ trợ người dùng theo dõi, quản lý và phân tích các khoản thu chi hàng ngày, đồng thời cung cấp báo cáo thống kê và quản lý ngân sách hiệu quả.

### Phạm vi
Hệ thống bao gồm các chức năng quản lý người dùng, danh mục thu chi, giao dịch, ngân sách, báo cáo và xuất dữ liệu, phục vụ cho việc quản lý tài chính cá nhân hoặc doanh nghiệp vừa và nhỏ.

## 2. Đối tượng sử dụng

- Người quản trị hệ thống: quản lý người dùng, thiết lập danh mục, và xét duyệt các hoạt động.
- Người dùng hệ thống: đăng nhập, thực hiện các giao dịch thu chi, quản lý ngân sách và xem báo cáo.
- Nhà phát triển: triển khai và bảo trì ứng dụng.

## 3. Chức năng hệ thống

- Đăng nhập
  - Người dùng nhập tài khoản và mật khẩu để truy cập hệ thống.
  - Hệ thống xác thực thông tin người dùng.

- Đăng xuất
  - Người dùng có thể đăng xuất để kết thúc phiên làm việc.

- Quản lý người dùng
  - Quản trị viên có thể tạo, chỉnh sửa, và xóa tài khoản người dùng.
  - Quản lý quyền truy cập cơ bản theo vai trò.

- Quản lý danh mục thu
  - Tạo và chỉnh sửa các loại nguồn thu.
  - Xóa hoặc kích hoạt lại danh mục thu.

- Quản lý danh mục chi
  - Tạo và chỉnh sửa các loại chi phí.
  - Xóa hoặc kích hoạt lại danh mục chi.

- Quản lý giao dịch
  - Ghi nhận các giao dịch thu và chi.
  - Xem, sửa và xóa giao dịch.

- Quản lý ngân sách
  - Thiết lập ngân sách cho khoảng thời gian nhất định.
  - Theo dõi việc thực hiện ngân sách so với thực tế.

- Báo cáo thống kê
  - Hiển thị báo cáo thu chi theo thời gian.
  - So sánh và phân tích xu hướng chi tiêu.

- Xuất XML
  - Xuất dữ liệu giao dịch và báo cáo ra định dạng XML.

- Web Service
  - Cung cấp giao diện Web Service để truy xuất dữ liệu (chưa triển khai chi tiết ở giai đoạn hiện tại).

## 4. Yêu cầu phi chức năng

- Bảo mật
  - Xác thực người dùng và bảo vệ truy cập phiên.
  - Hạn chế truy cập trái phép vào các chức năng quản trị.

- Hiệu năng
  - Hệ thống phản hồi nhanh với thời gian chờ hợp lý.
  - Tối ưu thao tác truy vấn và hiển thị báo cáo cơ bản.

- Khả năng mở rộng
  - Cấu trúc thiết kế cho phép mở rộng chức năng sau này.
  - Dễ dàng bổ sung thêm loại báo cáo và tính năng mở rộng.

- Khả năng bảo trì
  - Mã nguồn được tổ chức rõ ràng theo mô hình phân tách tầng.
  - Dễ dàng chỉnh sửa và bảo trì các thành phần giao diện và xử lý.

- Giao diện
  - Giao diện thân thiện, dễ sử dụng.
  - Sắp xếp các chức năng rõ ràng và trực quan.

## 5. Công nghệ sử dụng

- ASP.NET Web Forms (.NET Framework)
- C#
- HTML/CSS/JavaScript
- Bootstrap
- SQL Server (chưa kết nối trong giai đoạn hiện tại)

## 6. Phạm vi của giai đoạn hiện tại

- Thiết lập và chuẩn hóa môi trường dự án.
- Tạo cấu trúc solution và project ASP.NET Web Forms.
- Xây dựng tài liệu SRS cho yêu cầu hệ thống.
- Chưa triển khai source code chức năng cụ thể.
- Chưa tạo database và kết nối SQL Server.
