<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeBehind="myWorkHistory.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Staff.myWorkHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
    <tr>
        <td style="width: 59px">&nbsp;</td>
        <td style="width: 683px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 59px; height: 38px;"></td>
        <td style="width: 683px; font-size: large; height: 38px; background-color: #FFCCCC;"><strong>My Work History</strong></td>
        <td style="height: 38px"></td>
    </tr>
    <tr>
        <td style="width: 59px">&nbsp;</td>
        <td style="width: 683px">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 59px">&nbsp;</td>
        <td style="width: 683px">
            <asp:Image ID="Image3" runat="server" BorderStyle="Double" BorderWidth="2px" Height="132px" Width="158px" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 59px">&nbsp;</td>
        <td style="width: 683px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 59px">&nbsp;</td>
        <td style="width: 683px">
            <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                <table class="nav-justified">
                    <tr>
                        <td style="width: 209px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 209px; height: 33px">Name:</td>
                        <td style="height: 33px">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 209px; height: 33px">Current Station</td>
                        <td style="height: 33px">
                            <asp:Label ID="lblWorkstation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 209px; height: 33px">LGEA</td>
                        <td style="height: 33px">
                            <asp:Label ID="lblWorkLGEA" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 209px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 59px">&nbsp;</td>
        <td style="width: 683px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 59px">&nbsp;</td>
        <td style="width: 683px">
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
                            <asp:GridView ID="GridView1" runat="server" CellPadding="5" style="font-size: medium">
                                <HeaderStyle BackColor="#CCCCCC" ForeColor="#003366" />
                            </asp:GridView>
                        </td>
                        <td>&nbsp;</td>
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
        <td style="width: 59px">&nbsp;</td>
        <td style="width: 683px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
