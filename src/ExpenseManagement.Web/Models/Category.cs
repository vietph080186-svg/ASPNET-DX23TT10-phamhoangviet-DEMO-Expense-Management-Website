using System;

namespace ExpenseManagement.Web.Models
{
    /// <summary>
    /// Represents a category record from the Categories table.
    /// Maps directly to the database schema.
    /// </summary>
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
