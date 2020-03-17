﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotRequired.aspx.cs" Inherits="WebApplication8.NotRequired" %>
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
                 <asp:Table class="content-wrapper" ID="Table3" runat="server" Width="90%" HorizontalAlign="Center">
                <asp:TableRow>
                     <asp:TableCell HorizontalAlign="Right"  Width="50%">
                         <asp:LinkButton ID="lblAdmin" runat="server" OnClick="lblAdmin_Click" Font-Bold="true" ForeColor="#006699">ADMIN</asp:LinkButton>
                         <asp:Label ID="lblServerName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text=" | " Font-Bold="true"></asp:Label>
                <asp:LinkButton ID="lbChangeServer" runat="server" OnClick="lbChangeServer_Click" Font-Bold="true" ForeColor="#006699">CHANGE</asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
    <h2 class="content-wrapper">Not Required</h2>
            <div id="divLabel" class="content-wrapper">
            <asp:Label ID="lblTime" runat="server" Text="Label" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
            <asp:Table class="content-wrapper" ID="Table4" runat="server" Width="90%" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Width="50%">
                       <asp:LinkButton ID="lbCheckAll" runat="server" OnClick="lbCheckAll_Click">Select All</asp:LinkButton>
              <asp:Label ID="lblSlash" runat="server" Text=" / "></asp:Label>
                <asp:LinkButton ID="lbUncheckAll" runat="server" OnClick="lbUncheckAll_Click">Unselect All</asp:LinkButton>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Width="50%">
                        <asp:Button ID="btnSTUpload2" runat="server" Text="Upload to Database" BackColor="#045713" ForeColor="White"   OnClick="btnSTUpload_Click" />
                        <asp:Button ID="btnRefresh2" runat="server" Text="Refresh Table" OnClick="btnRefresh_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
                 <div id="divTime" style="width: 80%; overflow: auto; margin-left:auto; margin-right:auto;">
    <asp:GridView ID="gvTime" runat="server" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True"
        DataKeyNames="RecordId" CellPadding="4" ForeColor="#333333" HorizontalAlign="Center" GridLines="None"
        PageSize="50" OnRowCreated="gvTime_RowCreated" OnRowDataBound="gvTime_RowDataBound"
        OnPageIndexChanging="gvTime_PageIndexChanging" Width="100%" ShowHeader="false">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="#" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelect" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
            <asp:BoundField DataField="RecordId" HeaderText="RecordId" ReadOnly="True" SortExpression="RecordId" Visible="false" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" NullDisplayText="-"/>
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName"  />
            <asp:BoundField DataField="Emp_Seq_No" HeaderText="Emp Seq No" SortExpression="Emp_Seq_No" ItemStyle-HorizontalAlign="Center" NullDisplayText="-"/>
            <asp:BoundField DataField="est_emp_no" HeaderText="Est. Empno" SortExpression="est_emp_no" ItemStyle-HorizontalAlign="Center" NullDisplayText="-"/>
            <asp:BoundField DataField="WorkDate" HeaderText="Work Date" SortExpression="WorkDate" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" NullDisplayText="-"/>
            <asp:BoundField DataField="NRStatus" HeaderText="NR Status" SortExpression="NRStatus" ItemStyle-HorizontalAlign="Center" NullDisplayText="-"/>
            <asp:BoundField DataField="EstateLocationId" HeaderText="Estate Location Id" SortExpression="EstateLocationId" NullDisplayText="-" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="EstateId" HeaderText="Estate Id" SortExpression="EstateId" NullDisplayText="-"  ItemStyle-HorizontalAlign="Center"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="cssPager" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
       </div>
            <asp:Table class="content-wrapper" ID="Table1" runat="server" Width="90%" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Width="50%">
                        <asp:LinkButton ID="lbCheckAll2" runat="server" OnClick="lbCheckAll_Click">Select All</asp:LinkButton>
                <asp:Label ID="lblSlash2" runat="server" Text=" / "></asp:Label>
                <asp:LinkButton ID="lbUnheckAll2" runat="server" OnClick="lbUncheckAll_Click">Unselect All</asp:LinkButton>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Width="50%">
                        <asp:Button ID="btnSTUpload" runat="server" Text="Upload to Database" BackColor="#045713" ForeColor="White"  OnClick="btnSTUpload_Click" />
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh Table" OnClick="btnRefresh_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <%-- Panel to show message and errors--%>
            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="mpeMessage" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
                CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Width="400px" Style="display: none; border: Solid 4px #5C9CCC; max-height: 300px;">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display: none" />
                
                <asp:Table ID="Table7" runat="server" Width="80%" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right" Width="70%">
                            <asp:Label ID="lblHeader" runat="server" Text="" Font-Bold="true" Font-Names="Verdana" Font-Size="Medium"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="30%" HorizontalAlign="Right">
                            <asp:ImageButton ID="ibClosePopUp" runat="server" Width="25px" Height="25px" ImageUrl="~/Images/cancel.png" BorderStyle="None" OnClick="ibClosePopUp_Click" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Justify" ColumnSpan="2">
                            <asp:Label ID="lblMessage" runat="server" Text="" Font-Names="Verdana"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
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
