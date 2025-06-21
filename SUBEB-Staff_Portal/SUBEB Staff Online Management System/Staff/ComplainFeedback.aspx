<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeBehind="ComplainFeedback.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Staff.ComplainFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">
                <table class="nav-justified">
                    <tr>
                        <td>&nbsp;</td>
                        <td style="width: 555px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="width: 555px">&nbsp;</td>
                        <td>
                            <asp:Label ID="lblAddressee" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="width: 555px">&nbsp Address To</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="width: 555px">
                            <asp:DropDownList ID="ddlAddressTo" runat="server">
                                <asp:ListItem>Chairman</asp:ListItem>
                                <asp:ListItem>Accountant</asp:ListItem>
                                <asp:ListItem>Staff Officer</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">Heading</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">
                <asp:TextBox ID="txtTitle" runat="server" Height="32px" Width="818px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">
                <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="2px">
                    <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="270px" Width="818px"></asp:TextBox>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">
                <table class="nav-justified">
                    <tr>
                        <td class="text-right" style="width: 341px">
                            <asp:Button ID="btnPreview" runat="server" OnClick="btnPreview_Click" style="font-size: medium" Text="Preview" />
                        </td>
                        <td style="width: 176px">&nbsp;</td>
                        <td class="text-left">
                            <asp:Button ID="btnSend" runat="server" CssClass="col-md-offset-0" Height="35px" style="font-size: medium" Text="Send" Width="93px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 341px">&nbsp;</td>
                        <td style="width: 176px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">&nbsp;</td>
            <td style="width: 842px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
