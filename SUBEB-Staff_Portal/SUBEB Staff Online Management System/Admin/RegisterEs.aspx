<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="RegisterEs.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.RegisterEs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 126px; height: 29px"></td>
            <td style="width: 512px; height: 29px">
                <asp:Label ID="lblMsg" runat="server" style="color: #CC3300" Text="Label"></asp:Label>
            </td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td style="height: 32px; width: 126px"></td>
            <td style="height: 32px; font-size: medium; width: 512px; background-color: #FFCCCC"><strong>Register LGEA ES</strong></td>
            <td style="height: 32px"></td>
        </tr>
        <tr>
            <td style="width: 126px">&nbsp;</td>
            <td style="width: 512px">
                <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                    <table class="nav-justified">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 35px"></td>
                            <td style="height: 35px">User name</td>
                            <td style="height: 35px">
                                <asp:TextBox ID="txtUserName" runat="server" Height="22px" Width="180px"></asp:TextBox>
                            </td>
                            <td style="height: 35px"></td>
                        </tr>
                        <tr>
                            <td style="height: 35px">&nbsp;</td>
                            <td style="height: 35px">Staff Number</td>
                            <td style="height: 35px">
                                <asp:TextBox ID="txtStaffNo" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 35px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 35px"></td>
                            <td style="height: 35px">LGEA</td>
                            <td style="height: 35px">
                                <asp:DropDownList ID="ddlLGEA" runat="server" Height="34px" Width="230px">
                                </asp:DropDownList>
                            </td>
                            <td style="height: 35px"></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                            </td>
                            <td>&nbsp;</td>
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
            <td style="width: 126px">&nbsp;</td>
            <td style="width: 512px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
