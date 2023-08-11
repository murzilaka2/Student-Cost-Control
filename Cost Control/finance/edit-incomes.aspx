<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit-incomes.aspx.cs" Inherits="Cost_Control.finance.edit_incomes" %>

<%@ Register Src="~/Parts/Head.ascx" TagName="Head" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Scripts.ascx" TagName="Scripts" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Footer.ascx" TagName="Footer" TagPrefix="Place" %>
<%@ Register Src="~/Parts/NavBar.ascx" TagName="NavBar" TagPrefix="Place" %>
<%@ Register Src="~/Parts/SideBar.ascx" TagName="SideBar" TagPrefix="Place" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Income</title>
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
                                                <li class="breadcrumb-item active">Edit Incomes</li>
                                            </ol>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                            <%-- Input Form Start --%>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="card">
                                    <h5 class="card-header">Edit Your Income</h5>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label for="Name" class="col-form-label">Expenses Name</label>
                                            <asp:TextBox runat="server" ID="Name" CssClass="form-control" required></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="Sum" class="col-form-label">Sum</label>
                                            <asp:TextBox runat="server" ID="Sum" CssClass="form-control" TextMode="Number" required></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="Currency" class="col-form-label">Currency</label>
                                            <asp:DropDownList runat="server" ID="Currency" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="Date" class="col-form-label">Date</label>
                                            <asp:TextBox runat="server" ID="Date" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="Definition" class="col-form-label">Definition</label>
                                            <asp:TextBox runat="server" ID="Definition" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="Description" class="col-form-label">Description</label>
                                            <asp:TextBox runat="server" ID="Description" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                        </div>
                                    </div>
                                    <label runat="server" id="error_label" style="text-align:center"></label>
                                    <div class="card-body border-top">
                                        <asp:Button runat="server" ID="Save" OnClick="Save_Click" CssClass="btn btn-primary btn-block" Text="Edit"/>
                                    </div>
                                </div>
                            </div>
                            <%-- Input Form End --%>
                        </div>
                    </div>
                </div>
                <Place:Footer runat="server" />
            </div>
        </div>
        <Place:Scripts runat="server" />
    </form>
</body>
</html>
