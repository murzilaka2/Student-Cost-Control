<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detailed_statistics_expenses.aspx.cs" Inherits="Cost_Control.finance.detailed_statistics_expenses" %>

<%@ Register Src="~/Parts/Head.ascx" TagName="Head" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Scripts.ascx" TagName="Scripts" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Footer.ascx" TagName="Footer" TagPrefix="Place" %>
<%@ Register Src="~/Parts/NavBar.ascx" TagName="NavBar" TagPrefix="Place" %>
<%@ Register Src="~/Parts/SideBar.ascx" TagName="SideBar" TagPrefix="Place" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <Place:Head runat="server" />
    <script src="https://www.google.com/jsapi"></script>
    <%-- Tables --%>
    <link rel="stylesheet" type="text/css" href="../assets/vendor/datatables/css/dataTables.bootstrap4.css" />
    <link rel="stylesheet" type="text/css" href="../assets/vendor/datatables/css/buttons.bootstrap4.css" />
    <link rel="stylesheet" type="text/css" href="../assets/vendor/datatables/css/select.bootstrap4.css" />
    <link rel="stylesheet" type="text/css" href="../assets/vendor/datatables/css/fixedHeader.bootstrap4.css" />
    <%-- Tables End --%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-main-wrapper">
            <Place:NavBar runat="server" />
            <Place:SideBar runat="server" />
            <div class="dashboard-wrapper">
                <div class="dashboard-ecommerce">
                    <div class="container-fluid dashboard-content">
                        <div class="row">
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="page-header">
                                    <h2 class="pageheader-title">Your Money - Your Life</h2>
                                    <p class="pageheader-text"></p>
                                    <div class="page-breadcrumb">
                                        <nav aria-label="breadcrumb">
                                            <ol class="breadcrumb">
                                                <li class="breadcrumb-item"><a href="../panel.aspx" class="breadcrumb-link">Dashboard</a></li>
                                                <li class="breadcrumb-item active">Detailed Statistics - Expenses</li>
                                            </ol>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                            <%-- Table --%>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5 class="mb-0">Enter the start and end date of the search.</h5>
                                        <hr />
                                        <div class="col-sm-12 col-md-6">
                                            <div class="dt-buttons">
                                                <asp:TextBox runat="server" ID="StartDate" TextMode="Date" CssClass="btn btn-outline-light buttons-copy buttons-html5" required="true"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="EndDate" TextMode="Date" CssClass="btn btn-outline-light buttons-copy buttons-html5" required="true"></asp:TextBox>
                                                <asp:Button runat="server" ID="Search" Text="Search" CssClass="btn btn-outline-primary" OnClick="Search_Click" />
                                                <a href="../finance/detailed_statistics_expenses.aspx" class="btn btn-outline-primary">Refresh</a>
                                            </div>
                                        </div>
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
                                <%-- Table End --%>
                                <div class="card" runat="server" id="ReportItem" visible="false">
                                    <div class="card-header p-4">
                                        <a class="pt-2 d-inline-block">Based on Expenses report.</a>

                                        <div class="float-right">
                                            <h3 class="mb-0">Report #1</h3>
                                            <span runat="server" id="dateitem"></span></div>
                                    </div>
                                    <div class="card-body">
                                        <div class="table-responsive-sm">
                                            <table class="table table-striped">
                                                <thead>
                                                    <tr>
                                                        <th class="center">#</th>
                                                        <th>Item</th>
                                                        <th>Description</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class="center">1</td>
                                                        <td class="left strong"><b>Total Items</b></td>
                                                        <td class="left"><span runat="server" id="items">null</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="center">2</td>
                                                        <td class="left"><b>Currency</b></td>
                                                        <td class="left"><span runat="server" id="currencyitem">null</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="center">2</td>
                                                        <td class="left"><b>Date span</b></td>
                                                        <td class="left"><span runat="server" id="datespanitem">null</span></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4 col-sm-5">
                                            </div>
                                            <div class="col-lg-4 col-sm-5 ml-auto">
                                                <table class="table table-clear">
                                                    <tbody>
                                                        <tr>
                                                            <td class="left">
                                                                <strong class="text-dark">Name</strong>
                                                            </td>
                                                            <td class="right"><span runat="server" id="nameitem">null</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left">
                                                                <strong class="text-dark">Compared to the previous period</strong>
                                                            </td>
                                                            <td class="right" style="color: green"><label runat="server" id="previousperiod"></label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left">
                                                                <strong class="text-dark">Total</strong>
                                                            </td>
                                                            <td class="right">
                                                                <strong class="text-dark"><span runat="server" id="totalitem">null</span></strong>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer bg-white">
                                        <p class="mb-0">Cost Control</p>
                                    </div>
                                </div>
                            </div>
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

