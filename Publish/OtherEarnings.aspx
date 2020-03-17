


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OtherEarnings.aspx.cs" Inherits="WebApplication8.TimeDetail" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Other Earnings</h2>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="EntityDataSource1" DataKeyNames="RecordId" CellPadding="4" ForeColor="#333333" HorizontalAlign="Center" ShowFooter="True" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="RecordId" HeaderText="RecordId" ReadOnly="True" SortExpression="RecordId" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"  />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="Emp_seq_no" HeaderText="Emp_seq_no" SortExpression="Emp_seq_no" />
            <asp:BoundField DataField="Work_date" HeaderText="Work_date" SortExpression="Work_date" />
            <asp:BoundField DataField="INCOME_ID" HeaderText="INCOME_ID" SortExpression="INCOME_ID" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            <asp:BoundField DataField="EarningRate" HeaderText="EarningRate" SortExpression="EarningRate" />
            <asp:BoundField DataField="Total_other_earnings" HeaderText="Total_other_earnings" SortExpression="Total_other_earnings" />
            <asp:BoundField DataField="Earnings_table_name" HeaderText="Earnings_table_name" SortExpression="Earnings_table_name" />
            <asp:BoundField DataField="Link_id" HeaderText="Link_id" SortExpression="Link_id" Visible ="True"/>
            <asp:BoundField DataField="Estate_location_id" HeaderText="Estate_location_id" SortExpression="Estate_location_id" Visible ="True"/>
            <asp:BoundField DataField="Estate_ID" HeaderText="Estate_ID" SortExpression="Estate_ID" Visible ="True"/>
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
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AcuPayEntities" DefaultContainerName="AcuPayEntities" EnableFlattening="False" EntitySetName="tbl_3_Export_OtherEarnings" AutoGenerateOrderByClause="True" OrderBy="">
            <OrderByParameters>
                <asp:FormParameter Name="newparameter" />
            </OrderByParameters>
    </asp:EntityDataSource>
<asp:Button ID="Button1" runat="server" Text="Upload to Database" OnClick="Button1_Click" />
</asp:Content>
