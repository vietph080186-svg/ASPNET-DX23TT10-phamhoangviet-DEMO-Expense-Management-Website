using System;

namespace ExpenseManagement.Web.Models
{
    /// <summary>
    /// Represents a budget record from the Budgets table.
    /// Maps directly to the database schema.
    /// </summary>
    public class Budget
    {
        public int BudgetId { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
