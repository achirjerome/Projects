<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Retirement.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.Retirement" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <table class="nav-justified">
        <tr>
            <td style="height: 38px; width: 9px;"></td>
            <td class="text-center" style="height: 38px; color: #006600; font-size: large; width: 568px; background-color: #FFCCFF"><strong>Staff Due for Retirement</strong></td>
            <td style="height: 38px"></td>
        </tr>
        <tr>
            <td style="width: 9px">&nbsp;</td>
            <td style="width: 568px">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 9px">&nbsp;</td>
            <td style="width: 568px">
                <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="db" Text="LGEA" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="db" Text="Hqtrs" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 9px">&nbsp;</td>
            <td style="width: 568px">
                <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                    <table class="nav-justified">
                        <tr>
                            <td>&nbsp;</td>
                            <td style="width: 141px">
                                <asp:RadioButton ID="rbtThisMonth" runat="server" Text="This Month" GroupName="date" Checked="True" />
                            </td>
                            <td style="width: 157px">
                                <asp:RadioButton ID="rbtThisYear" runat="server" Text="This Year" GroupName="date" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rbtSelectDate" runat="server" Text="Select Date" GroupName="date" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtSelectDate" runat="server" OnTextChanged="txtSelectDate_TextChanged"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtSelectDate_CalendarExtender" runat="server" BehaviorID="txtSelectDate_CalendarExtender" TargetControlID="txtSelectDate" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td style="width: 141px">&nbsp;</td>
                            <td style="width: 157px">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="Ok" Width="69px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 9px">&nbsp;</td>
            <td style="width: 568px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</p>
<p>
    <table class="nav-justified">
        <tr>
            <td style="width: 6px">&nbsp;</td>
            <td style="width: 800px">
                <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="2px" Width="1193px" ScrollBars="Both">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" GridLines="Horizontal" CellPadding="3" CellSpacing="3">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="#FFCCCC" BorderColor="Black" BorderStyle="Double" BorderWidth="2px" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 6px">&nbsp;</td>
            <td style="width: 800px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
</p>
</asp:Content>
