<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication8.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var oldgridcolor;
        function SetMouseOver(element) {
            oldgridcolor = element.style.backgroundColor;
            element.style.backgroundColor = '#cecece';
        }
        function SetMouseOut(element) {
            element.style.backgroundColor = oldgridcolor;
        }
        function SetOriginalColor(element) {
            oldgridcolor = element.style.backgroundColor;
            element.style.backgroundColor = oldgridcolor;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="updPnl" runat="server">
        <ContentTemplate>
             <br />
    <h2 class="content-wrapper">Admin</h2>
            <div id="divLabel" class="content-wrapper">
            <asp:Label ID="lblTime" runat="server" Text="This page is under construction. Kindly return on 11-31-2015 for the relevant features, otherwise; ask God for help." Font-Bold="true" Font-Size="Medium"></asp:Label>
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
</asp:Content>
