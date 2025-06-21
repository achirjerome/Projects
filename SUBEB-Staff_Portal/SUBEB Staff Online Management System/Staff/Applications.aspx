<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeBehind="Applications.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Staff.Applications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
    <tr>
        <td style="width: 121px">&nbsp;</td>
        <td style="width: 541px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 36px; width: 121px;"></td>
        <td class="text-center" style="height: 36px; font-size: medium; background-color: #FFCCCC; width: 541px;"><strong>Application</strong></td>
        <td style="height: 36px"></td>
    </tr>
    <tr>
        <td style="width: 121px">&nbsp;</td>
        <td style="width: 541px">
            <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 121px">&nbsp;</td>
        <td style="width: 541px">
            <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="2px">
                <table class="nav-justified">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 41px"></td>
                        <td style="height: 41px">Application Title</td>
                        <td style="height: 41px">
                            <asp:DropDownList ID="ddlTitle" runat="server">
                                <asp:ListItem>Transfer Request</asp:ListItem>
                                <asp:ListItem>Maternity Leave</asp:ListItem>
                                <asp:ListItem>Annual Leave</asp:ListItem>
                                <asp:ListItem>Leave of Absence</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="height: 41px"></td>
                    </tr>
                    <tr>
                        <td style="height: 34px"></td>
                        <td style="height: 34px">Upload Letter</td>
                        <td style="height: 34px">
                            <asp:FileUpload ID="fuAppLetterUpload" runat="server" />
                        </td>
                        <td style="height: 34px"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnUpload" runat="server" Height="30px" Text="Upload" Width="85px" OnClick="btnUpload_Click" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
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
        <td style="width: 121px">&nbsp;</td>
        <td style="width: 541px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
