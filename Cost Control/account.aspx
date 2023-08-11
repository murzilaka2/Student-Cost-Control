<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="Cost_Control.account" %>

<%@ Register Src="~/Parts/Head.ascx" TagName="Head" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Scripts.ascx" TagName="Scripts" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Footer.ascx" TagName="Footer" TagPrefix="Place" %>
<%@ Register Src="~/Parts/NavBar.ascx" TagName="NavBar" TagPrefix="Place" %>
<%@ Register Src="~/Parts/SideBar.ascx" TagName="SideBar" TagPrefix="Place" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account</title>
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
                                                <li class="breadcrumb-item active">Account</li>
                                            </ol>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="row" style="padding-bottom: 15px">
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 ">
                                                <label for="validationCustomUsername">Login</label>
                                                <div class="input-group">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text" id="inputGroupPrepend">@</span>
                                                    </div>
                                                    <asp:TextBox runat="server" ID="Login" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="padding-bottom: 15px">
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 ">
                                                <label for="Email">Email</label>
                                                <asp:TextBox runat="server" ID="Email" TextMode="Email" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="row" style="padding-bottom: 15px">
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 ">
                                                <label for="FIO">FIO</label>
                                                <asp:TextBox runat="server" ID="FIO" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="row" style="padding-bottom: 15px">
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 ">
                                                <label for="About">About</label>
                                                <asp:TextBox runat="server" ID="About" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-row" style="padding-bottom: 15px">
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12 mb-2">
                                                <label for="Password">Password</label>
                                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12 mb-2">
                                                <label for="PasswordAgain">Password Again</label>
                                                <asp:TextBox runat="server" ID="PasswordAgain" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 ">
                                                <asp:Button runat="server" ID="Save" Text="Save" CssClass="btn btn-primary" OnClick="Save_Click"/>
                                            </div>                                      
                                        </div>
                                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 mb-2" style="text-align:center">
                                                  <label runat="server" id="error_label"></label>
                                            </div>
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
    </form>
</body>
</html>
