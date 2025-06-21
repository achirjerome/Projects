<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Messaging.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.Messaging" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <table class="nav-justified">
    <tr>
        <td style="width: 46px">&nbsp;</td>
        <td style="width: 610px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 46px">&nbsp;</td>
        <td class="text-center" style="font-size: medium; background-color: #FFCCCC; width: 610px;"><strong>Message Staff</strong></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 46px">&nbsp;</td>
        <td style="width: 610px">
            <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="db" Text="LGEA" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="db" Text="Hqtrs" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 46px">&nbsp;</td>
        <td style="width: 610px">
            <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 46px">&nbsp;</td>
        <td style="width: 610px">
            <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                <table class="nav-justified">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td style="width: 362px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 40px"></td>
                        <td style="height: 40px">Staff No</td>
                        <td style="width: 362px; height: 40px">
                            <asp:TextBox ID="txtStaffNo" runat="server"></asp:TextBox>
                        </td>
                        <td style="height: 40px">
                            <asp:Button ID="btnView" runat="server" Height="26px" OnClick="btnView_Click" Text="View" Width="70px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 37px"></td>
                        <td style="height: 37px">Name</td>
                        <td style="width: 362px; height: 37px">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                        <td style="height: 37px"></td>
                    </tr>
                    <tr>
                        <td style="height: 33px"></td>
                        <td style="height: 33px">Phone Number</td>
                        <td style="width: 362px; height: 33px">
                            <asp:Label ID="lblPhoneNo" runat="server"></asp:Label>
                        </td>
                        <td style="height: 33px"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td style="width: 362px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 46px">&nbsp;</td>
        <td style="width: 610px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 46px">&nbsp;</td>
        <td style="width: 610px; font-size: medium">
            <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="2px">
                <table class="nav-justified">
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Message (</strong><span style="font-size: x-small">Concise</span><strong>)</strong></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtMsg" runat="server" Height="69px" TextMode="MultiLine" Width="571px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" Width="98px" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 46px">&nbsp;</td>
        <td style="width: 610px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
