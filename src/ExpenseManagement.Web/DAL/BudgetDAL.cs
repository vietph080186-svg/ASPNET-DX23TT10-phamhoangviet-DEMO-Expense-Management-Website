using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web.DAL
{
    /// <summary>
    /// Data access layer for Budgets table.
    /// </summary>
    public static class BudgetDAL
    {
        /// <summary>
        /// Retrieves a budget by its primary key.
        /// Returns null if not found.
        /// </summary>
        public static Budget GetBudgetById(int budgetId)
        {
            if (budgetId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(budgetId),
                    "budgetId must be greater than zero");

            const string sql =
                "SELECT BudgetId, UserId, CategoryId, Amount, " +
                "StartDate, EndDate, CreatedAt, UpdatedAt " +
                "FROM Budgets WHERE BudgetId = @BudgetId";

            var param = new SqlParameter("@BudgetId", SqlDbType.Int)
            {
                Value = budgetId
            };

            var dt = DatabaseHelper.ExecuteDataTable(
                sql,
                CommandType.Text,
                param);

            if (dt.Rows.Count == 0)
                return null;

            return MapDataRowToBudget(dt.Rows[0]);
        }

        /// <summary>
        /// Retrieves all budgets.
        /// Returns an empty list when none exist.
        /// </summary>
        public static List<Budget> GetBudgets()
        {
            const string sql =
                "SELECT BudgetId, UserId, CategoryId, Amount, " +
                "StartDate, EndDate, CreatedAt, UpdatedAt " +
                "FROM Budgets";

            var dt = DatabaseHelper.ExecuteDataTable(
                sql,
                CommandType.Text);

            var list = new List<Budget>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToBudget(row));
            }

            return list;
        }

        /// <summary>
        /// Retrieves budgets belonging to a specific user.
        /// </summary>
        public static List<Budget> GetBudgetsByUser(int userId)
        {
            if (userId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(userId),
                    "userId must be greater than zero");

            const string sql =
                "SELECT BudgetId, UserId, CategoryId, Amount, " +
                "StartDate, EndDate, CreatedAt, UpdatedAt " +
                "FROM Budgets WHERE UserId = @UserId";

            var param = new SqlParameter("@UserId", SqlDbType.Int)
            {
                Value = userId
            };

            var dt = DatabaseHelper.ExecuteDataTable(
                sql,
                CommandType.Text,
                param);

            var list = new List<Budget>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToBudget(row));
            }

            return list;
        }

        /// <summary>
        /// Retrieves budgets linked to a specific category.
        /// </summary>
        public static List<Budget> GetBudgetsByCategory(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(categoryId),
                    "categoryId must be greater than zero");

            const string sql =
                "SELECT BudgetId, UserId, CategoryId, Amount, " +
                "StartDate, EndDate, CreatedAt, UpdatedAt " +
                "FROM Budgets WHERE CategoryId = @CategoryId";

            var param = new SqlParameter("@CategoryId", SqlDbType.Int)
            {
                Value = categoryId
            };

            var dt = DatabaseHelper.ExecuteDataTable(
                sql,
                CommandType.Text,
                param);

            var list = new List<Budget>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToBudget(row));
            }

            return list;
        }

        private static Budget MapDataRowToBudget(DataRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            return new Budget
            {
                BudgetId = row.Field<int>("BudgetId"),
                UserId = row.Field<int>("UserId"),
                CategoryId = row.Field<int?>("CategoryId"),
                Amount = row.Field<decimal>("Amount"),
                StartDate = row.Field<DateTime>("StartDate"),
                EndDate = row.Field<DateTime>("EndDate"),
                CreatedAt = row.Field<DateTime>("CreatedAt"),
                UpdatedAt = row.Field<DateTime?>("UpdatedAt")
            };
        }
    }
}
