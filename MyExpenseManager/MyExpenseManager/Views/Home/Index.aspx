<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page - My ASP.NET MVC Application
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Home Page.</h1>
                <h2><%: ViewBag.Message %></h2>
            </hgroup>
            <p>
                To learn more about ASP.NET MVC visit
                <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET MVC.
                If you have any questions about ASP.NET MVC visit
                <a href="http://forums.asp.net/1146.aspx/1?MVC" title="ASP.NET MVC Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>We suggest the create some entries:</h3>
    <ol class="round">
        <li class="one">
            <h5>Category Register</h5>
            If you want to do some entries for manage your money, we suggest to create your personal categories
                <ul>
                    <li><%: Html.ActionLink("Category Register", "RegisterCategory", "Category") %></li>
                </ul>
             
        </li>

        <li class="two">
            <h5>Expense Register</h5>
            If you want to do some entries for manage your money, we suggest to create your personal expenses
                <ul>
                    <li><%: Html.ActionLink("Expense Register", "RegisterExpense", "Expense") %></li>
                </ul>
        </li>

        <li class="three">
            <h5>Show Expense Summary</h5>
            This view show you all expense summary by category and period of time.
            <ul>
                <li><%: Html.ActionLink("Summary View", "ViewExpensesSummaryByCategory", "Expense") %></li>
            </ul>
        </li>
         <li class="four">
            <h5>Show Expense Hisroty</h5>
            This view show you all expense history corresponding to period of time given.
            <ul>
                <li><%: Html.ActionLink("History View", "ViewExpensesHistory", "Expense") %></li>
            </ul>
        </li>
    </ol>
</asp:Content>
