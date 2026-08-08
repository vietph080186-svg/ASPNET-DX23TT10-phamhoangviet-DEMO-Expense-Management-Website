using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExpenseManagement.Web.DAL
{
    /// <summary>
    /// Provides common database helper methods using ADO.NET for the ExpenseManagement.Web project.
    /// All connection strings are read from Web.config. Do not hard-code connection strings.
    /// </summary>
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString;

        static DatabaseHelper()
        {
            // Read connection string from Web.config (connectionStrings section)
            ConnectionString = ConfigurationManager.ConnectionStrings["PersonalFinanceDB"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new ConfigurationErrorsException("Connection string 'PersonalFinanceDB' was not found or is empty in Web.config.");
            }
        }

        /// <summary>
        /// Creates and opens a new SqlConnection using the connection string from Web.config.
        /// Caller is responsible for disposing the returned SqlConnection.
        /// </summary>
        /// <returns>An open SqlConnection.</returns>
        public static SqlConnection GetConnection()
        {
            try
            {
                var conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                // Preserve exception information and add context
                throw new InvalidOperationException("Failed to create and open SQL connection.", ex);
            }
        }

        /// <summary>
        /// Executes a non-query command (INSERT, UPDATE, DELETE, or a DDL/STORED PROCEDURE call) and returns the number of rows affected.
        /// </summary>
        /// <param name="commandText">The SQL statement or stored procedure name to execute.</param>
        /// <param name="commandType">The type of the command (Text or StoredProcedure). Default is Text.</param>
        /// <param name="parameters">Optional SqlParameter array for parameterized queries.</param>
        /// <returns>The number of rows affected.</returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new SqlCommand(commandText, conn) { CommandType = commandType })
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ExecuteNonQuery failed.", ex);
            }
        }

        /// <summary>
        /// Executes a command and returns the first column of the first row in the result set returned by the query.
        /// Extra rows and columns are ignored.
        /// </summary>
        /// <param name="commandText">The SQL statement or stored procedure name to execute.</param>
        /// <param name="commandType">The type of the command (Text or StoredProcedure). Default is Text.</param>
        /// <param name="parameters">Optional SqlParameter array for parameterized queries.</param>
        /// <returns>The first column of the first row in the result set; or null if the result set is empty.</returns>
        public static object ExecuteScalar(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new SqlCommand(commandText, conn) { CommandType = commandType })
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ExecuteScalar failed.", ex);
            }
        }

        /// <summary>
        /// Executes a command and returns the results as a DataTable.
        /// </summary>
        /// <param name="commandText">The SQL statement or stored procedure name to execute.</param>
        /// <param name="commandType">The type of the command (Text or StoredProcedure). Default is Text.</param>
        /// <param name="parameters">Optional SqlParameter array for parameterized queries.</param>
        /// <returns>A DataTable containing the result set. The returned DataTable is never null (may have zero rows).</returns>
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            try
            {
                var dt = new DataTable();

                using (var conn = GetConnection())
                using (var cmd = new SqlCommand(commandText, conn) { CommandType = commandType })
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    adapter.Fill(dt);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ExecuteDataTable failed.", ex);
            }
        }
    }
}
