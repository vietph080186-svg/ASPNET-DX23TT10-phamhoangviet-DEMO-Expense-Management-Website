# Database Design

## Tổng quan
Cơ sở dữ liệu được thiết kế theo chuẩn 3NF để hỗ trợ Website Quản lý Chi tiêu Cá nhân. Mục tiêu là giữ dữ liệu nhất quán, loại bỏ sự phụ thuộc dư thừa và thuận tiện cho mở rộng chức năng.

## Bảng chính

### Users
- Mô tả: Lưu thông tin tài khoản hệ thống, phân biệt người dùng thường và quản trị viên.
- Cột:
  - UserId: int IDENTITY(1,1) NOT NULL
  - Username: nvarchar(50) NOT NULL
  - PasswordHash: nvarchar(256) NOT NULL
  - FullName: nvarchar(100) NULL
  - Email: nvarchar(100) NULL
  - IsAdmin: bit NOT NULL DEFAULT 0
  - CreatedAt: datetime2 NOT NULL DEFAULT SYSUTCDATETIME()
  - UpdatedAt: datetime2 NULL
- Primary Key: UserId
- Foreign Key: Không
- Ghi chú: Username nên là duy nhất để xác thực.

### Categories
- Mô tả: Lưu các danh mục thu và chi do người dùng hoặc quản trị viên tạo.
- Cột:
  - CategoryId: int IDENTITY(1,1) NOT NULL
  - Name: nvarchar(100) NOT NULL
  - CategoryType: nvarchar(20) NOT NULL
  - Description: nvarchar(255) NULL
  - IsActive: bit NOT NULL DEFAULT 1
  - CreatedByUserId: int NOT NULL
  - CreatedAt: datetime2 NOT NULL DEFAULT SYSUTCDATETIME()
  - UpdatedAt: datetime2 NULL
- Primary Key: CategoryId
- Foreign Key: CreatedByUserId REFERENCES Users(UserId)
- Ràng buộc: CategoryType chỉ nhận giá trị 'Income' hoặc 'Expense'.

### Transactions
- Mô tả: Ghi nhận các giao dịch thu và chi của người dùng.
- Cột:
  - TransactionId: int IDENTITY(1,1) NOT NULL
  - UserId: int NOT NULL
  - CategoryId: int NOT NULL
  - Amount: decimal(18,2) NOT NULL
  - TransactionDate: datetime2 NOT NULL DEFAULT SYSUTCDATETIME()
  - Description: nvarchar(255) NULL
  - CreatedAt: datetime2 NOT NULL DEFAULT SYSUTCDATETIME()
  - UpdatedAt: datetime2 NULL
- Primary Key: TransactionId
- Foreign Key:
  - UserId REFERENCES Users(UserId)
  - CategoryId REFERENCES Categories(CategoryId)
- Ràng buộc: Amount > 0
- Ghi chú: Loại thu/chi được xác định từ Category.CategoryType.

### Budgets
- Mô tả: Lưu các ngân sách người dùng thiết lập cho khoảng thời gian nhất định.
- Cột:
  - BudgetId: int IDENTITY(1,1) NOT NULL
  - UserId: int NOT NULL
  - CategoryId: int NULL
  - Amount: decimal(18,2) NOT NULL
  - StartDate: date NOT NULL
  - EndDate: date NOT NULL
  - CreatedAt: datetime2 NOT NULL DEFAULT SYSUTCDATETIME()
  - UpdatedAt: datetime2 NULL
- Primary Key: BudgetId
- Foreign Key:
  - UserId REFERENCES Users(UserId)
  - CategoryId REFERENCES Categories(CategoryId)
- Ràng buộc:
  - Amount >= 0
  - EndDate >= StartDate
- Ghi chú: CategoryId NULL cho ngân sách tổng quát; nếu có thì áp dụng cho danh mục cụ thể.

## Mối quan hệ giữa các bảng

- Users và Categories: Một người dùng có thể tạo nhiều danh mục.
- Users và Transactions: Một người dùng có nhiều giao dịch.
- Categories và Transactions: Mỗi giao dịch gắn với một danh mục thu/chi.
- Users và Budgets: Một người dùng có nhiều ngân sách.
- Categories và Budgets: Ngân sách có thể liên kết với một danh mục cụ thể hoặc không.

## Giải thích bổ sung

Thiết kế chỉ sử dụng 4 bảng chính để tránh dư thừa thông tin và vẫn đáp ứng yêu cầu quản lý người dùng, danh mục, giao dịch và ngân sách. Bảng Users chứa trường IsAdmin để phân biệt Administrator và User mà không cần bảng vai trò riêng, phù hợp với phạm vi yêu cầu hiện tại.
