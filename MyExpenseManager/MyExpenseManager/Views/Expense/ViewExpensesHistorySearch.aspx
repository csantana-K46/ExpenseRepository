<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyExpenseManager.Models.ExpenseHistoryViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewExpensesHistorySearch
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>ViewExpensesHistorySearch</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>ExpenseHistoryViewModel</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FromDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.FromDate) %>
            <%: Html.ValidationMessageFor(model => model.FromDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ToDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ToDate) %>
            <%: Html.ValidationMessageFor(model => model.ToDate) %>
        </div>

        <p>
            <input type="submit" value="Search" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Register Expense", "RegisterExpense") %>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
