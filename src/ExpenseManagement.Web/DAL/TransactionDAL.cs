using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web.DAL
{
    /// <summary>
    /// Data access layer for Transactions table (read-only methods).
    /// </summary>
    public static class TransactionDAL
    {
        /// <summary>
        /// Retrieves a transaction by its primary key. Returns null if not found.
        /// </summary>
        public static Transaction GetTransactionById(int transactionId)
        {
            if (transactionId <= 0) throw new ArgumentOutOfRangeException(nameof(transactionId), "transactionId must be greater than zero");

            const string sql =
                "SELECT TransactionId, UserId, CategoryId, Amount, TransactionDate, Description, CreatedAt, UpdatedAt "
                + "FROM Transactions WHERE TransactionId = @TransactionId";

            var param = new SqlParameter("@TransactionId", SqlDbType.Int) { Value = transactionId };

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text, param);
            if (dt.Rows.Count == 0) return null;

            return MapDataRowToTransaction(dt.Rows[0]);
        }

        /// <summary>
        /// Retrieves all transactions. Returns empty list when none.
        /// </summary>
        public static List<Transaction> GetTransactions()
        {
            const string sql =
                "SELECT TransactionId, UserId, CategoryId, Amount, TransactionDate, Description, CreatedAt, UpdatedAt FROM Transactions";

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text);
            var list = new List<Transaction>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToTransaction(row));
            }

            return list;
        }

        /// <summary>
        /// Retrieves transactions for a specific user.
        /// </summary>
        public static List<Transaction> GetTransactionsByUser(int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "userId must be greater than zero");

            const string sql =
                "SELECT TransactionId, UserId, CategoryId, Amount, TransactionDate, Description, CreatedAt, UpdatedAt "
                + "FROM Transactions WHERE UserId = @UserId";

            var param = new SqlParameter("@UserId", SqlDbType.Int) { Value = userId };

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text, param);
            var list = new List<Transaction>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToTransaction(row));
            }

            return list;
        }

        /// <summary>
        /// Retrieves transactions for a specific category.
        /// </summary>
        public static List<Transaction> GetTransactionsByCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), "categoryId must be greater than zero");

            const string sql =
                "SELECT TransactionId, UserId, CategoryId, Amount, TransactionDate, Description, CreatedAt, UpdatedAt "
                + "FROM Transactions WHERE CategoryId = @CategoryId";

            var param = new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId };

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text, param);
            var list = new List<Transaction>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToTransaction(row));
            }

            return list;
        }

        private static Transaction MapDataRowToTransaction(DataRow row)
        {
            if (row == null) throw new ArgumentNullException(nameof(row));

            var t = new Transaction
            {
                TransactionId = row.Field<int>("TransactionId"),
                UserId = row.Field<int>("UserId"),
                CategoryId = row.Field<int>("CategoryId"),
                Amount = row.Field<decimal>("Amount"),
                TransactionDate = row.Field<DateTime>("TransactionDate"),
                Description = row.Table.Columns.Contains("Description") ? row.Field<string>("Description") : null,
                CreatedAt = row.Field<DateTime>("CreatedAt"),
                UpdatedAt = row.Table.Columns.Contains("UpdatedAt") ? row.Field<DateTime?>("UpdatedAt") : null
            };

            return t;
        }
    }
}
