<%@ Page Title="" Language="C#" MasterPageFile="~/Chairman/Chairman.master" AutoEventWireup="true" CodeBehind="RegApprovalHqtrs.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Chairman.RegApprovalHqtrs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="scripts/cancelInputs.js"; type="text/javascript"></script>
    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td style="width: 712px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width: 712px">
                <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="nav-justified">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblMsg" runat="server" Font-Size="Small" ForeColor="#FF3300"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="text-center" style="font-size: medium; background-color: #FFCCCC"><em><strong>Hqtrs Registration Approval</strong></em></td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td><span style="color: #FF3300"><strong><em>Note: You can not undo any deletion</em></strong></span></td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="2px">
                                            <asp:GridView ID="GridView1" runat="server" CellPadding="5" CellSpacing="5" OnRowDataBound="GridView1_RowDataBound">
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width: 712px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
