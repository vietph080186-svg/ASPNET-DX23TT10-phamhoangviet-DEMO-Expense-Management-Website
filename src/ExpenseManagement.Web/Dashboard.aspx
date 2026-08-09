<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ExpenseManagement.Web.Dashboard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Dashboard</h2>

    <asp:Panel ID="pnlSummary" runat="server">
        <table>
            <tr>
                <td>Total Transactions:</td>
                <td><asp:Label ID="lblTotalTransactions" runat="server" /></td>
            </tr>
            <tr>
                <td>Total Expense Amount:</td>
                <td><asp:Label ID="lblTotalExpense" runat="server" /></td>
            </tr>
            <tr>
                <td>Total Budgets:</td>
                <td><asp:Label ID="lblTotalBudgets" runat="server" /></td>
            </tr>
            <tr>
                <td>Total Budget Amount:</td>
                <td><asp:Label ID="lblTotalBudgetAmount" runat="server" /></td>
            </tr>
            <tr>
                <td>Remaining Budget:</td>
                <td><asp:Label ID="lblRemainingBudget" runat="server" /></td>
            </tr>
        </table>
    </asp:Panel>

    <h3>Recent Transactions</h3>
    <asp:Label ID="lblNoTransactions" runat="server" Visible="false" Text="No transactions to display." />
    <asp:GridView ID="gvRecentTransactions" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
        </Columns>
    </asp:GridView>

</asp:Content>
