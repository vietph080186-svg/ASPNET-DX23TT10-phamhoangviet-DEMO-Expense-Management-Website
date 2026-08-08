using System;

namespace ExpenseManagement.Web.Models
{
    /// <summary>
    /// Represents a user record from the Users table.
    /// Maps directly to the database schema.
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}