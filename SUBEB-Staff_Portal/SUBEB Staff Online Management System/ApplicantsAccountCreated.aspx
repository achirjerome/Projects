<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplicantsAccountCreated.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.ApplicantsAccountCreated" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">
    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td style="width: 548px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: justify; font-family: Arial; letter-spacing: 2px; width: 548px">Account created successfully. To continue with the application, a link has been sent to your email address registered on this site. Log into your email account and click on the link to continue with the application. Thanks.</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width: 548px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width: 548px"><span style="font-family: 'Monotype Corsiva'; font-size: large; color: #339933">Link not sent after 15 minutes?</span>
                <asp:Button ID="btnResend" runat="server" BackColor="White" BorderStyle="None" Font-Italic="True" Height="18px" style="color: #FF3300" Text="Resend" Width="69px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width: 548px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
