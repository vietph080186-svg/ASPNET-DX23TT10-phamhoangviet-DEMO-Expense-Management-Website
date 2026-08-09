using System;
using System.Linq;
using System.Collections.Generic;
using ExpenseManagement.Web.BLL;
using ExpenseManagement.Web.Models;

namespace ExpenseManagement.Web
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboard();
            }
        }

        private void LoadDashboard()
        {
            try
            {
                var transactions = TransactionBLL.GetTransactions() ?? new List<Transaction>();
                var budgets = BudgetBLL.GetBudgets() ?? new List<Budget>();

                // Determine expense transactions by category type 'Expense'
                var expenseCategories = ExpenseManagement.Web.BLL.CategoryBLL.GetCategoriesByType("Expense") ?? new List<Category>();
                var expenseCategoryIds = new HashSet<int>(expenseCategories.Select(c => c.CategoryId));

                var totalTransactions = transactions.Count;
                var totalExpenseAmount = transactions.Where(t => expenseCategoryIds.Contains(t.CategoryId)).Sum(t => t.Amount);
                var totalBudgets = budgets.Count;
                var totalBudgetAmount = budgets.Sum(b => b.Amount);
                var remainingBudget = totalBudgetAmount - totalExpenseAmount;

                lblTotalTransactions.Text = totalTransactions.ToString();
                lblTotalExpense.Text = totalExpenseAmount.ToString("N2");
                lblTotalBudgets.Text = totalBudgets.ToString();
                lblTotalBudgetAmount.Text = totalBudgetAmount.ToString("N2");
                lblRemainingBudget.Text = remainingBudget.ToString("N2");

                var recent = transactions.OrderByDescending(t => t.TransactionDate).Take(10).Select(t => new
                {
                    t.TransactionDate,
                    t.Amount,
                    t.Description
                }).ToList();

                if (recent.Count == 0)
                {
                    lblNoTransactions.Visible = true;
                    gvRecentTransactions.Visible = false;
                }
                else
                {
                    lblNoTransactions.Visible = false;
                    gvRecentTransactions.Visible = true;
                    gvRecentTransactions.DataSource = recent;
                    gvRecentTransactions.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Do not expose database exceptions directly. Show a generic message.
                // Log exception to trace for diagnostics (keeps behavior but removes compiler warning).
                System.Diagnostics.Trace.WriteLine(ex.Message);
                pnlSummary.Visible = false;
                gvRecentTransactions.Visible = false;
                lblNoTransactions.Visible = true;
                lblNoTransactions.Text = "An error occurred while loading the dashboard.";
            }
        }
    }
}
