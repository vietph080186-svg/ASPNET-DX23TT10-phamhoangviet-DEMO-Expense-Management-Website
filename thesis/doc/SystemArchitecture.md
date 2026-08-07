# System Architecture

## I. Kiến trúc tổng thể hệ thống

Hệ thống được thiết kế theo mô hình 3 lớp (3-tier architecture):

- Presentation Layer
  - Đây là lớp giao diện người dùng, chịu trách nhiệm hiển thị dữ liệu và nhận các tương tác từ người dùng.
  - Bao gồm các trang Web Forms, Master Pages, Scripts, và Content.

- Business Logic Layer (BLL)
  - Lớp xử lý nghiệp vụ chính của ứng dụng.
  - Chuyển đổi dữ liệu từ Presentation Layer sang định dạng phù hợp với Data Access Layer.
  - Áp dụng quy tắc nghiệp vụ, kiểm tra và xác thực trước khi lưu hoặc truy vấn dữ liệu.

- Data Access Layer (DAL)
  - Lớp truy cập dữ liệu với cơ sở dữ liệu SQL Server.
  - Chịu trách nhiệm tạo truy vấn, thực thi lệnh SQL và ánh xạ dữ liệu vào các đối tượng Models.

## II. Luồng xử lý dữ liệu

User
↓
Presentation Layer
↓
Business Logic Layer (BLL)
↓
Data Access Layer (DAL)
↓
SQL Server
↓
Data Access Layer (DAL)
↓
Business Logic Layer (BLL)
↓
Presentation Layer
↓
User

## III. Cấu trúc thư mục project

- `DAL/`
  - Chứa lớp truy cập dữ liệu và các phương thức tương tác trực tiếp với cơ sở dữ liệu.

- `BLL/`
  - Chứa lớp xử lý nghiệp vụ, điều phối logic và quy tắc xử lý trước khi dữ liệu được lưu hoặc truy vấn.

- `Models/`
  - Chứa các lớp dữ liệu mô tả cấu trúc thông tin như Users, Categories, Transactions, Budgets.

- `Pages/`
  - Chứa các trang Web Forms cụ thể cho từng tính năng, như danh sách danh mục, giao dịch, ngân sách.

- `MasterPages/`
  - Chứa các trang mẫu chung cho toàn bộ giao diện như bố cục chính, header, sidebar và footer.

- `Assets/`
  - Chứa tài nguyên tĩnh như CSS, JavaScript và hình ảnh.

- `WebServices/`
  - Chứa các dịch vụ web hoặc API nội bộ nếu được triển khai trong tương lai.

- `App_Data/`
  - Chứa dữ liệu cục bộ, cấu hình tạm, hoặc các file dữ liệu được sử dụng bởi ứng dụng trong môi trường phát triển.

- `Content/`
  - Chứa tài nguyên tĩnh giao diện như style, font và các tệp định dạng.

- `Scripts/`
  - Chứa mã JavaScript và tương tác phía client.

## IV. Quy tắc đặt tên

- Tên Project
  - `ExpenseManagement` cho solution và `ExpenseManagement.Web` cho project Web.

- Tên Namespace
  - Sử dụng định dạng `ExpenseManagement.Web`, `ExpenseManagement.BLL`, `ExpenseManagement.DAL`, `ExpenseManagement.Models`.

- Tên Class
  - Sử dụng `PascalCase` và mô tả chức năng, ví dụ `UserService`, `CategoryManager`, `TransactionHandler`.

- Tên Interface
  - Sử dụng tiền tố `I`, ví dụ `IUserRepository`, `ICategoryService`.

- Tên Method
  - Sử dụng `PascalCase` cho phương thức công khai, ví dụ `GetTransactions`, `CreateBudget`, `ValidateUser`.

- Tên Property
  - Sử dụng `PascalCase`, ví dụ `UserId`, `CategoryName`, `CreatedAt`.

- Tên Database
  - `PersonalFinanceDB`.

- Tên Table
  - Sử dụng danh từ số nhiều, ví dụ `Users`, `Categories`, `Transactions`, `Budgets`.

- Tên Primary Key
  - Sử dụng định dạng `TableNameId`, ví dụ `UserId`, `CategoryId`, `TransactionId`, `BudgetId`.

- Tên Foreign Key
  - Sử dụng định dạng `ReferencedTableNameId`, ví dụ `CreatedByUserId`, `UserId`, `CategoryId`.

## V. Quy tắc lập trình

- `PascalCase`
  - Dùng cho tên class, phương thức, property và event.

- `camelCase`
  - Dùng cho biến cục bộ, tham số phương thức và trường riêng trong phạm vi.

- Comment XML
  - Sử dụng comment XML cho các lớp, phương thức và property công khai.

- Parameterized Query
  - Sử dụng truy vấn tham số hóa để tránh SQL Injection.

- Không hard-code Connection String
  - Lưu connection string trong cấu hình, không để trực tiếp trong mã.

- Validate dữ liệu đầu vào
  - Kiểm tra tất cả đầu vào từ người dùng trước khi xử lý.

## VI. Chuẩn xử lý lỗi

- `try...catch`
  - Bắt lỗi tại các điểm truy vấn dữ liệu và logic chính.

- Logging
  - Ghi nhận lỗi và thông tin cảnh báo vào nhật ký để thuận tiện bảo trì.

- Hiển thị thông báo thân thiện
  - Khi xảy ra lỗi, hiển thị thông báo rõ ràng, tránh lộ thông tin hệ thống.

## VII. Chuẩn bảo mật

- Session
  - Quản lý phiên đăng nhập và kiểm tra trạng thái người dùng.

- Authentication
  - Xác thực người dùng trước khi cho phép truy cập.

- Authorization
  - Phân quyền cho Administrator và User.

- Chống SQL Injection
  - Sử dụng truy vấn tham số và tránh ghép chuỗi SQL trực tiếp.

- Validate dữ liệu
  - Kiểm tra dữ liệu đầu vào, bao gồm định dạng, giới hạn và phạm vi giá trị.

## VIII. Danh sách module sẽ phát triển

- Authentication
- Dashboard
- Category
- Transaction
- Budget
- Report
- XML
- Web Service
