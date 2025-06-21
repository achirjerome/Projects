<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobIntro.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.JobIntro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">
    <table class="nav-justified">
    <tr>
        <td style="width: 324px">&nbsp;</td>
        <td style="width: 487px; text-align: justify">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 324px">&nbsp;</td>
        <td style="width: 487px; text-align: justify">SUBEB advertises for various positions to be filled by qualified candidates. The vacancies are both for academic and administrator postions. Kindly click below to apply.
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Italic="True" NavigateUrl="~/createApplicantAccount.aspx">Apply</asp:HyperLink>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 324px">&nbsp;</td>
        <td style="width: 487px; text-align: justify">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
