using System;
using System.Collections.Generic;
using ExpenseManagement.Web.DAL;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web.BLL
{
    /// <summary>
    /// Business logic layer for budget-related operations.
    /// </summary>
    public static class BudgetBLL
    {
        /// <summary>
        /// Retrieves a budget by its primary key.
        /// </summary>
        /// <param name="budgetId">Primary key, must be greater than zero.</param>
        /// <returns>Budget or null if not found.</returns>
        public static Budget GetBudgetById(int budgetId)
        {
            if (budgetId <= 0) throw new ArgumentOutOfRangeException(nameof(budgetId), "budgetId must be greater than zero");

            return BudgetDAL.GetBudgetById(budgetId);
        }

        /// <summary>
        /// Retrieves all budgets.
        /// </summary>
        /// <returns>List of Budget. Never null (may be empty).</returns>
        public static List<Budget> GetBudgets()
        {
            return BudgetDAL.GetBudgets();
        }

        /// <summary>
        /// Retrieves budgets for a specific user.
        /// </summary>
        /// <param name="userId">User id, must be greater than zero.</param>
        /// <returns>List of Budget. Never null.</returns>
        public static List<Budget> GetBudgetsByUser(int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "userId must be greater than zero");

            return BudgetDAL.GetBudgetsByUser(userId);
        }

        /// <summary>
        /// Retrieves budgets for a specific category.
        /// </summary>
        /// <param name="categoryId">Category id, must be greater than zero.</param>
        /// <returns>List of Budget. Never null.</returns>
        public static List<Budget> GetBudgetsByCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), "categoryId must be greater than zero");

            return BudgetDAL.GetBudgetsByCategory(categoryId);
        }

        /// <summary>
        /// Validates a budget date range.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        public static void ValidateDateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("endDate must be greater than or equal to startDate", nameof(endDate));
            }
        }
    }
}
