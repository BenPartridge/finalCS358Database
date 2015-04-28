<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Available Classes:</h2>
            </hgroup>
            <p>
                 
                <asp:Label ID="Lable1" runat="server" Text="Label7"></asp:Label>
                <asp:GridView ID="CourseGV" runat="server">
                </asp:GridView>
                 
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

</asp:Content>
