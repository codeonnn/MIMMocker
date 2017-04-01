<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Jsontree._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TreeView ID="TreeView1" runat="server" OnLoad="TreeView1_Load"></asp:TreeView>

</asp:Content>

