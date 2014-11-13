<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<carlos.expense.core.Model.Expense>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewExpensesSummaryByCategory
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>View Expenses Summary By Category</h2>
     <table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.Amount) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.RegisterDate) %>
        </th>
        <th>
            <%: Html.Label("Category Name") %>
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Amount) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.RegisterDate) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Category.Name) %>
        </td>
    </tr>
<% } %>

</table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
