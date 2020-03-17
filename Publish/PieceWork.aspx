


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PieceWork.aspx.cs" Inherits="WebApplication8.TimeDetail" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Piece Work</h2>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="EntityDataSource1" DataKeyNames="RecordId" CellPadding="4" ForeColor="#333333" HorizontalAlign="Center" ShowFooter="True" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="RecordId" HeaderText="RecordId" ReadOnly="True" SortExpression="RecordId" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"  />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="Emp_Seq_No" HeaderText="Emp_Seq_No" SortExpression="Emp_Seq_No" />
            <asp:BoundField DataField="WorkDate" HeaderText="WorkDate" SortExpression="WorkDate" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="TentativeRate" HeaderText="TentativeRate" SortExpression="TentativeRate" />
            <asp:BoundField DataField="TotalEarnings" HeaderText="TotalEarnings" SortExpression="TotalEarnings" />
            <asp:BoundField DataField="DayWorked" HeaderText="DayWorked" SortExpression="DayWorked" />
            <asp:BoundField DataField="ActivityMaster" HeaderText="ActivityMaster" SortExpression="ActivityMaster" />
            <asp:BoundField DataField="ActivityCode" HeaderText="ActivityCode" SortExpression="ActivityCode" Visible ="True"/>
            <asp:BoundField DataField="ExpenseCode" HeaderText="ExpenseCode" SortExpression="ExpenseCode" Visible ="True"/>
            <asp:BoundField DataField="Holding_ac_Code" HeaderText="Holding_ac_Code" SortExpression="Holding_ac_Code" Visible ="True"/>
            <asp:BoundField DataField="LocationID" HeaderText="LocationID" SortExpression="LocationID"/>
            <asp:BoundField DataField="ChargedTo" HeaderText="ChargedTo" SortExpression="ChargedTo" Visible ="True"/>
            <asp:BoundField DataField="EstateLocationId" HeaderText="EstateLocationId" SortExpression="EstateLocationId"/>
            <asp:BoundField DataField="EstateiD" HeaderText="EstateiD" SortExpression="EstateiD" />
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
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AcuPayEntities" DefaultContainerName="AcuPayEntities" EnableFlattening="False" EntitySetName="tbl_1_Export_PieceWork" AutoGenerateOrderByClause="True" OrderBy="">
            <OrderByParameters>
                <asp:FormParameter Name="newparameter" />
            </OrderByParameters>
    </asp:EntityDataSource>
<asp:Button ID="Button1" runat="server" Text="Upload to Database" OnClick="Button1_Click" />
</asp:Content>
