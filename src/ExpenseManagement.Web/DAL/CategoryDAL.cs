using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web.DAL
{
    /// <summary>
    /// Data access layer for Categories table.
    /// </summary>
    public static class CategoryDAL
    {
        /// <summary>
        /// Retrieves a category by its primary key. Returns null if not found.
        /// </summary>
        public static Category GetCategoryById(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), "categoryId must be greater than zero");

            const string sql =
                "SELECT CategoryId, Name, CategoryType, Description, IsActive, CreatedByUserId, CreatedAt, UpdatedAt "
                + "FROM Categories WHERE CategoryId = @CategoryId";

            var param = new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId };

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text, param);
            if (dt.Rows.Count == 0) return null;

            return MapDataRowToCategory(dt.Rows[0]);
        }

        /// <summary>
        /// Retrieves all categories. Returns empty list when none.
        /// </summary>
        public static List<Category> GetCategories()
        {
            const string sql =
                "SELECT CategoryId, Name, CategoryType, Description, IsActive, CreatedByUserId, CreatedAt, UpdatedAt FROM Categories";

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text);
            var list = new List<Category>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToCategory(row));
            }

            return list;
        }

        /// <summary>
        /// Retrieves categories created by a specific user.
        /// </summary>
        public static List<Category> GetCategoriesByUser(int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "userId must be greater than zero");

            const string sql =
                "SELECT CategoryId, Name, CategoryType, Description, IsActive, CreatedByUserId, CreatedAt, UpdatedAt "
                + "FROM Categories WHERE CreatedByUserId = @UserId";

            var param = new SqlParameter("@UserId", SqlDbType.Int) { Value = userId };

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text, param);
            var list = new List<Category>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToCategory(row));
            }

            return list;
        }

        /// <summary>
        /// Retrieves active categories (IsActive = 1).
        /// </summary>
        public static List<Category> GetActiveCategories()
        {
            const string sql =
                "SELECT CategoryId, Name, CategoryType, Description, IsActive, CreatedByUserId, CreatedAt, UpdatedAt "
                + "FROM Categories WHERE IsActive = 1";

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text);
            var list = new List<Category>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToCategory(row));
            }

            return list;
        }

        /// <summary>
        /// Retrieves categories filtered by CategoryType (e.g., 'Income' or 'Expense').
        /// </summary>
        public static List<Category> GetCategoriesByType(string categoryType)
        {
            if (string.IsNullOrWhiteSpace(categoryType)) throw new ArgumentException("categoryType must not be null or whitespace", nameof(categoryType));

            const string sql =
                "SELECT CategoryId, Name, CategoryType, Description, IsActive, CreatedByUserId, CreatedAt, UpdatedAt "
                + "FROM Categories WHERE CategoryType = @CategoryType";

            var param = new SqlParameter("@CategoryType", SqlDbType.NVarChar, 20) { Value = categoryType };

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text, param);
            var list = new List<Category>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToCategory(row));
            }

            return list;
        }

        private static Category MapDataRowToCategory(DataRow row)
        {
            if (row == null) throw new ArgumentNullException(nameof(row));

            var category = new Category
            {
                CategoryId = row.Field<int>("CategoryId"),
                Name = row.Field<string>("Name"),
                CategoryType = row.Field<string>("CategoryType"),
                Description = row.Table.Columns.Contains("Description") ? row.Field<string>("Description") : null,
                IsActive = row.Field<bool>("IsActive"),
                CreatedByUserId = row.Field<int>("CreatedByUserId"),
                CreatedAt = row.Field<DateTime>("CreatedAt"),
                UpdatedAt = row.Table.Columns.Contains("UpdatedAt") ? row.Field<DateTime?>("UpdatedAt") : null
            };

            return category;
        }
    }
}
