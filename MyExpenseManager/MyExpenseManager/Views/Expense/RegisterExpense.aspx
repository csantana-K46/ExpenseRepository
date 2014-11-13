<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyExpenseManager.Models.ExpenseViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RegisterExpense
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>RegisterExpense</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>ExpenseViewModel</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Amount) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Amount) %>
            <%: Html.ValidationMessageFor(model => model.Amount) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.RegisterDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RegisterDate) %>
            <%: Html.ValidationMessageFor(model => model.RegisterDate) %>
        </div>

        <div class="editor-field">
            <%: Html.LabelFor(m => m.Categories) %>
            <%: Html.DropDownListFor(m => m.SelectedValue,new SelectList(Model.Categories, "Id","Name"),"-Please select a category-") %>
            <%: Html.ValidationMessageFor(m => m.Category.Id) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
