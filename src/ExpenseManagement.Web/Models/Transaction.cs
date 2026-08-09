using System;

namespace ExpenseManagement.Web.Models
{
    /// <summary>
    /// Represents a transaction record from the Transactions table.
    /// Maps directly to the database schema.
    /// </summary>
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
