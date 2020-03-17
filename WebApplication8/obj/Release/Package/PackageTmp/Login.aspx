<%@ Page Title="Select Server" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication8.Account.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title>Login Page</title>
    <link href="../Content/Site.css" rel="stylesheet" type="text/css" />

</head>
<body>

    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="updPnl" runat="server">
            <ContentTemplate>

                <div id="divlogin" runat="server" align="center">
                    <h1>Time and Attendance Data Upload</h1>
                    <br />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Bold="true" Font-Size="Large"></asp:Label>
                   <br />
                     <asp:Table class="content-wrapper" ID="tblLogin" runat="server" Width="600px" HorizontalAlign="Center">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                                   &nbsp;
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow HorizontalAlign="Center">
                            <asp:TableCell HorizontalAlign="Right" Width="250px">
                                <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Size="Medium">Select server for upload:</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="left" Width="200px">
                                <asp:DropDownList ID="ddlServers" runat="server" Width="200px" Height="30px"></asp:DropDownList>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" Width="80px">
                                <asp:Button ID="btnLogin" runat="server" Text="Start" OnClick="btnLogin_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/upload.png" Height="271px" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="updateProgress" runat="server">
            <ProgressTemplate>
                <div style="">
                    <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/loader2.gif" AlternateText="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>

</body>
</html>
