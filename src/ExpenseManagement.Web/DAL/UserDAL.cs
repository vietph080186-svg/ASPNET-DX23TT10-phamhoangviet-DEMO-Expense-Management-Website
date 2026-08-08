using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web.DAL
{
    /// <summary>
    /// Data access layer for Users table.
    /// </summary>
    public static class UserDAL
    {
        /// <summary>
        /// Retrieves a user by username.
        /// Returns null if not found.
        /// </summary>
        /// <param name="username">The username to look up (not null or empty).</param>
        /// <returns>User model or null.</returns>
        public static User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("username");

            const string sql =
                "SELECT UserId, Username, PasswordHash, FullName, Email, IsAdmin, CreatedAt, UpdatedAt "
                + "FROM Users WHERE Username = @Username";

            var param = new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = username };

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text, param);

            if (dt.Rows.Count == 0) return null;

            return MapDataRowToUser(dt.Rows[0]);
        }

        /// <summary>
        /// Retrieves a user by primary key (UserId).
        /// Returns null if not found.
        /// </summary>
        public static User GetUserById(int userId)
        {
            const string sql =
                "SELECT UserId, Username, PasswordHash, FullName, Email, IsAdmin, CreatedAt, UpdatedAt "
                + "FROM Users WHERE UserId = @UserId";

            var param = new SqlParameter("@UserId", SqlDbType.Int) { Value = userId };

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text, param);
            if (dt.Rows.Count == 0) return null;
            return MapDataRowToUser(dt.Rows[0]);
        }

        /// <summary>
        /// Returns all users. If no users, returns empty list.
        /// </summary>
        public static List<User> GetUsers()
        {
            const string sql =
                "SELECT UserId, Username, PasswordHash, FullName, Email, IsAdmin, CreatedAt, UpdatedAt FROM Users";

            var dt = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text);
            var list = new List<User>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToUser(row));
            }

            return list;
        }

        /// <summary>
        /// Maps a DataRow (from Users table) to a User model.
        /// </summary>
        private static User MapDataRowToUser(DataRow row)
        {
            if (row == null) throw new ArgumentNullException(nameof(row));

            var user = new User
            {
                UserId = row.Field<int>("UserId"),
                Username = row.Field<string>("Username"),
                PasswordHash = row.Field<string>("PasswordHash"),
                FullName = row.Table.Columns.Contains("FullName") ? row.Field<string>("FullName") : null,
                Email = row.Table.Columns.Contains("Email") ? row.Field<string>("Email") : null,
                IsAdmin = row.Field<bool>("IsAdmin"),
                CreatedAt = row.Field<DateTime>("CreatedAt"),
                UpdatedAt = row.Table.Columns.Contains("UpdatedAt") ? row.Field<DateTime?>("UpdatedAt") : null
            };

            return user;
        }
    }
}
