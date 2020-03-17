<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimeDetailDetail.aspx.cs" Inherits="WebApplication8.TimeDetailDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server" >
    <h2>Time Detail Details</h2>
      <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AcuPayEntities" DefaultContainerName="AcuPayEntities" EnableFlattening="False" EntitySetName="tbl_2_Export_TimeDetails" Select="it.[RecordId], it.[FirstName], it.[LastName], it.[Emp_seq_no], it.[WorkDate], it.[ShiftId], it.[FromTime], it.[ToTime], it.[OverNight], it.[HasSplit], it.[SS_FromTime], it.[SS_ToTime], it.[Rate], it.[ActivityMaster], it.[ActivityCode], it.[TypeOfEntry], it.[EstateID], it.[EstateLocationID], it.[ChargedTo], it.[LocationId], it.[Holding_Acc_Code]" AutoGenerateOrderByClause="True" OrderBy="">
            <OrderByParameters>
                <asp:FormParameter Name="newparameter" />
            </OrderByParameters>
    </asp:EntityDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataSourceID="EntityDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="RecordId" HeaderText="RecordId" ReadOnly="True" SortExpression="RecordId" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="True" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" ReadOnly="True" SortExpression="LastName" />
            <asp:BoundField DataField="Emp_seq_no" HeaderText="Emp_seq_no" ReadOnly="True" SortExpression="Emp_seq_no" />
            <asp:BoundField DataField="WorkDate" HeaderText="WorkDate" ReadOnly="True" SortExpression="WorkDate" />
            <asp:BoundField DataField="ShiftId" HeaderText="ShiftId" ReadOnly="True" SortExpression="ShiftId" />
            <asp:BoundField DataField="FromTime" HeaderText="FromTime" ReadOnly="True" SortExpression="FromTime" />
            <asp:BoundField DataField="ToTime" HeaderText="ToTime" ReadOnly="True" SortExpression="ToTime" />
            <asp:BoundField DataField="OverNight" HeaderText="OverNight" ReadOnly="True" SortExpression="OverNight" />
            <asp:BoundField DataField="HasSplit" HeaderText="HasSplit" ReadOnly="True" SortExpression="HasSplit" />
            <asp:BoundField DataField="SS_FromTime" HeaderText="SS_FromTime" ReadOnly="True" SortExpression="SS_FromTime" />
            <asp:BoundField DataField="SS_ToTime" HeaderText="SS_ToTime" ReadOnly="True" SortExpression="SS_ToTime" />
            <asp:BoundField DataField="Rate" HeaderText="Rate" ReadOnly="True" SortExpression="Rate" />
            <asp:BoundField DataField="ActivityMaster" HeaderText="ActivityMaster" ReadOnly="True" SortExpression="ActivityMaster" />
            <asp:BoundField DataField="ActivityCode" HeaderText="ActivityCode" ReadOnly="True" SortExpression="ActivityCode" />
            <asp:BoundField DataField="TypeOfEntry" HeaderText="TypeOfEntry" ReadOnly="True" SortExpression="TypeOfEntry" />
            <asp:BoundField DataField="EstateID" HeaderText="EstateID" ReadOnly="True" SortExpression="EstateID" />
            <asp:BoundField DataField="EstateLocationID" HeaderText="EstateLocationID" ReadOnly="True" SortExpression="EstateLocationID" />
            <asp:BoundField DataField="ChargedTo" HeaderText="ChargedTo" ReadOnly="True" SortExpression="ChargedTo" />
            <asp:BoundField DataField="LocationId" HeaderText="LocationId" ReadOnly="True" SortExpression="LocationId" />
            <asp:BoundField DataField="Holding_Acc_Code" HeaderText="Holding_Acc_Code" ReadOnly="True" SortExpression="Holding_Acc_Code" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TimeDetail.aspx" Target="_self">Back</asp:HyperLink>
   
</asp:Content>
