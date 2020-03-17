


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimeDetail.aspx.cs" Inherits="WebApplication8.TimeDetail" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Time Detail</h2>
    <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="EntityDataSource1" DataKeyNames="RecordId,Shiftid" CellPadding="4" ForeColor="#333333" HorizontalAlign="Center" ShowFooter="True" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="RecordId" HeaderText="RecordId" ReadOnly="True" SortExpression="RecordId"  Visible ="false" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"  />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
            <asp:BoundField DataField="Emp_seq_no" HeaderText="Emp Seq No" SortExpression="Emp_seq_no" />
            <asp:BoundField DataField="WorkDate" HeaderText="Work Date" SortExpression="WorkDate" />
            <asp:BoundField DataField="ShiftId" HeaderText="ShiftId" SortExpression="ShiftId" Visible ="false" />
            <asp:BoundField DataField="FromTime" HeaderText="From Time" SortExpression="FromTime" />
            <asp:BoundField DataField="ToTime" HeaderText="To Time" SortExpression="ToTime" />
            <asp:BoundField DataField="OverNight" HeaderText="Over Night" SortExpression="OverNight" />
            <asp:BoundField DataField="HasSplit" HeaderText="Has Split" SortExpression="HasSplit" />
            <asp:BoundField DataField="SS_FromTime" HeaderText="SS From Time" SortExpression="SS_FromTime" Visible ="True"/>
            <asp:BoundField DataField="SS_ToTime" HeaderText="SS To Time" SortExpression="SS_ToTime" Visible ="True"/>
            <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" Visible ="True"/>
            <asp:BoundField DataField="ActivityMaster" HeaderText="ActivityMaster" SortExpression="ActivityMaster" Visible ="False"/>
            <asp:BoundField DataField="ActivityCode" HeaderText="Activity Code" SortExpression="ActivityCode" Visible ="True"/>
            <asp:BoundField DataField="Holding_Acc_Code" HeaderText="Holding_Acc_Code" SortExpression="Holding_Acc_Code" Visible ="False"/>
            <asp:BoundField DataField="LocationId" HeaderText="LocationId" SortExpression="LocationId" Visible ="False" />
            <asp:BoundField DataField="ChargedTo" HeaderText="ChargedTo" SortExpression="Charged To"/>
            <asp:BoundField DataField="EstateLocationID" HeaderText="Estate Location" SortExpression="EstateLocationID" />
            <asp:BoundField DataField="EstateID" HeaderText="Estate" SortExpression="EstateID" />
            <asp:BoundField DataField="TypeOfEntry" HeaderText="TypeOfEntry" SortExpression="TypeOfEntry" Visible ="False"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AcuPayEntities" DefaultContainerName="AcuPayEntities" EnableFlattening="False" EntitySetName="tbl_2_Export_TimeDetails" AutoGenerateOrderByClause="True" OrderBy="">
            <OrderByParameters>
                <asp:FormParameter Name="newparameter" />
            </OrderByParameters>
    </asp:EntityDataSource>
<asp:Button ID="Button1" runat="server" Text="Upload to Database" OnClick="Button1_Click" />
        
</asp:Content>
