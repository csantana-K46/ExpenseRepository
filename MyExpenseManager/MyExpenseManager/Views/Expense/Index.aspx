<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<carlos.expense.core.Model.Expense>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Expenses Index</h2>

<p>
    <%: Html.ActionLink("Create New", "RegisterExpense") %>
</p>
<table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.Amount) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.RegisterDate) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Category.Name) %>
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
       <%-- <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
        </td>--%>
    </tr>
<% } %>

</table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
