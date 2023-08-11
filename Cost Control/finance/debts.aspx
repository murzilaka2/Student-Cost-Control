<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="debts.aspx.cs" Inherits="Cost_Control.finance.debts" %>

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
                                                <li class="breadcrumb-item active">Debts</li>
                                            </ol>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="accrodion-regular">
                                <div id="accordion">
                                    <div class="card">
                                        <div class="card-header" id="headingOne">
                                            <h5 class="mb-0">
                                               <button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                                Indicate Debt
                                             </button>       </h5>
                                        </div>
                                        <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
                                           <div class="card">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label for="Name" class="col-form-label">Name</label>
                                            <asp:TextBox runat="server" ID="Name" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="Sum" class="col-form-label">Sum</label>
                                            <asp:TextBox runat="server" ID="Sum" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="Currency" class="col-form-label">Currency</label>
                                            <asp:DropDownList runat="server" ID="Currency" CssClass="form-control" Enabled="true"></asp:DropDownList>
                                        </div>
                                         <div class="form-group">
                                            <label for="Date" class="col-form-label">Operation Type</label>
                                            <asp:DropDownList runat="server" ID="OperationType" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="Date" class="col-form-label">LoanDate</label>
                                            <asp:TextBox runat="server" ID="LoanDate" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="Date" class="col-form-label">ReturnDate</label>
                                            <asp:TextBox runat="server" ID="ReturnDate" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="Description" class="col-form-label">Description</label>
                                            <asp:TextBox runat="server" ID="Description" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                        </div>
                                    </div>
                                    <label runat="server" id="error_label" style="text-align:center"></label>
                                    <div class="card-body border-top">
                                        <asp:Button runat="server" ID="Save" OnClick="Save_Click" CssClass="btn btn-primary btn-block" Text="Save"/>
                                    </div>
                                        </div>
                                    </div>

                                </div>
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
                                                <a href="../finance/debts.aspx" class="btn btn-outline-primary">Refresh</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <table id="example" class="table table-striped table-bordered second" style="width: 100%">
                                                <thead>
                                                    <tr>
                                                        <th class="border-0">ID</th>
                                                        <th>Name</th>
                                                        <th>Sum</th>
                                                        <th>Currency</th>
                                                        <th>Type</th>
                                                        <th>LoanDate</th>
                                                        <th>ReturnDate</th>
                                                        <th>Description</th>
                                                        <th>Edit</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder runat="server" ID="AllDebtsPlace"></asp:PlaceHolder>
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <th class="border-0">ID</th>
                                                        <th>Name</th>
                                                        <th>Sum</th>
                                                        <th>Currency</th>
                                                        <th>Type</th>
                                                        <th>LoanDate</th>
                                                        <th>ReturnDate</th>
                                                        <th>Description</th>
                                                        <th>Edit</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <%-- Table End --%>
                    </div>
                </div>
                <Place:Footer runat="server" />
            </div>
        </div>
        <Place:Scripts runat="server" />
    </form>
</body>
</html>