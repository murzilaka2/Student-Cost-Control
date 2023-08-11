<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="Cost_Control.Parts.SideBar" %>
<div class="nav-left-sidebar sidebar-dark">
    <div class="menu-list">
        <nav class="navbar navbar-expand-lg navbar-light">
            <a class="d-xl-none d-lg-none" href="#">Dashboard</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav flex-column">
                    <li class="nav-divider">Menu
                            </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="../panel.aspx"><i class="fa fa-fw fa-rocket"></i>Dashboard</a>
                    </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="../finance/annotate-expenses.aspx"><i class="fa fa-fw fa-hand-holding-usd"></i>Annotate Expenses</a>
                    </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="../finance/annotate-incomes.aspx"><i class="fa fa-fw fa-chart-line"></i>Annotate Incomes</a>
                    </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="#" data-toggle="collapse" aria-expanded="false" data-target="#submenu-2" aria-controls="submenu-2"><i class="fa fa-fw fa-rocket"></i>Detailed Statistics</a>
                        <div id="submenu-2" class="collapse submenu" style="">
                            <ul class="nav flex-column">
                                <li class="nav-item">
                                    <a class="nav-link" href="../finance/detailed_statistics_expenses.aspx">Expenses<span class="badge badge-secondary">New</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="../finance/detailed_statistics_incomes.aspx">Incomes</a>
                            </ul>
                        </div>
                    </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="../finance/debts.aspx"><i class="fa fa-fw fa-suitcase"></i>Debts</a>
                    </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="../account.aspx"><i class="fa fa-fw fa-user"></i>Account</a>
                    </li>
                    <li class="nav-item ">
                        <asp:LinkButton runat="server" ID="Exit" OnClick="Exit_Click" CssClass="nav-link"><i class="fa fa-fw fa-sign-out-alt"></i>Logout</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
</div>
