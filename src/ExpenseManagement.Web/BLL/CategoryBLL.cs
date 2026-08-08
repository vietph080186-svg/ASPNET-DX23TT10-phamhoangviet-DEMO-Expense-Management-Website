using System;
using System.Collections.Generic;
using ExpenseManagement.Web.DAL;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web.BLL
{
    /// <summary>
    /// Business logic layer for category-related operations.
    /// </summary>
    public static class CategoryBLL
    {
        /// <summary>
        /// Retrieves a category by id after validating the input.
        /// </summary>
        /// <param name="categoryId">Primary key, must be greater than zero.</param>
        /// <returns>Category or null if not found.</returns>
        public static Category GetCategoryById(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), "categoryId must be greater than zero");

            return CategoryDAL.GetCategoryById(categoryId);
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>List of Category. Never null (may be empty).</returns>
        public static List<Category> GetCategories()
        {
            return CategoryDAL.GetCategories();
        }

        /// <summary>
        /// Retrieves categories created by a specific user.
        /// </summary>
        /// <param name="userId">User id, must be greater than zero.</param>
        /// <returns>List of Category. Never null.</returns>
        public static List<Category> GetCategoriesByUser(int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "userId must be greater than zero");

            return CategoryDAL.GetCategoriesByUser(userId);
        }

        /// <summary>
        /// Retrieves active categories (IsActive = 1).
        /// </summary>
        /// <returns>List of Category. Never null.</returns>
        public static List<Category> GetActiveCategories()
        {
            return CategoryDAL.GetActiveCategories();
        }

        /// <summary>
        /// Retrieves categories filtered by category type. Accepts only 'Income' or 'Expense'.
        /// </summary>
        /// <param name="categoryType">Category type to filter by. Must be 'Income' or 'Expense' (case-insensitive allowed).</param>
        /// <returns>List of Category. Never null.</returns>
        public static List<Category> GetCategoriesByType(string categoryType)
        {
            if (string.IsNullOrWhiteSpace(categoryType)) throw new ArgumentException("categoryType must not be null or whitespace", nameof(categoryType));

            // Validate allowed values (case-insensitive)
            var normalized = categoryType.Trim();
            if (!string.Equals(normalized, "Income", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(normalized, "Expense", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("categoryType must be either 'Income' or 'Expense'", nameof(categoryType));
            }

            // Pass through the original value (preserve casing provided by caller).
            return CategoryDAL.GetCategoriesByType(categoryType);
        }
    }
}
