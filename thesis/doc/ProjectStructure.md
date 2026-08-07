# Project Structure

## Mô tả chi tiết thư mục và vai trò file dự kiến

- `DAL/`
  - Chứa các lớp truy cập dữ liệu (repository hoặc helper) tương tác trực tiếp với SQL Server.
  - Dự kiến: `UserRepository.cs`, `CategoryRepository.cs`, `TransactionRepository.cs`, `BudgetRepository.cs`.

- `BLL/`
  - Chứa các lớp xử lý nghiệp vụ và điều phối dữ liệu giữa Presentation và DAL.
  - Dự kiến: `UserService.cs`, `CategoryService.cs`, `TransactionService.cs`, `BudgetService.cs`.

- `Models/`
  - Chứa các lớp dữ liệu mô tả đối tượng nghiệp vụ.
  - Dự kiến: `User.cs`, `Category.cs`, `Transaction.cs`, `Budget.cs`.

- `Pages/`
  - Chứa các trang Web Forms chức năng.
  - Dự kiến: `Login.aspx`, `Dashboard.aspx`, `Category.aspx`, `Transaction.aspx`, `Budget.aspx`, `Report.aspx`, `Profile.aspx`.

- `MasterPages/`
  - Chứa các trang mẫu dùng chung cho toàn bộ giao diện.
  - Dự kiến: `Site.Master`, `Site.master.cs`, `Site.Master.designer.cs`.

- `Assets/`
  - Chứa tài nguyên tĩnh hỗ trợ giao diện.
  - `css/`: các tệp stylesheet.
  - `js/`: mã JavaScript điều khiển tương tác.
  - `images/`: hình ảnh logo và icon.

- `WebServices/`
  - Chứa các dịch vụ Web hoặc API nội bộ.
  - Dự kiến: các file `.asmx` hoặc lớp xử lý dịch vụ nếu triển khai sau.

- `App_Data/`
  - Nơi chứa dữ liệu tạm, cấu hình nội bộ hoặc tệp dữ liệu dùng cho môi trường phát triển.

- `Content/`
  - Chứa các tài nguyên giao diện như stylesheet, fonts, hoặc file hỗ trợ cho giao diện.

- `Scripts/`
  - Chứa mã JavaScript dùng cho tương tác phía client.

- `thesis/doc/`
  - Chứa toàn bộ tài liệu phân tích, thiết kế và kiến trúc.

- `setup/`
  - Chứa các tập tin thiết lập cơ sở dữ liệu và cấu hình môi trường ban đầu.

- `progress-report/`
  - Chứa báo cáo tiến độ theo ngày.

## Vai trò từng file dự kiến

- `Login.aspx`:
  - Trang đăng nhập người dùng.

- `Dashboard.aspx`:
  - Trang tổng quan hiển thị thu chi và số dư.

- `Category.aspx`:
  - Trang quản lý danh mục thu và chi.

- `Transaction.aspx`:
  - Trang quản lý giao dịch, tìm kiếm và lọc.

- `Budget.aspx`:
  - Trang thiết lập và quản lý ngân sách.

- `Report.aspx`:
  - Trang hiển thị báo cáo thống kê và xuất XML.

- `Profile.aspx`:
  - Trang quản lý thông tin người dùng và đổi mật khẩu.

- `UserRepository.cs` / `UserService.cs`:
  - Quản lý dữ liệu người dùng và xác thực.

- `CategoryRepository.cs` / `CategoryService.cs`:
  - Quản lý danh mục thu/chi.

- `TransactionRepository.cs` / `TransactionService.cs`:
  - Quản lý các giao dịch thu chi.

- `BudgetRepository.cs` / `BudgetService.cs`:
  - Quản lý ngân sách và kiểm tra trạng thái ngân sách.

- `Models`:
  - Chứa định nghĩa cấu trúc dữ liệu và thuộc tính cần thiết.

- `WebServices`:
  - Lưu trữ các interface dịch vụ nếu cần mở rộng Web Service.

- `App_Data`:
  - Không dùng để chứa mã nguồn, chỉ dữ liệu ứng dụng cục bộ.

- `Content` và `Scripts`:
  - Chứa tài nguyên giao diện và các tương tác phía client.
