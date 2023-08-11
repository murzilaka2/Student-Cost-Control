<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Cost_Control.index"%>

<%@ Register Src="~/Parts/Head.ascx" TagName="Head" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Scripts.ascx" TagName="Scripts" TagPrefix="Place" %>
<%@ Register Src="~/Parts/Footer.ascx" TagName="Footer" TagPrefix="Place" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cost Control - Auth</title>
    <meta content="" name="description" />
    <meta content="" name="author" />
    <Place:Head runat="server" />
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="splash-container" style="margin-top:auto">
                    <div class="card">
                        <div class="card-header text-center">
                            <a href="../index.html">
                                <img class="logo-img" src="../assets/images/logo.png" alt="logo"></a>
                            <span class="splash-description">Please enter your user information.</span>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="Login" CssClass="form-control form-control-lg" placeholder="Login" required="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="Password" CssClass="form-control form-control-lg" placeholder="Password" TextMode="Password" required="true"></asp:TextBox>
                            </div>
                            <asp:Button runat="server" ID="Login_But" CssClass="btn btn-primary btn-lg btn-block" Text="Sign In" OnClick="Login_But_Click" />
                            <label runat="server" id="error_label" style="margin-top:10px"></label>
                        </div>
                        <div class="card-footer bg-white p-0  ">
                <div class="card-footer-item card-footer-item-bordered">
                    <a class="footer-link">Create An Account</a></div>
                <div class="card-footer-item card-footer-item-bordered">
                    <aclass="footer-link">Forgot Password</a>
                </div>
            </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <Place:Scripts runat="server" />
</body>
</html>
