<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ViewAppilcations.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.ViewAppilcations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td style="width: 658px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 32px; width: 90px"></td>
            <td class="text-center" style="height: 32px; width: 658px; background-color: #FFCCCC">Applications</td>
            <td style="height: 32px"></td>
        </tr>
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td style="width: 658px">
                <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="db" Text="LGEA" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="Hqtrs" runat="server" GroupName="db" Text="Hqtrs" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td style="width: 658px">
                <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                    <table class="nav-justified">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 50px"></td>
                            <td style="height: 50px">
                                <asp:Button ID="btnViewPnding" runat="server" OnClick="btnViewPnding_Click" Text="View Pending" />
                            </td>
                            <td style="height: 50px">
                                <asp:Button ID="btnViewAll" runat="server" Text="View All" OnClick="btnViewAll_Click" />
                            </td>
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
            <td style="width: 90px">&nbsp;</td>
            <td style="width: 658px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td style="width: 658px">
                <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="2px">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" CellSpacing="4" OnRowDataBound="GridView1_RowDataBound">
                        <HeaderStyle BackColor="#CCFFFF" BorderColor="#333333" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" />
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td style="width: 658px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
