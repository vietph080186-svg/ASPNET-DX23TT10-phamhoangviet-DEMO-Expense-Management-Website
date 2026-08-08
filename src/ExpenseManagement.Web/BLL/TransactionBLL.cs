using System;
using System.Collections.Generic;
using ExpenseManagement.Web.DAL;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web.BLL
{
    /// <summary>
    /// Business logic layer for transaction-related operations.
    /// Coordinates validation and calls into TransactionDAL.
    /// </summary>
    public static class TransactionBLL
    {
        /// <summary>
        /// Retrieves a transaction by its primary key.
        /// </summary>
        public static Transaction GetTransactionById(int transactionId)
        {
            if (transactionId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(transactionId),
                    "transactionId must be greater than zero");

            return TransactionDAL.GetTransactionById(transactionId);
        }

        /// <summary>
        /// Retrieves all transactions.
        /// </summary>
        public static List<Transaction> GetTransactions()
        {
            return TransactionDAL.GetTransactions();
        }

        /// <summary>
        /// Retrieves transactions belonging to a specific user.
        /// </summary>
        public static List<Transaction> GetTransactionsByUser(int userId)
        {
            if (userId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(userId),
                    "userId must be greater than zero");

            return TransactionDAL.GetTransactionsByUser(userId);
        }

        /// <summary>
        /// Retrieves transactions belonging to a specific category.
        /// </summary>
        public static List<Transaction> GetTransactionsByCategory(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(categoryId),
                    "categoryId must be greater than zero");

            return TransactionDAL.GetTransactionsByCategory(categoryId);
        }
    }
}
