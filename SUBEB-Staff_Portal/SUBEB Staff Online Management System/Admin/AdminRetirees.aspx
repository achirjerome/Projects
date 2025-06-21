<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="AdminRetirees.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.AdminRetirees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
    <tr>
        <td style="height: 14px">&nbsp;</td>
        <td style="height: 14px; width: 840px">&nbsp;</td>
        <td style="height: 14px">&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 14px"></td>
        <td style="height: 14px; width: 840px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td style="height: 14px"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td style="width: 840px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                        <table class="nav-justified">
                            <tr>
                                <td style="width: 23px">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 23px">&nbsp;</td>
                                <td class="text-center" style="height: 43px; font-size: medium; width: 840px; background-color: #FFCCCC"><strong>
                                    <asp:Label ID="lblDB" runat="server"></asp:Label>
                                    &nbsp;RETIREES</strong></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 23px">&nbsp;</td>
                                <td>
                                    <asp:RadioButton ID="rbtLGEA" runat="server" AutoPostBack="True" Checked="True" GroupName="db" OnCheckedChanged="rbtLGEA_CheckedChanged" Text="LGEA" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rbtHqtrs" runat="server" AutoPostBack="True" GroupName="db" OnCheckedChanged="rbtHqtrs_CheckedChanged" Text="Hqtrs" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 23px">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 23px">&nbsp;</td>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server">
                                    </asp:GridView>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 23px">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td style="width: 840px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
