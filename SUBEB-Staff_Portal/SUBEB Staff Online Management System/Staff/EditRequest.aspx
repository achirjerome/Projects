<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeBehind="EditRequest.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Staff.EditRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
    <tr>
        <td style="width: 335px">&nbsp;</td>
        <td style="width: 449px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 335px">&nbsp;</td>
        <td class="text-center" style="font-size: medium; width: 449px; background-color: #FFCCCC"><strong>Edit Staff Record Request Form</strong></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 335px">&nbsp;</td>
        <td style="width: 449px">
            <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="2px">
                <table class="nav-justified">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="chkNextOfKin" runat="server" Text="Next of Kin" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="chkPhoneNo" runat="server" Text="Phone Number" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 22px"></td>
                        <td style="height: 22px">
                            <asp:CheckBox ID="chkEmail" runat="server" Text="Email" />
                        </td>
                        <td style="height: 22px"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 335px">&nbsp;</td>
        <td style="width: 449px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
