<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent1" runat="server">
    <h2><%: Title %>.</h2>
    <address>
        ........ Street<br />
        Markurdi, Benue State.<br />
        Nigeria.<br />
        <asp:Image ID="Image2" runat="server" Height="21px" ImageUrl="~/Images/telephone_318-61547.jpeg" Width="27px" />
        <abbr title="Phone">:</abbr>
        +234 (0) ................
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@subeb.be.gov.ng</a>
    </address>
    <address>
        <strong>Administrator:</strong>   <a href="mailto:admin@subeb.be.gov.ng">admin@subeb.be.gov.ng</a>
    </address>
    <address>       
        <strong>chairman:</strong> <a href="mailto:chairman@subeb.be.gov.ng">chairman@subeb.be.gov.ng</a>
    </address>
</asp:Content>
