using System;
using System.Collections.Generic;
using ExpenseManagement.Web.DAL;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web.BLL
{
    /// <summary>
    /// Business logic layer for user-related operations.
    /// Coordinates validation and calls into UserDAL.
    /// </summary>
    public static class UserBLL
    {
        /// <summary>
        /// Retrieves a user by username after validating the input.
        /// Returns null if the user does not exist.
        /// </summary>
        /// <param name="username">Username to look up. Must not be null or whitespace.</param>
        /// <returns>User or null.</returns>
        public static User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("username must not be null or whitespace", nameof(username));
            }

            // Delegate to DAL. DAL is responsible for data access and mapping.
            return UserDAL.GetUserByUsername(username);
        }

        /// <summary>
        /// Retrieves a user by its primary key (UserId).
        /// </summary>
        /// <param name="userId">Primary key, must be greater than zero.</param>
        /// <returns>User or null.</returns>
        public static User GetUserById(int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "userId must be greater than zero");

            return UserDAL.GetUserById(userId);
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of User. Never null (may be empty).</returns>
        public static List<User> GetUsers()
        {
            return UserDAL.GetUsers();
        }
    }
}
