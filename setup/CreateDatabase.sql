CREATE DATABASE PersonalFinanceDB;
GO
USE PersonalFinanceDB;
GO

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    FullName NVARCHAR(100) NULL,
    Email NVARCHAR(100) NULL,
    IsAdmin BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL
);

CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    CategoryType NVARCHAR(20) NOT NULL,
    Description NVARCHAR(255) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedByUserId INT NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT CK_Categories_CategoryType CHECK (CategoryType IN ('Income', 'Expense')),
    CONSTRAINT FK_Categories_Users FOREIGN KEY (CreatedByUserId) REFERENCES Users(UserId)
);

CREATE TABLE Transactions (
    TransactionId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserId INT NOT NULL,
    CategoryId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL CHECK (Amount > 0),
    TransactionDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    Description NVARCHAR(255) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_Transactions_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),
    CONSTRAINT FK_Transactions_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

CREATE TABLE Budgets (
    BudgetId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserId INT NOT NULL,
    CategoryId INT NULL,
    Amount DECIMAL(18,2) NOT NULL CHECK (Amount >= 0),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT CK_Budgets_DateRange CHECK (EndDate >= StartDate),
    CONSTRAINT FK_Budgets_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),
    CONSTRAINT FK_Budgets_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
