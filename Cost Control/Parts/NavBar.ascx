<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBar.ascx.cs" Inherits="Cost_Control.Parts.NavBar" %>
            <div class="dashboard-header">
                <nav class="navbar navbar-expand-lg bg-white fixed-top">                   
                    <a class="navbar-brand" href="../index.aspx"> <img class="logo-img" src="../assets/images/logo.png" alt="logo"/></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>                
                    <div class="collapse navbar-collapse " id="navbarSupportedContent">
                        <ul class="navbar-nav ml-auto navbar-right-top">
                            <li class="nav-item dropdown nav-user">
                                <a class="nav-link nav-user-img" href="#" id="navbarDropdownMenuLink2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <img src="../assets/images/user.png" alt="User" class="user-avatar-md rounded-circle"></a>
                                <div class="dropdown-menu dropdown-menu-right nav-user-dropdown" aria-labelledby="navbarDropdownMenuLink2">
                                    <div class="nav-user-info"><img src="../assets/images/user.png" alt="User" class="user-avatar-md rounded-circle">
                                        <h5 class="mb-0 text-white nav-user-name" runat="server" id="User_Name"></h5>
                                        <span class="status"></span><span class="ml-2">Available</span>
                                    </div>
                                    <a class="dropdown-item" href="../account.aspx"><i class="fas fa-user mr-2"></i>Account</a>
                                    <asp:LinkButton runat="server" CssClass="dropdown-item" OnClick="Unnamed_Click"><i class="fas fa-power-off mr-2"></i>Logout</asp:LinkButton>
                                </div>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>