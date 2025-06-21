<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="viewCert.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.viewCert" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 26px">&nbsp;</td>
            <td style="width: 513px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 26px">&nbsp;</td>
            <td style="width: 513px">
                <asp:Panel ID="Panel3" runat="server" BackColor="#FFCCCC" BorderStyle="Solid" BorderWidth="2px">
                    <table class="nav-justified">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="section" Text="LGEA" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="section" Text="Hqtrs" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 37px"></td>
                            <td style="height: 37px">Staff No</td>
                            <td style="height: 37px">
                                <asp:TextBox ID="txtStaffNo" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 37px">
                                <asp:Button ID="btnViewCert" runat="server" Text="View" OnClick="btnViewCert_Click" />
                            </td>
                            <td style="height: 37px"></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
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
            <td style="width: 26px">&nbsp;</td>
            <td style="width: 513px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td style="width: 1113px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width: 1113px">
                <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="2px">
                </asp:Panel>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width: 1113px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
