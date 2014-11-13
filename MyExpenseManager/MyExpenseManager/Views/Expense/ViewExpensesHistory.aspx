<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<carlos.expense.core.Model.Expense>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewExpensesHistory
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>View Expenses History</h2>
     <table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.Id) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Amount) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.RegisterDate) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Category) %>
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Id) %>
        </td>
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
    <div>
    <%: Html.ActionLink("Reset Search","ViewExpensesHistory") %>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
