<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="panel.aspx.cs" Inherits="Cost_Control.panel" %>

<%@ Register Src="~/Parts/Head.ascx" TagName="Head" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Scripts.ascx" TagName="Scripts" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Footer.ascx" TagName="Footer" TagPrefix="Place" %>
<%@ Register Src="~/Parts/NavBar.ascx" TagName="NavBar" TagPrefix="Place" %>
<%@ Register Src="~/Parts/SideBar.ascx" TagName="SideBar" TagPrefix="Place" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <Place:Head runat="server" />
    <%-- Tables --%>
    <link rel="stylesheet" type="text/css" href="../assets/vendor/datatables/css/dataTables.bootstrap4.css" />
    <link rel="stylesheet" type="text/css" href="../assets/vendor/datatables/css/buttons.bootstrap4.css" />
    <link rel="stylesheet" type="text/css" href="../assets/vendor/datatables/css/select.bootstrap4.css" />
    <link rel="stylesheet" type="text/css" href="../assets/vendor/datatables/css/fixedHeader.bootstrap4.css" />
    <%-- Tables End --%>
</head>
<body>
    <form id="form1" runat="server">
        <!-- ============================================================== -->
        <!-- main wrapper -->
        <!-- ============================================================== -->
        <div class="dashboard-main-wrapper">
            <Place:NavBar runat="server" />
            <Place:SideBar runat="server" />
            <!-- ============================================================== -->
            <!-- wrapper  -->
            <!-- ============================================================== -->
            <div class="dashboard-wrapper">
                <div class="dashboard-ecommerce">
                    <div class="container-fluid dashboard-content ">
                        <!-- ============================================================== -->
                        <!-- pageheader  -->
                        <!-- ============================================================== -->
                        <div class="row">
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="page-header">
                                    <h2 class="pageheader-title">Your Money - Your Life</h2>
                                    <p class="pageheader-text"></p>
                                    <div class="page-breadcrumb">
                                        <nav aria-label="breadcrumb">
                                            <ol class="breadcrumb">
                                                <li class="breadcrumb-item"><a href="../panel.aspx" class="breadcrumb-link">Dashboard</a></li>
                                                <li class="breadcrumb-item active">Statistics</li>
                                            </ol>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- ============================================================== -->
                        <!-- end pageheader  -->
                        <!-- ============================================================== -->
                        <div class="row">
                            <!-- ============================================================== -->
                            <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="d-inline-block">
                                            <h5 class="text-muted">Your Month Balance</h5>
                                            <h2 class="mb-0"><asp:Label runat="server" ID="your_balance">$149.00</asp:Label></h2>
                                        </div>
                                        <div class="float-right icon-circle-medium  icon-box-lg  bg-brand-light mt-1">
                                            <i class="fa fa-money-bill-alt fa-fw fa-sm text-brand"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- ============================================================== -->
                            <!-- ============================================================== -->
                            <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="d-inline-block">
                                            <h5 class="text-muted">Total debtors</h5>
                                              <h2 class="mb-0"><asp:Label runat="server" ID="total_deborts">$149.00</asp:Label></h2>
                                        </div>
                                        <div class="float-right icon-circle-medium  icon-box-lg  bg-primary-light mt-1">
                                            <i class="fa fa-user fa-fw fa-sm text-primary"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- ============================================================== -->
                            <!-- ============================================================== -->
                            <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                                
                            </div>
                            <!-- ============================================================== -->
                            <!-- ============================================================== -->
                            <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                                
                            </div>
                            <!-- ============================================================== -->
                            <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="text-muted">This Month Expenses<label runat="server" id="monthexpensesdate"></label></h5>
                                        <h5 class="text-muted"></h5>
                                        <div class="metric-value d-inline-block">
                                            <h1 class="mb-1">
                                                <asp:Label runat="server" ID="CurrencyExpensesMonthLabel"></asp:Label>
                                                <asp:Label runat="server" ID="MoneyExpensesMonthLabel"></asp:Label>
                                            </h1>
                                        </div>
                                    </div>
                                    <div id="sparkline-revenue3"></div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="text-muted">This Month Incomes<label runat="server" id="monthincomesdate"></label></h5>
                                        <div class="metric-value d-inline-block">
                                            <h1 class="mb-1">
                                                <asp:Label runat="server" ID="CurrencyIncomesMonthLabel"></asp:Label>
                                                <asp:Label runat="server" ID="MoneyIncomesMonthLabel"></asp:Label>
                                            </h1>
                                        </div>
                                    </div>
                                    <div id="sparkline-revenue4"></div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="text-muted" style="margin-bottom: 46px">All Expenses</h5>
                                        <div class="metric-value d-inline-block">
                                            <h1 class="mb-1">
                                                <asp:Label runat="server" ID="CurrencyExpensesLabel"></asp:Label>
                                                <asp:Label runat="server" ID="MoneyExpensesLabel"></asp:Label>
                                            </h1>
                                        </div>
                                        <%-- Выводить сравние с прошлым месяцем. --%>
                                        <%--<div class="metric-label d-inline-block float-right text-success font-weight-bold">
                                            <span><i class="fa fa-fw fa-arrow-up"></i></span><span>5.86%</span>
                                        </div>--%>
                                    </div>
                                    <div id="sparkline-revenue"></div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="text-muted" style="margin-bottom: 46px">All Incomes</h5>
                                        <div class="metric-value d-inline-block">
                                            <h1 class="mb-1">
                                                <asp:Label runat="server" ID="CurrencyIncomeLabel"></asp:Label>
                                                <asp:Label runat="server" ID="MoneyIncomeLabel"></asp:Label>
                                            </h1>
                                        </div>
                                        <%--<div class="metric-label d-inline-block float-right text-success font-weight-bold">
                                            <span><i class="fa fa-fw fa-arrow-up"></i></span><span>5.86%</span>
                                        </div>--%>
                                    </div>
                                    <div id="sparkline-revenue2"></div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <%-- All Expenses --%>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h3 class="mb-0">All Expenses</h3>
                                    </div>
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <table id="example" class="table table-striped table-bordered second" style="width: 100%">
                                                <thead>
                                                    <tr>
                                                        <th class="border-0">Product ID</th>
                                                        <th>Name</th>
                                                        <th>Sum</th>
                                                        <th>Currency</th>
                                                        <th>Date</th>
                                                        <th>Definition</th>
                                                        <th>Description</th>
                                                        <th>Edit</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder runat="server" ID="AllExpensesPlace"></asp:PlaceHolder>
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <th>Product ID</th>
                                                        <th>Name</th>
                                                        <th>Sum</th>
                                                        <th>Currency</th>
                                                        <th>Date</th>
                                                        <th>Definition</th>
                                                        <th>Description</th>
                                                        <th>Edit</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- End All Expensis --%>
                            <%-- All Incomes --%>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h3 class="mb-0">All Incomes</h3>
                                    </div>
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <table id="example3" class="table table-striped table-bordered" style="width: 100%">
                                                <thead>
                                                    <tr>
                                                        <th class="border-0">Product ID</th>
                                                        <th>Name</th>
                                                        <th>Sum</th>
                                                        <th>Currency</th>
                                                        <th>Date</th>
                                                        <th>Definition</th>
                                                        <th>Description</th>
                                                        <th>Edit</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder runat="server" ID="AllIncomePlace"></asp:PlaceHolder>
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <th>Product ID</th>
                                                        <th>Name</th>
                                                        <th>Sum</th>
                                                        <th>Currency</th>
                                                        <th>Date</th>
                                                        <th>Definition</th>
                                                        <th>Description</th>
                                                        <th>Edit</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- End All Incomes --%>
                        </div>
                    </div>
                </div>
                <Place:Footer runat="server" />
            </div>
        </div>
        <Place:Scripts runat="server" />
        <%-- Tables --%>
        <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
        <script src="../assets/vendor/datatables/js/dataTables.bootstrap4.min.js"></script>
        <script src="https://cdn.datatables.net/buttons/1.5.2/js/dataTables.buttons.min.js"></script>
        <script src="../assets/vendor/datatables/js/buttons.bootstrap4.min.js"></script>
        <script src="../assets/vendor/datatables/js/data-table.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/pdfmake.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/vfs_fonts.js"></script>
        <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.html5.min.js"></script>
        <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.print.min.js"></script>
        <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.colVis.min.js"></script>
        <script src="https://cdn.datatables.net/rowgroup/1.0.4/js/dataTables.rowGroup.min.js"></script>
        <script src="https://cdn.datatables.net/select/1.2.7/js/dataTables.select.min.js"></script>
        <%-- Tables End --%>
    </form>
</body>
</html>
